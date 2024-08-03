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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chargeOption1 = new BlarmWF.ChargeOption();
            this.chargeOption2 = new BlarmWF.ChargeOption();
            this.chargeOption3 = new BlarmWF.ChargeOption();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chargeOption1
            // 
            this.chargeOption1.Location = new System.Drawing.Point(13, 14);
            this.chargeOption1.Name = "chargeOption1";
            this.chargeOption1.NumericMax = 100;
            this.chargeOption1.NumericMin = 50;
            this.chargeOption1.NumericValue = 90;
            this.chargeOption1.PanelColorStatus = BlarmWF.ColorStatusName.Mute;
            this.chargeOption1.Size = new System.Drawing.Size(248, 102);
            this.chargeOption1.TabIndex = 0;
            this.chargeOption1.Title = "High charge";
            // 
            // chargeOption2
            // 
            this.chargeOption2.Location = new System.Drawing.Point(13, 122);
            this.chargeOption2.Name = "chargeOption2";
            this.chargeOption2.NumericMax = 49;
            this.chargeOption2.NumericMin = 20;
            this.chargeOption2.NumericValue = 20;
            this.chargeOption2.PanelColorStatus = BlarmWF.ColorStatusName.On;
            this.chargeOption2.Size = new System.Drawing.Size(248, 102);
            this.chargeOption2.TabIndex = 1;
            this.chargeOption2.Title = "Low charge";
            // 
            // chargeOption3
            // 
            this.chargeOption3.Location = new System.Drawing.Point(13, 230);
            this.chargeOption3.Name = "chargeOption3";
            this.chargeOption3.NumericMax = 19;
            this.chargeOption3.NumericMin = 1;
            this.chargeOption3.NumericValue = 15;
            this.chargeOption3.PanelColorStatus = BlarmWF.ColorStatusName.On;
            this.chargeOption3.Size = new System.Drawing.Size(248, 102);
            this.chargeOption3.TabIndex = 2;
            this.chargeOption3.Title = "Critical charge";
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Cascadia Mono", 9F);
            this.buttonSave.Location = new System.Drawing.Point(107, 347);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(154, 39);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Font = new System.Drawing.Font("Cascadia Mono", 8F);
            this.buttonReset.Location = new System.Drawing.Point(12, 347);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(89, 39);
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 398);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.chargeOption3);
            this.Controls.Add(this.chargeOption2);
            this.Controls.Add(this.chargeOption1);
            this.Font = new System.Drawing.Font("Cascadia Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Blarm - Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private ChargeOption chargeOption1;
        private ChargeOption chargeOption2;
        private ChargeOption chargeOption3;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonReset;
    }
}

