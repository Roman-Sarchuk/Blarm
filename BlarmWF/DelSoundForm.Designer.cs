namespace BlarmWF
{
    partial class DelSoundForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DelSoundForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelDel = new System.Windows.Forms.Label();
            this.comboBoxSound = new System.Windows.Forms.ComboBox();
            this.buttonDel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelDel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxSound, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(213, 115);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelDel
            // 
            this.labelDel.AutoSize = true;
            this.labelDel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelDel.Location = new System.Drawing.Point(3, 0);
            this.labelDel.Name = "labelDel";
            this.labelDel.Size = new System.Drawing.Size(207, 46);
            this.labelDel.TabIndex = 0;
            this.labelDel.Text = "Sounds";
            this.labelDel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxSound
            // 
            this.comboBoxSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSound.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBoxSound.FormattingEnabled = true;
            this.comboBoxSound.Location = new System.Drawing.Point(3, 68);
            this.comboBoxSound.Name = "comboBoxSound";
            this.comboBoxSound.Size = new System.Drawing.Size(207, 28);
            this.comboBoxSound.TabIndex = 1;
            // 
            // buttonDel
            // 
            this.buttonDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonDel.Location = new System.Drawing.Point(21, 143);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(193, 40);
            this.buttonDel.TabIndex = 1;
            this.buttonDel.Text = "Delete";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // DelSoundForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(237, 200);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(255, 247);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(255, 247);
            this.Name = "DelSoundForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sounds";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelDel;
        private System.Windows.Forms.ComboBox comboBoxSound;
        private System.Windows.Forms.Button buttonDel;
    }
}