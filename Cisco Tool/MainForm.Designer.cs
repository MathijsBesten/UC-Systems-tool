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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.mainErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mainMenu = new System.Windows.Forms.TabControl();
            this.MainMenuTab = new System.Windows.Forms.TabPage();
            this.maxOutputWindow = new System.Windows.Forms.PictureBox();
            this.ClearOutputFieldButton = new System.Windows.Forms.Button();
            this.outputLabel = new System.Windows.Forms.Label();
            this.OutputBox = new System.Windows.Forms.TextBox();
            this.allSelectedRouters = new System.Windows.Forms.ListBox();
            this.allSelectedRoutersLabel = new System.Windows.Forms.Label();
            this.CommandoGB = new System.Windows.Forms.Panel();
            this.ScriptButton = new System.Windows.Forms.Label();
            this.CommandoInfo2 = new System.Windows.Forms.Label();
            this.RunCommands = new System.Windows.Forms.Button();
            this.Command4 = new System.Windows.Forms.TextBox();
            this.Command3 = new System.Windows.Forms.TextBox();
            this.Command2 = new System.Windows.Forms.TextBox();
            this.Command1 = new System.Windows.Forms.TextBox();
            this.CommandoInfo = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.Username = new System.Windows.Forms.TextBox();
            this.ScriptLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.SearchGroupBox = new System.Windows.Forms.Panel();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchLabel = new System.Windows.Forms.Label();
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
            this.CMDTelnetPanel = new System.Windows.Forms.Panel();
            this.CMDTelnetLabel = new System.Windows.Forms.Label();
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MainContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.instellingenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLServerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutCiscoToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instellingenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainErrorProvider)).BeginInit();
            this.mainMenu.SuspendLayout();
            this.MainMenuTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxOutputWindow)).BeginInit();
            this.CommandoGB.SuspendLayout();
            this.SearchGroupBox.SuspendLayout();
            this.ManualLoginGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGridView)).BeginInit();
            this.RouterTab.SuspendLayout();
            this.CMDTelnetPanel.SuspendLayout();
            this.MainContextMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 20;
            // 
            // mainErrorProvider
            // 
            this.mainErrorProvider.ContainerControl = this;
            // 
            // mainMenu
            // 
            this.mainMenu.Controls.Add(this.MainMenuTab);
            this.mainMenu.Controls.Add(this.RouterTab);
            this.mainMenu.Location = new System.Drawing.Point(17, 41);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.SelectedIndex = 0;
            this.mainMenu.Size = new System.Drawing.Size(1241, 643);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.SelectedIndexChanged += new System.EventHandler(this.MainTabControl_SelectedIndexChanged);
            // 
            // MainMenuTab
            // 
            this.MainMenuTab.BackColor = System.Drawing.Color.White;
            this.MainMenuTab.Controls.Add(this.maxOutputWindow);
            this.MainMenuTab.Controls.Add(this.ClearOutputFieldButton);
            this.MainMenuTab.Controls.Add(this.outputLabel);
            this.MainMenuTab.Controls.Add(this.OutputBox);
            this.MainMenuTab.Controls.Add(this.allSelectedRouters);
            this.MainMenuTab.Controls.Add(this.allSelectedRoutersLabel);
            this.MainMenuTab.Controls.Add(this.CommandoGB);
            this.MainMenuTab.Controls.Add(this.SearchGroupBox);
            this.MainMenuTab.Controls.Add(this.ManualLoginGroupBox);
            this.MainMenuTab.Controls.Add(this.MainDataGridView);
            this.MainMenuTab.Location = new System.Drawing.Point(4, 22);
            this.MainMenuTab.Name = "MainMenuTab";
            this.MainMenuTab.Padding = new System.Windows.Forms.Padding(3);
            this.MainMenuTab.Size = new System.Drawing.Size(1233, 617);
            this.MainMenuTab.TabIndex = 0;
            this.MainMenuTab.Text = "Home";
            // 
            // maxOutputWindow
            // 
            this.maxOutputWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maxOutputWindow.Image = global::Cisco_Tool.Properties.Resources.perspective;
            this.maxOutputWindow.Location = new System.Drawing.Point(483, 565);
            this.maxOutputWindow.Name = "maxOutputWindow";
            this.maxOutputWindow.Size = new System.Drawing.Size(34, 34);
            this.maxOutputWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.maxOutputWindow.TabIndex = 25;
            this.maxOutputWindow.TabStop = false;
            this.maxOutputWindow.Click += new System.EventHandler(this.maxOutputWindow_Click);
            this.maxOutputWindow.MouseLeave += new System.EventHandler(this.maxOutputWindow_MouseLeave);
            this.maxOutputWindow.MouseHover += new System.EventHandler(this.maxOutputWindow_MouseHover);
            // 
            // ClearOutputFieldButton
            // 
            this.ClearOutputFieldButton.ForeColor = System.Drawing.Color.Black;
            this.ClearOutputFieldButton.Location = new System.Drawing.Point(343, 563);
            this.ClearOutputFieldButton.Name = "ClearOutputFieldButton";
            this.ClearOutputFieldButton.Size = new System.Drawing.Size(121, 36);
            this.ClearOutputFieldButton.TabIndex = 24;
            this.ClearOutputFieldButton.Text = "Clear output";
            this.ClearOutputFieldButton.UseVisualStyleBackColor = true;
            this.ClearOutputFieldButton.Click += new System.EventHandler(this.ClearOutputFieldButton_Click);
            // 
            // outputLabel
            // 
            this.outputLabel.BackColor = System.Drawing.Color.Transparent;
            this.outputLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputLabel.ForeColor = System.Drawing.Color.Black;
            this.outputLabel.Location = new System.Drawing.Point(346, 241);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(171, 24);
            this.outputLabel.TabIndex = 23;
            this.outputLabel.Text = "OUTPUT";
            this.outputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OutputBox
            // 
            this.OutputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputBox.Location = new System.Drawing.Point(343, 268);
            this.OutputBox.Multiline = true;
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutputBox.Size = new System.Drawing.Size(174, 287);
            this.OutputBox.TabIndex = 22;
            // 
            // allSelectedRouters
            // 
            this.allSelectedRouters.BackColor = System.Drawing.Color.White;
            this.allSelectedRouters.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.allSelectedRouters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.allSelectedRouters.ForeColor = System.Drawing.Color.Black;
            this.allSelectedRouters.FormattingEnabled = true;
            this.allSelectedRouters.ItemHeight = 16;
            this.allSelectedRouters.Location = new System.Drawing.Point(346, 46);
            this.allSelectedRouters.Name = "allSelectedRouters";
            this.allSelectedRouters.Size = new System.Drawing.Size(171, 192);
            this.allSelectedRouters.TabIndex = 20;
            this.allSelectedRouters.MouseDown += new System.Windows.Forms.MouseEventHandler(this.allSelectedRouters_MouseDown);
            this.allSelectedRouters.MouseLeave += new System.EventHandler(this.allSelectedRouters_MouseLeave);
            this.allSelectedRouters.MouseHover += new System.EventHandler(this.allSelectedRouters_MouseHover);
            // 
            // allSelectedRoutersLabel
            // 
            this.allSelectedRoutersLabel.BackColor = System.Drawing.Color.Transparent;
            this.allSelectedRoutersLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allSelectedRoutersLabel.ForeColor = System.Drawing.Color.Black;
            this.allSelectedRoutersLabel.Location = new System.Drawing.Point(343, 6);
            this.allSelectedRoutersLabel.Name = "allSelectedRoutersLabel";
            this.allSelectedRoutersLabel.Size = new System.Drawing.Size(171, 37);
            this.allSelectedRoutersLabel.TabIndex = 21;
            this.allSelectedRoutersLabel.Text = "Alle geselecteerde routers";
            this.allSelectedRoutersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CommandoGB
            // 
            this.CommandoGB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CommandoGB.Controls.Add(this.ScriptButton);
            this.CommandoGB.Controls.Add(this.CommandoInfo2);
            this.CommandoGB.Controls.Add(this.RunCommands);
            this.CommandoGB.Controls.Add(this.Command4);
            this.CommandoGB.Controls.Add(this.Command3);
            this.CommandoGB.Controls.Add(this.Command2);
            this.CommandoGB.Controls.Add(this.Command1);
            this.CommandoGB.Controls.Add(this.CommandoInfo);
            this.CommandoGB.Controls.Add(this.Password);
            this.CommandoGB.Controls.Add(this.Username);
            this.CommandoGB.Controls.Add(this.ScriptLabel);
            this.CommandoGB.Controls.Add(this.PasswordLabel);
            this.CommandoGB.Controls.Add(this.UsernameLabel);
            this.CommandoGB.Location = new System.Drawing.Point(10, 222);
            this.CommandoGB.Name = "CommandoGB";
            this.CommandoGB.Size = new System.Drawing.Size(330, 377);
            this.CommandoGB.TabIndex = 19;
            // 
            // ScriptButton
            // 
            this.ScriptButton.BackColor = System.Drawing.Color.Gainsboro;
            this.ScriptButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScriptButton.ForeColor = System.Drawing.Color.Black;
            this.ScriptButton.Location = new System.Drawing.Point(124, 125);
            this.ScriptButton.Name = "ScriptButton";
            this.ScriptButton.Size = new System.Drawing.Size(171, 18);
            this.ScriptButton.TabIndex = 73;
            this.ScriptButton.Text = "Kies script";
            this.ScriptButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ScriptButton.Click += new System.EventHandler(this.ScriptButton_Click);
            this.ScriptButton.MouseEnter += new System.EventHandler(this.ScriptButton_MouseEnter);
            this.ScriptButton.MouseLeave += new System.EventHandler(this.ScriptButton_MouseLeave);
            // 
            // CommandoInfo2
            // 
            this.CommandoInfo2.AutoSize = true;
            this.CommandoInfo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CommandoInfo2.Location = new System.Drawing.Point(20, 159);
            this.CommandoInfo2.Name = "CommandoInfo2";
            this.CommandoInfo2.Size = new System.Drawing.Size(245, 20);
            this.CommandoInfo2.TabIndex = 72;
            this.CommandoInfo2.Text = "Handmatig commando\'s invoeren";
            // 
            // RunCommands
            // 
            this.RunCommands.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.RunCommands.ForeColor = System.Drawing.Color.Black;
            this.RunCommands.Location = new System.Drawing.Point(24, 321);
            this.RunCommands.Name = "RunCommands";
            this.RunCommands.Size = new System.Drawing.Size(100, 25);
            this.RunCommands.TabIndex = 67;
            this.RunCommands.Text = "Uitvoeren";
            this.RunCommands.UseVisualStyleBackColor = true;
            this.RunCommands.Click += new System.EventHandler(this.RunCommands_Click);
            // 
            // Command4
            // 
            this.Command4.Location = new System.Drawing.Point(24, 270);
            this.Command4.Name = "Command4";
            this.Command4.Size = new System.Drawing.Size(271, 20);
            this.Command4.TabIndex = 66;
            // 
            // Command3
            // 
            this.Command3.Location = new System.Drawing.Point(24, 244);
            this.Command3.Name = "Command3";
            this.Command3.Size = new System.Drawing.Size(271, 20);
            this.Command3.TabIndex = 65;
            // 
            // Command2
            // 
            this.Command2.Location = new System.Drawing.Point(24, 218);
            this.Command2.Name = "Command2";
            this.Command2.Size = new System.Drawing.Size(271, 20);
            this.Command2.TabIndex = 64;
            // 
            // Command1
            // 
            this.Command1.Location = new System.Drawing.Point(24, 192);
            this.Command1.Name = "Command1";
            this.Command1.Size = new System.Drawing.Size(271, 20);
            this.Command1.TabIndex = 63;
            // 
            // CommandoInfo
            // 
            this.CommandoInfo.AutoSize = true;
            this.CommandoInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.CommandoInfo.Location = new System.Drawing.Point(19, 35);
            this.CommandoInfo.Name = "CommandoInfo";
            this.CommandoInfo.Size = new System.Drawing.Size(213, 25);
            this.CommandoInfo.TabIndex = 71;
            this.CommandoInfo.Text = "Commando\'s uitvoeren";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(124, 97);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(171, 20);
            this.Password.TabIndex = 61;
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(124, 71);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(171, 20);
            this.Username.TabIndex = 60;
            // 
            // ScriptLabel
            // 
            this.ScriptLabel.AutoSize = true;
            this.ScriptLabel.Location = new System.Drawing.Point(21, 125);
            this.ScriptLabel.Name = "ScriptLabel";
            this.ScriptLabel.Size = new System.Drawing.Size(34, 13);
            this.ScriptLabel.TabIndex = 70;
            this.ScriptLabel.Text = "Script";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(21, 100);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 69;
            this.PasswordLabel.Text = "Password";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(21, 74);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.UsernameLabel.TabIndex = 68;
            this.UsernameLabel.Text = "Username";
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
            this.SearchButton.TabIndex = 8;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(56, 7);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(216, 20);
            this.SearchBox.TabIndex = 7;
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
            this.ManualLoginGroupBox.Size = new System.Drawing.Size(334, 200);
            this.ManualLoginGroupBox.TabIndex = 13;
            // 
            // ManualLoginTitle
            // 
            this.ManualLoginTitle.AutoSize = true;
            this.ManualLoginTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ManualLoginTitle.Location = new System.Drawing.Point(16, 17);
            this.ManualLoginTitle.Name = "ManualLoginTitle";
            this.ManualLoginTitle.Size = new System.Drawing.Size(289, 25);
            this.ManualLoginTitle.TabIndex = 10;
            this.ManualLoginTitle.Text = "Handmatig verbinden met router";
            // 
            // ManualConnect
            // 
            this.ManualConnect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ManualConnect.ForeColor = System.Drawing.Color.Black;
            this.ManualConnect.Location = new System.Drawing.Point(21, 144);
            this.ManualConnect.Name = "ManualConnect";
            this.ManualConnect.Size = new System.Drawing.Size(100, 23);
            this.ManualConnect.TabIndex = 5;
            this.ManualConnect.Text = "Verbinden";
            this.ManualConnect.UseVisualStyleBackColor = true;
            this.ManualConnect.Click += new System.EventHandler(this.ManualConnect_Click);
            // 
            // ManualPasswordLabel
            // 
            this.ManualPasswordLabel.AutoSize = true;
            this.ManualPasswordLabel.Location = new System.Drawing.Point(41, 108);
            this.ManualPasswordLabel.Name = "ManualPasswordLabel";
            this.ManualPasswordLabel.Size = new System.Drawing.Size(68, 13);
            this.ManualPasswordLabel.TabIndex = 16;
            this.ManualPasswordLabel.Text = "Wachtwoord";
            // 
            // ManualPassword
            // 
            this.ManualPassword.Location = new System.Drawing.Point(134, 105);
            this.ManualPassword.Name = "ManualPassword";
            this.ManualPassword.PasswordChar = '*';
            this.ManualPassword.Size = new System.Drawing.Size(163, 20);
            this.ManualPassword.TabIndex = 4;
            // 
            // ManualIPAddressLabel
            // 
            this.ManualIPAddressLabel.AutoSize = true;
            this.ManualIPAddressLabel.Location = new System.Drawing.Point(41, 56);
            this.ManualIPAddressLabel.Name = "ManualIPAddressLabel";
            this.ManualIPAddressLabel.Size = new System.Drawing.Size(46, 13);
            this.ManualIPAddressLabel.TabIndex = 14;
            this.ManualIPAddressLabel.Text = "IP adres";
            // 
            // ManualIPAddress
            // 
            this.ManualIPAddress.Location = new System.Drawing.Point(134, 53);
            this.ManualIPAddress.Name = "ManualIPAddress";
            this.ManualIPAddress.Size = new System.Drawing.Size(163, 20);
            this.ManualIPAddress.TabIndex = 2;
            // 
            // ManualUsernameLabel
            // 
            this.ManualUsernameLabel.AutoSize = true;
            this.ManualUsernameLabel.Location = new System.Drawing.Point(41, 82);
            this.ManualUsernameLabel.Name = "ManualUsernameLabel";
            this.ManualUsernameLabel.Size = new System.Drawing.Size(84, 13);
            this.ManualUsernameLabel.TabIndex = 12;
            this.ManualUsernameLabel.Text = "Gebruikersnaam";
            // 
            // ManualUsername
            // 
            this.ManualUsername.Location = new System.Drawing.Point(134, 79);
            this.ManualUsername.Name = "ManualUsername";
            this.ManualUsername.Size = new System.Drawing.Size(163, 20);
            this.ManualUsername.TabIndex = 3;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MainDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.MainDataGridView.Location = new System.Drawing.Point(523, 6);
            this.MainDataGridView.Name = "MainDataGridView";
            this.MainDataGridView.RowHeadersVisible = false;
            this.MainDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MainDataGridView.Size = new System.Drawing.Size(696, 593);
            this.MainDataGridView.TabIndex = 6;
            this.MainDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainGridView_CellContentClick);
            this.MainDataGridView.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.MainDataGridView_ColumnWidthChanged);
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
            this.RouterTab.Controls.Add(this.button1);
            this.RouterTab.Controls.Add(this.CMDTelnetPanel);
            this.RouterTab.Controls.Add(this.MainTableLayoutPanel);
            this.RouterTab.Location = new System.Drawing.Point(4, 22);
            this.RouterTab.Name = "RouterTab";
            this.RouterTab.Padding = new System.Windows.Forms.Padding(3);
            this.RouterTab.Size = new System.Drawing.Size(1233, 617);
            this.RouterTab.TabIndex = 1;
            this.RouterTab.Text = "Router connection";
            this.RouterTab.UseVisualStyleBackColor = true;
            // 
            // CMDTelnetPanel
            // 
            this.CMDTelnetPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CMDTelnetPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CMDTelnetPanel.Controls.Add(this.CMDTelnetLabel);
            this.CMDTelnetPanel.Location = new System.Drawing.Point(940, 17);
            this.CMDTelnetPanel.Name = "CMDTelnetPanel";
            this.CMDTelnetPanel.Size = new System.Drawing.Size(264, 95);
            this.CMDTelnetPanel.TabIndex = 2;
            this.CMDTelnetPanel.Click += new System.EventHandler(this.CMDTelnetPanel_Click);
            this.CMDTelnetPanel.MouseLeave += new System.EventHandler(this.CMDTelnetPanel_MouseLeave);
            this.CMDTelnetPanel.MouseHover += new System.EventHandler(this.CMDTelnetPanel_MouseHover);
            // 
            // CMDTelnetLabel
            // 
            this.CMDTelnetLabel.AutoSize = true;
            this.CMDTelnetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDTelnetLabel.Location = new System.Drawing.Point(20, 30);
            this.CMDTelnetLabel.Name = "CMDTelnetLabel";
            this.CMDTelnetLabel.Size = new System.Drawing.Size(219, 31);
            this.CMDTelnetLabel.TabIndex = 0;
            this.CMDTelnetLabel.Text = "Handmatig telnet";
            this.CMDTelnetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 4;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(230, 154);
            this.MainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 2;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(1000, 460);
            this.MainTableLayoutPanel.TabIndex = 1;
            // 
            // MainContextMenuStrip
            // 
            this.MainContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.MainContextMenuStrip.Name = "MainContextMenuStrip";
            this.MainContextMenuStrip.Size = new System.Drawing.Size(118, 26);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.removeToolStripMenuItem_MouseDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instellingenToolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1283, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // instellingenToolStripMenuItem1
            // 
            this.instellingenToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sQLServerToolStripMenuItem1});
            this.instellingenToolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.instellingenToolStripMenuItem1.Name = "instellingenToolStripMenuItem1";
            this.instellingenToolStripMenuItem1.Size = new System.Drawing.Size(80, 20);
            this.instellingenToolStripMenuItem1.Text = "Instellingen";
            // 
            // sQLServerToolStripMenuItem1
            // 
            this.sQLServerToolStripMenuItem1.Name = "sQLServerToolStripMenuItem1";
            this.sQLServerToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.sQLServerToolStripMenuItem1.Text = "SQL server";
            this.sQLServerToolStripMenuItem1.Click += new System.EventHandler(this.sQLServerToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutCiscoToolToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutCiscoToolToolStripMenuItem
            // 
            this.aboutCiscoToolToolStripMenuItem.Name = "aboutCiscoToolToolStripMenuItem";
            this.aboutCiscoToolToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutCiscoToolToolStripMenuItem.Text = "About...";
            this.aboutCiscoToolToolStripMenuItem.Click += new System.EventHandler(this.aboutCiscoToolToolStripMenuItem_Click);
            // 
            // instellingenToolStripMenuItem
            // 
            this.instellingenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sQLServerToolStripMenuItem});
            this.instellingenToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.instellingenToolStripMenuItem.Name = "instellingenToolStripMenuItem";
            this.instellingenToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.instellingenToolStripMenuItem.Text = "Instellingen";
            // 
            // sQLServerToolStripMenuItem
            // 
            this.sQLServerToolStripMenuItem.Name = "sQLServerToolStripMenuItem";
            this.sQLServerToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.sQLServerToolStripMenuItem.Text = "SQL server";
            // 
            // jhToolStripMenuItem
            // 
            this.jhToolStripMenuItem.Name = "jhToolStripMenuItem";
            this.jhToolStripMenuItem.Size = new System.Drawing.Size(29, 20);
            this.jhToolStripMenuItem.Text = "jh";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(672, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1283, 696);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.mainMenu);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cisco Tool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainErrorProvider)).EndInit();
            this.mainMenu.ResumeLayout(false);
            this.MainMenuTab.ResumeLayout(false);
            this.MainMenuTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxOutputWindow)).EndInit();
            this.CommandoGB.ResumeLayout(false);
            this.CommandoGB.PerformLayout();
            this.SearchGroupBox.ResumeLayout(false);
            this.SearchGroupBox.PerformLayout();
            this.ManualLoginGroupBox.ResumeLayout(false);
            this.ManualLoginGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGridView)).EndInit();
            this.RouterTab.ResumeLayout(false);
            this.CMDTelnetPanel.ResumeLayout(false);
            this.CMDTelnetPanel.PerformLayout();
            this.MainContextMenuStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.ErrorProvider mainErrorProvider;
        private System.Windows.Forms.TabControl mainMenu;
        private System.Windows.Forms.TabPage RouterTab;
        private System.Windows.Forms.TabPage MainMenuTab;
        private System.Windows.Forms.Panel SearchGroupBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Panel ManualLoginGroupBox;
        private System.Windows.Forms.Label ManualLoginTitle;
        private System.Windows.Forms.Button ManualConnect;
        private System.Windows.Forms.Label ManualPasswordLabel;
        private System.Windows.Forms.Label ManualIPAddressLabel;
        private System.Windows.Forms.TextBox ManualIPAddress;
        private System.Windows.Forms.Label ManualUsernameLabel;
        private System.Windows.Forms.TextBox ManualUsername;
        private System.Windows.Forms.DataGridView MainDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn rowCheckbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn routerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.Panel CommandoGB;
        private System.Windows.Forms.Label CommandoInfo2;
        private System.Windows.Forms.Button RunCommands;
        private System.Windows.Forms.TextBox Command4;
        private System.Windows.Forms.TextBox Command3;
        private System.Windows.Forms.TextBox Command2;
        private System.Windows.Forms.TextBox Command1;
        private System.Windows.Forms.Label CommandoInfo;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.Label ScriptLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.ListBox allSelectedRouters;
        private System.Windows.Forms.Label allSelectedRoutersLabel;
        private System.Windows.Forms.TextBox OutputBox;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.ContextMenuStrip MainContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox ManualPassword;
        private System.Windows.Forms.Label ScriptButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem instellingenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLServerToolStripMenuItem;
        private System.Windows.Forms.Button ClearOutputFieldButton;
        private System.Windows.Forms.ToolStripMenuItem jhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instellingenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sQLServerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutCiscoToolToolStripMenuItem;
        private System.Windows.Forms.PictureBox maxOutputWindow;
        private System.Windows.Forms.Panel CMDTelnetPanel;
        private System.Windows.Forms.Label CMDTelnetLabel;
        public System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
    }
}

