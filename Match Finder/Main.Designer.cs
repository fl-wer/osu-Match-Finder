namespace Match_Finder
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.apiKeyMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.apiKeyLabel = new System.Windows.Forms.Label();
            this.playersLabel = new System.Windows.Forms.Label();
            this.roomNameLabel = new System.Windows.Forms.Label();
            this.roomNameDropdown = new System.Windows.Forms.ComboBox();
            this.liner_6xox3c = new System.Windows.Forms.Label();
            this.playersDropdown = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.startFromRoomIdLabel = new System.Windows.Forms.Label();
            this.searchStopButton = new System.Windows.Forms.Button();
            this.playersTextBox = new System.Windows.Forms.TextBox();
            this.roomNameTextBox = new System.Windows.Forms.TextBox();
            this.startFromRoomIdNumeric = new System.Windows.Forms.NumericUpDown();
            this.webQueue1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.startFromRoomIdNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // apiKeyMaskedTextBox
            // 
            this.apiKeyMaskedTextBox.Location = new System.Drawing.Point(59, 12);
            this.apiKeyMaskedTextBox.Name = "apiKeyMaskedTextBox";
            this.apiKeyMaskedTextBox.Size = new System.Drawing.Size(273, 20);
            this.apiKeyMaskedTextBox.TabIndex = 0;
            this.apiKeyMaskedTextBox.UseSystemPasswordChar = true;
            // 
            // apiKeyLabel
            // 
            this.apiKeyLabel.AutoSize = true;
            this.apiKeyLabel.Location = new System.Drawing.Point(13, 15);
            this.apiKeyLabel.Name = "apiKeyLabel";
            this.apiKeyLabel.Size = new System.Drawing.Size(40, 13);
            this.apiKeyLabel.TabIndex = 1;
            this.apiKeyLabel.Text = "ApiKey";
            // 
            // playersLabel
            // 
            this.playersLabel.AutoSize = true;
            this.playersLabel.Location = new System.Drawing.Point(12, 61);
            this.playersLabel.Name = "playersLabel";
            this.playersLabel.Size = new System.Drawing.Size(34, 13);
            this.playersLabel.TabIndex = 2;
            this.playersLabel.Text = "Users";
            // 
            // roomNameLabel
            // 
            this.roomNameLabel.AutoSize = true;
            this.roomNameLabel.Location = new System.Drawing.Point(10, 90);
            this.roomNameLabel.Name = "roomNameLabel";
            this.roomNameLabel.Size = new System.Drawing.Size(68, 13);
            this.roomNameLabel.TabIndex = 4;
            this.roomNameLabel.Text = "Match Name";
            // 
            // roomNameDropdown
            // 
            this.roomNameDropdown.FormattingEnabled = true;
            this.roomNameDropdown.Items.AddRange(new object[] {
            "Equals",
            "Contains"});
            this.roomNameDropdown.Location = new System.Drawing.Point(250, 87);
            this.roomNameDropdown.Name = "roomNameDropdown";
            this.roomNameDropdown.Size = new System.Drawing.Size(82, 21);
            this.roomNameDropdown.TabIndex = 6;
            // 
            // liner_6xox3c
            // 
            this.liner_6xox3c.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.liner_6xox3c.Location = new System.Drawing.Point(15, 44);
            this.liner_6xox3c.Name = "liner_6xox3c";
            this.liner_6xox3c.Size = new System.Drawing.Size(315, 2);
            this.liner_6xox3c.TabIndex = 32;
            // 
            // playersDropdown
            // 
            this.playersDropdown.FormattingEnabled = true;
            this.playersDropdown.Items.AddRange(new object[] {
            "All",
            "Single"});
            this.playersDropdown.Location = new System.Drawing.Point(250, 57);
            this.playersDropdown.Name = "playersDropdown";
            this.playersDropdown.Size = new System.Drawing.Size(82, 21);
            this.playersDropdown.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(17, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(315, 2);
            this.label4.TabIndex = 34;
            // 
            // startFromRoomIdLabel
            // 
            this.startFromRoomIdLabel.AutoSize = true;
            this.startFromRoomIdLabel.Location = new System.Drawing.Point(10, 118);
            this.startFromRoomIdLabel.Name = "startFromRoomIdLabel";
            this.startFromRoomIdLabel.Size = new System.Drawing.Size(100, 13);
            this.startFromRoomIdLabel.TabIndex = 35;
            this.startFromRoomIdLabel.Text = "Start From Room ID";
            // 
            // searchStopButton
            // 
            this.searchStopButton.Location = new System.Drawing.Point(17, 159);
            this.searchStopButton.Name = "searchStopButton";
            this.searchStopButton.Size = new System.Drawing.Size(313, 23);
            this.searchStopButton.TabIndex = 37;
            this.searchStopButton.Text = "Search";
            this.searchStopButton.UseVisualStyleBackColor = true;
            this.searchStopButton.Click += new System.EventHandler(this.searchStopButton_Click);
            // 
            // playersTextBox
            // 
            this.playersTextBox.Location = new System.Drawing.Point(52, 57);
            this.playersTextBox.Name = "playersTextBox";
            this.playersTextBox.Size = new System.Drawing.Size(192, 20);
            this.playersTextBox.TabIndex = 39;
            // 
            // roomNameTextBox
            // 
            this.roomNameTextBox.Location = new System.Drawing.Point(82, 87);
            this.roomNameTextBox.Name = "roomNameTextBox";
            this.roomNameTextBox.Size = new System.Drawing.Size(162, 20);
            this.roomNameTextBox.TabIndex = 40;
            // 
            // startFromRoomIdNumeric
            // 
            this.startFromRoomIdNumeric.Location = new System.Drawing.Point(116, 116);
            this.startFromRoomIdNumeric.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.startFromRoomIdNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startFromRoomIdNumeric.Name = "startFromRoomIdNumeric";
            this.startFromRoomIdNumeric.Size = new System.Drawing.Size(216, 20);
            this.startFromRoomIdNumeric.TabIndex = 41;
            this.startFromRoomIdNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.startFromRoomIdNumeric.Value = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            // 
            // webQueue1
            // 
            this.webQueue1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.webQueue1_DoWork);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 192);
            this.Controls.Add(this.startFromRoomIdNumeric);
            this.Controls.Add(this.roomNameTextBox);
            this.Controls.Add(this.playersTextBox);
            this.Controls.Add(this.searchStopButton);
            this.Controls.Add(this.startFromRoomIdLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.playersDropdown);
            this.Controls.Add(this.liner_6xox3c);
            this.Controls.Add(this.roomNameDropdown);
            this.Controls.Add(this.roomNameLabel);
            this.Controls.Add(this.playersLabel);
            this.Controls.Add(this.apiKeyLabel);
            this.Controls.Add(this.apiKeyMaskedTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Match Finder";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.startFromRoomIdNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox apiKeyMaskedTextBox;
        private System.Windows.Forms.Label apiKeyLabel;
        private System.Windows.Forms.Label playersLabel;
        private System.Windows.Forms.Label roomNameLabel;
        private System.Windows.Forms.ComboBox roomNameDropdown;
        private System.Windows.Forms.Label liner_6xox3c;
        private System.Windows.Forms.ComboBox playersDropdown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label startFromRoomIdLabel;
        private System.Windows.Forms.Button searchStopButton;
        private System.Windows.Forms.TextBox playersTextBox;
        private System.Windows.Forms.TextBox roomNameTextBox;
        private System.Windows.Forms.NumericUpDown startFromRoomIdNumeric;
        private System.ComponentModel.BackgroundWorker webQueue1;
    }
}

