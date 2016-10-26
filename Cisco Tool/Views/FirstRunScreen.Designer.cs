namespace Cisco_Tool.Views
{
    partial class FirstRunScreen
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
            this.tabs = new System.Windows.Forms.TabControl();
            this.welcomePage = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sqlPage = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.SQLPassword = new System.Windows.Forms.TextBox();
            this.SQLIPAddress = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.SQLUsername = new System.Windows.Forms.TextBox();
            this.IPaddressLabel = new System.Windows.Forms.Label();
            this.DatabaseLabel = new System.Windows.Forms.Label();
            this.SQLDatabase = new System.Windows.Forms.TextBox();
            this.summaryPage = new System.Windows.Forms.TabPage();
            this.summaryTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.mainErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabs.SuspendLayout();
            this.welcomePage.SuspendLayout();
            this.sqlPage.SuspendLayout();
            this.summaryPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.welcomePage);
            this.tabs.Controls.Add(this.sqlPage);
            this.tabs.Controls.Add(this.summaryPage);
            this.tabs.Location = new System.Drawing.Point(31, 21);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(648, 323);
            this.tabs.TabIndex = 0;
            // 
            // welcomePage
            // 
            this.welcomePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.welcomePage.Controls.Add(this.textBox1);
            this.welcomePage.Controls.Add(this.label2);
            this.welcomePage.ForeColor = System.Drawing.Color.White;
            this.welcomePage.Location = new System.Drawing.Point(4, 22);
            this.welcomePage.Name = "welcomePage";
            this.welcomePage.Padding = new System.Windows.Forms.Padding(3);
            this.welcomePage.Size = new System.Drawing.Size(640, 297);
            this.welcomePage.TabIndex = 0;
            this.welcomePage.Text = "Welkom";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(50, 70);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(420, 100);
            this.textBox1.TabIndex = 3;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Om de applicatie te kunnen gebruiken, moet je eerst de wizard volgen. Druk op vol" +
    "gende om door te gaan. De database gegevens zullen worden gevraagd, deze kan wor" +
    "den verschaft door het ontwikkelteam.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(25, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Welkom bij Cisco Tool";
            // 
            // sqlPage
            // 
            this.sqlPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sqlPage.Controls.Add(this.label3);
            this.sqlPage.Controls.Add(this.PasswordLabel);
            this.sqlPage.Controls.Add(this.SQLPassword);
            this.sqlPage.Controls.Add(this.SQLIPAddress);
            this.sqlPage.Controls.Add(this.UsernameLabel);
            this.sqlPage.Controls.Add(this.SQLUsername);
            this.sqlPage.Controls.Add(this.IPaddressLabel);
            this.sqlPage.Controls.Add(this.DatabaseLabel);
            this.sqlPage.Controls.Add(this.SQLDatabase);
            this.sqlPage.Location = new System.Drawing.Point(4, 22);
            this.sqlPage.Name = "sqlPage";
            this.sqlPage.Padding = new System.Windows.Forms.Padding(3);
            this.sqlPage.Size = new System.Drawing.Size(640, 297);
            this.sqlPage.TabIndex = 1;
            this.sqlPage.Text = "SQL Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(25, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(262, 24);
            this.label3.TabIndex = 27;
            this.label3.Text = "Geef SQL database gegevens";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.ForeColor = System.Drawing.Color.White;
            this.PasswordLabel.Location = new System.Drawing.Point(50, 220);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(75, 15);
            this.PasswordLabel.TabIndex = 26;
            this.PasswordLabel.Text = "Wachtwoord";
            // 
            // SQLPassword
            // 
            this.SQLPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SQLPassword.Location = new System.Drawing.Point(186, 219);
            this.SQLPassword.Name = "SQLPassword";
            this.SQLPassword.PasswordChar = '*';
            this.SQLPassword.Size = new System.Drawing.Size(163, 20);
            this.SQLPassword.TabIndex = 22;
            // 
            // SQLIPAddress
            // 
            this.SQLIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SQLIPAddress.Location = new System.Drawing.Point(186, 69);
            this.SQLIPAddress.Name = "SQLIPAddress";
            this.SQLIPAddress.Size = new System.Drawing.Size(163, 20);
            this.SQLIPAddress.TabIndex = 19;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.ForeColor = System.Drawing.Color.White;
            this.UsernameLabel.Location = new System.Drawing.Point(50, 170);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(99, 15);
            this.UsernameLabel.TabIndex = 24;
            this.UsernameLabel.Text = "Gebruikersnaam";
            // 
            // SQLUsername
            // 
            this.SQLUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SQLUsername.Location = new System.Drawing.Point(186, 169);
            this.SQLUsername.Name = "SQLUsername";
            this.SQLUsername.Size = new System.Drawing.Size(163, 20);
            this.SQLUsername.TabIndex = 21;
            // 
            // IPaddressLabel
            // 
            this.IPaddressLabel.AutoSize = true;
            this.IPaddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPaddressLabel.ForeColor = System.Drawing.Color.White;
            this.IPaddressLabel.Location = new System.Drawing.Point(50, 70);
            this.IPaddressLabel.Name = "IPaddressLabel";
            this.IPaddressLabel.Size = new System.Drawing.Size(52, 15);
            this.IPaddressLabel.TabIndex = 23;
            this.IPaddressLabel.Text = "IP adres";
            // 
            // DatabaseLabel
            // 
            this.DatabaseLabel.AutoSize = true;
            this.DatabaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabaseLabel.ForeColor = System.Drawing.Color.White;
            this.DatabaseLabel.Location = new System.Drawing.Point(50, 120);
            this.DatabaseLabel.Name = "DatabaseLabel";
            this.DatabaseLabel.Size = new System.Drawing.Size(95, 15);
            this.DatabaseLabel.TabIndex = 22;
            this.DatabaseLabel.Text = "Naam database";
            // 
            // SQLDatabase
            // 
            this.SQLDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SQLDatabase.Location = new System.Drawing.Point(186, 119);
            this.SQLDatabase.Name = "SQLDatabase";
            this.SQLDatabase.Size = new System.Drawing.Size(163, 20);
            this.SQLDatabase.TabIndex = 20;
            // 
            // summaryPage
            // 
            this.summaryPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.summaryPage.Controls.Add(this.summaryTextBox);
            this.summaryPage.Controls.Add(this.label1);
            this.summaryPage.Location = new System.Drawing.Point(4, 22);
            this.summaryPage.Name = "summaryPage";
            this.summaryPage.Size = new System.Drawing.Size(640, 297);
            this.summaryPage.TabIndex = 2;
            this.summaryPage.Text = "Overzicht";
            // 
            // summaryTextBox
            // 
            this.summaryTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.summaryTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.summaryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summaryTextBox.Location = new System.Drawing.Point(50, 70);
            this.summaryTextBox.Multiline = true;
            this.summaryTextBox.Name = "summaryTextBox";
            this.summaryTextBox.ReadOnly = true;
            this.summaryTextBox.Size = new System.Drawing.Size(350, 200);
            this.summaryTextBox.TabIndex = 33;
            this.summaryTextBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 24);
            this.label1.TabIndex = 32;
            this.label1.Text = "Overzicht";
            // 
            // BackButton
            // 
            this.BackButton.ForeColor = System.Drawing.Color.Black;
            this.BackButton.Location = new System.Drawing.Point(31, 367);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(113, 35);
            this.BackButton.TabIndex = 18;
            this.BackButton.Text = "Terug";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.ForeColor = System.Drawing.Color.Black;
            this.NextButton.Location = new System.Drawing.Point(162, 367);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(113, 35);
            this.NextButton.TabIndex = 17;
            this.NextButton.Text = "Volgende";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // mainErrorProvider
            // 
            this.mainErrorProvider.ContainerControl = this;
            // 
            // FirstRunScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(734, 436);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.tabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FirstRunScreen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instellingen";
            this.tabs.ResumeLayout(false);
            this.welcomePage.ResumeLayout(false);
            this.welcomePage.PerformLayout();
            this.sqlPage.ResumeLayout(false);
            this.sqlPage.PerformLayout();
            this.summaryPage.ResumeLayout(false);
            this.summaryPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage sqlPage;
        private System.Windows.Forms.TabPage welcomePage;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage summaryPage;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox SQLPassword;
        private System.Windows.Forms.TextBox SQLIPAddress;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox SQLUsername;
        private System.Windows.Forms.Label IPaddressLabel;
        private System.Windows.Forms.Label DatabaseLabel;
        private System.Windows.Forms.TextBox SQLDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox summaryTextBox;
        private System.Windows.Forms.ErrorProvider mainErrorProvider;
    }
}