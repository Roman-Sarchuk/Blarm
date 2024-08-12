using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WMPLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


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
            get { return labelCharge.Text; }
            set { labelCharge.Text = value; }
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


        public void SetTitleFont(Font font)
        {
            labelCharge.Font = font;
            labelSound.Font = font;
        }

        public void UpdateSoundCB(List<string> items)
        {
            var selectedItem = comboBoxSound.SelectedItem;

            comboBoxSound.Items.Clear();
            comboBoxSound.Items.AddRange(items.ToArray());

            if (selectedItem == null)   // guard: item isn't selected
                return;

            if (comboBoxSound.Items.Contains(selectedItem))
                comboBoxSound.SelectedItem = selectedItem;
            else
                comboBoxSound.Text = string.Empty;

        }

        private void PlaySound()
        {
            // guard system
            if (SoundName == "None")    // item isn't selected
                return;
            if (!System.IO.File.Exists(SoundPath))     // file doesn't exist
            {
                MessageBox.Show($"Can't find the \"{SoundName}\" in '{soundDirectoryName}' folder", "Getting sound file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (player.playState == WMPPlayState.wmppsPlaying)     // sound's playing now
                return;

            // execute
            try
            {
                player.URL = SoundPath;
                player.controls.play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing sound:\n" + ex.Message, "Play sound file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ***** bined func *****
        private void buttonStatus_Click(object sender, EventArgs e)
        {
            btnColorStatus = (btnColorStatus == StatusName.On) ? StatusName.Off : StatusName.On;
            buttonStatus.BackColor = StatusColor.GetColor(btnColorStatus);
            labelStatus.Text = StatusColor.GetText(btnColorStatus);
        }
        // ***** ***** **** *****
    }

}
