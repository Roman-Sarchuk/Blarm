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

namespace BlarmWF
{
    public partial class Form1 : Form
    {
        private byte[] defLevelList = { 90, 20, 15 };   // high , low , critival

        public Form1()
        {
            InitializeComponent();

            pfc.AddFontFile("Jura-VariableFont_wght.ttf");
            // Set fonts
            chargeOption1.labelTitle.Font = new Font(pfc.Families[0], 16, FontStyle.Regular);
            chargeOption2.labelTitle.Font = new Font(pfc.Families[0], 16, FontStyle.Regular);
            chargeOption3.labelTitle.Font = new Font(pfc.Families[0], 16, FontStyle.Regular);
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
