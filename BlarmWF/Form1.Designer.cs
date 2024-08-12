using System.Drawing.Text;

namespace BlarmWF
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private PrivateFontCollection pfc = new PrivateFontCollection();

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autostartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelIntervalSec = new System.Windows.Forms.Label();
            this.NUDsec = new System.Windows.Forms.NumericUpDown();
            this.labelIntervalMin = new System.Windows.Forms.Label();
            this.labelTitleInterval = new System.Windows.Forms.Label();
            this.NUDmin = new System.Windows.Forms.NumericUpDown();
            this.chargeOption3 = new BlarmWF.ChargeOption();
            this.chargeOption2 = new BlarmWF.ChargeOption();
            this.chargeOption1 = new BlarmWF.ChargeOption();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDsec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDmin)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Font = new System.Drawing.Font("Cascadia Mono", 9F);
            this.buttonSave.Location = new System.Drawing.Point(107, 442);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(154, 39);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReset.Font = new System.Drawing.Font("Cascadia Mono", 8F);
            this.buttonReset.Location = new System.Drawing.Point(12, 442);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(89, 39);
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Blarm";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autostartToolStripMenuItem,
            this.activeToolStripMenuItem,
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 136);
            // 
            // autostartToolStripMenuItem
            // 
            this.autostartToolStripMenuItem.Checked = true;
            this.autostartToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autostartToolStripMenuItem.Name = "autostartToolStripMenuItem";
            this.autostartToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.autostartToolStripMenuItem.Text = "Autostart";
            this.autostartToolStripMenuItem.Click += new System.EventHandler(this.autostartToolStripMenuItem_Click);
            // 
            // activeToolStripMenuItem
            // 
            this.activeToolStripMenuItem.Checked = true;
            this.activeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activeToolStripMenuItem.Name = "activeToolStripMenuItem";
            this.activeToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.activeToolStripMenuItem.Text = "Active";
            this.activeToolStripMenuItem.Click += new System.EventHandler(this.activeToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelIntervalSec);
            this.panel1.Controls.Add(this.NUDsec);
            this.panel1.Controls.Add(this.labelIntervalMin);
            this.panel1.Controls.Add(this.labelTitleInterval);
            this.panel1.Controls.Add(this.NUDmin);
            this.panel1.Location = new System.Drawing.Point(12, 333);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 102);
            this.panel1.TabIndex = 5;
            // 
            // labelIntervalSec
            // 
            this.labelIntervalSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelIntervalSec.AutoSize = true;
            this.labelIntervalSec.Location = new System.Drawing.Point(193, 66);
            this.labelIntervalSec.Name = "labelIntervalSec";
            this.labelIntervalSec.Size = new System.Drawing.Size(32, 17);
            this.labelIntervalSec.TabIndex = 12;
            this.labelIntervalSec.Text = "sec";
            // 
            // NUDsec
            // 
            this.NUDsec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NUDsec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.NUDsec.Location = new System.Drawing.Point(128, 53);
            this.NUDsec.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.NUDsec.Name = "NUDsec";
            this.NUDsec.Size = new System.Drawing.Size(59, 30);
            this.NUDsec.TabIndex = 11;
            this.NUDsec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUDsec.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // labelIntervalMin
            // 
            this.labelIntervalMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelIntervalMin.AutoSize = true;
            this.labelIntervalMin.Location = new System.Drawing.Point(90, 66);
            this.labelIntervalMin.Name = "labelIntervalMin";
            this.labelIntervalMin.Size = new System.Drawing.Size(32, 17);
            this.labelIntervalMin.TabIndex = 10;
            this.labelIntervalMin.Text = "min";
            // 
            // labelTitleInterval
            // 
            this.labelTitleInterval.AutoSize = true;
            this.labelTitleInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelTitleInterval.Location = new System.Drawing.Point(15, 8);
            this.labelTitleInterval.Name = "labelTitleInterval";
            this.labelTitleInterval.Size = new System.Drawing.Size(104, 31);
            this.labelTitleInterval.TabIndex = 3;
            this.labelTitleInterval.Text = "Interval";
            this.labelTitleInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NUDmin
            // 
            this.NUDmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NUDmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.NUDmin.Location = new System.Drawing.Point(25, 53);
            this.NUDmin.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUDmin.Name = "NUDmin";
            this.NUDmin.Size = new System.Drawing.Size(59, 30);
            this.NUDmin.TabIndex = 9;
            this.NUDmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUDmin.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // chargeOption3
            // 
            this.chargeOption3.Location = new System.Drawing.Point(13, 230);
            this.chargeOption3.Name = "chargeOption3";
            this.chargeOption3.NumericMax = 19;
            this.chargeOption3.NumericMin = 1;
            this.chargeOption3.NumericValue = 15;
            this.chargeOption3.PanelColorStatus = BlarmWF.StatusName.On;
            this.chargeOption3.Size = new System.Drawing.Size(248, 102);
            this.chargeOption3.TabIndex = 2;
            this.chargeOption3.Title = "Critical charge";
            // 
            // chargeOption2
            // 
            this.chargeOption2.Location = new System.Drawing.Point(13, 122);
            this.chargeOption2.Name = "chargeOption2";
            this.chargeOption2.NumericMax = 49;
            this.chargeOption2.NumericMin = 20;
            this.chargeOption2.NumericValue = 20;
            this.chargeOption2.PanelColorStatus = BlarmWF.StatusName.On;
            this.chargeOption2.Size = new System.Drawing.Size(248, 102);
            this.chargeOption2.TabIndex = 1;
            this.chargeOption2.Title = "Low charge";
            // 
            // chargeOption1
            // 
            this.chargeOption1.Location = new System.Drawing.Point(13, 14);
            this.chargeOption1.Name = "chargeOption1";
            this.chargeOption1.NumericMax = 100;
            this.chargeOption1.NumericMin = 50;
            this.chargeOption1.NumericValue = 90;
            this.chargeOption1.PanelColorStatus = BlarmWF.StatusName.Off;
            this.chargeOption1.Size = new System.Drawing.Size(248, 102);
            this.chargeOption1.TabIndex = 0;
            this.chargeOption1.Title = "High charge";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 493);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.chargeOption3);
            this.Controls.Add(this.chargeOption2);
            this.Controls.Add(this.chargeOption1);
            this.Font = new System.Drawing.Font("Cascadia Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blarm - Settings";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDsec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDmin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ChargeOption chargeOption1;
        private ChargeOption chargeOption2;
        private ChargeOption chargeOption3;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem activeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label labelTitleInterval;
        private System.Windows.Forms.Label labelIntervalMin;
        private System.Windows.Forms.NumericUpDown NUDmin;
        private System.Windows.Forms.Label labelIntervalSec;
        private System.Windows.Forms.NumericUpDown NUDsec;
        private System.Windows.Forms.ToolStripMenuItem autostartToolStripMenuItem;
    }
}

