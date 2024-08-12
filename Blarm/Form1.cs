using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using IWshRuntimeLibrary;

namespace BlarmWF
{
    internal struct Error
    {
        public string Title { get; private set; }
        public string Message { get; private set; }

        public bool Is => !string.IsNullOrEmpty(Title);

        public void Set(string title, string message) { Title = title; Message = message; }
        public void Clear() { Title = ""; Message = ""; }
    }
    internal enum NotificationType { None, High, Low, Critical }

    public partial class Form1 : Form
    {
        // --- setting values ---
        private static byte HIGH_LEVE;
        private static byte LOW_LEVEL;
        private static byte CRITICAL_LEVEL;
        private static StatusName HIGH_STATUS;
        private static StatusName LOW_STATUS;
        private static StatusName CRITICAL_STATUS;
        private static string HIGH_SYMBOL;
        private static string LOW_SYMBOL;
        private static string CRITICAL_SYMBOL;

        // --- ini parser values ---
        private string configFileName = "config.ini";
        private FileIniDataParser parser = new FileIniDataParser();
        private IniData data;

        // --- additional values ---
        private static bool isCharging = false;
        private static Error errMsg = new Error();
        private static NotificationType notification = new NotificationType();
        private bool isClose = false;
        private bool allowShowDisplay = false;
        private static bool isAutostart = false;


        public Form1()
        {
            InitializeComponent();

            pfc.AddFontFile("Jura-VariableFont_wght.ttf");
            Font font = new Font(pfc.Families[0], 16, FontStyle.Regular);
            // Set fonts
            chargeOption1.labelTitle.Font = font;
            chargeOption2.labelTitle.Font = font;
            chargeOption3.labelTitle.Font = font;
            labelTitleInterval.Font = font;

            // Load data from config.ini
            LoadConfigData();

            // Set notifyIcon autostart 'Checked'
            isAutostart = IsShortcutInStartup();
            autostartToolStripMenuItem.Checked = isAutostart;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!isClose)
            {
                e.Cancel = true;
                this.Hide();
            }
            
            base.OnFormClosing(e);
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(allowShowDisplay ? value : allowShowDisplay);
        }

        private void ShowForm()
        {
            allowShowDisplay = true;
            this.Show();
            this.Activate();
            this.WindowState = FormWindowState.Normal;
        }

        private void CloseForm()
        {
            isClose = true;
            DisposeResources();
            Application.Exit();
        }

        private void DisposeResources()
        {
            if (notifyIcon1 != null)
            {
                notifyIcon1.Visible = false; // Ховаємо NotifyIcon
                notifyIcon1.Dispose(); // Звільняємо ресурси
                notifyIcon1 = null;
            }
        }


        // ***** config.ini processing *****
        private void Form1_Load(object sender, EventArgs e)
        {
            // update data from config.ini
            LoadConfigData();

            // set notifyIcon autostart 'Checked'
            isAutostart = IsShortcutInStartup();
            autostartToolStripMenuItem.Checked = isAutostart;

            // set form values
            chargeOption1.NumericValue = HIGH_LEVE;
            chargeOption2.NumericValue = LOW_LEVEL;
            chargeOption3.NumericValue = CRITICAL_LEVEL;

            chargeOption1.PanelColorStatus = HIGH_STATUS;
            chargeOption2.PanelColorStatus = LOW_STATUS;
            chargeOption3.PanelColorStatus = CRITICAL_STATUS;
        }

        private string ThrowCannotFindIniValue(string section, string parameter)
        {
            throw new ArgumentNullException($"\nCan't find: section \"{section}\" -> property \"{parameter}\" in \"{configFileName}\"");
        }

