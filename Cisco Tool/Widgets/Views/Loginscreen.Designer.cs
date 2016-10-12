namespace Cisco_Tool.Widgets.Views
{
    partial class LoginScreen
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
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.LoginPasswordLabel = new System.Windows.Forms.Label();
            this.LoginPassword = new System.Windows.Forms.TextBox();
            this.loginIPLabel = new System.Windows.Forms.Label();
            this.LoginIPAddress = new System.Windows.Forms.TextBox();
            this.LoginUsernameLabel = new System.Windows.Forms.Label();
            this.LoginUsername = new System.Windows.Forms.TextBox();
            this.LoginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginPanel
            // 
            this.LoginPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LoginPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LoginPanel.Controls.Add(this.LoginUsername);
            this.LoginPanel.Controls.Add(this.LoginLabel);
            this.LoginPanel.Controls.Add(this.LoginButton);
            this.LoginPanel.Controls.Add(this.LoginPasswordLabel);
            this.LoginPanel.Controls.Add(this.LoginPassword);
            this.LoginPanel.Controls.Add(this.loginIPLabel);
            this.LoginPanel.Controls.Add(this.LoginIPAddress);
            this.LoginPanel.Controls.Add(this.LoginUsernameLabel);
            this.LoginPanel.ForeColor = System.Drawing.Color.White;
            this.LoginPanel.Location = new System.Drawing.Point(41, 43);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(386, 211);
            this.LoginPanel.TabIndex = 15;
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.LoginLabel.Location = new System.Drawing.Point(16, 17);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(174, 25);
            this.LoginLabel.TabIndex = 10;
            this.LoginLabel.Text = "Login voor selectie";
            // 
            // LoginButton
            // 
            this.LoginButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.LoginButton.ForeColor = System.Drawing.Color.Black;
            this.LoginButton.Location = new System.Drawing.Point(21, 160);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(100, 23);
            this.LoginButton.TabIndex = 5;
            this.LoginButton.Text = "Code ophalen";
            this.LoginButton.UseVisualStyleBackColor = true;
            // 
            // LoginPasswordLabel
            // 
            this.LoginPasswordLabel.AutoSize = true;
            this.LoginPasswordLabel.Location = new System.Drawing.Point(51, 116);
            this.LoginPasswordLabel.Name = "LoginPasswordLabel";
            this.LoginPasswordLabel.Size = new System.Drawing.Size(68, 13);
            this.LoginPasswordLabel.TabIndex = 16;
            this.LoginPasswordLabel.Text = "Wachtwoord";
            // 
            // LoginPassword
            // 
            this.LoginPassword.Location = new System.Drawing.Point(157, 113);
            this.LoginPassword.Name = "LoginPassword";
            this.LoginPassword.Size = new System.Drawing.Size(208, 20);
            this.LoginPassword.TabIndex = 4;
            // 
            // loginIPLabel
            // 
            this.loginIPLabel.AutoSize = true;
            this.loginIPLabel.Location = new System.Drawing.Point(51, 64);
            this.loginIPLabel.Name = "loginIPLabel";
            this.loginIPLabel.Size = new System.Drawing.Size(46, 13);
            this.loginIPLabel.TabIndex = 14;
            this.loginIPLabel.Text = "IP adres";
            // 
            // LoginIPAddress
            // 
            this.LoginIPAddress.Location = new System.Drawing.Point(157, 61);
            this.LoginIPAddress.Name = "LoginIPAddress";
            this.LoginIPAddress.Size = new System.Drawing.Size(208, 20);
            this.LoginIPAddress.TabIndex = 2;
            // 
            // LoginUsernameLabel
            // 
            this.LoginUsernameLabel.AutoSize = true;
            this.LoginUsernameLabel.Location = new System.Drawing.Point(51, 90);
            this.LoginUsernameLabel.Name = "LoginUsernameLabel";
            this.LoginUsernameLabel.Size = new System.Drawing.Size(84, 13);
            this.LoginUsernameLabel.TabIndex = 12;
            this.LoginUsernameLabel.Text = "Gebruikersnaam";
            // 
            // LoginUsername
            // 
            this.LoginUsername.Location = new System.Drawing.Point(157, 87);
            this.LoginUsername.Name = "LoginUsername";
            this.LoginUsername.Size = new System.Drawing.Size(208, 20);
            this.LoginUsername.TabIndex = 20;
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.LoginPanel);
            this.Name = "LoginScreen";
            this.Text = "Loginscreen";
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.TextBox LoginUsername;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label LoginPasswordLabel;
        private System.Windows.Forms.TextBox LoginPassword;
        private System.Windows.Forms.Label loginIPLabel;
        private System.Windows.Forms.TextBox LoginIPAddress;
        private System.Windows.Forms.Label LoginUsernameLabel;
    }
}