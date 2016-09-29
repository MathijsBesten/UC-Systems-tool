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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.mainErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.MainMenuTab = new System.Windows.Forms.TabPage();
            this.allSelectedRoutersLabel = new System.Windows.Forms.Label();
            this.allSelectedRouters = new System.Windows.Forms.ListBox();
            this.SearchGroupBox = new System.Windows.Forms.Panel();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.CommandoGB = new System.Windows.Forms.Panel();
            this.CommandoInfo2 = new System.Windows.Forms.Label();
            this.RunCommands = new System.Windows.Forms.Button();
            this.Command7 = new System.Windows.Forms.TextBox();
            this.Command6 = new System.Windows.Forms.TextBox();
            this.Command5 = new System.Windows.Forms.TextBox();
            this.Command1 = new System.Windows.Forms.TextBox();
            this.CommandoInfo = new System.Windows.Forms.Label();
            this.ScriptButton = new System.Windows.Forms.Button();
            this.Password = new System.Windows.Forms.TextBox();
            this.Username = new System.Windows.Forms.TextBox();
            this.ScriptLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.ManualLoginGroupBox = new System.Windows.Forms.Panel();
            this.ManualLoginTitle = new System.Windows.Forms.Label();
            this.ManualConnect = new System.Windows.Forms.Button();
            this.ManualPasswordLabel = new System.Windows.Forms.Label();
            this.ManualPassword = new System.Windows.Forms.TextBox();
            this.ManualIPAddressLabel = new System.Windows.Forms.Label();
            this.ManualIPAddress = new System.Windows.Forms.TextBox();
            this.ManualUsernameLabel = new System.Windows.Forms.Label();
            this.ManualUsername = new System.Windows.Forms.TextBox();
            this.MainDataGridView = new System.Windows.Forms.DataGridView();
            this.rowCheckbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.routerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RouterTab = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.mainErrorProvider)).BeginInit();
            this.MainTabControl.SuspendLayout();
            this.MainMenuTab.SuspendLayout();
            this.SearchGroupBox.SuspendLayout();
            this.CommandoGB.SuspendLayout();
            this.ManualLoginGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Cisco_Tool.Properties.Resources.warningIcon;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 20;
            // 
            // mainErrorProvider
            // 
            this.mainErrorProvider.ContainerControl = this;
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.MainMenuTab);
            this.MainTabControl.Controls.Add(this.RouterTab);
            this.MainTabControl.Location = new System.Drawing.Point(17, 12);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(1235, 657);
            this.MainTabControl.TabIndex = 1;
            // 
            // MainMenuTab
            // 
            this.MainMenuTab.Controls.Add(this.allSelectedRouters);
            this.MainMenuTab.Controls.Add(this.allSelectedRoutersLabel);
            this.MainMenuTab.Controls.Add(this.SearchGroupBox);
            this.MainMenuTab.Controls.Add(this.CommandoGB);
            this.MainMenuTab.Controls.Add(this.ManualLoginGroupBox);
            this.MainMenuTab.Controls.Add(this.MainDataGridView);
            this.MainMenuTab.Location = new System.Drawing.Point(4, 22);
            this.MainMenuTab.Name = "MainMenuTab";
            this.MainMenuTab.Padding = new System.Windows.Forms.Padding(3);
            this.MainMenuTab.Size = new System.Drawing.Size(1227, 631);
            this.MainMenuTab.TabIndex = 0;
            this.MainMenuTab.Text = "Home";
            this.MainMenuTab.UseVisualStyleBackColor = true;
            // 
            // allSelectedRoutersLabel
            // 
            this.allSelectedRoutersLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allSelectedRoutersLabel.ForeColor = System.Drawing.Color.Black;
            this.allSelectedRoutersLabel.Location = new System.Drawing.Point(328, 160);
            this.allSelectedRoutersLabel.Name = "allSelectedRoutersLabel";
            this.allSelectedRoutersLabel.Size = new System.Drawing.Size(189, 36);
            this.allSelectedRoutersLabel.TabIndex = 17;
            this.allSelectedRoutersLabel.Text = "Alle geselecteerde routers";
            this.allSelectedRoutersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.allSelectedRoutersLabel.MouseHover += new System.EventHandler(this.allSelectedRoutersLabel_MouseHover);
            // 
            // allSelectedRouters
            // 
            this.allSelectedRouters.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.allSelectedRouters.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.allSelectedRouters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.allSelectedRouters.ForeColor = System.Drawing.Color.Black;
            this.allSelectedRouters.FormattingEnabled = true;
            this.allSelectedRouters.ItemHeight = 16;
            this.allSelectedRouters.Location = new System.Drawing.Point(328, 199);
            this.allSelectedRouters.Name = "allSelectedRouters";
            this.allSelectedRouters.Size = new System.Drawing.Size(189, 336);
            this.allSelectedRouters.TabIndex = 16;
            this.allSelectedRouters.MouseLeave += new System.EventHandler(this.allSelectedRouters_MouseLeave);
            this.allSelectedRouters.MouseHover += new System.EventHandler(this.allSelectedRoutersLabel_MouseHover);
            // 
            // SearchGroupBox
            // 
            this.SearchGroupBox.BackColor = System.Drawing.Color.White;
            this.SearchGroupBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SearchGroupBox.Controls.Add(this.SearchButton);
            this.SearchGroupBox.Controls.Add(this.SearchBox);
            this.SearchGroupBox.Controls.Add(this.SearchLabel);
            this.SearchGroupBox.ForeColor = System.Drawing.Color.White;
            this.SearchGroupBox.Location = new System.Drawing.Point(878, 568);
            this.SearchGroupBox.Name = "SearchGroupBox";
            this.SearchGroupBox.Size = new System.Drawing.Size(341, 31);
            this.SearchGroupBox.TabIndex = 15;
            // 
            // SearchButton
            // 
            this.SearchButton.ForeColor = System.Drawing.Color.Black;
            this.SearchButton.Location = new System.Drawing.Point(278, 4);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(56, 23);
            this.SearchButton.TabIndex = 11;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(56, 7);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(216, 20);
            this.SearchBox.TabIndex = 10;
            this.SearchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkEnterKeyPressed);
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.ForeColor = System.Drawing.Color.Black;
            this.SearchLabel.Location = new System.Drawing.Point(6, 9);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(44, 13);
            this.SearchLabel.TabIndex = 9;
            this.SearchLabel.Text = "Zoeken";
            // 
            // CommandoGB
            // 
            this.CommandoGB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CommandoGB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CommandoGB.Controls.Add(this.CommandoInfo2);
            this.CommandoGB.Controls.Add(this.RunCommands);
            this.CommandoGB.Controls.Add(this.Command7);
            this.CommandoGB.Controls.Add(this.Command6);
            this.CommandoGB.Controls.Add(this.Command5);
            this.CommandoGB.Controls.Add(this.Command1);
            this.CommandoGB.Controls.Add(this.CommandoInfo);
            this.CommandoGB.Controls.Add(this.ScriptButton);
            this.CommandoGB.Controls.Add(this.Password);
            this.CommandoGB.Controls.Add(this.Username);
            this.CommandoGB.Controls.Add(this.ScriptLabel);
            this.CommandoGB.Controls.Add(this.PasswordLabel);
            this.CommandoGB.Controls.Add(this.UsernameLabel);
            this.CommandoGB.Location = new System.Drawing.Point(3, 160);
            this.CommandoGB.Name = "CommandoGB";
            this.CommandoGB.Size = new System.Drawing.Size(319, 394);
            this.CommandoGB.TabIndex = 14;
            // 
            // CommandoInfo2
            // 
            this.CommandoInfo2.AutoSize = true;
            this.CommandoInfo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CommandoInfo2.Location = new System.Drawing.Point(18, 133);
            this.CommandoInfo2.Name = "CommandoInfo2";
            this.CommandoInfo2.Size = new System.Drawing.Size(245, 20);
            this.CommandoInfo2.TabIndex = 46;
            this.CommandoInfo2.Text = "Handmatig commando\'s invoeren";
            // 
            // RunCommands
            // 
            this.RunCommands.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.RunCommands.ForeColor = System.Drawing.Color.Black;
            this.RunCommands.Location = new System.Drawing.Point(22, 304);
            this.RunCommands.Name = "RunCommands";
            this.RunCommands.Size = new System.Drawing.Size(100, 25);
            this.RunCommands.TabIndex = 30;
            this.RunCommands.Text = "Uitvoeren";
            this.RunCommands.UseVisualStyleBackColor = true;
            this.RunCommands.Click += new System.EventHandler(this.RunCommands_Click);
            // 
            // Command7
            // 
            this.Command7.Location = new System.Drawing.Point(22, 244);
            this.Command7.Name = "Command7";
            this.Command7.Size = new System.Drawing.Size(271, 20);
            this.Command7.TabIndex = 45;
            // 
            // Command6
            // 
            this.Command6.Location = new System.Drawing.Point(22, 218);
            this.Command6.Name = "Command6";
            this.Command6.Size = new System.Drawing.Size(271, 20);
            this.Command6.TabIndex = 44;
            // 
            // Command5
            // 
            this.Command5.Location = new System.Drawing.Point(22, 192);
            this.Command5.Name = "Command5";
            this.Command5.Size = new System.Drawing.Size(271, 20);
            this.Command5.TabIndex = 43;
            // 
            // Command1
            // 
            this.Command1.Location = new System.Drawing.Point(22, 166);
            this.Command1.Name = "Command1";
            this.Command1.Size = new System.Drawing.Size(271, 20);
            this.Command1.TabIndex = 39;
            // 
            // CommandoInfo
            // 
            this.CommandoInfo.AutoSize = true;
            this.CommandoInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.CommandoInfo.Location = new System.Drawing.Point(17, 9);
            this.CommandoInfo.Name = "CommandoInfo";
            this.CommandoInfo.Size = new System.Drawing.Size(213, 25);
            this.CommandoInfo.TabIndex = 31;
            this.CommandoInfo.Text = "Commando\'s uitvoeren";
            // 
            // ScriptButton
            // 
            this.ScriptButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ScriptButton.ForeColor = System.Drawing.Color.Black;
            this.ScriptButton.Location = new System.Drawing.Point(122, 97);
            this.ScriptButton.Name = "ScriptButton";
            this.ScriptButton.Size = new System.Drawing.Size(171, 23);
            this.ScriptButton.TabIndex = 29;
            this.ScriptButton.Text = "Kies script";
            this.ScriptButton.UseVisualStyleBackColor = true;
            this.ScriptButton.Click += new System.EventHandler(this.ScriptButton_Click);
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(122, 71);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(171, 20);
            this.Password.TabIndex = 28;
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(122, 45);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(171, 20);
            this.Username.TabIndex = 27;
            // 
            // ScriptLabel
            // 
            this.ScriptLabel.AutoSize = true;
            this.ScriptLabel.Location = new System.Drawing.Point(19, 103);
            this.ScriptLabel.Name = "ScriptLabel";
            this.ScriptLabel.Size = new System.Drawing.Size(34, 13);
            this.ScriptLabel.TabIndex = 26;
            this.ScriptLabel.Text = "Script";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(19, 74);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 25;
            this.PasswordLabel.Text = "Password";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(19, 48);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.UsernameLabel.TabIndex = 24;
            this.UsernameLabel.Text = "Username";
            // 
            // ManualLoginGroupBox
            // 
            this.ManualLoginGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ManualLoginGroupBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ManualLoginGroupBox.Controls.Add(this.ManualLoginTitle);
            this.ManualLoginGroupBox.Controls.Add(this.ManualConnect);
            this.ManualLoginGroupBox.Controls.Add(this.ManualPasswordLabel);
            this.ManualLoginGroupBox.Controls.Add(this.ManualPassword);
            this.ManualLoginGroupBox.Controls.Add(this.ManualIPAddressLabel);
            this.ManualLoginGroupBox.Controls.Add(this.ManualIPAddress);
            this.ManualLoginGroupBox.Controls.Add(this.ManualUsernameLabel);
            this.ManualLoginGroupBox.Controls.Add(this.ManualUsername);
            this.ManualLoginGroupBox.Location = new System.Drawing.Point(6, 6);
            this.ManualLoginGroupBox.Name = "ManualLoginGroupBox";
            this.ManualLoginGroupBox.Size = new System.Drawing.Size(511, 148);
            this.ManualLoginGroupBox.TabIndex = 13;
            // 
            // ManualLoginTitle
            // 
            this.ManualLoginTitle.AutoSize = true;
            this.ManualLoginTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ManualLoginTitle.Location = new System.Drawing.Point(17, 11);
            this.ManualLoginTitle.Name = "ManualLoginTitle";
            this.ManualLoginTitle.Size = new System.Drawing.Size(289, 25);
            this.ManualLoginTitle.TabIndex = 10;
            this.ManualLoginTitle.Text = "Handmatig verbinden met router";
            // 
            // ManualConnect
            // 
            this.ManualConnect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ManualConnect.ForeColor = System.Drawing.Color.Black;
            this.ManualConnect.Location = new System.Drawing.Point(21, 116);
            this.ManualConnect.Name = "ManualConnect";
            this.ManualConnect.Size = new System.Drawing.Size(100, 23);
            this.ManualConnect.TabIndex = 17;
            this.ManualConnect.Text = "Verbinden";
            this.ManualConnect.UseVisualStyleBackColor = true;
            this.ManualConnect.Click += new System.EventHandler(this.ManualConnect_Click);
            // 
            // ManualPasswordLabel
            // 
            this.ManualPasswordLabel.AutoSize = true;
            this.ManualPasswordLabel.Location = new System.Drawing.Point(281, 56);
            this.ManualPasswordLabel.Name = "ManualPasswordLabel";
            this.ManualPasswordLabel.Size = new System.Drawing.Size(68, 13);
            this.ManualPasswordLabel.TabIndex = 16;
            this.ManualPasswordLabel.Text = "Wachtwoord";
            // 
            // ManualPassword
            // 
            this.ManualPassword.Location = new System.Drawing.Point(284, 72);
            this.ManualPassword.Name = "ManualPassword";
            this.ManualPassword.Size = new System.Drawing.Size(100, 20);
            this.ManualPassword.TabIndex = 15;
            // 
            // ManualIPAddressLabel
            // 
            this.ManualIPAddressLabel.AutoSize = true;
            this.ManualIPAddressLabel.Location = new System.Drawing.Point(18, 53);
            this.ManualIPAddressLabel.Name = "ManualIPAddressLabel";
            this.ManualIPAddressLabel.Size = new System.Drawing.Size(46, 13);
            this.ManualIPAddressLabel.TabIndex = 14;
            this.ManualIPAddressLabel.Text = "IP adres";
            // 
            // ManualIPAddress
            // 
            this.ManualIPAddress.Location = new System.Drawing.Point(21, 72);
            this.ManualIPAddress.Name = "ManualIPAddress";
            this.ManualIPAddress.Size = new System.Drawing.Size(100, 20);
            this.ManualIPAddress.TabIndex = 13;
            // 
            // ManualUsernameLabel
            // 
            this.ManualUsernameLabel.AutoSize = true;
            this.ManualUsernameLabel.Location = new System.Drawing.Point(146, 56);
            this.ManualUsernameLabel.Name = "ManualUsernameLabel";
            this.ManualUsernameLabel.Size = new System.Drawing.Size(84, 13);
            this.ManualUsernameLabel.TabIndex = 12;
            this.ManualUsernameLabel.Text = "Gebruikersnaam";
            // 
            // ManualUsername
            // 
            this.ManualUsername.Location = new System.Drawing.Point(149, 72);
            this.ManualUsername.Name = "ManualUsername";
            this.ManualUsername.Size = new System.Drawing.Size(100, 20);
            this.ManualUsername.TabIndex = 11;
            // 
            // MainDataGridView
            // 
            this.MainDataGridView.AllowUserToAddRows = false;
            this.MainDataGridView.AllowUserToDeleteRows = false;
            this.MainDataGridView.AllowUserToOrderColumns = true;
            this.MainDataGridView.AllowUserToResizeRows = false;
            this.MainDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MainDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.MainDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowCheckbox,
            this.routerName,
            this.IpAddress,
            this.ID});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MainDataGridView.DefaultCellStyle = dataGridViewCellStyle10;
            this.MainDataGridView.Location = new System.Drawing.Point(523, 6);
            this.MainDataGridView.Name = "MainDataGridView";
            this.MainDataGridView.RowHeadersVisible = false;
            this.MainDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MainDataGridView.Size = new System.Drawing.Size(696, 593);
            this.MainDataGridView.TabIndex = 10;
            this.MainDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainGridView_CellContentClick);
            // 
            // rowCheckbox
            // 
            this.rowCheckbox.HeaderText = "";
            this.rowCheckbox.Name = "rowCheckbox";
            this.rowCheckbox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.rowCheckbox.Width = 32;
            // 
            // routerName
            // 
            this.routerName.HeaderText = "Naam";
            this.routerName.Name = "routerName";
            this.routerName.Width = 250;
            // 
            // IpAddress
            // 
            this.IpAddress.HeaderText = "IP adres";
            this.IpAddress.Name = "IpAddress";
            this.IpAddress.Width = 250;
            // 
            // ID
            // 
            this.ID.HeaderText = "mainID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 5;
            // 
            // RouterTab
            // 
            this.RouterTab.Location = new System.Drawing.Point(4, 22);
            this.RouterTab.Name = "RouterTab";
            this.RouterTab.Padding = new System.Windows.Forms.Padding(3);
            this.RouterTab.Size = new System.Drawing.Size(1227, 631);
            this.RouterTab.TabIndex = 1;
            this.RouterTab.Text = "Router connection";
            this.RouterTab.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.MainTabControl);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MainForm";
            this.Text = "Cisco Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainErrorProvider)).EndInit();
            this.MainTabControl.ResumeLayout(false);
            this.MainMenuTab.ResumeLayout(false);
            this.SearchGroupBox.ResumeLayout(false);
            this.SearchGroupBox.PerformLayout();
            this.CommandoGB.ResumeLayout(false);
            this.CommandoGB.PerformLayout();
            this.ManualLoginGroupBox.ResumeLayout(false);
            this.ManualLoginGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.ErrorProvider mainErrorProvider;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage RouterTab;
        private System.Windows.Forms.TabPage MainMenuTab;
        private System.Windows.Forms.ListBox allSelectedRouters;
        private System.Windows.Forms.Panel SearchGroupBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Panel CommandoGB;
        private System.Windows.Forms.Label CommandoInfo2;
        private System.Windows.Forms.Button RunCommands;
        private System.Windows.Forms.TextBox Command7;
        private System.Windows.Forms.TextBox Command6;
        private System.Windows.Forms.TextBox Command5;
        private System.Windows.Forms.TextBox Command1;
        private System.Windows.Forms.Label CommandoInfo;
        private System.Windows.Forms.Button ScriptButton;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.Label ScriptLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Panel ManualLoginGroupBox;
        private System.Windows.Forms.Label ManualLoginTitle;
        private System.Windows.Forms.Button ManualConnect;
        private System.Windows.Forms.Label ManualPasswordLabel;
        private System.Windows.Forms.TextBox ManualPassword;
        private System.Windows.Forms.Label ManualIPAddressLabel;
        private System.Windows.Forms.TextBox ManualIPAddress;
        private System.Windows.Forms.Label ManualUsernameLabel;
        private System.Windows.Forms.TextBox ManualUsername;
        private System.Windows.Forms.DataGridView MainDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn rowCheckbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn routerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.Label allSelectedRoutersLabel;
    }
}