        private void LoadConfigData()
        {
            uint min, sec;
            try
            {
                data = parser.ReadFile(configFileName);

                // get Charge Levels
                HIGH_LEVE = byte.Parse(data["ChargeLevels"]["HighCharge"] ?? ThrowCannotFindIniValue("ChargeLevels", "HighCharge"));
                LOW_LEVEL = byte.Parse(data["ChargeLevels"]["LowCharge"] ?? ThrowCannotFindIniValue("ChargeLevels", "LowCharge"));
                CRITICAL_LEVEL = byte.Parse(data["ChargeLevels"]["CriticalCharge"] ?? ThrowCannotFindIniValue("ChargeLevels", "CriticalCharge"));

                // get Status
                HIGH_STATUS = (StatusName)Enum.Parse(typeof(StatusName), data["ChargeStatus"]["HighStatus"] ?? ThrowCannotFindIniValue("ChargeStatus", "HighStatus"));
                LOW_STATUS = (StatusName)Enum.Parse(typeof(StatusName), data["ChargeStatus"]["LowStatus"] ?? ThrowCannotFindIniValue("ChargeStatus", "LowStatus"));
                CRITICAL_STATUS = (StatusName)Enum.Parse(typeof(StatusName), data["ChargeStatus"]["CriticalStatus"] ?? ThrowCannotFindIniValue("ChargeStatus", "CriticalStatus"));

                // get Notification Symbols
                HIGH_SYMBOL = data["Notification"]["HighSymbol"] ?? ThrowCannotFindIniValue("Notification", "HighSymbol");
                LOW_SYMBOL = data["Notification"]["LowSymbol"] ?? ThrowCannotFindIniValue("Notification", "LowSymbol");
                CRITICAL_SYMBOL = data["Notification"]["CriticalSymbol"] ?? ThrowCannotFindIniValue("Notification", "CriticalSymbol");

                // get Interval
                min = uint.Parse(data["Interval"]["Minutes"] ?? ThrowCannotFindIniValue("Interval", "Minutes"));
                sec = uint.Parse(data["Interval"]["Seconds"] ?? ThrowCannotFindIniValue("Interval", "Seconds"));
                if (min > NUDmin.Maximum)
                    throw new ArgumentNullException($"Getted \"Minutes\" from \"{configFileName}\" must be from 0 to {NUDmin.Maximum}");
                if (sec > NUDsec.Maximum)
                    throw new ArgumentNullException($"Getted \"Minutes\" from \"{configFileName}\" must be from 0 to {NUDsec.Maximum}");
                NUDmin.Value = min;
                NUDsec.Value = sec;
                timer1.Interval = (int)(min * 60000 + sec * 1000);

                // get Notification Active Status
                activeToolStripMenuItem.Checked = bool.Parse(data["Notification"]["ActiveStatus"] ?? ThrowCannotFindIniValue("Notification", "ActiveStatus"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Getting config data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseForm();
            }
        }

        private void UpdateConfigFile()
        {
            try
            {
                data = parser.ReadFile(configFileName);

                // set setting values
                HIGH_LEVE = (byte)chargeOption1.NumericValue;
                LOW_LEVEL = (byte)chargeOption2.NumericValue;
                CRITICAL_LEVEL = (byte)chargeOption3.NumericValue;
                
                HIGH_STATUS = chargeOption1.PanelColorStatus;
                LOW_STATUS = chargeOption2.PanelColorStatus;
                CRITICAL_STATUS = chargeOption3.PanelColorStatus;

                // set Charge levels
                data["ChargeLevels"]["HighCharge"] = HIGH_LEVE.ToString();
                data["ChargeLevels"]["LowCharge"] = LOW_LEVEL.ToString();
                data["ChargeLevels"]["CriticalCharge"] = CRITICAL_LEVEL.ToString();

                // set Status
                data["ChargeStatus"]["HighStatus"] = HIGH_STATUS.ToString();
                data["ChargeStatus"]["LowStatus"] = LOW_STATUS.ToString();
                data["ChargeStatus"]["CriticalStatus"] = CRITICAL_STATUS.ToString();

                // set Interval
                data["Interval"]["Minutes"] = NUDmin.Value.ToString();
                data["Interval"]["Seconds"] = NUDsec.Value.ToString();
                timer1.Interval = ((int)NUDmin.Value) * 60000 + ((int)NUDsec.Value) * 1000;

                parser.WriteFile("config.ini", data);

                MessageBox.Show("Values are updated successfully", "Updating config data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating config data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ***** ********** ********** *****


        // ***** Battery processing *****
        private static byte GetBatteryPercentage()
        {
            // get
            PowerStatus powerStatus = SystemInformation.PowerStatus;
            short batteryPercentage = (short)Math.Round(powerStatus.BatteryLifePercent * 100);

            // verify
            if (powerStatus.BatteryChargeStatus.HasFlag(BatteryChargeStatus.Unknown))
            {
                errMsg.Set("Getting Battery info", "Battery life percentage is unknown");
                return 225;
            }
            else if (powerStatus.BatteryChargeStatus.HasFlag(BatteryChargeStatus.NoSystemBattery))
            {
                errMsg.Set("Getting Battery info", "No Battery");
                return 225;
            }
            if (batteryPercentage < 0 || batteryPercentage > 100)
            {
                errMsg.Set("Getting Battery info", "Incorrect battery percentage. Can't get the correct value");
                return 225;
            }

            // set isCharging value
            isCharging = powerStatus.BatteryChargeStatus.HasFlag(BatteryChargeStatus.Charging);

            // finish
            return (byte)batteryPercentage;
        }

        private void CheckBatteryLevel(short batteryPercentage)
        {
            // reset notification type
            if ((notification == NotificationType.High && (batteryPercentage < HIGH_LEVE || !isCharging)) ||
                (notification == NotificationType.Low && (batteryPercentage <= CRITICAL_LEVEL || batteryPercentage > LOW_LEVEL || isCharging)) ||
                (notification == NotificationType.Critical && (batteryPercentage > CRITICAL_LEVEL || isCharging)))
            {
                notification = NotificationType.None;
            }

            // execute
            if (notification != NotificationType.None)  // guard: multiple notification
                return;
            if (isCharging && HIGH_STATUS != StatusName.Off && batteryPercentage >= HIGH_LEVE)
            {
                notification = NotificationType.High;
                ShowNotification($"{HIGH_SYMBOL} Battery {batteryPercentage}%", $"Battery is charged. Unplug the charger.");
            }
            else if (!isCharging && LOW_STATUS != StatusName.Off && batteryPercentage > CRITICAL_LEVEL && batteryPercentage <= LOW_LEVEL)
            {
                notification = NotificationType.Low;
                ShowNotification($"{LOW_SYMBOL} Battery {batteryPercentage}%", $"Low charge level. Consider charging.");
            }
            else if (!isCharging && CRITICAL_STATUS != StatusName.Off && batteryPercentage <= CRITICAL_LEVEL)
            {
                notification = NotificationType.Critical;
                ShowNotification($"{CRITICAL_SYMBOL} Battery {batteryPercentage}%", $"CRITICAL charge level. Plug in the charger❗");
            }
        }

        private void ShowNotification(string title, string message, ToolTipIcon icon = ToolTipIcon.None)
        {
            notifyIcon1.BalloonTipTitle = title;
            notifyIcon1.BalloonTipText = message;
            notifyIcon1.BalloonTipIcon = icon;
            notifyIcon1.ShowBalloonTip(1000);
        }
        // ***** ******* ********** *****


        // ***** Autostar processing *****
        public static bool IsShortcutInStartup()
        {
            string startupFolderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Startup), "BlarmAgent.lnk");
            return System.IO.File.Exists(startupFolderPath);
        }

        public static void AddShortcutToStartup()
        {
            string startupFolderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Startup), "BlarmAgent.lnk");
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(startupFolderPath);
            shortcut.Description = "BlarmAgent";
            shortcut.TargetPath = exePath;
            shortcut.Save();
        }

        public static void RemoveShortcutFromStartup()
        {
            string startupFolderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Startup), "BlarmAgent.lnk");
            if (System.IO.File.Exists(startupFolderPath))
            {
                System.IO.File.Delete(startupFolderPath);
            }
        }
        // ***** ******** ********** *****


        // ***** Bined func *****
        private void buttonReset_Click(object sender, EventArgs e)
        {
            // NumericValue
            chargeOption1.NumericValue = 90;
            chargeOption2.NumericValue = 20;
            chargeOption3.NumericValue = 15;

            // PanelColorStatus
            chargeOption1.PanelColorStatus = StatusName.Off;
            chargeOption2.PanelColorStatus = StatusName.On;
            chargeOption3.PanelColorStatus = StatusName.On;

            // Interval
            NUDmin.Value = 2;
            NUDsec.Value = 0;

            UpdateConfigFile();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            UpdateConfigFile();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!activeToolStripMenuItem.Checked)
                return;
            
            byte batteryPercentage = GetBatteryPercentage();
            if (errMsg.Is)
            {
                // guard: incorrect batteryPercentage
                ShowNotification(errMsg.Title, errMsg.Message, ToolTipIcon.Error);
                errMsg.Clear();
                return;
            }

            notifyIcon1.Text = $"Battery: {batteryPercentage}%";

            CheckBatteryLevel(batteryPercentage);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible)
                this.Hide();
            else
                ShowForm();
        }

        private void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // switch 'checked'
            activeToolStripMenuItem.Checked = !activeToolStripMenuItem.Checked;

            // update 'ActiveStatus' in config.ini
            try
            {
                data = parser.ReadFile(configFileName);

                data["Notification"]["ActiveStatus"] = activeToolStripMenuItem.Checked.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating config data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // change the notifyIcon text
            if (!activeToolStripMenuItem.Checked)
                notifyIcon1.Text = "Blarm: OFF";
            else
                notifyIcon1.Text = "Blarm";
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void autostartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autostartToolStripMenuItem.Checked = !autostartToolStripMenuItem.Checked;
            isAutostart = IsShortcutInStartup();

            if (isAutostart == autostartToolStripMenuItem.Checked)
                return;

            if (isAutostart)    // autostartToolStripMenuItem.Checked is false
                RemoveShortcutFromStartup();
            else                // autostartToolStripMenuItem.Checked is true
                AddShortcutToStartup();
        }
        // ***** ***** **** *****
    }
}
