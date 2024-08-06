using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlarmWF
{
    public partial class DelSoundForm : Form
    {
        private static string soundDirectoryName = "Sounds\\";

        public DelSoundForm()
        {
            InitializeComponent();
        }

        public void SetTitleFont(Font font)
        {
            labelDel.Font = font;
        }

        public void SetSoundCB(List<string> items)
        {
            comboBoxSound.Items.Clear();
            comboBoxSound.Items.AddRange(items.ToArray());
        }

        // ***** bined func *****
        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (comboBoxSound.SelectedItem == null)     // observer: some item is selected
            {
                MessageBox.Show("Please select a file to delete.", "No File Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedFileName = comboBoxSound.SelectedItem.ToString();
            string filePath = Path.Combine(soundDirectoryName, selectedFileName);

            try
            {
                if (File.Exists(filePath))      // guard: such file exists
                {
                    File.Delete(filePath);
                    MessageBox.Show($"File '{selectedFileName}' has been deleted.", "Sound deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"File '{selectedFileName}' does not exist.", "Sound deletion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting file: {ex.Message}", "Sound deletion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // finish
            this.Close();
        }
        // ***** ***** **** *****
    }
}
