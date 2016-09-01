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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ManualConnect = new System.Windows.Forms.Button();
            this.ManualPasswordLabel = new System.Windows.Forms.Label();
            this.ManualPassword = new System.Windows.Forms.TextBox();
            this.ManualIPAddressLabel = new System.Windows.Forms.Label();
            this.ManualIPAddress = new System.Windows.Forms.TextBox();
            this.ManualUsernameLabel = new System.Windows.Forms.Label();
            this.ManualUsername = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Status = new System.Windows.Forms.DataGridViewImageColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.ManualLoginTitle.Location = new System.Drawing.Point(51, 16);
            this.ManualLoginTitle.Name = "ManualLoginTitle";
            this.ManualLoginTitle.Size = new System.Drawing.Size(289, 25);
            this.ManualLoginTitle.TabIndex = 2;
            this.ManualLoginTitle.Text = "Handmatig verbinden met router";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ManualConnect);
            this.groupBox1.Controls.Add(this.ManualPasswordLabel);
            this.groupBox1.Controls.Add(this.ManualPassword);
            this.groupBox1.Controls.Add(this.ManualIPAddressLabel);
            this.groupBox1.Controls.Add(this.ManualIPAddress);
            this.groupBox1.Controls.Add(this.ManualUsernameLabel);
            this.groupBox1.Controls.Add(this.ManualUsername);
            this.groupBox1.Controls.Add(this.ManualLoginTitle);
            this.groupBox1.Location = new System.Drawing.Point(17, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 192);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ManualLoginGroupBox";
            // 
            // ManualConnect
            // 
            this.ManualConnect.Location = new System.Drawing.Point(145, 151);
            this.ManualConnect.Name = "ManualConnect";
            this.ManualConnect.Size = new System.Drawing.Size(75, 23);
            this.ManualConnect.TabIndex = 9;
            this.ManualConnect.Text = "Verbinden";
            this.ManualConnect.UseVisualStyleBackColor = true;
            // 
            // ManualPasswordLabel
            // 
            this.ManualPasswordLabel.AutoSize = true;
            this.ManualPasswordLabel.Location = new System.Drawing.Point(298, 84);
            this.ManualPasswordLabel.Name = "ManualPasswordLabel";
            this.ManualPasswordLabel.Size = new System.Drawing.Size(68, 13);
            this.ManualPasswordLabel.TabIndex = 8;
            this.ManualPasswordLabel.Text = "Wachtwoord";
            // 
            // ManualPassword
            // 
            this.ManualPassword.Location = new System.Drawing.Point(281, 103);
            this.ManualPassword.Name = "ManualPassword";
            this.ManualPassword.Size = new System.Drawing.Size(100, 20);
            this.ManualPassword.TabIndex = 7;
            // 
            // ManualIPAddressLabel
            // 
            this.ManualIPAddressLabel.AutoSize = true;
            this.ManualIPAddressLabel.Location = new System.Drawing.Point(28, 84);
            this.ManualIPAddressLabel.Name = "ManualIPAddressLabel";
            this.ManualIPAddressLabel.Size = new System.Drawing.Size(46, 13);
            this.ManualIPAddressLabel.TabIndex = 6;
            this.ManualIPAddressLabel.Text = "IP adres";
            // 
            // ManualIPAddress
            // 
            this.ManualIPAddress.Location = new System.Drawing.Point(5, 103);
            this.ManualIPAddress.Name = "ManualIPAddress";
            this.ManualIPAddress.Size = new System.Drawing.Size(100, 20);
            this.ManualIPAddress.TabIndex = 5;
            // 
            // ManualUsernameLabel
            // 
            this.ManualUsernameLabel.AutoSize = true;
            this.ManualUsernameLabel.Location = new System.Drawing.Point(142, 84);
            this.ManualUsernameLabel.Name = "ManualUsernameLabel";
            this.ManualUsernameLabel.Size = new System.Drawing.Size(84, 13);
            this.ManualUsernameLabel.TabIndex = 4;
            this.ManualUsernameLabel.Text = "Gebruikersnaam";
            // 
            // ManualUsername
            // 
            this.ManualUsername.Location = new System.Drawing.Point(138, 103);
            this.ManualUsername.Name = "ManualUsername";
            this.ManualUsername.Size = new System.Drawing.Size(100, 20);
            this.ManualUsername.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Status,
            this.CompanyName,
            this.IpAddress,
            this.StatusInfo});
            this.dataGridView1.Location = new System.Drawing.Point(821, 9);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(431, 660);
            this.dataGridView1.TabIndex = 4;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Width = 20;
            // 
            // CompanyName
            // 
            this.CompanyName.HeaderText = "Bedrijfsnaam";
            this.CompanyName.Name = "CompanyName";
            // 
            // IpAddress
            // 
            this.IpAddress.HeaderText = "IP adres router";
            this.IpAddress.Name = "IpAddress";
            // 
            // StatusInfo
            // 
            this.StatusInfo.HeaderText = "Status informatie";
            this.StatusInfo.Name = "StatusInfo";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TitleLabel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label ManualLoginTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label ManualPasswordLabel;
        private System.Windows.Forms.TextBox ManualPassword;
        private System.Windows.Forms.Label ManualIPAddressLabel;
        private System.Windows.Forms.TextBox ManualIPAddress;
        private System.Windows.Forms.Label ManualUsernameLabel;
        private System.Windows.Forms.TextBox ManualUsername;
        private System.Windows.Forms.Button ManualConnect;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewImageColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusInfo;
    }
}

