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
     public partial class ChargeOption : UserControl
    {
        // --- values ---
        private StatusName btnColorStatus = StatusName.On;

        // *** interface properties ***
        [Category("Appearance")]
        public string Title
        {
            get { return labelTitle.Text; }
            set { labelTitle.Text = value; }
        }
        [Category("Behavior")]
        public int NumericValue
        {
            get { return (int)numericUpDown1.Value; }
            set { numericUpDown1.Value = value; }
        }
        [Category("Data")]
        public int NumericMax
        {
            get { return (int)numericUpDown1.Maximum; }
            set { numericUpDown1.Maximum = value; }
        }
        [Category("Data")]
        public int NumericMin
        {
            get { return (int)numericUpDown1.Minimum; }
            set { numericUpDown1.Minimum = value; }
        }
        [Category("Appearance")]
        [TypeConverter(typeof(ColorTypeConverter))]
        public StatusName PanelColorStatus
        {
            get { return btnColorStatus; }
            set { 
                btnColorStatus = value;
                buttonStatus.BackColor = StatusColor.GetColor(btnColorStatus);
                labelStatus.Text = StatusColor.GetText(btnColorStatus);
            }
        }
        // *** ********* ********** ***


        public ChargeOption()
        {
            InitializeComponent();
            btnColorStatus = StatusName.On;
            buttonStatus.BackColor = StatusColor.GetColor(StatusName.On);
            labelStatus.Text = StatusColor.GetText(StatusName.On);
        }

        private void ChangeButton()
        {
            btnColorStatus = (btnColorStatus == StatusName.On) ? StatusName.Off : StatusName.On;
            buttonStatus.BackColor = StatusColor.GetColor(btnColorStatus);
            labelStatus.Text = StatusColor.GetText(btnColorStatus);
        }


        // ***** Bined func *****
        private void button1_Click(object sender, EventArgs e)
        {
            ChangeButton();
        }
        // ***** ***** **** *****
    }

}
