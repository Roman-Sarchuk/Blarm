using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
        private byte[] defLevelList = { 90, 20, 15 };   // high , low , critival
        private string configFileName = "config.ini";
        private FileIniDataParser parser = new FileIniDataParser();
        private IniData data;

        public Form1()
        {
            InitializeComponent();

            pfc.AddFontFile("Jura-VariableFont_wght.ttf");
            // Set fonts
            chargeOption1.labelTitle.Font = new Font(pfc.Families[0], 16, FontStyle.Regular);
            chargeOption2.labelTitle.Font = new Font(pfc.Families[0], 16, FontStyle.Regular);
            chargeOption3.labelTitle.Font = new Font(pfc.Families[0], 16, FontStyle.Regular);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Getting config data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void UpdateConfigFile()
        {

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            // NumericValue
            chargeOption1.NumericValue = defLevelList[0];
            chargeOption2.NumericValue = defLevelList[1];
            chargeOption3.NumericValue = defLevelList[2];

            // PanelColorStatus
            chargeOption1.PanelColorStatus = ColorStatusName.Mute;
            chargeOption2.PanelColorStatus = ColorStatusName.On;
            chargeOption3.PanelColorStatus = ColorStatusName.On;

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }
    }
}
