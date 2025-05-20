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


namespace GuestExtractor
{
    public partial class Form2 : Form
    {
        private string[] TaskName = { "HD-Player" };
        private nexx32 nexx = new nexx32();

        public Form2()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            UpdateStatus("Welcome to GuestExtractor.");
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
            "40 cd cc 8c 3f 8f c2 f5 3c cd cc CC 3D 07 00 00 00 00 00 00 00 00 00 00 00 00 00 f0 41 00 00 48 42 00 00 00 3f 33 33 13 40 00 00 b0 3f 00 00 80 3F 01 00 00",
        "10 4C 2D E9 08 B0 8D E2 0C 01 9F E5 00 00 8F E0 00 00 D0 E5 00 00 50 E3 06 00 00 1A FC 00 9F E5"};



        private string[] replacePatterns = new string[] { "40 cd cc 8C 3F 8f c2 F5 3C cd cc CC 3D 07 00 00 00 00 00 ff ff 00 00 00 00 00 00 f0 41 00 00 48 42 00 00 00 3f 33 33 13 40 00 00 b0 3f 00 00 80 3f 01 00 00",
        "01 00 A0 E3 1E FF 2F E1 0C 01 9F E5 00 00 8F E0 00 00 D0 E5 00 00 50 E3 06 00 00 1A FC 00 9F E5"};

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
                    // Un message unique indiquant le démarrage de l'opération
                    UpdateStatus($"{nameFonction}: {(activate ? "Activating" : "Deactivating")}...");

                    IEnumerable<long> result = await nexx.Trace(activate ? scanPattern : replacePattern);

                    if (result == null || !result.Any())
                    {
                        UpdateStatus($"{nameFonction}: No matching pattern found. Operation aborted.");
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

                    UpdateStatus($"{nameFonction}: {(activate ? "Activated" : "Deactivated")}");
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus($"{nameFonction}: Error - {ex.Message}");
            }
        }

        // Bouton de sécurisation (ex.: Anticheat Bypass)
        private void securiteButton_Click(object sender, EventArgs e)
        {
            _ = EnableFunction(replacePatterns[0], scanPatterns[0], "Anticheat Bypass");
        }

        // Bouton de réinitialisation des guest (Guest Reset)
        // Ici, nous distinguons deux opérations si deux ensembles de patterns sont définis.
        private void btnResetGuest_Click(object sender, EventArgs e)
        {
            // Vérifie que les arrays contiennent au moins deux éléments pour éviter les erreurs
            if (scanPatterns.Length >= 2 && replacePatterns.Length >= 2)
            {
                // Première étape de reset
                _ = EnableFunction(scanPatterns[0], replacePatterns[0], "Guest Reset (Step 1)");
                // Seconde étape de reset
                _ = EnableFunction(scanPatterns[1], replacePatterns[1], "Guest Reset (Step 2)");
            }
            else
            {
                UpdateStatus("Guest Reset: Patterns not properly defined.");
            }
        }


























        private void btnSelectInputDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtInputDir.Text = fbd.SelectedPath;
            }
        }

        private void btnSelectOutputDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtOutputDir.Text = fbd.SelectedPath;
            }
        }

        private void btnDump_Click(object sender, EventArgs e)
        {
            string inputDir = txtInputDir.Text;
            string outputDir = txtOutputDir.Text;
            string outputFile = Path.Combine(outputDir, "guest_accounts.json");
            string errorFile = Path.Combine(outputDir, "error_report.txt");

            List<GuestAccountInfo> guestData = new List<GuestAccountInfo>();
            HashSet<string> seenAccounts = new HashSet<string>();
            List<string> errorReports = new List<string>();

            if (!Directory.Exists(inputDir) || !Directory.Exists(outputDir))
            {
                UpdateStatus("Input/output directory does not exist.");
                return;
            }

            UpdateStatus($"Starting scan in: {inputDir}");

            int folderCount = 0;
            try
            {
                folderCount = Directory.GetDirectories(inputDir).Length;
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error: {ex.Message}");
                return;
            }

            for (int i = 1; i <= folderCount; i++)
            {
                string dirPath = Path.Combine(inputDir, i.ToString());
                string datFilePath = Path.Combine(dirPath, "guest100067.dat");
                UpdateStatus($"Folder {i}: {dirPath}");

                if (!Directory.Exists(dirPath) || !File.Exists(datFilePath))
                {
                    errorReports.Add($"Folder {i}: Missing file");
                    continue;
                }

                GuestAccountInfo guest = ExtractGuestInfo(datFilePath, errorReports, i);
                if (guest != null)
                {
                    string key = $"{guest.uid}-{guest.password}";
                    if (!seenAccounts.Contains(key))
                    {
                        seenAccounts.Add(key);
                        guestData.Add(guest);
                    }
                }
            }

            try
            {
                File.WriteAllText(outputFile, JsonConvert.SerializeObject(guestData, Formatting.Indented), Encoding.UTF8);
                UpdateStatus($"Data saved to: {outputFile}");
            }
            catch (Exception ex)
            {
                UpdateStatus($"JSON write error: {ex.Message}");
            }

            try
            {
                File.WriteAllLines(errorFile, errorReports, Encoding.UTF8);
                UpdateStatus($"Error report saved to: {errorFile}");
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error report write failed: {ex.Message}");
            }

            UpdateStatus($"Scan complete. {guestData.Count} accounts found.");
        }

        private GuestAccountInfo ExtractGuestInfo(string filePath, List<string> errors, int index)
        {
            try
            {
                string content = File.ReadAllText(filePath).Trim();
                if (string.IsNullOrEmpty(content)) return null;

                var uid = Regex.Match(content, @"""com\.garena\.msdk\.guest_uid""\s*:\s*""(\d+)""");
                var pw = Regex.Match(content, @"""com\.garena\.msdk\.guest_password""\s*:\s*""([A-F0-9]+)""");

                if (uid.Success && pw.Success)
                {
                    return new GuestAccountInfo { uid = uid.Groups[1].Value, password = pw.Groups[1].Value };
                }
                errors.Add($"Folder {index}: extraction failed");
            }
            catch (Exception ex)
            {
                errors.Add($"Folder {index}: read error - {ex.Message}");
            }
            return null;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtInputDir.Text = "";
            txtOutputDir.Text = "";
            statusTextBox.Clear();
            UpdateStatus("Reset.");
        }

        private void UpdateStatus(string msg)
        {
            statusTextBox.AppendText($"{msg}{Environment.NewLine}");
        }

        private class GuestAccountInfo
        {
            public string uid { get; set; }
            public string password { get; set; }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            statusTextBox.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://t.me/nopethug", // Remplace par l'URL de ton choix
                UseShellExecute = true
            });
        }

        private void statusTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
