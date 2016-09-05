namespace Cisco_Tool
{
    partial class MainForm
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.ManualLoginTitle = new System.Windows.Forms.Label();
            this.ManualLoginGroupBox = new System.Windows.Forms.GroupBox();
            this.ManualConnect = new System.Windows.Forms.Button();
            this.ManualPasswordLabel = new System.Windows.Forms.Label();
            this.ManualPassword = new System.Windows.Forms.TextBox();
            this.ManualIPAddressLabel = new System.Windows.Forms.Label();
            this.ManualIPAddress = new System.Windows.Forms.TextBox();
            this.ManualUsernameLabel = new System.Windows.Forms.Label();
            this.ManualUsername = new System.Windows.Forms.TextBox();
            this.MainGridView = new System.Windows.Forms.DataGridView();
            this.Status = new System.Windows.Forms.DataGridViewImageColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.SearchGroupBox = new System.Windows.Forms.GroupBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.CommandoGB = new System.Windows.Forms.GroupBox();
            this.CommandoInfo2 = new System.Windows.Forms.Label();
            this.RunCommands = new System.Windows.Forms.Button();
            this.Command7 = new System.Windows.Forms.TextBox();
            this.Command6 = new System.Windows.Forms.TextBox();
            this.Command5 = new System.Windows.Forms.TextBox();
            this.Command4 = new System.Windows.Forms.TextBox();
            this.Command3 = new System.Windows.Forms.TextBox();
            this.Command2 = new System.Windows.Forms.TextBox();
            this.Command1 = new System.Windows.Forms.TextBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.CommandoInfo = new System.Windows.Forms.Label();
            this.ScriptButton = new System.Windows.Forms.Button();
            this.Password = new System.Windows.Forms.TextBox();
            this.Username = new System.Windows.Forms.TextBox();
            this.ScriptLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.ManualLoginGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainGridView)).BeginInit();
            this.SearchGroupBox.SuspendLayout();
            this.CommandoGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.TitleLabel.Location = new System.Drawing.Point(12, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(106, 25);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Cisco Tool";
            // 
            // ManualLoginTitle
            // 
            this.ManualLoginTitle.AutoSize = true;
            this.ManualLoginTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ManualLoginTitle.Location = new System.Drawing.Point(10, 16);
            this.ManualLoginTitle.Name = "ManualLoginTitle";
            this.ManualLoginTitle.Size = new System.Drawing.Size(289, 25);
            this.ManualLoginTitle.TabIndex = 2;
            this.ManualLoginTitle.Text = "Handmatig verbinden met router";
            // 
            // ManualLoginGroupBox
            // 
            this.ManualLoginGroupBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ManualLoginGroupBox.Controls.Add(this.ManualConnect);
            this.ManualLoginGroupBox.Controls.Add(this.ManualPasswordLabel);
            this.ManualLoginGroupBox.Controls.Add(this.ManualPassword);
            this.ManualLoginGroupBox.Controls.Add(this.ManualIPAddressLabel);
            this.ManualLoginGroupBox.Controls.Add(this.ManualIPAddress);
            this.ManualLoginGroupBox.Controls.Add(this.ManualUsernameLabel);
            this.ManualLoginGroupBox.Controls.Add(this.ManualUsername);
            this.ManualLoginGroupBox.Controls.Add(this.ManualLoginTitle);
            this.ManualLoginGroupBox.Location = new System.Drawing.Point(17, 50);
            this.ManualLoginGroupBox.Name = "ManualLoginGroupBox";
            this.ManualLoginGroupBox.Size = new System.Drawing.Size(400, 166);
            this.ManualLoginGroupBox.TabIndex = 3;
            this.ManualLoginGroupBox.TabStop = false;
            // 
            // ManualConnect
            // 
            this.ManualConnect.Location = new System.Drawing.Point(15, 120);
            this.ManualConnect.Name = "ManualConnect";
            this.ManualConnect.Size = new System.Drawing.Size(100, 23);
            this.ManualConnect.TabIndex = 9;
            this.ManualConnect.Text = "Verbinden";
            this.ManualConnect.UseVisualStyleBackColor = true;
            // 
            // ManualPasswordLabel
            // 
            this.ManualPasswordLabel.AutoSize = true;
            this.ManualPasswordLabel.Location = new System.Drawing.Point(298, 53);
            this.ManualPasswordLabel.Name = "ManualPasswordLabel";
            this.ManualPasswordLabel.Size = new System.Drawing.Size(68, 13);
            this.ManualPasswordLabel.TabIndex = 8;
            this.ManualPasswordLabel.Text = "Wachtwoord";
            // 
            // ManualPassword
            // 
            this.ManualPassword.Location = new System.Drawing.Point(281, 72);
            this.ManualPassword.Name = "ManualPassword";
            this.ManualPassword.Size = new System.Drawing.Size(100, 20);
            this.ManualPassword.TabIndex = 7;
            // 
            // ManualIPAddressLabel
            // 
            this.ManualIPAddressLabel.AutoSize = true;
            this.ManualIPAddressLabel.Location = new System.Drawing.Point(22, 53);
            this.ManualIPAddressLabel.Name = "ManualIPAddressLabel";
            this.ManualIPAddressLabel.Size = new System.Drawing.Size(46, 13);
            this.ManualIPAddressLabel.TabIndex = 6;
            this.ManualIPAddressLabel.Text = "IP adres";
            // 
            // ManualIPAddress
            // 
            this.ManualIPAddress.Location = new System.Drawing.Point(15, 72);
            this.ManualIPAddress.Name = "ManualIPAddress";
            this.ManualIPAddress.Size = new System.Drawing.Size(100, 20);
            this.ManualIPAddress.TabIndex = 5;
            // 
            // ManualUsernameLabel
            // 
            this.ManualUsernameLabel.AutoSize = true;
            this.ManualUsernameLabel.Location = new System.Drawing.Point(152, 53);
            this.ManualUsernameLabel.Name = "ManualUsernameLabel";
            this.ManualUsernameLabel.Size = new System.Drawing.Size(84, 13);
            this.ManualUsernameLabel.TabIndex = 4;
            this.ManualUsernameLabel.Text = "Gebruikersnaam";
            // 
            // ManualUsername
            // 
            this.ManualUsername.Location = new System.Drawing.Point(145, 72);
            this.ManualUsername.Name = "ManualUsername";
            this.ManualUsername.Size = new System.Drawing.Size(100, 20);
            this.ManualUsername.TabIndex = 3;
            // 
            // MainGridView
            // 
            this.MainGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Status,
            this.CompanyName,
            this.IpAddress,
            this.StatusInfo});
            this.MainGridView.Location = new System.Drawing.Point(730, 9);
            this.MainGridView.Name = "MainGridView";
            this.MainGridView.ReadOnly = true;
            this.MainGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MainGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MainGridView.Size = new System.Drawing.Size(522, 615);
            this.MainGridView.TabIndex = 4;
            // 
            // Status
            // 
            this.Status.HeaderText = "";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 16;
            // 
            // CompanyName
            // 
            this.CompanyName.HeaderText = "Bedrijfsnaam";
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.ReadOnly = true;
            // 
            // IpAddress
            // 
            this.IpAddress.HeaderText = "IP adres router";
            this.IpAddress.Name = "IpAddress";
            this.IpAddress.ReadOnly = true;
            // 
            // StatusInfo
            // 
            this.StatusInfo.HeaderText = "Status informatie";
            this.StatusInfo.Name = "StatusInfo";
            this.StatusInfo.ReadOnly = true;
            this.StatusInfo.Width = 300;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Cisco_Tool.Properties.Resources.warningIcon;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 20;
            // 
            // SearchGroupBox
            // 
            this.SearchGroupBox.Controls.Add(this.SearchButton);
            this.SearchGroupBox.Controls.Add(this.SearchBox);
            this.SearchGroupBox.Controls.Add(this.SearchLabel);
            this.SearchGroupBox.Location = new System.Drawing.Point(730, 630);
            this.SearchGroupBox.Name = "SearchGroupBox";
            this.SearchGroupBox.Size = new System.Drawing.Size(522, 39);
            this.SearchGroupBox.TabIndex = 5;
            this.SearchGroupBox.TabStop = false;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(460, 10);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(56, 23);
            this.SearchButton.TabIndex = 8;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(56, 13);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(398, 20);
            this.SearchBox.TabIndex = 7;
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(6, 15);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(44, 13);
            this.SearchLabel.TabIndex = 6;
            this.SearchLabel.Text = "Zoeken";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(283, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 43);
            this.button2.TabIndex = 6;
            this.button2.Text = "GoToAdvancedTab";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CommandoGB
            // 
            this.CommandoGB.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.CommandoGB.Controls.Add(this.CommandoInfo2);
            this.CommandoGB.Controls.Add(this.RunCommands);
            this.CommandoGB.Controls.Add(this.Command7);
            this.CommandoGB.Controls.Add(this.Command6);
            this.CommandoGB.Controls.Add(this.Command5);
            this.CommandoGB.Controls.Add(this.Command4);
            this.CommandoGB.Controls.Add(this.Command3);
            this.CommandoGB.Controls.Add(this.Command2);
            this.CommandoGB.Controls.Add(this.Command1);
            this.CommandoGB.Controls.Add(this.checkBox7);
            this.CommandoGB.Controls.Add(this.checkBox6);
            this.CommandoGB.Controls.Add(this.checkBox5);
            this.CommandoGB.Controls.Add(this.checkBox4);
            this.CommandoGB.Controls.Add(this.checkBox3);
            this.CommandoGB.Controls.Add(this.checkBox2);
            this.CommandoGB.Controls.Add(this.checkBox1);
            this.CommandoGB.Controls.Add(this.CommandoInfo);
            this.CommandoGB.Controls.Add(this.ScriptButton);
            this.CommandoGB.Controls.Add(this.Password);
            this.CommandoGB.Controls.Add(this.Username);
            this.CommandoGB.Controls.Add(this.ScriptLabel);
            this.CommandoGB.Controls.Add(this.PasswordLabel);
            this.CommandoGB.Controls.Add(this.UsernameLabel);
            this.CommandoGB.Location = new System.Drawing.Point(17, 222);
            this.CommandoGB.Name = "CommandoGB";
            this.CommandoGB.Size = new System.Drawing.Size(400, 447);
            this.CommandoGB.TabIndex = 7;
            this.CommandoGB.TabStop = false;
            // 
            // CommandoInfo2
            // 
            this.CommandoInfo2.AutoSize = true;
            this.CommandoInfo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CommandoInfo2.Location = new System.Drawing.Point(11, 161);
            this.CommandoInfo2.Name = "CommandoInfo2";
            this.CommandoInfo2.Size = new System.Drawing.Size(245, 20);
            this.CommandoInfo2.TabIndex = 23;
            this.CommandoInfo2.Text = "Handmatig commando\'s invoeren";
            // 
            // RunCommands
            // 
            this.RunCommands.Location = new System.Drawing.Point(15, 379);
            this.RunCommands.Name = "RunCommands";
            this.RunCommands.Size = new System.Drawing.Size(115, 23);
            this.RunCommands.TabIndex = 8;
            this.RunCommands.Text = "Uitvoeren";
            this.RunCommands.UseVisualStyleBackColor = true;
            // 
            // Command7
            // 
            this.Command7.Location = new System.Drawing.Point(115, 335);
            this.Command7.Name = "Command7";
            this.Command7.Size = new System.Drawing.Size(251, 20);
            this.Command7.TabIndex = 22;
            // 
            // Command6
            // 
            this.Command6.Location = new System.Drawing.Point(115, 309);
            this.Command6.Name = "Command6";
            this.Command6.Size = new System.Drawing.Size(251, 20);
            this.Command6.TabIndex = 21;
            // 
            // Command5
            // 
            this.Command5.Location = new System.Drawing.Point(115, 286);
            this.Command5.Name = "Command5";
            this.Command5.Size = new System.Drawing.Size(251, 20);
            this.Command5.TabIndex = 20;
            // 
            // Command4
            // 
            this.Command4.Location = new System.Drawing.Point(115, 263);
            this.Command4.Name = "Command4";
            this.Command4.Size = new System.Drawing.Size(251, 20);
            this.Command4.TabIndex = 19;
            // 
            // Command3
            // 
            this.Command3.Location = new System.Drawing.Point(115, 240);
            this.Command3.Name = "Command3";
            this.Command3.Size = new System.Drawing.Size(251, 20);
            this.Command3.TabIndex = 18;
            // 
            // Command2
            // 
            this.Command2.Location = new System.Drawing.Point(115, 217);
            this.Command2.Name = "Command2";
            this.Command2.Size = new System.Drawing.Size(251, 20);
            this.Command2.TabIndex = 17;
            // 
            // Command1
            // 
            this.Command1.Location = new System.Drawing.Point(115, 191);
            this.Command1.Name = "Command1";
            this.Command1.Size = new System.Drawing.Size(251, 20);
            this.Command1.TabIndex = 16;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(15, 335);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(15, 14);
            this.checkBox7.TabIndex = 15;
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(15, 312);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(15, 14);
            this.checkBox6.TabIndex = 14;
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(15, 289);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(15, 14);
            this.checkBox5.TabIndex = 13;
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(15, 266);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 14);
            this.checkBox4.TabIndex = 12;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(15, 243);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 11;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(15, 220);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 197);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // CommandoInfo
            // 
            this.CommandoInfo.AutoSize = true;
            this.CommandoInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.CommandoInfo.Location = new System.Drawing.Point(10, 16);
            this.CommandoInfo.Name = "CommandoInfo";
            this.CommandoInfo.Size = new System.Drawing.Size(213, 25);
            this.CommandoInfo.TabIndex = 8;
            this.CommandoInfo.Text = "Commando\'s uitvoeren";
            // 
            // ScriptButton
            // 
            this.ScriptButton.Location = new System.Drawing.Point(115, 104);
            this.ScriptButton.Name = "ScriptButton";
            this.ScriptButton.Size = new System.Drawing.Size(171, 23);
            this.ScriptButton.TabIndex = 5;
            this.ScriptButton.Text = "Kies script";
            this.ScriptButton.UseVisualStyleBackColor = true;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(115, 78);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(171, 20);
            this.Password.TabIndex = 4;
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(115, 52);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(171, 20);
            this.Username.TabIndex = 3;
            // 
            // ScriptLabel
            // 
            this.ScriptLabel.AutoSize = true;
            this.ScriptLabel.Location = new System.Drawing.Point(12, 110);
            this.ScriptLabel.Name = "ScriptLabel";
            this.ScriptLabel.Size = new System.Drawing.Size(34, 13);
            this.ScriptLabel.TabIndex = 2;
            this.ScriptLabel.Text = "Script";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(12, 81);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Password";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(12, 55);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "Username";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.CommandoGB);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SearchGroupBox);
            this.Controls.Add(this.MainGridView);
            this.Controls.Add(this.ManualLoginGroupBox);
            this.Controls.Add(this.TitleLabel);
            this.Name = "MainForm";
            this.Text = "Cisco Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ManualLoginGroupBox.ResumeLayout(false);
            this.ManualLoginGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainGridView)).EndInit();
            this.SearchGroupBox.ResumeLayout(false);
            this.SearchGroupBox.PerformLayout();
            this.CommandoGB.ResumeLayout(false);
            this.CommandoGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label ManualLoginTitle;
        private System.Windows.Forms.GroupBox ManualLoginGroupBox;
        private System.Windows.Forms.Label ManualPasswordLabel;
        private System.Windows.Forms.TextBox ManualPassword;
        private System.Windows.Forms.Label ManualIPAddressLabel;
        private System.Windows.Forms.TextBox ManualIPAddress;
        private System.Windows.Forms.Label ManualUsernameLabel;
        private System.Windows.Forms.TextBox ManualUsername;
        private System.Windows.Forms.Button ManualConnect;
        private System.Windows.Forms.DataGridView MainGridView;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusInfo;
        private System.Windows.Forms.GroupBox SearchGroupBox;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox CommandoGB;
        private System.Windows.Forms.Label ScriptLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.Button ScriptButton;
        private System.Windows.Forms.Label CommandoInfo;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button RunCommands;
        private System.Windows.Forms.TextBox Command7;
        private System.Windows.Forms.TextBox Command6;
        private System.Windows.Forms.TextBox Command5;
        private System.Windows.Forms.TextBox Command4;
        private System.Windows.Forms.TextBox Command3;
        private System.Windows.Forms.TextBox Command2;
        private System.Windows.Forms.TextBox Command1;
        private System.Windows.Forms.Label CommandoInfo2;
    }
}

