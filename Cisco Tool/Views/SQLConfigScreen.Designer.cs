namespace Cisco_Tool.Views
{
    partial class SQLConfigScreen
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
            this.components = new System.ComponentModel.Container();
            this.mainTextLabel = new System.Windows.Forms.Label();
            this.ManualLoginGroupBox = new System.Windows.Forms.Panel();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.SQLPassword = new System.Windows.Forms.TextBox();
            this.SQLIPAddress = new System.Windows.Forms.TextBox();
            this.ManualLoginTitle = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.SQLUsername = new System.Windows.Forms.TextBox();
            this.IPaddressLabel = new System.Windows.Forms.Label();
            this.DatabaseLabel = new System.Windows.Forms.Label();
            this.SQLDatabase = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.mainErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ManualLoginGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTextLabel
            // 
            this.mainTextLabel.AutoSize = true;
            this.mainTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTextLabel.ForeColor = System.Drawing.Color.White;
            this.mainTextLabel.Location = new System.Drawing.Point(12, 9);
            this.mainTextLabel.Name = "mainTextLabel";
            this.mainTextLabel.Size = new System.Drawing.Size(210, 25);
            this.mainTextLabel.TabIndex = 0;
            this.mainTextLabel.Text = "Database selecteren";
            // 
            // ManualLoginGroupBox
            // 
            this.ManualLoginGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ManualLoginGroupBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ManualLoginGroupBox.Controls.Add(this.PasswordLabel);
            this.ManualLoginGroupBox.Controls.Add(this.SQLPassword);
            this.ManualLoginGroupBox.Controls.Add(this.SQLIPAddress);
            this.ManualLoginGroupBox.Controls.Add(this.ManualLoginTitle);
            this.ManualLoginGroupBox.Controls.Add(this.UsernameLabel);
            this.ManualLoginGroupBox.Controls.Add(this.SQLUsername);
            this.ManualLoginGroupBox.Controls.Add(this.IPaddressLabel);
            this.ManualLoginGroupBox.Controls.Add(this.DatabaseLabel);
            this.ManualLoginGroupBox.Controls.Add(this.SQLDatabase);
            this.ManualLoginGroupBox.Location = new System.Drawing.Point(39, 54);
            this.ManualLoginGroupBox.Name = "ManualLoginGroupBox";
            this.ManualLoginGroupBox.Size = new System.Drawing.Size(459, 258);
            this.ManualLoginGroupBox.TabIndex = 14;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(44, 207);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(75, 15);
            this.PasswordLabel.TabIndex = 18;
            this.PasswordLabel.Text = "Wachtwoord";
            // 
            // SQLPassword
            // 
            this.SQLPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SQLPassword.Location = new System.Drawing.Point(176, 204);
            this.SQLPassword.Name = "SQLPassword";
            this.SQLPassword.PasswordChar = '*';
            this.SQLPassword.Size = new System.Drawing.Size(163, 20);
            this.SQLPassword.TabIndex = 17;
            // 
            // SQLIPAddress
            // 
            this.SQLIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SQLIPAddress.Location = new System.Drawing.Point(176, 65);
            this.SQLIPAddress.Name = "SQLIPAddress";
            this.SQLIPAddress.Size = new System.Drawing.Size(163, 20);
            this.SQLIPAddress.TabIndex = 2;
            // 
            // ManualLoginTitle
            // 
            this.ManualLoginTitle.AutoSize = true;
            this.ManualLoginTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ManualLoginTitle.Location = new System.Drawing.Point(16, 17);
            this.ManualLoginTitle.Name = "ManualLoginTitle";
            this.ManualLoginTitle.Size = new System.Drawing.Size(302, 25);
            this.ManualLoginTitle.TabIndex = 10;
            this.ManualLoginTitle.Text = "Gegevens van de routerdatabase";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(44, 162);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(99, 15);
            this.UsernameLabel.TabIndex = 16;
            this.UsernameLabel.Text = "Gebruikersnaam";
            // 
            // SQLUsername
            // 
            this.SQLUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SQLUsername.Location = new System.Drawing.Point(176, 159);
            this.SQLUsername.Name = "SQLUsername";
            this.SQLUsername.Size = new System.Drawing.Size(163, 20);
            this.SQLUsername.TabIndex = 4;
            // 
            // IPaddressLabel
            // 
            this.IPaddressLabel.AutoSize = true;
            this.IPaddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPaddressLabel.Location = new System.Drawing.Point(44, 68);
            this.IPaddressLabel.Name = "IPaddressLabel";
            this.IPaddressLabel.Size = new System.Drawing.Size(52, 15);
            this.IPaddressLabel.TabIndex = 14;
            this.IPaddressLabel.Text = "IP adres";
            // 
            // DatabaseLabel
            // 
            this.DatabaseLabel.AutoSize = true;
            this.DatabaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabaseLabel.Location = new System.Drawing.Point(44, 115);
            this.DatabaseLabel.Name = "DatabaseLabel";
            this.DatabaseLabel.Size = new System.Drawing.Size(95, 15);
            this.DatabaseLabel.TabIndex = 12;
            this.DatabaseLabel.Text = "Naam database";
            // 
            // SQLDatabase
            // 
            this.SQLDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SQLDatabase.Location = new System.Drawing.Point(176, 112);
            this.SQLDatabase.Name = "SQLDatabase";
            this.SQLDatabase.Size = new System.Drawing.Size(163, 20);
            this.SQLDatabase.TabIndex = 3;
            // 
            // OKButton
            // 
            this.OKButton.ForeColor = System.Drawing.Color.Black;
            this.OKButton.Location = new System.Drawing.Point(39, 349);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(113, 35);
            this.OKButton.TabIndex = 15;
            this.OKButton.Text = "Toepassen";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.ForeColor = System.Drawing.Color.Black;
            this.cancelButton.Location = new System.Drawing.Point(158, 349);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(113, 35);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "Annuleren";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // mainErrorProvider
            // 
            this.mainErrorProvider.ContainerControl = this;
            // 
            // SQLConfigScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.ManualLoginGroupBox);
            this.Controls.Add(this.mainTextLabel);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "SQLConfigScreen";
            this.Text = "SQL server instellen";
            this.ManualLoginGroupBox.ResumeLayout(false);
            this.ManualLoginGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainTextLabel;
        private System.Windows.Forms.Panel ManualLoginGroupBox;
        private System.Windows.Forms.Label ManualLoginTitle;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox SQLUsername;
        private System.Windows.Forms.Label IPaddressLabel;
        private System.Windows.Forms.TextBox SQLIPAddress;
        private System.Windows.Forms.Label DatabaseLabel;
        private System.Windows.Forms.TextBox SQLDatabase;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox SQLPassword;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ErrorProvider mainErrorProvider;
    }
}