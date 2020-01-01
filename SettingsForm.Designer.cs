﻿namespace T3pyRYster
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.NameLabel = new System.Windows.Forms.Label();
            this.BlackButton = new System.Windows.Forms.Button();
            this.WhiteButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.Autorun = new System.Windows.Forms.CheckBox();
            this.ComboFonts = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.BackColor = System.Drawing.Color.Transparent;
            this.NameLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLabel.ForeColor = System.Drawing.Color.White;
            this.NameLabel.Location = new System.Drawing.Point(2, 8);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(87, 15);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Settings";
            this.NameLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveMe);
            this.NameLabel.MouseHover += new System.EventHandler(this.AnimateName);
            // 
            // BlackButton
            // 
            this.BlackButton.BackColor = System.Drawing.Color.Black;
            this.BlackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BlackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BlackButton.ForeColor = System.Drawing.Color.White;
            this.BlackButton.Location = new System.Drawing.Point(0, 30);
            this.BlackButton.Name = "BlackButton";
            this.BlackButton.Size = new System.Drawing.Size(100, 100);
            this.BlackButton.TabIndex = 3;
            this.BlackButton.Text = "Black ME!";
            this.BlackButton.UseVisualStyleBackColor = false;
            this.BlackButton.Click += new System.EventHandler(this.BlackButton_Click);
            // 
            // WhiteButton
            // 
            this.WhiteButton.BackColor = System.Drawing.Color.White;
            this.WhiteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.WhiteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WhiteButton.ForeColor = System.Drawing.Color.Black;
            this.WhiteButton.Location = new System.Drawing.Point(100, 30);
            this.WhiteButton.Name = "WhiteButton";
            this.WhiteButton.Size = new System.Drawing.Size(100, 100);
            this.WhiteButton.TabIndex = 3;
            this.WhiteButton.Text = "White ME!";
            this.WhiteButton.UseVisualStyleBackColor = false;
            this.WhiteButton.Click += new System.EventHandler(this.WhiteButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.BackgroundImage = global::T3pyRYster.Properties.Resources.CloseIcon;
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(170, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(30, 30);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Autorun
            // 
            this.Autorun.AutoSize = true;
            this.Autorun.BackColor = System.Drawing.Color.Black;
            this.Autorun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Autorun.ForeColor = System.Drawing.Color.White;
            this.Autorun.Location = new System.Drawing.Point(10, 130);
            this.Autorun.Name = "Autorun";
            this.Autorun.Size = new System.Drawing.Size(140, 17);
            this.Autorun.TabIndex = 5;
            this.Autorun.Text = "Run on Windows startup";
            this.Autorun.UseVisualStyleBackColor = false;
            this.Autorun.CheckedChanged += new System.EventHandler(this.Autorun_CheckedChanged);
            // 
            // ComboFonts
            // 
            this.ComboFonts.FormattingEnabled = true;
            this.ComboFonts.Items.AddRange(new object[] {
            "Arial",
            "Calibria",
            "Sans Serif"});
            this.ComboFonts.Location = new System.Drawing.Point(0, 153);
            this.ComboFonts.Name = "ComboFonts";
            this.ComboFonts.Size = new System.Drawing.Size(200, 21);
            this.ComboFonts.TabIndex = 6;
            this.ComboFonts.Text = "Select font";
            this.ComboFonts.SelectedIndexChanged += new System.EventHandler(this.ComboFonts_SelectedIndexChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(201, 176);
            this.Controls.Add(this.ComboFonts);
            this.Controls.Add(this.Autorun);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.WhiteButton);
            this.Controls.Add(this.BlackButton);
            this.Controls.Add(this.NameLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsForm";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button BlackButton;
        private System.Windows.Forms.Button WhiteButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.CheckBox Autorun;
        private System.Windows.Forms.ComboBox ComboFonts;

        public bool CurrTheme { get; private set; }
    }
}