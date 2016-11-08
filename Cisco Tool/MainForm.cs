using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Cisco_Tool.Functions.SQL;
using Cisco_Tool.Values;
using static Cisco_Tool.Values.PrivateValues;
using System.Data.SqlClient;
using Cisco_Tool.Functions.Network;
using Cisco_Tool.Widgets.Views;
using Cisco_Tool.Widgets.Functions;
using Cisco_Tool.Widgets.Templates;
using Cisco_Tool.Functions.Stream;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;
using Cisco_Tool.Views;
using System.Text.RegularExpressions;
using System.Threading;
using Cisco_Tool.Functions.Telnet;
using static Cisco_Tool.Widgets.Classes;
using Cisco_Tool.Widgets;

namespace Cisco_Tool
{
    public partial class MainForm : Form
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region properties
        private static List<router> allRouters;
        private string selectedScriptPath = "";
        public List<string> allCommands = new List<string>();
        public List<string> selectedIPAddresses = new List<string>();
        public static List<Control> readyPanels = new List<Control>();
        static List<widgetResult> allOutputs = new List<widgetResult>();
        public int widgetTag = 0;
        public bool loginDetailsChanged = false;
        public static List<telnetDetails> readyTelnetOutputs = new List<telnetDetails>();
        public static int totalAsyncTelnetExcutions = 0;

