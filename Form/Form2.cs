using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Aimguard;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using static CuoreUI.DeviceInfo;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using System.Drawing;

namespace GuestExtractor
{

    public partial class Form2 : Form
    {
        private string[] TaskName = { "HD-Player" };
        private nexx32 nexx = new nexx32();

        // ADB related fields
        private string adbPath = "";
        private bool isAdbMonitoring = false;
        private CancellationTokenSource monitoringCancellationToken;
        private readonly string deviceGuestPath = "/storage/emulated/0/com.garena.msdk/guest100067.dat";
        private readonly string tempGuestFile = "temp_guest.dat";

        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;



        public Form2()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            UpdateStatus("Welcome to GuestExtractor.");

            // Set placeholder-like text for output directory
            txtOutputDir.ForeColor = System.Drawing.Color.Gray;
            txtOutputDir.Text = "Leave empty to use current directory";
            txtOutputDir.Enter += txtOutputDir_Enter;
            txtOutputDir.Leave += txtOutputDir_Leave;

            EnableWindowDragging();
        }

        private void EnableWindowDragging()
        {
            // Enable dragging from the header panel
            panelHeader.MouseDown += PanelHeader_MouseDown;
            panelHeader.MouseMove += PanelHeader_MouseMove;
            panelHeader.MouseUp += PanelHeader_MouseUp;

            // Enable dragging from the title label
            label1.MouseDown += PanelHeader_MouseDown;
            label1.MouseMove += PanelHeader_MouseMove;
            label1.MouseUp += PanelHeader_MouseUp;

            // Enable dragging from the version label
            labelVersion.MouseDown += PanelHeader_MouseDown;
            labelVersion.MouseMove += PanelHeader_MouseMove;
            labelVersion.MouseUp += PanelHeader_MouseUp;

            // Enable dragging from the top container control
            guna2ContainerControl1.MouseDown += PanelHeader_MouseDown;
            guna2ContainerControl1.MouseMove += PanelHeader_MouseMove;
            guna2ContainerControl1.MouseUp += PanelHeader_MouseUp;
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
            "10 4C 2D E9 08 B0 8D E2 0C 01 9F E5 00 00 8F E0" ,"01 41"};

        private string[] replacePatterns = new string[] { "01 00 A0 E3 1E FF 2F E1 0C 01 9F E5 00 00 8F E0", "01 45" };

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
            bool success = nexx.getTask(TaskName);
            if (!success)
            {
                UpdateStatus("Process not found.");
                return;
            }

            try
            {
                await Task.Run(async () =>
                {
                    UpdateStatus($"{nameFonction}: {(activate ? "Activating" : "Deactivating")}...");

                    IEnumerable<long> result = await nexx.Trace(activate ? scanPattern : replacePattern);

                    if (result == null || !result.Any())
                    {
                        UpdateStatus($"{nameFonction}: Guest Reset Sucessful !!!");
                        return;
                    }

                    foreach (long id in result)
                    {
                        bool setSuccess = nexx.SetBytes(id, activate ? replacePattern : scanPattern);
                        if (!setSuccess)
                        {
                            MessageBox.Show($"Failed to update memory at ID: {id}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            UpdateStatus($"{nameFonction}: Memory update failed at ID {id}.");
                            return;
                        }
                    }

                    UpdateStatus($"{nameFonction}: {(activate ? "Try Again reset failed !!!" : "Deactivated")}");
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus($"{nameFonction}: Error - {ex.Message}");
            }
        }

        // Guest Reset button
        private void btnResetGuest_Click(object sender, EventArgs e)
        {
            if (scanPatterns.Length >= 1 && replacePatterns.Length >= 1)
            {
                _ = EnableFunction(scanPatterns[0], replacePatterns[0], "Guest Reset (Step 1)");
            }
            else
            {
                UpdateStatus("Guest Reset: Patterns not properly defined.");
            }
        }

        // Button to select ADB location
        private void btnSelectAdb_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ADB Executable|adb.exe|All Files|*.*";
            ofd.Title = "Select ADB Server Location";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                adbPath = ofd.FileName;
                txtAdbPath.Text = adbPath;
                UpdateStatus($"ADB selected: {adbPath}");

                // Test ADB connection
                _ = TestAdbConnection();
            }
        }

