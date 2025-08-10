using Aimguard; // Ensure this reference is correct
using Microsoft.Win32; 
using Newtonsoft.Json; // Ensure Newtonsoft.Json is added via NuGet
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
//using ApiAccountResponse;

namespace GuestExtractor
{
    public partial class Form2 : Form
    {        

        private string[] TaskName = { "HD-Player" };
        private nexx32 nexx = new nexx32(); // Ensure this class and its DLL are available

        private bool isGuestResetLoopActive = false;
        private CancellationTokenSource guestResetCancellationToken;

        private bool isChecking = false;
        private CancellationTokenSource verificationCancellationToken;

        private string adbPath;
        private string adbFolder = Path.Combine(Path.GetTempPath(), "ADB");

        private string adbIpAddress; // Variable to store the emulator's ADB IP address
        private string adbPort = "5555";

        private bool isAdbMonitoring = false;
        private CancellationTokenSource monitoringCancellationToken;
        private readonly string deviceGuestPath = "/storage/emulated/0/com.garena.msdk/guest100067.dat";
        private readonly string tempGuestFileName = "temp_guest.dat"; // Just the file name
        private string tempGuestFilePath => Path.Combine(adbFolder, tempGuestFileName); // Full path

        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

     
        public Label lblAdbStatus;
        private Dictionary<string, string> emulatorInstallPaths = new Dictionary<string, string>();




        public Form2()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            cmbEmulatorSelection.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            UpdateStatus("GuestExtractor.");

            // Set placeholder-like text for output directory
            txtOutputDir.ForeColor = System.Drawing.Color.Gray;
            txtOutputDir.Text = "Leave empty to use current directory";
            txtOutputDir.Enter += txtOutputDir_Enter;
            txtOutputDir.Leave += txtOutputDir_Leave;

            // Create ADB folder for temporary files if it doesn't exist
            if (!Directory.Exists(adbFolder))
            {
                Directory.CreateDirectory(adbFolder);
            }

            textPort.Text= adbPort; // Set default port for BlueStacks ADB
            textPort.Leave+=textPort_Leave;


            //await CheckAndSetupAdb();
            await PopulateEmulatorComboBox();

            //await CreateTestGuestAccount();

            EnableWindowDragging();
        }


        // -----------------------------------------------------------------------
        // NOUVELLES MÉTHODES POUR LA SÉLECTION D'ÉMULATEUR
        // -----------------------------------------------------------------------

        private async Task PopulateEmulatorComboBox()
        {
            UpdateStatus("Searching for emulators...");
            cmbEmulatorSelection.Items.Clear();
            cmbEmulatorSelection.Enabled = false;

            emulatorInstallPaths = GetEmulatorInstallPaths();

            if (emulatorInstallPaths == null || !emulatorInstallPaths.Any())
            {
                UpdateStatus("No emulators found. Please make sure one is installed.");
                cmbEmulatorSelection.Items.Add("No emulator found");
                cmbEmulatorSelection.SelectedIndex = 0;
            }
            else
            {
                UpdateStatus($"{emulatorInstallPaths.Count} emulators found. Select one to use.");
                cmbEmulatorSelection.Enabled = true;

                foreach (var name in emulatorInstallPaths.Keys)
                {
                    cmbEmulatorSelection.Items.Add(name);
                }

                // Initialise le ComboBox
                cmbEmulatorSelection.SelectedIndex = 0;
            }
        }

