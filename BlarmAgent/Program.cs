using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using WMPLib;

namespace BlarmAgent
{
    enum StatusName { On, Mute, Off };
    enum NotificationType { None, High, Low, Critical };

    internal static class Program
    {
        // --- setting values ---
        private static short HIGH_LEVEL = 94;
        private static short LOW_LEVEL = 20;
        private static short CRITICAL_LEVEL = 15;
        private static StatusName HIGH_STATUS = StatusName.Mute;
        private static StatusName LOW_STATUS = StatusName.On;
        private static StatusName CRITICAL_STATUS = StatusName.Off;

        // --- sounds values
        private static string soundDirectoryName = "Sounds\\";
        private static WindowsMediaPlayer player = new WindowsMediaPlayer();
        private static string HIGH_SOUND_FILE_NAME = "None";
        private static string LOW_SOUND_FILE_NAME = "None";
        private static string CRITICAL_SOUND_FILE_NAME = "None";


        // --- additional values ---
        private static bool isCharging = false;
        private static Error errMsg = new Error();
        private static NotificationType notification = new NotificationType();

        // --- ini parser values ---
        private static string configFileName = "config.ini";
        private static FileIniDataParser parser = new FileIniDataParser();
        private static IniData data;

        [STAThread]
        static void Main(string[] args)
        {
            if (!LoadSettings())
            {
                // guard
                ShowNotification(errMsg.Title, errMsg.Message + "\n\nBlarm isn't started!");
                errMsg.Clear();
                return;
            }

            // TODO: TESTING
            //Console.WriteLine("BlarmAgent is running. Press Ctrl+C to exit.\n");

            short batteryPercentage;
            while (true)
            {
                batteryPercentage = GetBatteryPercentage();
                // guard
                if (errMsg.Is)
                {
                    ShowNotification(errMsg.Title, errMsg.Message);
                    errMsg.Clear();
                    continue;
                }

                CheckBatteryLevel(batteryPercentage);

                Thread.Sleep(5000); // every 5 sec
            }
        }

        private static bool LoadSettings()
        {
            try
            {
                data = parser.ReadFile(configFileName);

                // get Charge levels
                HIGH_LEVEL = short.Parse(data["ChargeLevels"]["HighCharge"] ?? throw new ArgumentNullException("\nCan't find: section \"ChargeLevels\" -> property \"HighCharge\" in \"" + configFileName + "\""));
                LOW_LEVEL = short.Parse(data["ChargeLevels"]["LowCharge"] ?? throw new ArgumentNullException("\nCan't find: section \"ChargeLevels\" -> property \"LowCharge\" in \"" + configFileName + "\""));
                CRITICAL_LEVEL = short.Parse(data["ChargeLevels"]["CriticalCharge"] ?? throw new ArgumentNullException("\nCan't find: section \"ChargeLevels\" -> property \"CriticalCharge\" in \"" + configFileName + "\""));

                // get Status
                HIGH_STATUS = (StatusName)Enum.Parse(typeof(StatusName), data["ChargeStatus"]["HighStatus"] ?? throw new ArgumentNullException("\nCan't find: section \"ChargeStatus\" -> property \"HighStatus\" in \"" + configFileName + "\""));
                LOW_STATUS = (StatusName)Enum.Parse(typeof(StatusName), data["ChargeStatus"]["LowStatus"] ?? throw new ArgumentNullException("\nCan't find: section \"ChargeStatus\" -> property \"LowStatus\" in \"" + configFileName + "\""));
                CRITICAL_STATUS = (StatusName)Enum.Parse(typeof(StatusName), data["ChargeStatus"]["CriticalStatus"] ?? throw new ArgumentNullException("\nCan't find: section \"ChargeStatus\" -> property \"CriticalStatus\" in \"" + configFileName + "\""));

                // get Sound
                HIGH_SOUND_FILE_NAME = data["SoundOptions"]["HighSoundFileName"] ?? throw new ArgumentNullException("\nCan't find: section \"SoundOptions\" -> property \"SoundFilePath\" in \"" + configFileName + "\"");
                LOW_SOUND_FILE_NAME = data["SoundOptions"]["LowSoundFileName"] ?? throw new ArgumentNullException("\nCan't find: section \"SoundOptions\" -> property \"SoundFilePath\" in \"" + configFileName + "\"");
                CRITICAL_SOUND_FILE_NAME = data["SoundOptions"]["CriticalSoundFileName"] ?? throw new ArgumentNullException("\nCan't find: section \"SoundOptions\" -> property \"SoundFilePath\" in \"" + configFileName + "\"");
            }
            catch (Exception ex)
            {
                errMsg.Set("Getting config data", ex.Message);
                return false;
            }
            return true;
        }