        // Test ADB connection
        private async Task TestAdbConnection()
        {
            if (string.IsNullOrEmpty(adbPath) || !File.Exists(adbPath))
            {
                UpdateStatus("ADB path not set or file doesn't exist.");
                return;
            }

            try
            {
                var result = await RunAdbCommand("devices");
                if (result.success)
                {
                    var lines = result.output.Split('\n')
                        .Skip(1)
                        .Where(l => !string.IsNullOrWhiteSpace(l) && l.Contains("device"));

                    if (lines.Any())
                    {
                        UpdateStatus("✅ ADB device connected and ready.");
                        btnStartMonitoring.Enabled = true;
                    }
                    else
                    {
                        UpdateStatus("❌ No ADB devices found. Restarting ADB server...");

                        // Restart the ADB server
                        await RunAdbCommand("kill-server");
                        await Task.Delay(1000); // slight delay to ensure kill completes
                        await RunAdbCommand("start-server");

                        UpdateStatus("🔄 ADB server restarted. Please reconnect or re-authorize your device.");
                        btnStartMonitoring.Enabled = false;
                    }
                }
                else
                {
                    UpdateStatus($"ADB connection test failed: {result.error}");
                    btnStartMonitoring.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                UpdateStatus($"ADB test error: {ex.Message}");
                btnStartMonitoring.Enabled = false;
            }
        }


        // Start/Stop ADB monitoring
        private async void btnStartMonitoring_Click(object sender, EventArgs e)
        {
            if (!isAdbMonitoring)
            {
                // Get actual output directory (ignore placeholder text)
                string outputDir = txtOutputDir.Text;
                if (outputDir == "Leave empty to use current directory" || string.IsNullOrWhiteSpace(outputDir))
                {
                    outputDir = "";
                }

                // Validate output directory if specified
                if (!string.IsNullOrWhiteSpace(outputDir) && !Directory.Exists(outputDir))
                {
                    UpdateStatus("❌ Output directory doesn't exist. Please select a valid directory or leave empty to use current directory.");
                    return;
                }

                // Start monitoring
                monitoringCancellationToken = new CancellationTokenSource();
                isAdbMonitoring = true;
                btnStartMonitoring.Text = "Stop Monitoring";
                btnStartMonitoring.BackColor = System.Drawing.Color.Red;

                UpdateStatus("🔍 Started ADB monitoring for guest files...");
                await StartAdbMonitoring(monitoringCancellationToken.Token);
            }
            else
            {
                // Stop monitoring
                StopAdbMonitoring();
            }
        }

        private void StopAdbMonitoring()
        {
            if (monitoringCancellationToken != null)
            {
                monitoringCancellationToken.Cancel();
            }

            isAdbMonitoring = false;
            btnStartMonitoring.Text = "Start ADB Monitoring";
            btnStartMonitoring.BackColor = System.Drawing.Color.LightGreen;
            UpdateStatus("⏹️ ADB monitoring stopped.");
        }

        // Main ADB monitoring loop
        private async Task StartAdbMonitoring(CancellationToken cancellationToken)
        {
            // Get actual output directory (ignore placeholder text)
            string outputDir = txtOutputDir.Text;
            if (outputDir == "Leave empty to use current directory" || string.IsNullOrWhiteSpace(outputDir))
            {
                outputDir = Environment.CurrentDirectory;
            }

            string outputFile = Path.Combine(outputDir, "guest_accounts.json");
            UpdateStatus($"💾 Output file: {outputFile}");

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    // Check if guest file exists on device
                    var checkResult = await RunAdbCommand($"shell \"test -f {deviceGuestPath} && echo exists || echo not_found\"");

                    if (checkResult.success && checkResult.output.Contains("exists"))
                    {
                        UpdateStatus("📱 Guest file detected on device, processing...");

                        // Process the file
                        bool processSuccess = await ProcessGuestFileFromDevice(outputFile);

                        if (processSuccess)
                        {
                            UpdateStatus("✅ Guest file processed successfully!");
                        }
                        else
                        {
                            UpdateStatus("❌ Failed to process guest file.");
                        }
                    }

                    // Wait 3 seconds before next check
                    await Task.Delay(3000, cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    UpdateStatus($"Monitoring error: {ex.Message}");
                    await Task.Delay(5000, cancellationToken); // Wait longer on error
                }
            }
        }

        // Process guest file from device
        private async Task<bool> ProcessGuestFileFromDevice(string outputFile)
        {
            try
            {
                // Step 1: Copy file from device
                var pullResult = await RunAdbCommand($"pull {deviceGuestPath} {tempGuestFile}");
                if (!pullResult.success)
                {
                    UpdateStatus($"Failed to copy file from device: {pullResult.error}");
                    return false;
                }

                // Step 2: Parse the file
                if (!File.Exists(tempGuestFile))
                {
                    UpdateStatus("Temp file not found after ADB pull.");
                    return false;
                }

                var guestInfo = ExtractGuestInfoFromFile(tempGuestFile);
                if (guestInfo == null)
                {
                    UpdateStatus("Failed to extract guest information from file.");
                    CleanupTempFile();
                    return false;
                }

                // Step 3: Update JSON file
                bool updateSuccess = await UpdateGuestAccountsJson(outputFile, guestInfo);
                if (!updateSuccess)
                {
                    CleanupTempFile();
                    return false;
                }

                // Step 4: Delete file from device
                var deleteResult = await RunAdbCommand($"shell \"rm {deviceGuestPath}\"");
                if (!deleteResult.success)
                {
                    UpdateStatus($"Warning: Failed to delete file from device: {deleteResult.error}");
                }
                else
                {
                    UpdateStatus("🗑️ Guest file deleted from device.");
                }

                // Step 5: Cleanup temp file
                CleanupTempFile();

                return true;
            }
            catch (Exception ex)
            {
                UpdateStatus($"Process error: {ex.Message}");
                CleanupTempFile();
                return false;
            }
        }