        private Dictionary<string, string> GetEmulatorInstallPaths()
        {
            var paths = new Dictionary<string, string>();
            // Define a map of registry paths to user-friendly emulator names
            var registryToNameMap = new Dictionary<string, string>
            {
                { @"SOFTWARE\BlueStacks_msi5", "MSI App Player" },
                { @"SOFTWARE\BlueStacks_nxt", "Bluestacks App Player " }
            };

            string[] valueNames = new string[]
            {
                "InstallDir",
                "InstallPath"
            };

            foreach (var entry in registryToNameMap)
            {
                string regPath = entry.Key;
                string emulatorName = entry.Value;

                foreach (RegistryKey baseKey in new[] { Registry.LocalMachine, Registry.CurrentUser })
                {
                    try
                    {
                        using (RegistryKey key = baseKey.OpenSubKey(regPath))
                        {
                            if (key != null)
                            {
                                foreach (string valueName in valueNames)
                                {
                                    object installDir = key.GetValue(valueName);
                                    if (installDir != null && !string.IsNullOrWhiteSpace(installDir.ToString()))
                                    {
                                        string path = installDir.ToString().TrimEnd('\\');
                                        if (File.Exists(Path.Combine(path, "HD-Adb.exe")))
                                        {
                                            // Add only if HD-Adb.exe is found and the emulator name is not already present
                                            if (!paths.ContainsKey(emulatorName))
                                            {
                                                paths.Add(emulatorName, path);
                                                break; // Found it, move to the next emulator
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        UpdateStatus($"Warning: Could not read registry path {regPath} from {baseKey.Name}. Error: {ex.Message}");
                    }
                }
            }
            return paths;
        }


        private async Task SetEmulatorAdbPath(string selectedEmulatorName)
        {
            if (string.IsNullOrEmpty(selectedEmulatorName))
            {
                adbPath = null;
                adbIpAddress = null;
                txtAdbPath.Text = "No emulator selected";
                UpdateStatus("Please select an emulator from the list.");
                return;
            }

            if (emulatorInstallPaths.TryGetValue(selectedEmulatorName, out string emulatorInstallPath))
            {
                string potentialAdbPath = Path.Combine(emulatorInstallPath, "HD-Adb.exe");

                if (File.Exists(potentialAdbPath))
                {
                    adbPath = potentialAdbPath;
                    adbIpAddress = $"127.0.0.1:{adbPort}";
                    UpdateStatus($"ADB configured for {selectedEmulatorName}: {adbPath}");
                    txtAdbPath.Text = adbPath;
                }
                else
                {
                    UpdateStatus($"Found emulator installation at '{emulatorInstallPath}', but 'HD-Adb.exe' was not found inside.");
                    adbPath = null;
                    adbIpAddress = null;
                    txtAdbPath.Text = "ADB not found";
                }
            }
            else
            {
                adbPath = null;
                adbIpAddress = null;
                txtAdbPath.Text = "No emulator selected";
                UpdateStatus("Please select a valid emulator from the list.");
            }
        }

        private async void cmbEmulatorSelection_SelectedIndexChanged_1(object sender, EventArgs e)

        {
            string selectedEmulatorName = cmbEmulatorSelection.SelectedItem?.ToString();
            if (selectedEmulatorName == "No emulator found")
            {
                adbPath = null;
                adbIpAddress = null;
                UpdateStatus("No emulator selected. Cannot proceed.");
                UpdateAdbStatusLabel("Not Configured", Color.Gray);
                return;
            }

            await SetEmulatorAdbPath(selectedEmulatorName);
            await TestAdbConnection();
        }

        private async Task CreateTestGuestAccount()
        {
            UpdateStatus("Creating test guest account...");

            string outputDir = txtOutputDir.Text;
            if (outputDir == "Leave empty to use current directory" || string.IsNullOrWhiteSpace(outputDir))
            {
                outputDir = Environment.CurrentDirectory;
            }

            // Ensure the output directory exists
            try
            {
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error: Could not create output directory '{outputDir}'. {ex.Message}");
                return;
            }

            string testOutputFile = Path.Combine(outputDir, "guest_accounts.json");

            var testAccount = new GuestAccountInfo
            {
                uid = "123456789",
                password = "test_password_example"
            };

            bool success = await UpdateGuestAccountsJson(testOutputFile, testAccount);

            if (success)
            {
                UpdateStatus($"Test account UID: {testAccount.uid} saved to: {testOutputFile}");
            }
            else
            {
                UpdateStatus("Failed to create test guest account.");
            }
        }

        private void EnableWindowDragging()
        {
            label1.MouseDown += PanelHeader_MouseDown;
            label1.MouseMove += PanelHeader_MouseMove;
            label1.MouseUp += PanelHeader_MouseUp;

            guna2ContainerControl1.MouseDown += PanelHeader_MouseDown;
            guna2ContainerControl1.MouseMove += PanelHeader_MouseMove;
            guna2ContainerControl1.MouseUp += PanelHeader_MouseUp;



            statusTextBox.ReadOnly = true; // Empêche la modification
            statusTextBox.TabStop = false; // Empêche la navigation par Tab
            statusTextBox.Cursor = Cursors.Default; // Curseur normal
            statusTextBox.GotFocus += (s, e) => this.ActiveControl = null; // Enlève le focus immédiatement


        }

        private void PanelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        private void PanelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentCursorPos = Cursor.Position;
                Point offset = new Point(currentCursorPos.X - dragCursorPoint.X, currentCursorPos.Y - dragCursorPoint.Y);
                this.Location = new Point(dragFormPoint.X + offset.X, dragFormPoint.Y + offset.Y);
            }
        }

        private void PanelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void txtOutputDir_Enter(object sender, EventArgs e)
        {
            if (txtOutputDir.Text == "Leave empty to use current directory")
            {
                txtOutputDir.Text = "";
                txtOutputDir.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtOutputDir_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOutputDir.Text))
            {
                txtOutputDir.Text = "Leave empty to use current directory";
                txtOutputDir.ForeColor = System.Drawing.Color.Gray;
            }
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);

        private string[] scanPatterns = new string[] {
        

        "10 4C 2D E9 08 B0 8D E2 0C 01 9F E5 00 00 8F E0 00 00 D0 E5 00 00 50 E3 06 00 00 1A FC 00 9F E5 00 00 9F E7 00 00 90 E5 BE 21 09 EB F0 00 9F E5"};
        

        private string[] replacePatterns = new string[] { "01 00 A0 E3 1E FF 2F E1 0C 01 9F E5 00 00 8F E0 00 00 D0 E5 00 00 50 E3 06 00 00 1A FC 00 9F E5 00 00 9F E7 00 00 90 E5 BE 21 09 EB F0 00 9F E5" };
                                                         
                                                         

        private async Task EnableFunction(string scanPattern, string replacePattern, string nameFonction)
        {
            await ToggleBytes(scanPattern, replacePattern, nameFonction, true);
        }

        private async Task DisableFunction(string scanPattern, string replacePattern, string nameFonction)
        {
            await ToggleBytes(scanPattern, replacePattern, nameFonction, false);
        }

        private async Task ToggleBytes(string scanPattern, string replacePattern, string nameFonction, bool activate)
        {
            UpdateStatus($"Attempting to {nameFonction}...");

            bool success = nexx.getTask(TaskName);
            if (!success)
            {
                UpdateStatus("Process not found.");
                return;
            }

            int maxRetries = 5; 
            int currentTry = 0;

            try
            {
                while (currentTry < maxRetries)
                {
                    currentTry++;
                    UpdateStatus($"{nameFonction}: Attempt {currentTry}/{maxRetries}...");

                    IEnumerable<long> result = await nexx.Trace(activate ? scanPattern : replacePattern);

                    if (result == null || !result.Any())
                    {
                        UpdateStatus($"{nameFonction}: Guest Reset Successful !!!");
                        return;
                    }

                    bool allSuccess = true;
                    foreach (long id in result)
                    {
                        bool setSuccess = nexx.SetBytes(id, activate ? replacePattern : scanPattern);
                        if (!setSuccess)
                        {
                            allSuccess = false;
                            UpdateStatus($"{nameFonction}: Failed to update memory at ID {id}. Attempt {currentTry}.");
                        }
                    }

                    if (allSuccess)
                    {
                        UpdateStatus($"{nameFonction}: Attempt {currentTry} completed, verifying...");
                        IEnumerable<long> verifyResult = await nexx.Trace(activate ? scanPattern : replacePattern);
                        if (verifyResult == null || !verifyResult.Any())
                        {
                            UpdateStatus($"{nameFonction}: Activation/deactivation successful.");
                            return;
                        }
                        else
                        {
                            UpdateStatus($"{nameFonction}: Verification failed, bytes were not modified as expected. Retrying...");
                        }
                    }
                    else
                    {
                        UpdateStatus($"{nameFonction}: Some modifications failed. Retrying...");
                    }
                    await Task.Delay(300); // Small delay before next attempt
                }

                UpdateStatus($"{nameFonction}: Failed after {maxRetries} attempts.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus($"{nameFonction}: Error - {ex.Message}");
            }
        }

        private async void btnResetGuest_Click_1(object sender, EventArgs e)
        {
            if (scanPatterns.Length < 1 || replacePatterns.Length < 1)
            {
                UpdateStatus("Guest Reset: Patterns not properly defined.");
                return;
            }

            if (!isGuestResetLoopActive)
            {
                isGuestResetLoopActive = true;
                guestResetCancellationToken = new CancellationTokenSource();
                btnResetGuest.Text = "STOP";
                btnResetGuest.BackColor = Color.Red;
                btnResetGuest.TextAlign = ContentAlignment.MiddleCenter;

                UpdateStatus("Starting Guest Reset loop...");
                await StartGuestResetLoop(guestResetCancellationToken.Token);
            }
            else
            {
                StopGuestResetLoop();
                btnResetGuest.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        private async Task StartGuestResetLoop(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    UpdateStatus("Executing Guest Reset...");
                    await EnableFunction(scanPatterns[0], replacePatterns[0], "Guest Reset Loop");

                    await Task.Delay(500, cancellationToken); // 500ms = 0.5 second
                }
            }
            catch (OperationCanceledException)
            {
                UpdateStatus("Guest Reset loop cancelled.");
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error in Guest Reset loop: {ex.Message}");
            }
            finally
            {
                isGuestResetLoopActive = false;
                if (btnResetGuest.InvokeRequired)
                {
                    btnResetGuest.Invoke(new Action(() => {
                        btnResetGuest.Text = "RESET GUEST (LOOP)";
                        btnResetGuest.BackColor = System.Drawing.Color.LightGreen; // Or your default color
                        btnResetGuest.Enabled = true; // Ensure it's re-enabled
                    }));
                }
                else
                {
                    btnResetGuest.Text = "RESET GUEST (LOOP)";
                    btnResetGuest.BackColor = System.Drawing.Color.LightGreen; // Or your default color
                    btnResetGuest.Enabled = true; // Ensure it's re-enabled
                }
            }
        }

        private void StopGuestResetLoop()
        {
            if (guestResetCancellationToken != null)
            {
                guestResetCancellationToken.Cancel();
            }
        }


        private async void btnSelectAdb_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ADB Executable|HD-Adb.exe;adb.exe|All Files|*.*";
            ofd.Title = "Select ADB Server Location";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                adbPath = ofd.FileName;
                txtAdbPath.Text = adbPath;

                adbIpAddress = null;
                UpdateStatus($"ADB manually selected: {adbPath}");


                await TestAdbConnection();
            }
        }

        private async Task TestAdbConnection()
        {
            if (string.IsNullOrEmpty(adbPath) || !File.Exists(adbPath))
            {
                UpdateStatus("ADB path not set or file doesn't exist. Please check your emulator installation.");
                UpdateAdbStatusLabel("Not Configured", Color.Gray);
                btnStartMonitoring.Enabled = false;
                return;
            }

            try
            {
                UpdateStatus("Testing ADB connection...");
                UpdateAdbStatusLabel("Checking...", Color.Orange);

                if (string.IsNullOrEmpty(adbIpAddress))
                {

                    adbIpAddress = $"127.0.0.1:{adbPort}";
                    UpdateStatus($"Attempting to connect to emulator on default IP: {adbIpAddress}");
                    await RunAdbCommand($"connect {adbIpAddress}", 10000); // Attempt to connect
                }
                else
                {
                    // If the IP is already defined (by FindEmulatorAdbPath), try connecting directly
                    UpdateStatus($"Attempting to connect to emulator on detected IP: {adbIpAddress}");
                    await RunAdbCommand($"connect {adbIpAddress}", 10000); // Attempt to connect
                }

                // Use -s to specify the device when listing
                var result = await RunAdbCommand($"-s {adbIpAddress} devices", 10000);

                if (result.success)
                {
                    var lines = result.output.Split('\n')
                        .Skip(1)
                        .Where(l => !string.IsNullOrWhiteSpace(l) && l.Contains("device"));

                    if (lines.Any())
                    {
                        UpdateStatus("ADB device connected and ready.");
                        UpdateAdbStatusLabel("Connected", Color.Green);
                        btnStartMonitoring.Enabled = true;
                    }
                    else
                    {
                        UpdateStatus("No ADB device found (even after connection). Restarting ADB server...");
                        UpdateAdbStatusLabel("Restarting...", Color.Orange);

                        await RunAdbCommand("kill-server", 5000);
                        await Task.Delay(1000); // Small delay to ensure kill is complete
                        var startServerResult = await RunAdbCommand("start-server", 5000);

                        if (startServerResult.success)
                        {
                            UpdateStatus("ADB server restarted. Please reconnect or re-authorize your device.");
                            UpdateAdbStatusLabel("Waiting for device", Color.Red);
                        }
                        else
                        {
                            UpdateStatus($"Failed to restart ADB server: {startServerResult.error}");
                            UpdateAdbStatusLabel("Error (Server)", Color.DarkRed);
                        }
                        btnStartMonitoring.Enabled = false;
                    }
                }
                else
                {
                    UpdateStatus($"Failed ADB connection test: {result.error}");
                    UpdateAdbStatusLabel("Error (Connection)", Color.DarkRed);
                    btnStartMonitoring.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                UpdateStatus($"Unexpected ADB test error: {ex.Message}");
                UpdateAdbStatusLabel("Error (Exception)", Color.DarkRed);
                btnStartMonitoring.Enabled = false;
            }
        }

        private void UpdateAdbStatusLabel(string text, Color color)
        {
            if (lblAdbStatus != null) // Check that the control exists
            {
                if (lblAdbStatus.InvokeRequired)
                {
                    lblAdbStatus.Invoke(new Action(() => {
                        lblAdbStatus.Text = text;
                        lblAdbStatus.ForeColor = color;
                    }));
                }
                else
                {
                    lblAdbStatus.Text = text;
                    lblAdbStatus.ForeColor = color;
                }
            }
        }

        private async void btnStartMonitoring_Click_1(object sender, EventArgs e)
        {
            btnStartMonitoring.Enabled = false;

            try
            {
                if (!isAdbMonitoring)
                {
                    string outputDir = txtOutputDir.Text;
                    if (outputDir == "Leave empty to use current directory" || string.IsNullOrWhiteSpace(outputDir))
                    {
                        outputDir = "";
                    }

                    if (!string.IsNullOrWhiteSpace(outputDir) && !Directory.Exists(outputDir))
                    {
                        UpdateStatus("Output directory does not exist. Please select a valid directory or leave empty.");
                        btnStartMonitoring.Enabled = true;
                        return;
                    }

                    monitoringCancellationToken = new CancellationTokenSource();
                    isAdbMonitoring = true;
                    //btnStartMonitoring.Text = "STOP MONITORING";
                    btnStartMonitoring.Text = "STOP";
                    btnStartMonitoring.BackColor = System.Drawing.Color.Red;
                    btnStartMonitoring.TextAlign = ContentAlignment.MiddleCenter;
                    await CreateTestGuestAccount();
                    UpdateStatus("Starting ADB monitoring for guest files...");
                    await StartAdbMonitoring(monitoringCancellationToken.Token);

                }
                else
                {
                    StopAdbMonitoring();
                    btnStartMonitoring.TextAlign = ContentAlignment.MiddleCenter;
                }
            }

            finally
            {
                
                btnStartMonitoring.Enabled = true;
            }


        }

        private void StopAdbMonitoring()
        {
            if (monitoringCancellationToken != null)
            {
                monitoringCancellationToken.Cancel();
            }

            isAdbMonitoring = false;
            btnStartMonitoring.Text = "START ADB";
            btnStartMonitoring.BackColor = System.Drawing.Color.LightGreen;
            UpdateStatus("ADB monitoring stopped.");
            btnStartMonitoring.Enabled = true;
        }

        private async Task StartAdbMonitoring(CancellationToken cancellationToken)
        {
            string outputDir = txtOutputDir.Text;
            if (outputDir == "Leave empty to use current directory" || string.IsNullOrWhiteSpace(outputDir))
            {
                outputDir = Environment.CurrentDirectory;
            }

            string outputFile = Path.Combine(outputDir, "guest_accounts.json");
            UpdateStatus($"Output file: {outputFile}");

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    // Use the specific emulator IP address
                    var checkResult = await RunAdbCommand($"-s {adbIpAddress} shell \"test -f {deviceGuestPath} && echo exists || echo not_found\"", 5000);

                    if (checkResult.success && checkResult.output.Contains("exists"))
                    {
                        UpdateStatus("Guest file detected on device. Waiting 10 seconds before processing...");
                        // Wait 20 seconds as in the Python script
                        await Task.Delay(10000, cancellationToken);

                        bool processSuccess = await ProcessGuestFileFromDevice(outputFile);

                        if (processSuccess)
                        {
                            UpdateStatus("Guest file processed successfully!");
                        }
                        else
                        {
                            UpdateStatus("Failed to process guest file.");
                        }
                    }

                    // Wait 1 second before next check (as in the python script)
                    await Task.Delay(1000, cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    UpdateStatus("ADB monitoring cancelled.");
                    break;
                }
                catch (Exception ex)
                {
                    UpdateStatus($"Monitoring error: {ex.Message}");
                    await Task.Delay(5000, cancellationToken); // Wait longer on error
                }
            }
            btnStartMonitoring.Enabled = true;
        }

        private async Task<bool> ProcessGuestFileFromDevice(string outputFile)
        {
            try
            {
                string currentTempGuestFilePath = tempGuestFilePath;

                // Use the specific emulator IP address for the pull
                var pullResult = await RunAdbCommand($"-s {adbIpAddress} pull {deviceGuestPath} \"{currentTempGuestFilePath}\"", 30000); // Increased timeout for pull
                if (!pullResult.success)
                {
                    UpdateStatus($"Failed to copy file from device: {pullResult.error}");
                    CleanupTempFile(currentTempGuestFilePath); // Clean up even on pull failure
                    return false;
                }

                if (!File.Exists(currentTempGuestFilePath))
                {
                    UpdateStatus("Temporary file not found after ADB pull.");
                    return false;
                }

                var guestInfo = ExtractGuestInfoFromFile(currentTempGuestFilePath);
                if (guestInfo == null)
                {
                    UpdateStatus("Failed to extract guest information from file.");
                    CleanupTempFile(currentTempGuestFilePath); // Clean up temp file even on extraction failure
                    return false;
                }

                bool updateSuccess = await UpdateGuestAccountsJson(outputFile, guestInfo);
                if (!updateSuccess)
                {
                    CleanupTempFile(currentTempGuestFilePath);
                    return false;
                }

                // Use the specific emulator IP address for deletion
                var deleteResult = await RunAdbCommand($"-s {adbIpAddress} shell \"rm {deviceGuestPath}\"", 5000); // Timeout for deletion
                if (!deleteResult.success)
                {
                    UpdateStatus($"Warning: Failed to delete file on device: {deleteResult.error}");
                }
                else
                {
                    UpdateStatus("Guest file deleted from device.");
                }

                CleanupTempFile(currentTempGuestFilePath);

                return true;
            }
            catch (Exception ex)
            {
                UpdateStatus($"Processing error: {ex.Message}");
                CleanupTempFile(tempGuestFilePath); // Ensure temporary file is cleaned up
                return false;
            }
        }

        private GuestAccountInfo ExtractGuestInfoFromFile(string filePath)
        {
            try
            {
                string content = File.ReadAllText(filePath, Encoding.UTF8).Trim();
                if (string.IsNullOrEmpty(content))
                {
                    UpdateStatus("Empty guest file content.");
                    return null;
                }

                // Attempt to deserialize JSON as in the Python script
                try
                {
                    var rootData = JsonConvert.DeserializeObject<RootGuestData>(content);
                    if (rootData?.GuestAccount != null)
                    {
                        if (!string.IsNullOrEmpty(rootData.GuestAccount.uid) && !string.IsNullOrEmpty(rootData.GuestAccount.password))
                        {
                            UpdateStatus("JSON extraction successful.");
                            return new GuestAccountInfo
                            {
                                uid = rootData.GuestAccount.uid,
                                password = rootData.GuestAccount.password
                            };
                        }
                        else
                        {
                            UpdateStatus("UID or password is empty in extracted JSON. Attempting with RegEx...");
                        }
                    }
                    else
                    {
                        UpdateStatus("The 'guest_account_info' structure is missing or invalid in the JSON file. Attempting with RegEx...");
                    }
                }
                catch (JsonSerializationException jsonEx)
                {
                    UpdateStatus($"JSON deserialization error: {jsonEx.Message}. Attempting with RegEx...");
                }

                // Fallback to RegEx extraction if JSON is not compliant or deserialization fails
                var uid = Regex.Match(content, @"""com\.garena\.msdk\.guest_uid""\s*:\s*""(\d+)""");
                var pw = Regex.Match(content, @"""com\.garena\.msdk\.guest_password""\s*:\s*""([A-F0-9]+)""");

                if (uid.Success && pw.Success)
                {
                    UpdateStatus("RegEx extraction successful.");
                    return new GuestAccountInfo
                    {
                        uid = uid.Groups[1].Value,
                        password = pw.Groups[1].Value
                    };
                }
                else
                {
                    UpdateStatus("Guest UID or password not found in file, neither by JSON nor by RegEx.");
                }
            }
            catch (Exception ex)
            {
                UpdateStatus($"General file extraction error: {ex.Message}");
            }
            return null;
        }

        private Task<bool> UpdateGuestAccountsJson(string outputFile, GuestAccountInfo newAccount)
        {
            return Task.Run(() =>
            {
                try
                {
                    List<GuestAccountInfo> accounts = new List<GuestAccountInfo>();

                    if (File.Exists(outputFile))
                    {
                        string existingJson = File.ReadAllText(outputFile, Encoding.UTF8);
                        if (!string.IsNullOrEmpty(existingJson))
                        {
                            accounts = JsonConvert.DeserializeObject<List<GuestAccountInfo>>(existingJson) ?? new List<GuestAccountInfo>();
                        }
                    }

                    var existingAccount = accounts.FirstOrDefault(a => a.uid == newAccount.uid);
                    if (existingAccount != null)
                    {
                        existingAccount.password = newAccount.password;
                        UpdateStatus($"Existing account updated: UID {newAccount.uid}");
                    }
                    else
                    {
                        accounts.Add(newAccount);
                        UpdateStatus($"New account added: UID {newAccount.uid}");
                    }

                    string json = JsonConvert.SerializeObject(accounts, Formatting.Indented);
                    File.WriteAllText(outputFile, json, Encoding.UTF8);

                    UpdateStatus($"Accounts saved (Total: {accounts.Count})");
                    // Assurez-vous que labelAccount est un contrôle valide sur votre formulaire
                    if (labelAccount.InvokeRequired)
                    {
                        labelAccount.Invoke(new Action(() => labelAccount.Text = $"ACCOUNTS: {accounts.Count}"));
                    }
                    else
                    {
                        labelAccount.Text = $"Accounts: {accounts.Count}";
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    UpdateStatus($"JSON update error: {ex.Message}");
                    return false;
                }
            });
        }


        private async Task<(bool success, string output, string error)> RunAdbCommand(string command, int timeoutMs = 60000)
        {
            try
            {
                if (string.IsNullOrEmpty(adbPath) || !File.Exists(adbPath))
                {
                    return (false, "", "ADB path is not set or adb.exe does not exist.");
                }

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = adbPath,
                    Arguments = command,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using (Process process = new Process { StartInfo = startInfo })
                {
                    process.Start();

                    string output = await process.StandardOutput.ReadToEndAsync();
                    string error = await process.StandardError.ReadToEndAsync();

                    bool exited = process.WaitForExit(timeoutMs);

                    if (!exited)
                    {
                        try
                        {
                            process.Kill();
                            return (false, "", $"ADB command timed out after {timeoutMs}ms. Output: {output}, Error: {error}");
                        }
                        catch (InvalidOperationException)
                        {
                            // Process already exited, or cannot be killed
                        }
                    }

                    return (process.ExitCode == 0, output.Trim(), error.Trim());
                }
            }
            catch (Exception ex)
            {
                return (false, "", ex.Message);
            }
        }

        private void CleanupTempFile(string filePath = null)
        {
            try
            {
                string fileToDelete = filePath ?? tempGuestFilePath; // Use passed path or default path
                if (File.Exists(fileToDelete))
                {
                    File.Delete(fileToDelete);
                    UpdateStatus($"Temporary file '{Path.GetFileName(fileToDelete)}' deleted.");
                }
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error cleaning up temporary file: {ex.Message}");
            }
        }


        private void UpdateStatus(string msg)
        {
            if (statusTextBox.InvokeRequired)
            {
                statusTextBox.Invoke(new Action<string>(UpdateStatus), msg);
                return;
            }
            statusTextBox.AppendText($"[{DateTime.Now:HH:mm:ss}]: {msg}{Environment.NewLine}");
            statusTextBox.SelectionStart = statusTextBox.Text.Length;
            statusTextBox.ScrollToCaret();
        }



        public class RootGuestData
        {
            [JsonProperty("guest_account_info")]
            public GuestAccountInfo GuestAccount { get; set; }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopAdbMonitoring();
            StopGuestResetLoop();
            CleanupTempFile(tempGuestFilePath); // Ensure temporary file is cleaned up
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            // Peut être laissé vide si aucune logique de dessin personnalisée n'est nécessaire
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            statusTextBox.Clear();
        }

        private void btnSelectOutputDir_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtOutputDir.Text = fbd.SelectedPath;
                txtOutputDir.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }


        private void label2_Click(object sender, EventArgs e)
        {
    
        }

        private void about_Click(object sender, EventArgs e)
        {
            About2 about = new About2();
            about.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void textPort_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(textPort.Text, out int port) && port > 0)
            {
                adbPort = textPort.Text;
                UpdateStatus($"ADB port manually set to: {adbPort}");
                // Il peut être judicieux de relancer la connexion ici si l'utilisateur change le port manuellement.
            }
            else
            {
                MessageBox.Show("Invalid port number. Please enter a valid number.", "Invalid Port", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textPort.Text = adbPort; // Remet la dernière valeur valide
            }
        }


        private void statusTextBox_TextChanged(object sender, EventArgs e)
        {
        
        }



        private async void btnCheck_Click(object sender, EventArgs e)
        {
            if (isChecking)
            {
                // Si la vérification est déjà en cours, annulez-la
                verificationCancellationToken?.Cancel();
                UpdateStatus("Verification process is being cancelled...");
                return; // Sortez de la méthode
            }

            // Démarrez la vérification
            isChecking = true;
            btnCheck.Text = "STOP";
            btnCheck.BackColor = Color.Red;
            verificationCancellationToken = new CancellationTokenSource();
            CancellationToken cancellationToken = verificationCancellationToken.Token;

            UpdateStatus("Starting account verification...");

            string outputDir = txtOutputDir.Text;
            if (string.IsNullOrWhiteSpace(outputDir) || outputDir == "Leave empty to use current directory")
            {
                outputDir = Environment.CurrentDirectory;
            }

            string accountsFile = Path.Combine(outputDir, "guest_accounts.json");
            string logsFile = Path.Combine(outputDir, "verification_logs.txt");

            if (!File.Exists(accountsFile))
            {
                UpdateStatus("Error: The file guest_accounts.json does not exist. Cannot verify accounts.");
                ResetCheckButton();
                return;
            }

            try
            {
                string jsonContent = File.ReadAllText(accountsFile);
                List<GuestAccountInfo> accounts = JsonConvert.DeserializeObject<List<GuestAccountInfo>>(jsonContent);

                if (accounts == null || !accounts.Any())
                {
                    UpdateStatus("No accounts found in guest_accounts.json. Nothing to verify.");
                    ResetCheckButton();
                    return;
                }

                UpdateStatus($"Found {accounts.Count} accounts. Starting verification...");
                string logMessage = $"Found {accounts.Count} accounts. Starting verification...";
                
                labelAccount.Text = $"ACCOUNTS: {accounts.Count}";
                List<string> logEntries = new List<string>();
                logEntries.Add(logMessage);
                using (var httpClient = new HttpClient())
                {
                    for (int i = 0; i < accounts.Count; i++)
                    {
                        // Vérifiez si une annulation a été demandée
                        if (cancellationToken.IsCancellationRequested)
                        {
                            UpdateStatus("Verification cancelled by user.");
                            break; // Sortez de la boucle
                        }

                        var account = accounts[i];
                        string progress = $"({i + 1}/{accounts.Count})";

                        if (string.IsNullOrEmpty(account.uid) || string.IsNullOrEmpty(account.password))
                        {
                            string invalidMessage = $"{progress} Skipping invalid account: UID or password missing.";
                            UpdateStatus(invalidMessage);
                            logEntries.Add(invalidMessage);
                            continue;
                        }

                        string apiUrl = $"https://jwtthug.onrender.com/token?uid={account.uid}&password={account.password}";

                        try
                        {
                            string apiResponse = await httpClient.GetStringAsync(apiUrl);
                            var apiResult = JsonConvert.DeserializeObject<ApiAccountResponse>(apiResponse);

                            if (apiResult != null)
                            {
                                logMessage = $"{progress} UID: {apiResult.uid} | Region: {apiResult.region} | Status: {apiResult.status}";
                                logEntries.Add(logMessage);
                                UpdateStatus(logMessage);
                            }
                            else
                            {
                                string errorMessage = $"{progress} Failed to parse API response for UID: {account.uid}";
                                logEntries.Add(errorMessage);
                                UpdateStatus(errorMessage);
                            }
                        }
                        catch (Exception ex)
                        {
                            string errorMessage = $"{progress} Error verifying UID {account.uid}: {ex.Message}";
                            logEntries.Add(errorMessage);
                            UpdateStatus(errorMessage);
                        }

                        // Vérifiez l'annulation avant de faire le délai
                        if (cancellationToken.IsCancellationRequested)
                        {
                            UpdateStatus("Verification cancelled by user.");
                            break;
                        }
                        await Task.Delay(500, cancellationToken);
                    }
                }

               
                File.WriteAllLines(logsFile, logEntries);
                UpdateStatus($"Verification complete! Logs saved to: {logsFile}");

            }
            catch (OperationCanceledException)
            {
                
                UpdateStatus("Verification successfully cancelled. Logs for processed accounts saved.");
            }
            catch (Exception ex)
            {
                UpdateStatus($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                ResetCheckButton();
            }
        }

        private void ResetCheckButton()
        {
            isChecking = false;
            if (btnCheck.InvokeRequired)
            {
                btnCheck.Invoke(new Action(() =>
                {
                    btnCheck.Text = "CHECK";
                    btnCheck.BackColor = SystemColors.Control;
                }));
            }
            else
            {
                btnCheck.Text = "CHECK";
                btnCheck.BackColor = SystemColors.Control;
            }
        }


      
    }
}