        private static void ShowNotification(string title, string message)
        {
            // TODO: TESTING
            //Console.WriteLine($"{title}: {message}");
        }

        private static void CheckBatteryLevel(short batteryPercentage)
        {
            // reset notification type
            if ((notification == NotificationType.High && (batteryPercentage < HIGH_LEVEL || !isCharging)) ||
                (notification == NotificationType.Low && (batteryPercentage <= CRITICAL_LEVEL || batteryPercentage > LOW_LEVEL || isCharging)) ||
                (notification == NotificationType.Critical && (batteryPercentage > CRITICAL_LEVEL || isCharging)))
            {
                notification = NotificationType.None;
            }

            // execute
            if (notification != NotificationType.None)  // guard: multiple notification
                return;
            if (isCharging && HIGH_STATUS != StatusName.Off && batteryPercentage >= HIGH_LEVEL)
            {
                notification = NotificationType.High;
                ShowNotification("High Battery", $"Battery is fully charged: {batteryPercentage}%.");
                if (HIGH_STATUS != StatusName.Mute)
                    PlaySound(HIGH_SOUND_FILE_NAME);
            }
            else if (!isCharging && LOW_STATUS != StatusName.Off && batteryPercentage > CRITICAL_LEVEL && batteryPercentage <= LOW_LEVEL)
            {
                notification = NotificationType.Low;
                ShowNotification("Low Battery", $"Low battery level: {batteryPercentage}%. Consider charging.");
                if (LOW_STATUS != StatusName.Mute)
                    PlaySound(LOW_SOUND_FILE_NAME);
            }
            else if (!isCharging && CRITICAL_STATUS != StatusName.Off && batteryPercentage <= CRITICAL_LEVEL)
            {
                notification = NotificationType.Critical;
                ShowNotification("Critical Battery", $"CRITICAL battery level: {batteryPercentage}%. Plug in the charger!");
                if (CRITICAL_STATUS != StatusName.Mute)
                    PlaySound(CRITICAL_SOUND_FILE_NAME);
            }
        }

        private static void PlaySound(string soundName)
        {
            // guard system
            if (soundName == "None")    // item isn't selected
                return;
            if (!System.IO.File.Exists(soundDirectoryName + soundName))     // file doesn't exist
            {
                errMsg.Set("Getting sound file", $"Can't find the \"{soundName}\" in '{soundDirectoryName}' folder");
                return;
            }
            if (player.playState == WMPPlayState.wmppsPlaying)     // sound's playing now
                return;

            // execute
            try
            {
                player.URL = soundDirectoryName + soundName;
                player.controls.play();
            }
            catch (Exception ex)
            {
                errMsg.Set("Play sound file", "Error playing sound:\n" + ex.Message);
            }
        }

        // ***** Battery level processing *****
        [StructLayout(LayoutKind.Sequential)]
        private struct SYSTEM_POWER_STATUS
        {
            public byte ACLineStatus;
            public byte BatteryFlag;
            public byte BatteryLifePercent;
            public byte Reserved1;
            public int BatteryLifeTime;
            public int BatteryFullLifeTime;
        }
        private static SYSTEM_POWER_STATUS status = new SYSTEM_POWER_STATUS();

        private struct Error
        {
            public string Title { get; private set; }
            public string Message { get; private set; }

            public bool Is => !string.IsNullOrEmpty(Title);

            public void Set(string title, string message) { Title = title; Message = message; }
            public void Clear() { Title = ""; Message = ""; }
        }

        private static short GetBatteryPercentage()
        {
            // get
            if (!GetSystemPowerStatus(out status))
            {
                errMsg.Set("Getting Battery info", "Can't get the battery data");
                return -1;
            }

            // verify
            if (status.BatteryLifePercent == 255)
            {
                errMsg.Set("Getting Battery info", "Battery life percentage is unknown");
                return -2;
            }

            switch (status.BatteryFlag)
            {
                case 0x08:
                    errMsg.Set("Getting Battery info", "Battery status (Flag) is unknown");
                    return -3;
                case 0x0F:
                    errMsg.Set("Getting Battery info", "No Battery");
                    return -4;
            }

            if (status.ACLineStatus == 255)
            {
                errMsg.Set("Getting Battery info", "Battery charging status is unknown");
                isCharging = false;
                return -5;
            }

            // set isCharging value
            isCharging = status.ACLineStatus == 1;

            // finish
            return status.BatteryLifePercent;
        }

        [DllImport("kernel32.dll")]
        private static extern bool GetSystemPowerStatus(out SYSTEM_POWER_STATUS sps);
        // ***** ******* ***** ********** *****
    }
}
