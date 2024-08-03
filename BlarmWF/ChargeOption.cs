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
        private PrivateFontCollection pfc = new PrivateFontCollection();
        private ColorStatusName btnColorStatus = ColorStatusName.On;

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
        public ColorStatusName PanelColorStatus
        {
            get { return btnColorStatus; }
            set { 
                btnColorStatus = value;
                buttonStatus.BackColor = StatusColor.GetColor(btnColorStatus);
                labelStatus.Text = StatusColor.GetText(btnColorStatus);
            }
        }

        public ChargeOption()
        {
            InitializeComponent();
            btnColorStatus = ColorStatusName.On;
            buttonStatus.BackColor = StatusColor.GetColor(ColorStatusName.On);
            labelStatus.Text = StatusColor.GetText(ColorStatusName.On);
        }

        private void ChangeButton()
        {
            // Change color
            if (btnColorStatus == ColorStatusName.On)
            {
                btnColorStatus = ColorStatusName.Mute;
                buttonStatus.BackColor = StatusColor.GetColor(ColorStatusName.Mute);
                labelStatus.Text = StatusColor.GetText(ColorStatusName.Mute);
            }
            else if (btnColorStatus == ColorStatusName.Mute)
            {
                btnColorStatus = ColorStatusName.Off;
                buttonStatus.BackColor = StatusColor.GetColor(ColorStatusName.Off);
                labelStatus.Text = StatusColor.GetText(ColorStatusName.Off);
            }
            else if (btnColorStatus == ColorStatusName.Off)
            {
                btnColorStatus = ColorStatusName.On;
                buttonStatus.BackColor = StatusColor.GetColor(ColorStatusName.On);
                labelStatus.Text = StatusColor.GetText(ColorStatusName.On);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeButton();
        }
    }

}
