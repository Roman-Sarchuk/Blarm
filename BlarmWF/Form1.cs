using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;

namespace BlarmWF
{
    public partial class Form1 : Form
    {
        // --- WF values --- 
        private static string titleFontName = "Jura-VariableFont_wght.ttf";
        private static byte[] defLevelList = { 90, 20, 15 };   // high , low , critival
        private List<string> soundNameList = new List<string>();
        private DelSoundForm delSoundForm = new DelSoundForm();

        // --- ini parse values ---
        private static string configFileName = "config.ini";
        private static string soundDirectoryName = "Sounds\\";
        private FileIniDataParser parser = new FileIniDataParser();
        private IniData data;


        // ***** init func *****
        public Form1()
        {
            InitializeComponent();

            // Set fonts
            try
            {
                pfc.AddFontFile(titleFontName);
                Font font = new Font(pfc.Families[0], 16, FontStyle.Regular);
                
                chargeOption1.SetTitleFont(font);
                chargeOption2.SetTitleFont(font);
                chargeOption3.SetTitleFont(font);

                delSoundForm.SetTitleFont(font);
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show($"Can't find \"{titleFontName}\" font in the program folder", "Set fonts", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Set fonts", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            // fuse: check if the sound folder exists else create it
            if (!Directory.Exists(soundDirectoryName))
            {
                Directory.CreateDirectory(soundDirectoryName);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                data = parser.ReadFile(configFileName);

                // get Charge levels
                chargeOption1.NumericValue = int.Parse(data["ChargeLevels"]["HighCharge"] ?? throw new ArgumentNullException("\nCan't find: section \"ChargeLevels\" -> property \"HighCharge\" in \"" + configFileName + "\""));
                chargeOption2.NumericValue = int.Parse(data["ChargeLevels"]["LowCharge"] ?? throw new ArgumentNullException("\nCan't find: section \"ChargeLevels\" -> property \"LowCharge\" in \"" + configFileName + "\""));
                chargeOption3.NumericValue = int.Parse(data["ChargeLevels"]["CriticalCharge"] ?? throw new ArgumentNullException("\nCan't find: section \"ChargeLevels\" -> property \"CriticalCharge\" in \"" + configFileName + "\""));

                // get Status
                chargeOption1.PanelColorStatus = (ColorStatusName)Enum.Parse(typeof(ColorStatusName), data["ChargeStatus"]["HighStatus"] ?? throw new ArgumentNullException("\nCan't find: section \"ChargeStatus\" -> property \"HighStatus\" in \"" + configFileName + "\""));
                chargeOption2.PanelColorStatus = (ColorStatusName)Enum.Parse(typeof(ColorStatusName), data["ChargeStatus"]["LowStatus"] ?? throw new ArgumentNullException("\nCan't find: section \"ChargeStatus\" -> property \"LowStatus\" in \"" + configFileName + "\""));
                chargeOption3.PanelColorStatus = (ColorStatusName)Enum.Parse(typeof(ColorStatusName), data["ChargeStatus"]["CriticalStatus"] ?? throw new ArgumentNullException("vCan't find: section \"ChargeStatus\" -> property \"CriticalStatus\" in \"" + configFileName + "\""));

                // get Sounds
                UpdateSoundCB();
                chargeOption1.SoundName = data["SoundOptions"]["HighSoundFileName"] ?? throw new ArgumentNullException("\nCan't find: section \"SoundOptions\" -> property \"HighSoundFileName\" in \"" + configFileName + "\"");
                chargeOption2.SoundName = data["SoundOptions"]["LowSoundFileName"] ?? throw new ArgumentNullException("\nCan't find: section \"SoundOptions\" -> property \"LowSoundFileName\" in \"" + configFileName + "\"");
                chargeOption3.SoundName = data["SoundOptions"]["CriticalSoundFileName"] ?? throw new ArgumentNullException("\nCan't find: section \"SoundOptions\" -> property \"CriticalSoundFileName\" in \"" + configFileName + "\"");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Getting config data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        // ***** **** **** *****


        private void UpdateConfigFile()
        {
            try
            {
                data = parser.ReadFile(configFileName);

                // set Charge levels
                data["ChargeLevels"]["HighCharge"] = chargeOption1.NumericValue.ToString();
                data["ChargeLevels"]["LowCharge"] = chargeOption2.NumericValue.ToString();
                data["ChargeLevels"]["CriticalCharge"] = chargeOption3.NumericValue.ToString();

                // set Status
                data["ChargeStatus"]["HighStatus"] = chargeOption1.PanelColorStatus.ToString();
                data["ChargeStatus"]["LowStatus"] = chargeOption2.PanelColorStatus.ToString();
                data["ChargeStatus"]["CriticalStatus"] = chargeOption3.PanelColorStatus.ToString();

                // set Sounds
                data["SoundOptions"]["HighSoundFileName"] = chargeOption1.SoundName;
                data["SoundOptions"]["LowSoundFileName"] = chargeOption2.SoundName;
                data["SoundOptions"]["CriticalSoundFileName"] = chargeOption3.SoundName;

                parser.WriteFile("config.ini", data);

                MessageBox.Show("Values are updated successfully", "Updating config data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating config data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ***** sound file processing *****
        public void GetWavFiles()
        {
            if (Directory.Exists(soundDirectoryName))   // guard: directory exists
            {
                // get file names
                string[] files = Directory.GetFiles(soundDirectoryName, "*.*", SearchOption.TopDirectoryOnly).Where(
                            file => file.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase) ||
                            file.EndsWith(".wav", StringComparison.OrdinalIgnoreCase) ||
                            file.EndsWith(".wma", StringComparison.OrdinalIgnoreCase) ||
                            file.EndsWith(".m4a", StringComparison.OrdinalIgnoreCase) ||
                            file.EndsWith(".aac", StringComparison.OrdinalIgnoreCase)).ToArray();

                soundNameList.Clear();

                if (files.Length == 0)  // observer: folder is empty
                {
                    MessageBox.Show("'Sounds' folder is empty", "Getting sound files", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                foreach (string filePath in files)
                {
                    soundNameList.Add(Path.GetFileName(filePath));
                }
            }
            else
            {
                MessageBox.Show("Can't find the 'Sounds' folder", "Getting sound files", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSoundCB()
        {
            GetWavFiles();

            chargeOption1.UpdateSoundCB(soundNameList);
            chargeOption2.UpdateSoundCB(soundNameList);
            chargeOption3.UpdateSoundCB(soundNameList);
        }
        // ***** ***** **** ********** *****


        // ***** bined func *****
        private void buttonReset_Click(object sender, EventArgs e)
        {
            // fuse: update
            UpdateSoundCB();

            // NumericValue
            chargeOption1.NumericValue = defLevelList[0];
            chargeOption2.NumericValue = defLevelList[1];
            chargeOption3.NumericValue = defLevelList[2];

            // PanelColorStatus
            chargeOption1.PanelColorStatus = ColorStatusName.Mute;
            chargeOption2.PanelColorStatus = ColorStatusName.On;
            chargeOption3.PanelColorStatus = ColorStatusName.On;

            // Sound CBs
            chargeOption1.SoundSelectedIndex = 0;
            chargeOption2.SoundSelectedIndex = 0;
            chargeOption3.SoundSelectedIndex = 0;

            // save data
            UpdateConfigFile();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            UpdateSoundCB();
            UpdateConfigFile();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdateSoundCB();
        }

        private void buttonAddSound_Click(object sender, EventArgs e)
        {
            // open the file selection dialog
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Audio Files|*.wav;*.mp3;*.wma;*.m4a;*.aac",
                Title = "Select an Audio File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)     // observer: user choosed a file
            {
                string selectedFilePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(selectedFilePath);
                string destinationPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, soundDirectoryName, fileName);

                try
                {
                    // fuse: check if the sound folder exists else create it
                    if (!Directory.Exists(soundDirectoryName))
                    {
                        Directory.CreateDirectory(soundDirectoryName);
                    }

                    // copy the file
                    File.Copy(selectedFilePath, destinationPath, false); // true - rewrite file if it exists

                    UpdateSoundCB();

                    MessageBox.Show($"File '{fileName}' has been copied to the 'Sounds' folder.", "Add sound", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error copying file: {ex.Message}", "Add sound", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonDelSound_Click(object sender, EventArgs e)
        {
            GetWavFiles();

            delSoundForm.SetSoundCB(soundNameList);
            delSoundForm.ShowDialog();

            UpdateSoundCB();
        }
        // ***** ***** **** *****
    }
}