        // Extract guest info from file
        private GuestAccountInfo ExtractGuestInfoFromFile(string filePath)
        {
            try
            {
                string content = File.ReadAllText(filePath).Trim();
                if (string.IsNullOrEmpty(content)) return null;

                var uid = Regex.Match(content, @"""com\.garena\.msdk\.guest_uid""\s*:\s*""(\d+)""");
                var pw = Regex.Match(content, @"""com\.garena\.msdk\.guest_password""\s*:\s*""([A-F0-9]+)""");

                if (uid.Success && pw.Success)
                {
                    return new GuestAccountInfo
                    {
                        uid = uid.Groups[1].Value,
                        password = pw.Groups[1].Value
                    };
                }
            }
            catch (Exception ex)
            {
                UpdateStatus($"File extraction error: {ex.Message}");
            }
            return null;
        }

        // Update guest accounts JSON file
        private Task<bool> UpdateGuestAccountsJson(string outputFile, GuestAccountInfo newAccount)
        {
            return Task.Run(() =>
            {
                try
                {
                    List<GuestAccountInfo> accounts = new List<GuestAccountInfo>();

                    // Load existing accounts if file exists
                    if (File.Exists(outputFile))
                    {
                        string existingJson = File.ReadAllText(outputFile, Encoding.UTF8);
                        if (!string.IsNullOrEmpty(existingJson))
                        {
                            accounts = JsonConvert.DeserializeObject<List<GuestAccountInfo>>(existingJson) ?? new List<GuestAccountInfo>();
                        }
                    }

                    // Check if account already exists
                    var existingAccount = accounts.FirstOrDefault(a => a.uid == newAccount.uid);
                    if (existingAccount != null)
                    {
                        // Update existing account
                        existingAccount.password = newAccount.password;
                        UpdateStatus($"🔄 Updated existing account: UID {newAccount.uid}");
                    }
                    else
                    {
                        // Add new account
                        accounts.Add(newAccount);
                        UpdateStatus($"➕ Added new account: UID {newAccount.uid}");
                    }

                    // Save updated accounts
                    string json = JsonConvert.SerializeObject(accounts, Formatting.Indented);
                    File.WriteAllText(outputFile, json, Encoding.UTF8);

                    UpdateStatus($"💾 Accounts saved to: {outputFile} (Total: {accounts.Count})");
                    return true;
                }
                catch (Exception ex)
                {
                    UpdateStatus($"JSON update error: {ex.Message}");
                    return false;
                }
            });
        }

        // Run ADB command
        private async Task<(bool success, string output, string error)> RunAdbCommand(string command)
        {
            try
            {
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

                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    return (process.ExitCode == 0, output.Trim(), error.Trim());
                }
            }
            catch (Exception ex)
            {
                return (false, "", ex.Message);
            }
        }

        // Cleanup temp file
        private void CleanupTempFile()
        {
            try
            {
                if (File.Exists(tempGuestFile))
                {
                    File.Delete(tempGuestFile);
                }
            }
            catch (Exception ex)
            {
                UpdateStatus($"Cleanup error: {ex.Message}");
            }
        }

        private void btnSelectOutputDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtOutputDir.Text = fbd.SelectedPath;
                txtOutputDir.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            statusTextBox.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://t.me/nopethug",
                UseShellExecute = true
            });
        }

        private void statusTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://t.me/oxramm",
                UseShellExecute = true
            });
        }

        private void UpdateStatus(string msg)
        {
            if (statusTextBox.InvokeRequired)
            {
                statusTextBox.Invoke(new Action<string>(UpdateStatus), msg);
                return;
            }
            statusTextBox.AppendText($"[{DateTime.Now:HH:mm:ss}] {msg}{Environment.NewLine}");
            statusTextBox.SelectionStart = statusTextBox.Text.Length;
            statusTextBox.ScrollToCaret();
        }

        private class GuestAccountInfo
        {
            public string uid { get; set; }
            public string password { get; set; }
        }

        // Form closing event to cleanup
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopAdbMonitoring();
            CleanupTempFile();
        }

        private void labelVersion_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }
    }
}