        private string SQLIP = Properties.Settings.Default.CiscoToolServerIP;
        private string SQLDatabase = Properties.Settings.Default.CiscoToolServerDatabase;
        private string SQLUsername = Properties.Settings.Default.CiscoToolServerUsername;
        private string SQLPassword = Properties.Settings.Default.CiscoToolServerPassword;
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (SQLIP == "" && SQLDatabase == "" && SQLUsername == "" && SQLPassword == "")
            {
                log.Info("No database details available - asking user to enter database details");
                var firstRunDialog = new FirstRunScreen();
                firstRunDialog.ShowDialog();
            }
            mainMenu.TabPages.Remove(RouterTab);
            try
            {
                SqlConnection connection = Connections.OwnDB();
                allRouters = Data.getDataFromMicrosoftSQL(connection, PrivateValues.OwnServerServerQuery);
                if (allRouters != null)
                {
                    foreach (var router in allRouters)
                    {
                        MainDataGridView.Rows.Add(false, router.routerAlias, router.routerAddress, "", router.routerMainDB); //  false is for checkbox is not checked
                    }
                    log.Info("Loaded all routers to the application");
                }
            }
            catch (Exception ex)
            {
                log.Error("Database details are wrong - could not load routers from routerlist");
                log.Error("error message - " + ex.Message);
                log.Error("Please try entering the correct details using the sql wizard from the menubar");
            }
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            log.Info("Closing application");
            Application.Exit();
        }
        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainMenu.SelectedIndex == 1) // if user switched to router tab
            {
                var widgets = JSON.readJSON(); // 7ms for reading a empty file
                if (loginDetailsChanged == true)
                {
                    log.Info("Loading all router information...");
                    routerIPText.Text = ManualIPAddress.Text;
                    try
                    {
                        List<telnetDetails> listToRun = new List<telnetDetails>();

                        telnetDetails PID = new telnetDetails();
                        PID.IPAddress = ManualIPAddress.Text;
                        PID.command = "show inventory";
                        PID.username = ManualUsername.Text;
                        PID.password = ManualPassword.Text;
                        PID.useLongProcessTime = false ; // needs to be async
                        listToRun.Add(PID);

                        telnetDetails showRun = new telnetDetails();
                        showRun.IPAddress = ManualIPAddress.Text;
                        showRun.command = "show run";
                        showRun.username = ManualUsername.Text;
                        showRun.password = ManualPassword.Text;
                        showRun.useLongProcessTime = true; // needs to be async
                        listToRun.Add(showRun);

                        for (int i = 0; i < 2; i++)
                        {
                            BackgroundWorker bw = new BackgroundWorker();
                            bw.DoWork += asyncTelnet_Work;
                            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(asyncTelnet_runCompleted);
                            bw.RunWorkerAsync(listToRun[i]);
                        }




                        string PID = TelnetConnection.findPID(result);
                        routerAliasText.Text = PID;
                    }
                    catch (Exception ex)
                    {
                        log.Info("Could not connect to server - username and/or password are wrong");
                        log.Info("Message - " + ex.Message);
                        MessageBox.Show("Kan niet verbinden met router - probeer het opnieuw");
                    }
                    log.Info("Loading all widgets / if available");
                    if (widgets == null || widgets.Count == 0) 
                    {
                        log.Info("No widgets were found - adding plus sign");
                        PictureBox addButton = new PictureBox();
                        addButton.Size = new Size(100, 100);
                        addButton.BackColor = Color.Transparent;
                        addButton.Image = Properties.Resources.add_1;
                        addButton.SizeMode = PictureBoxSizeMode.Zoom;
                        addButton.Anchor = AnchorStyles.None;
                        addButton.Click += new EventHandler(addButtonClick);
                        MainTableLayoutPanel.Controls.Add(addButton);
                    }
                    else if (MainTableLayoutPanel.Controls.Count != widgets.Count + 1)
                    {
                        MainTableLayoutPanel.Controls.Clear();
                        taskGetWidgets(ManualIPAddress.Text, ManualUsername.Text, ManualPassword.Text); // main get function
                        readyPanels = readyPanels.OrderBy(o => o.Tag).ToList();
                        allOutputs = allOutputs.OrderBy(o => o.widgetTag).ToList();
                        for (int i = 0; i < allOutputs.Count; i++)
                        {
                            readyPanels[i].Controls[1].Controls[1].Text = allOutputs[i].widgetOutput;
                        }

                    }
                    loginDetailsChanged = false; // this will prevent reloading if user switches tabs
                }
            }
        }

        private void asyncTelnet_runCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (totalAsyncTelnetExcutions == readyTelnetOutputs.Count)
            {
                routerAliasText.Text = 
                runningConfigOutputField.Text = 
            }
        }

        private void asyncTelnet_Work(object sender, DoWorkEventArgs e)
        {
            telnetDetails details = (telnetDetails)e.Argument;
            string output = TelnetConnection.telnetClientTCP(details.IPAddress, details.command, details.username, details.password, details.useLongProcessTime);
            if (output == null)
            {
                log.Info(@"Commando '" + details.command + @"'  is not a valid command");
            }
            details.output = output;
            readyTelnetOutputs.Add(details);
        }

        public void fillTableWithWidgets()
        {
            log.Info("loading widgets");
            foreach (var panel in readyPanels)
            {
                MainTableLayoutPanel.Controls.Add(panel);
            }
            //readyPanels.Clear();
            //log.Info("Adding plus sign");
            //PictureBox addButton = new PictureBox();
            //addButton.Size = new Size(100, 100);
            //addButton.BackColor = Color.Transparent;
            //addButton.Image = Properties.Resources.add_1;
            //addButton.SizeMode = PictureBoxSizeMode.Zoom;
            //addButton.Anchor = AnchorStyles.None;
            //addButton.Click += new EventHandler(addButtonClick);
            //MainTableLayoutPanel.Controls.Add(addButton);

            log.Info("widgets and plus sign are added to GUI");
        }

        #region widget layout
        // when user checks a router
        private void MainGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MainDataGridView.CurrentCell.ColumnIndex == 2)
            {

            }
            else if (MainDataGridView.CurrentCell is DataGridViewCheckBoxCell)
            {
                string nameOfRouter = MainDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                string IPAddress = MainDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (allSelectedRouters.Items.Contains(nameOfRouter))
                {
                    allSelectedRouters.Items.Remove(nameOfRouter);
                }
                else
                {
                    allSelectedRouters.Items.Add(nameOfRouter);
                }
                if (selectedIPAddresses.Contains(IPAddress))
                {
                    selectedIPAddresses.Remove(IPAddress);
                }
                else
                {
                    selectedIPAddresses.Add(IPAddress);
                }
            }
        }

        private void MainDataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            SearchGroupBox.Refresh();
        }

        void addButtonClick(object sender, EventArgs e)
        {
            var widgetCreator = new WidgetCreator();
            var result = widgetCreator.ShowDialog();
            if (result == DialogResult.OK)
            {
                log.Info("user made a new widget");
                log.Info("clearing and refilling MainTableLayoutPanel");
                MainTableLayoutPanel.Controls.Clear();
                readyPanels.Clear();
                taskGetWidgets(ManualIPAddress.Text, ManualUsername.Text, ManualPassword.Text);
                fillTableWithWidgets();
            }
        }
        #endregion

        #region homescreen
        private void ManualConnect_Click(object sender, EventArgs e)
        {
            if (ManualIPAddress.Text != "")
                mainErrorProvider.SetError(ManualIPAddress, "");
            else
                mainErrorProvider.SetError(ManualIPAddress, "ip adres verplicht");
            if (ManualUsername.Text != "")
                mainErrorProvider.SetError(ManualUsername, "");
            else
                mainErrorProvider.SetError(ManualUsername, "Gebruikersnaam verplicht");
            if (ManualPassword.Text != "")
                mainErrorProvider.SetError(ManualPassword, "");
            else
                mainErrorProvider.SetError(ManualPassword, "Wachtwoord verplicht");


            if (ManualIPAddress.Text != "" && ManualUsername.Text != "" && ManualPassword.Text != "")
            {
                bool IPisValid = validation.validateIPv4(ManualIPAddress.Text);
                if (!IPisValid)
                {
                    mainErrorProvider.SetError(ManualIPAddress, "Geen geldig ip adres");
                }
                else
                {
                    if (mainMenu.TabCount == 1)
                    {
                        mainMenu.TabPages.Add(RouterTab);
                        RouterTab.Text = ManualIPAddress.Text;
                        log.Info("Router tab added to mainmenu");
                    }
                    else
                    {
                        mainMenu.TabPages.Remove(RouterTab);
                        mainMenu.TabPages.Add(RouterTab);
                        RouterTab.Text = ManualIPAddress.Text;
                        log.Info("Router tab refresh in the mainmenu");
                    }
                    loginDetailsChanged = true;
                }
            }
        }
        private void RunCommands_Click(object sender, EventArgs e)
        {
            if (Username.Text == "")
            {
                mainErrorProvider.SetError(Username, "gebruikersnaam vereist");
            }
            else
            {
                mainErrorProvider.SetError(Username, "");
            }
            if (Password.Text == "")
            {
                mainErrorProvider.SetError(Password, "wachtwoord vereist");
            }
            else
            {
                mainErrorProvider.SetError(Password, "");
            }
            if (Command1.Text == "")
            {
                if (selectedScriptPath != "") // user selected a script
                {
                    mainErrorProvider.SetError(Command1, "");
                }
                else
                {
                    mainErrorProvider.SetError(Command1, "commando of script vereist");
                }
            }
            else
            {
                mainErrorProvider.SetError(Command1, "");
            }
            if (Username.Text != "" && Password.Text != "" && (Command1.Text != "" || allCommands.Count != 0))
            {
                if (selectedIPAddresses.Count == 0)
                {
                    MessageBox.Show("geen routers geselecteerd, vink de router(s) aan die je wilt aansturen");
                }
                else
                {
                    log.Info("start the executing commands function");
                    List<string> commands = new List<string>();
                    foreach (var item in allCommands)
                    {
                        commands.Add(item);
                    }
                    if (Command1.Text != "") { commands.Add(Command1.Text); }
                    if (Command2.Text != "") { commands.Add(Command2.Text); }
                    if (Command3.Text != "") { commands.Add(Command3.Text); }
                    if (Command4.Text != "") { commands.Add(Command4.Text); }

                    var confirmDialog = new Views.ConfirmationScreen(allSelectedRouters.Items.Cast<string>().ToList(), commands);
                    confirmDialog.ShowDialog();
                    if (confirmDialog.DialogResult == DialogResult.OK)
                    {
                        int passwordFailedThreeTimes = 0;
                        string stringIfPasswordIsWrong = "Password: "; // this will be always the last part of response if the username/password is wrong
                        string username = Username.Text;
                        string password = Password.Text;

                        foreach (var IPAddress in selectedIPAddresses)
                        {
                            if (passwordFailedThreeTimes < 3) // to prevent more runs when username or password is wrong
                            {
#pragma warning disable CS0219 // Variable is assigned but its value is never used
                                bool passwordIsStillWrong = false;
#pragma warning restore CS0219 // Variable is assigned but its value is never used
                                string ipWherePasswordIsWrong = "";
                                int indexOfCommand = 0;
                                string localIP = "172.28.81.180";


                                foreach (var command in commands)
                                {
                                    if (localIP != ipWherePasswordIsWrong)
                                    {
                                        Console.WriteLine(localIP);
                                        OutputBox.Text += Environment.NewLine;
                                        OutputBox.Text += localIP;
                                        OutputBox.Text += Environment.NewLine;
                                        OutputBox.Text += Environment.NewLine;
                                        string output;
                                        if (command.ToLower() == "show running-config" || command.ToLower() == "write")
                                        {
                                            output = TelnetConnection.telnetClientTCP(localIP, command, username, password, true);
                                        }
                                        else
                                        {
                                            output = TelnetConnection.telnetClientTCP(localIP, command, username, password, false);
                                        }
                                        indexOfCommand++;
                                        var splittedOutput = Regex.Split(output, stringIfPasswordIsWrong);
                                        if (splittedOutput.Count() == 2) // sometimes the network function will retrun a few characters and will not be split
                                        {
                                            if (splittedOutput[1] == "")
                                            {
                                                if (selectedIPAddresses.Count < 3)
                                                {
                                                    ipWherePasswordIsWrong = localIP;
                                                    passwordFailedThreeTimes = 3;
                                                    OutputBox.Text += Environment.NewLine;
                                                    OutputBox.Text += "Gebruikersnaam en/of wachtwoord is waarschijnlijk fout";
                                                    OutputBox.Text += Environment.NewLine;
                                                    log.Info("Username and or password is wrong");

                                                }
                                                else
                                                {
                                                    passwordFailedThreeTimes++;
                                                }
                                            }
                                            else
                                            {
                                                if (output.Contains(@"% Invalid input detected at '^' marker."))
                                                {
                                                    OutputBox.Text += @"'" + command + @"'" + " -  GEEN GELDIG COMMANDO";
                                                    OutputBox.Text += Environment.NewLine;
                                                    OutputBox.Text += "--------------";
                                                    OutputBox.Text += Environment.NewLine;
                                                    log.Info("command is not valid - command: " + command);
                                                }
                                                else
                                                {
                                                    OutputBox.Text += output;
                                                    OutputBox.Text += Environment.NewLine;
                                                    OutputBox.Text += "--------------";
                                                    OutputBox.Text += Environment.NewLine;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (selectedIPAddresses.Count < 3)
                                            {
                                                ipWherePasswordIsWrong = localIP;
                                                passwordFailedThreeTimes = 3;
                                                OutputBox.Text += Environment.NewLine;
                                                OutputBox.Text += "Problemen met het ophalen van router output";
                                                OutputBox.Text += Environment.NewLine;
                                                log.Info("response from router was too little");
                                                log.Info("response from router: " + splittedOutput[0]);
                                            }
                                            else
                                            {
                                                passwordFailedThreeTimes++;
                                            }
                                        }
                                        
                                    }
                                    else
                                    {
                                        // continues to fail
                                        string output;
                                        if (commands[indexOfCommand].ToLower() == "show running-config" || commands[indexOfCommand].ToLower() == "write")
                                        {
                                            output = TelnetConnection.telnetClientTCP(localIP, commands[indexOfCommand], username, password, true);
                                        }
                                        else
                                        {
                                            output = TelnetConnection.telnetClientTCP(localIP, commands[indexOfCommand], username, password, false);
                                        }
                                        var splittedOutput = Regex.Split(output, stringIfPasswordIsWrong);
                                        if (splittedOutput[1] == "")
                                        {
                                            passwordIsStillWrong = true;
                                            OutputBox.Text += Environment.NewLine;
                                            OutputBox.Text += "Gebruikersnaam en/of wachtwoord is waarschijnlijk fout";
                                            OutputBox.Text += Environment.NewLine;
                                            log.Info("Username and or password is wrong");
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                OutputBox.Text += Environment.NewLine;
                                OutputBox.Text += "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
                                OutputBox.Text += Environment.NewLine;
                                OutputBox.Text += Environment.NewLine;
                                OutputBox.Text += "Om meer problemen te voorkomen, is het uitvoeren van commando's gestopt";
                                OutputBox.Text += Environment.NewLine;
                                OutputBox.Text += Environment.NewLine;
                                OutputBox.Text += "De logingegevens zijn niet correct bevonden op één of meerdere geselecteerde routers";
                                OutputBox.Text += Environment.NewLine;
                                OutputBox.Text += Environment.NewLine;
                                OutputBox.Text += "Controleer de gebruikersnaam en wachtwoord en voer de commando's opnieuw uit";
                                OutputBox.Text += Environment.NewLine;
                                OutputBox.Text += Environment.NewLine;
                                OutputBox.Text += "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
                                OutputBox.Text += Environment.NewLine;
                                break;
                            }
                        }
                        // uncommand the following code to get output box in logfile


                        //log.Info("Output box");
                        //log.Info("----------");
                        //foreach (string line in OutputBox.Lines)
                        //{
                        //    log.Info(line);
                        //}
                        //log.Info("----------");
                    }
                    else
                    {
                        // user cancelled the operation
                        // Commands will not be run
                    }
                }
            }
        }
        #endregion

        #region selected routers list
        private void allSelectedRouters_MouseHover(object sender, EventArgs e)
        {
            if (allSelectedRouters.Items.Count >= 1)
            {
                List<string> listOfRouters = new List<string>();
                foreach (var item in allSelectedRouters.Items)
                {
                    listOfRouters.Add(item.ToString());
                }
                int maxwidth = Animations.Resizing.getLongestStringInPixels(listOfRouters);
                while (allSelectedRouters.Width < maxwidth)
                {
                    allSelectedRouters.Width++;
                }
            }
        }

        private void allSelectedRouters_MouseLeave(object sender, EventArgs e)
        {
            if (allSelectedRouters.Items.Count >= 1)
            {
                while (allSelectedRouters.Width != 171) // default = 171
                {
                    allSelectedRouters.Width--;
                }
            }
        }

        private void allSelectedRouters_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                allSelectedRouters.SelectedIndex = allSelectedRouters.IndexFromPoint(e.Location);
                if (allSelectedRouters.SelectedIndex != -1)
                {
                    MainContextMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private void removeToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            List<DataGridViewRow> data = new List<DataGridViewRow>();
            int index = allSelectedRouters.SelectedIndex;
            if (index != -1)
            {
                foreach (DataGridViewRow row in MainDataGridView.Rows)
                {
                    if (row.Cells[1].Value.ToString() == allSelectedRouters.Items[index].ToString())
                    {
                        int rowIndex = Int32.Parse(row.Index.ToString());
                        (row.Cells[0] as DataGridViewCheckBoxCell).Value = false;
                    }
                }
                MainDataGridView.Refresh();
                allSelectedRouters.Items.RemoveAt(index); // functions as jquery
                MainContextMenuStrip.Close();
            }
        }

        #endregion

        #region searchbox
        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (MainDataGridView.RowCount != 0)
            {
                filterRoutersInList();
            }
        }
        private void filterRoutersInList()
        {
            int count = 0;
            for (int i = 0; i < MainDataGridView.RowCount; i++)
            {
                MainDataGridView.Rows[i].Visible = true;

            }
            if (SearchBox.Text != "")
            {

                foreach (var router in allRouters)
                {
                    string routerAliasLowered = router.routerAlias.ToLower();
                    string searchBoxTextLowerer = SearchBox.Text.ToLower();
                    if (!routerAliasLowered.Contains(searchBoxTextLowerer))
                    {
                        MainDataGridView.Rows[count].Visible = false;
                    }
                    count++;
                }
            }
        }

        private void checkEnterKeyPressed(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (MainDataGridView.RowCount != 0)
                {
                    filterRoutersInList();
                    e.Handled = true;
                }

            }
        }
        #endregion

        #region scriptbutton
        private void ScriptButton_Click(object sender, EventArgs e)
        {
            if (ScriptButton.Text == "Verwijder script")
            {
                log.Info("Script has been released from application");
                allCommands.Clear(); //remove all commands from script
                selectedScriptPath = ""; // removes path for futher if statements
                ScriptButton.Text = "Kies script";
                ScriptButton.TextAlign = ContentAlignment.MiddleCenter;
                ScriptButton.BackColor = Color.Gainsboro;
                ScriptButton.ForeColor = Color.Black;
                ScriptButton.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = ("Text Files|*.txt");
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    log.Info("Script has been loaded - location :" + selectedScriptPath);
                    string path = dialog.FileName;
                    allCommands = Functions.Scripting.Read.readScript(path);
                    selectedScriptPath = path; // styling for the text
                    ScriptButton.Text = selectedScriptPath;
                    ScriptButton.TextAlign = ContentAlignment.BottomLeft;
                    ScriptButton.BackColor = Color.FromArgb(64, 64, 64);
                    ScriptButton.ForeColor = Color.White;
                    ScriptButton.BorderStyle = BorderStyle.None;
                }
            }
        }

        private void ScriptButton_MouseEnter(object sender, EventArgs e)
        {
            if (ScriptButton.Text != "Kies script")
            {
                ScriptButton.Text = "Verwijder script";
                ScriptButton.TextAlign = ContentAlignment.MiddleCenter;
                ScriptButton.BackColor = Color.Gainsboro;
                ScriptButton.ForeColor = Color.Black;
                ScriptButton.BorderStyle = BorderStyle.FixedSingle;
            }
            if (ScriptButton.Text == "Verwijder script")
            {
                ScriptButton.BorderStyle = BorderStyle.Fixed3D;
            }
        }
        private void ScriptButton_MouseLeave(object sender, EventArgs e)
        {
            if (selectedScriptPath != "")
            {
                ScriptButton.Text = selectedScriptPath;
                ScriptButton.TextAlign = ContentAlignment.BottomLeft;
                ScriptButton.BackColor = Color.FromArgb(64, 64, 64);
                ScriptButton.ForeColor = Color.White;
                ScriptButton.BorderStyle = BorderStyle.None;
            }
            if (ScriptButton.Text == "Kies script")
            {
                ScriptButton.BorderStyle = BorderStyle.FixedSingle;
            }
        }
        #endregion


        private void ClearOutputFieldButton_Click(object sender, EventArgs e)
        {
            if (OutputBox.Text != "")
            {
                DialogResult confirm = MessageBox.Show("Als u op OK drukt zal alle output worden verwijderd," + Environment.NewLine + "DIT IS ONOMKEERBAAR!", "Waarschuwing", MessageBoxButtons.OKCancel);
                if (confirm == DialogResult.OK)
                {
                    log.Info("Output box has been cleared by the user");
                    OutputBox.Text = "";
                }
            }
        }


        private void sQLServerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var wizard = new FirstRunScreen();
            wizard.ShowDialog();
        }

        private void aboutCiscoToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutScreen = new AboutScreen();
            var result = aboutScreen.ShowDialog();
        }

        private void maxOutputWindow_Click(object sender, EventArgs e)
        {
            if (OutputBox.Width == 174) // make bigger
            {
                if (OutputBox.Text.Length >= 10)
                {
                    string originalOutput = OutputBox.Text;
                    string[] strings = Regex.Split(originalOutput, "\r\n");
                    List<string> listOfRouters = new List<string>();
                    foreach (var item in strings)
                    {
                        listOfRouters.Add(item.ToString());
                    }
                    int maxwidth = Animations.Resizing.getLongestStringInPixels(listOfRouters);
                    while (OutputBox.Width < maxwidth)
                    {
                        OutputBox.Width++;
                    }
                }
            }
            else // make smaller
            {
                while (OutputBox.Width != 174)
                {
                    OutputBox.Width--;
                }
            }
        }

        private void maxOutputWindow_MouseHover(object sender, EventArgs e)
        {
            maxOutputWindow.BorderStyle = BorderStyle.None;
        }

        private void maxOutputWindow_MouseLeave(object sender, EventArgs e)
        {
            maxOutputWindow.BorderStyle = BorderStyle.FixedSingle;

        }

        private void CMDTelnetPanel_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = @"C:\windows\sysnative\telnet.exe";
            process.StartInfo.Arguments = ManualIPAddress.Text;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.Start();
            log.Info("Telnet.exe has been started by the user");
        }

        private void taskGetWidgets(string ip, string username, string password)
        {
            var widgets = JSON.readJSON(); // 7ms for reading a empty file

            //getting widget infromation and setting up template details
            Size templateSize = new Size(250, 230);
            Color templateBackColor = Color.Gray; //backcolor
            Color templateForeColor = Color.White; // font color
            Padding templateMargin = new System.Windows.Forms.Padding(0); // margin
            int count = 0;
            log.Info("every widget is being made and will be put into maintable");
            foreach (var widget in widgets)
            {
                if (widget.widgetType == "Informatie")
                {
                    var newPanel = new InfoTemplate();
                    newPanel.Name = "Panel" + count.ToString();
                    newPanel.Tag = count.ToString();
                    newPanel.titleWidgetLabel.Text = widget.widgetName;
                    newPanel.commandName.Text = widget.widgetCommand;
                    newPanel.closeWidgetPicturebox.Click += new EventHandler(removeWidget);
                    newPanel.maxWidgetPicturebox.Click += new EventHandler(maximizeWidget);

                    if (count % 2 == 0 || count == 0)
                    {
                        newPanel.topBar.BackColor = Color.FromArgb(255, 64, 14, 14);
                        newPanel.informationPanel.BackColor = Color.FromArgb(255, 76, 17, 17);
                        newPanel.BackColor = Color.FromArgb(255, 76, 17, 17);

                    }
                    else
                    {
                        newPanel.topBar.BackColor = Color.FromArgb(255, 140, 32, 32);
                        newPanel.informationPanel.BackColor = Color.FromArgb(255, 153, 35, 35);
                        newPanel.BackColor = Color.FromArgb(255, 153, 35, 35);
                    }
                    readyPanels.Add(newPanel);
                }

                else //execute widget
                {
                    var newPanel = new ExecuteTemplate();
                    newPanel.Name = "Panel" + count.ToString();
                    newPanel.Tag = count.ToString();
                    newPanel.titleWidgetLabel.Text = widget.widgetName;
                    newPanel.commandName.Text = widget.widgetCommand;
                    newPanel.closeWidgetPicturebox.Click += new EventHandler(removeWidget);
                    newPanel.runButton.Click += new EventHandler(runCommand);
                    newPanel.maxWidgetPicturebox.Click += new EventHandler(maximizeWidget);


                    if (count % 2 == 0 || count == 0)
                    {
                        newPanel.topBar.BackColor = Color.FromArgb(255, 64, 14, 14);
                        newPanel.informationPanel.BackColor = Color.FromArgb(255, 76, 17, 17);
                        newPanel.BackColor = Color.FromArgb(255, 76, 17, 17);

                    }
                    else
                    {
                        newPanel.topBar.BackColor = Color.FromArgb(255, 140, 32, 32);
                        newPanel.informationPanel.BackColor = Color.FromArgb(255, 153, 35, 35);
                        newPanel.BackColor = Color.FromArgb(255, 153, 35, 35);
                    }
                    newPanel.runButton.Text = "Uitvoeren";
                    readyPanels.Add(newPanel);
                }
                BackgroundWorker backgroundWorkerMakeWidget = new BackgroundWorker();
                backgroundWorkerMakeWidget.DoWork += backgroundWorkerMakeWidget_work;
                backgroundWorkerMakeWidget.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerMakeWidget_runCompleted);
                widgetTag = count;
                backgroundWorkerMakeWidget.RunWorkerAsync(widget);
                count++;
            }
        }

        private void backgroundWorkerMakeWidget_runCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (allOutputs.Count == readyPanels.Count)
            {
                Console.WriteLine("totaal aantal widgets: " + allOutputs.Count);
                readyPanels = readyPanels.OrderBy(o => o.Tag).ToList();
                allOutputs = allOutputs.OrderBy(o => o.widgetTag).ToList();
                for (int i = 0; i < allOutputs.Count; i++)
                {
                    readyPanels[i].Controls[1].Controls[1].Text = allOutputs[i].widgetOutput;
                }

                log.Info("widgets and plus sign are added to GUI");
                fillTableWithWidgets();

                //adding plus sign
                log.Info("Adding plus sign");
                PictureBox addButton = new PictureBox();
                addButton.Size = new Size(100, 100);
                addButton.BackColor = Color.Transparent;
                addButton.Image = Properties.Resources.add_1;
                addButton.SizeMode = PictureBoxSizeMode.Zoom;
                addButton.Anchor = AnchorStyles.None;
                addButton.Click += new EventHandler(addButtonClick);
                MainTableLayoutPanel.Controls.Add(addButton);


                readyPanels.Clear();
                allOutputs.Clear();

            }
        }

        private void backgroundWorkerMakeWidget_work(object sender, DoWorkEventArgs e)
        {
            widget widget = (widget)e.Argument;
            widgetResult widgetOutput = new widgetResult();
            widgetOutput.widgetTag = widgetTag;


            string output = TelnetConnection.telnetClientTCP(ManualIPAddress.Text, widget.widgetCommand, ManualUsername.Text, ManualPassword.Text, widget.widgetUseLongProcessTime);
            if (output != null)
            {
                if (!output.Contains(@"% Invalid input detected at '^' marker")) // check if command was valid
                {
                    if (widget.widgetUseSelection == true)
                    {
                        string finalResult = Widgets.Functions.Responses.getStringFromResponse(output, widget.widgetEnterCountBeforeString, widget.WidgetEnterCountInString);
                        widgetOutput.widgetOutput = finalResult.ToString();
                    }
                    else
                    {
                        widgetOutput.widgetOutput = output;
                    }
                }
            }
            else
            {
                widgetOutput.widgetOutput = @"Commando '" + widget.widgetCommand + @"'  is niet geldig";
                log.Info(@"Commando '" + widget.widgetCommand + @"'  is not a valid command");
            }
            allOutputs.Add(widgetOutput);
        }

        private void maximizeWidget(object sender, EventArgs e)
        {
            PictureBox realSender = ((PictureBox)sender);
            Control targetWidget = realSender.Parent.Parent; // first parent = top bar - second parent = widget
            var widgetOutputBox = targetWidget.Controls[1].Controls[1];// infopart - outputbox
            MessageBox.Show(widgetOutputBox.ToString());
            string outputText = widgetOutputBox.Text;
            bigOutputBox.Text = outputText;
            MainTableLayoutPanel.Enabled = false;
            bigOutputPanel.Visible = true;
            while (bigOutputPanel.Height != 550)
            {
                bigOutputPanel.Height++;
            }
        }

        private void runCommand(object sender, EventArgs e)
        {
            log.Info("Running command from execute widget");
            Button realsender = ((Button)sender);
            ExecuteTemplate widgetSender = (ExecuteTemplate)realsender.Parent.Parent;
            int widgetIndex = Int32.Parse(widgetSender.Tag.ToString());
            var widgets = JSON.readJSON(); // 7ms for reading a empty file
            var widget = widgets[widgetIndex];
            string command = widgetSender.commandName.Text;
            var outputbox = MainTableLayoutPanel.Controls[widgetIndex].Controls[1].Controls[1];


            if (command != "")
            {
                outputbox.Visible = true;
                outputbox.Text = "";
                bool usesLongProcessTime = widget.widgetUseLongProcessTime;
                string output = TelnetConnection.telnetClientTCP(ManualIPAddress.Text, command, ManualUsername.Text, ManualPassword.Text, usesLongProcessTime);
                if (output != null)
                {
                    if (!output.Contains(@"% Invalid input detected at '^' marker")) // check if command was valid
                    {
                        if (widget.widgetUseSelection == true)
                        {
                            string finalResult = Widgets.Functions.Responses.getStringFromResponse(output, widget.widgetEnterCountBeforeString, widget.WidgetEnterCountInString);
                            outputbox.Text = finalResult.ToString();
                        }
                        else
                        {
                            outputbox.Text = output;
                        }
                    }
                    else
                    {
                        outputbox.Font = new Font("Microsoft Sans Serif", 15);
                        outputbox.Text = @"Commando '" + widget.widgetCommand + @"' is niet geldig ";
                        log.Info(@"Commando '" + widget.widgetCommand + @"'  is not a valid command");
                    }
                }
                else
                {
                    log.Info("cannot connect to router - username and/or password is wrong");
                    outputbox.Text = "Kan niet verbinden met router - controleer de gebruikersnaam en wachtwoord";
                    MessageBox.Show("Kan niet verbinden met router - controleer de gebruikersnaam en wachtwoord");
                }
            }
        }

        void removeWidget(object sender, EventArgs e)
        {
            log.Info("removing widget from maintable");
            PictureBox realSender = ((PictureBox)sender);
            Control targetWidget = realSender.Parent.Parent; // first parent = top bar - second parent = widget
            DialogResult confirmRemove = MessageBox.Show("Wil je widget '" + realSender.Parent.Controls[0].Text + "' verwijderen?", "Widget verwijderen", MessageBoxButtons.YesNo);
            if (confirmRemove == DialogResult.Yes)
            {
                JSON.removeWidgetFromWidgetList(Int32.Parse(targetWidget.Tag.ToString()));
                MainTableLayoutPanel.Controls.Clear();
                //readyPanels.Clear();
                taskGetWidgets(ManualIPAddress.Text, ManualUsername.Text, ManualPassword.Text);
                fillTableWithWidgets();
                log.Info("Widget is removed and the GUI is refreshed");
            }
        }

        private void CMDTelnetLabel_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = @"C:\windows\sysnative\telnet.exe";
            process.StartInfo.Arguments = ManualIPAddress.Text;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.Start();
            log.Info("Telnet.exe has been started by the user");
        }

        private void manualTelnetPicture_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = @"C:\windows\sysnative\telnet.exe";
            process.StartInfo.Arguments = ManualIPAddress.Text;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.Start();
            log.Info("Telnet.exe has been started by the user");
        }

        private void bigOutputBoxClose_Click(object sender, EventArgs e)
        {
            while (bigOutputPanel.Height != 0)
            {
                bigOutputPanel.Height--;
            }
            MainTableLayoutPanel.Enabled = true;
            bigOutputPanel.Visible = false;
        }
    }
}
