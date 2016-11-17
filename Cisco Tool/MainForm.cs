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
using System.Reflection;

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
        public static List<widget> readyWidgets = new List<widget>();
        public int widgetTag = 0;
        public bool loginDetailsChanged = false;
        List<widgetResult> listOfWidgetItems = new List<widgetResult>();

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
            string version = Assembly.GetExecutingAssembly()
                               .GetName()
                               .Version
                               .ToString();
            log.Info("Current version: " + version);

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
                List<widget> widgets = JSON.readJSON(); 
                if (loginDetailsChanged == true)
                {
                    MainTableLayoutPanel.Controls.Clear();
                    log.Info("Loading all router information...");
                    routerIPText.Text = ManualIPAddress.Text;

                    List<widgetResult> listToRun = new List<widgetResult>(); // list contains all widgets and other elements

                    widgetResult PID = new widgetResult();
                    PID.widgetCommand = "show inventory";
                    PID.uselongTime = false ;
                    PID.widgetTag = "PID";
                    listToRun.Add(PID);

                    widgetResult showRun = new widgetResult();
                    showRun.widgetCommand = "show run";
                    showRun.uselongTime = true; // needs to be async
                    showRun.widgetTag = "showRun";
                    listToRun.Add(showRun);
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
                        MainTableLayoutPanel.Enabled = true;
                        int count = 0;
                        foreach (widget widget in widgets)
                        {
                            widgetResult item = new widgetResult();
                            item.widgetCommand = widget.widgetCommand;
                            item.uselongTime = widget.widgetUseLongProcessTime;
                            item.widgetTag = count.ToString();
                            listToRun.Add(item);
                            count++;
                        }


                        //getInformationForWidgetPage(ManualIPAddress.Text, ManualUsername.Text, ManualPassword.Text); // main get function
                        //readyPanels = readyPanels.OrderBy(o => o.Tag).ToList();
                        //allOutputs = allOutputs.OrderBy(o => o.widgetTag).ToList();
                        //for (int i = 0; i < allOutputs.Count; i++)
                        //{
                        //    readyPanels[i].Controls[1].Controls[1].Text = allOutputs[i].widgetOutput;
                        //}
                    }
                    BackgroundWorker widgetPageBackgroundWorker = new BackgroundWorker();
                    widgetPageBackgroundWorker.DoWork += getWidgetPageInfo_Work;
                    widgetPageBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(getWidgetPageInfo_runCompleted);
                    widgetPageBackgroundWorker.RunWorkerAsync(listToRun);
                    loginDetailsChanged = false; // this will prevent reloading if user switches tabs
                }
            }
        }



        private void getWidgetPageInfo_Work(object sender, DoWorkEventArgs e)
        {
            List<widgetResult> listToRun = (List<widgetResult>)e.Argument;
            for (int i = 0; i < listToRun.Count; i++)
            {
                List<string> command = new List<string>() { listToRun[i].widgetCommand };
                listToRun[i].widgetOutput = new TelnetConnection().telnetClientTCP(ManualIPAddress.Text, command, ManualUsername.Text, ManualPassword.Text, listToRun[i].uselongTime); // find output
            }
            listOfWidgetItems = listToRun;
            log.Info("all items from the widget page has been loaded");
        }
        private void getWidgetPageInfo_runCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<widget> widgets = JSON.readJSON();
            int indexWidget = 0;
            foreach (var item in listOfWidgetItems)
            {
                if (item.widgetTag == "PID")
                {
                    string totalOutput = item.widgetOutput;
                    string PID = TelnetConnection.findPID(totalOutput);
                    routerType.Text = PID;
                }
                else if (item.widgetTag == "showRun")
                {
                    runningConfigOutputField.Text = item.widgetOutput;
                }
                else
                {
                    int index = Int32.Parse(item.widgetTag);
                    if (widgets[index].widgetType == "Informatie")
                    {
                        var newPanel = new InfoTemplate();
                        newPanel.Name = "Panel" + indexWidget.ToString();
                        newPanel.Tag = indexWidget.ToString();
                        newPanel.titleWidgetLabel.Text = widgets[indexWidget].widgetName;
                        newPanel.commandName.Text = widgets[indexWidget].widgetCommand;
                        newPanel.closeWidgetPicturebox.Click += new EventHandler(removeWidget);
                        newPanel.maxWidgetPicturebox.Click += new EventHandler(maximizeWidget);

                        if (widgets[indexWidget].widgetUseSelection == true)
                        {
                            string finalString = Responses.getStringFromResponse(item.widgetOutput, widgets[indexWidget].widgetEnterCountBeforeString, widgets[indexWidget].WidgetEnterCountInString);
                            newPanel.outputbox.Text = finalString;
                        }
                        else
                        {
                            newPanel.outputbox.Text = item.widgetOutput;
                        }


                        MainTableLayoutPanel.Controls.Add(newPanel);
                    }

                    else //execute widget
                    {
                        var newPanel = new ExecuteTemplate();
                        newPanel.Name = "Panel" + indexWidget.ToString();
                        newPanel.Tag = indexWidget.ToString();
                        newPanel.titleWidgetLabel.Text = widgets[indexWidget].widgetName;
                        newPanel.commandName.Text = widgets[indexWidget].widgetCommand;
                        newPanel.closeWidgetPicturebox.Click += new EventHandler(removeWidget);
                        newPanel.runButton.Click += new EventHandler(runCommand);
                        //newPanel.maxWidgetPicturebox.Click += new EventHandler(maximizeWidget);
                        newPanel.runButton.Text = "Uitvoeren";
                        MainTableLayoutPanel.Controls.Add(newPanel);
                    }
                    indexWidget++;
                }
            }
            PictureBox addButton = new PictureBox();
            addButton.Size = new Size(100, 100);
            addButton.BackColor = Color.Transparent;
            addButton.Image = Properties.Resources.add_1;
            addButton.SizeMode = PictureBoxSizeMode.Zoom;
            addButton.Anchor = AnchorStyles.None;
            addButton.Click += new EventHandler(addButtonClick);
            MainTableLayoutPanel.Controls.Add(addButton);
            MainTableLayoutPanel.Enabled = true;
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
                getWidgetsAsync(true);

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
                        sendCommandsInBulkAsync(selectedIPAddresses,commands);
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
            if (OutputBox.Width == 171) // make bigger
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
                while (OutputBox.Width != 171)
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

        private void getInformationForWidgetPage(string ip, string username, string password)
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

                    newPanel.runButton.Text = "Uitvoeren";
                    readyPanels.Add(newPanel);
                }
                BackgroundWorker backgroundWorkerMakeWidget = new BackgroundWorker();
                backgroundWorkerMakeWidget.DoWork += getWidgetPageInfo_Work;
                backgroundWorkerMakeWidget.RunWorkerCompleted += new RunWorkerCompletedEventHandler(getWidgetPageInfo_runCompleted);
                widgetTag = count;
                backgroundWorkerMakeWidget.RunWorkerAsync(widget);
                count++;
            }
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
                List<string> commands = new List<string>() { command };
                string output = new TelnetConnection().telnetClientTCP(ManualIPAddress.Text, commands, ManualUsername.Text, ManualPassword.Text, usesLongProcessTime);
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
                getWidgetsAsync(true);

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



        private void getWidgetsAsync(bool addPlusButton)
        {
            MainTableLayoutPanel.Enabled = false;


            BackgroundWorker getWidgetsBackgroundWorker = new BackgroundWorker(); // only one backgroundworker is being used - router cannot handle more than 1 request at a time
            getWidgetsBackgroundWorker.DoWork += getWidgetsAsync_work;
            getWidgetsBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(getWidgetsAsync_runCompleted);
            getWidgetsBackgroundWorker.RunWorkerAsync(true);
        }
        private void getWidgetsAsync_work(object sender, DoWorkEventArgs e)
        {
            e.Result = e.Argument;
            List<widget> widgets = JSON.readJSON(); 
            for (int i = 0; i < widgets.Count; i++)
            {
                List<string> command = new List<string>() { widgets[i].widgetCommand };
                widgets[i].widgetOutput = new TelnetConnection().telnetClientTCP(ManualIPAddress.Text, command, ManualUsername.Text, ManualPassword.Text, widgets[i].widgetUseLongProcessTime); // find output
            }
            readyWidgets = widgets;
            log.Info("all items from the widget page has been loaded");
        }
        private void getWidgetsAsync_runCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int indexWidget = 0;
            foreach (var item in readyWidgets)
            {
              
                if (item.widgetType == "Informatie")
                {
                    var newPanel = new InfoTemplate();
                    newPanel.Name = "Panel" + indexWidget.ToString();
                    newPanel.Tag = indexWidget.ToString();
                    newPanel.titleWidgetLabel.Text = item.widgetName;
                    newPanel.commandName.Text = item.widgetCommand;
                    newPanel.closeWidgetPicturebox.Click += new EventHandler(removeWidget);
                    newPanel.maxWidgetPicturebox.Click += new EventHandler(maximizeWidget);

                    if (item.widgetUseSelection == true)
                    {
                        string finalString = Responses.getStringFromResponse(item.widgetOutput, item.widgetEnterCountBeforeString, item.WidgetEnterCountInString);
                        newPanel.outputbox.Text = finalString;
                    }
                    else
                    {
                        newPanel.outputbox.Text = item.widgetOutput;
                    }



                    MainTableLayoutPanel.Controls.Add(newPanel);
                }

                else //execute widget
                {
                    var newPanel = new ExecuteTemplate();
                    newPanel.Name = "Panel" + indexWidget.ToString();
                    newPanel.Tag = indexWidget.ToString();
                    newPanel.titleWidgetLabel.Text = item.widgetName;
                    newPanel.commandName.Text = item.widgetCommand;
                    newPanel.closeWidgetPicturebox.Click += new EventHandler(removeWidget);
                    newPanel.runButton.Click += new EventHandler(runCommand);
                    newPanel.maxWidgetPicturebox.Click += new EventHandler(maximizeWidget);
                    newPanel.runButton.Text = "Uitvoeren";
                    MainTableLayoutPanel.Controls.Add(newPanel);
                }
                indexWidget++;
            }
            if ((bool)e.Result == true)
            {
                PictureBox addButton = new PictureBox();
                addButton.Size = new Size(100, 100);
                addButton.BackColor = Color.Transparent;
                addButton.Image = Properties.Resources.add_1;
                addButton.SizeMode = PictureBoxSizeMode.Zoom;
                addButton.Anchor = AnchorStyles.None;
                addButton.Click += new EventHandler(addButtonClick);
                MainTableLayoutPanel.Controls.Add(addButton);
                MainTableLayoutPanel.Enabled = true;

            }
        }
        public void sendCommandsInBulkAsync(List<string> routers,List<string> commands)
        {
            // foreach router a backgroundworker will be started
            // every backgroundworker will run all the commands
            // the backgroundworker will format all the output to a readable format
            // the output will be given as a eventArgs result

            foreach (var router in routers)
            {
                List<object> allArguments = new List<object>();
                allArguments.Add(router);
                allArguments.Add(commands);

                BackgroundWorker sendCommandBackgroundWorker = new BackgroundWorker(); // only one backgroundworker is being used - router cannot handle more than 1 request at a time
                sendCommandBackgroundWorker.DoWork += sendCommandAsync_doWork;
                sendCommandBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(sendCommandAsync_runCompleted);
                sendCommandBackgroundWorker.RunWorkerAsync(allArguments);
            }
        }

        private void sendCommandAsync_doWork(object sender, DoWorkEventArgs e)
        {
            List<object> arguments = (List<object>)e.Argument;
            string router = (string)arguments[0];
            List<string> commands = (List<string>)arguments[1];
            List<string> totalOutput = new List<string>();

            //start function
            string username = Username.Text;
            string password = Password.Text;
            int indexOfCommand = 0;
            string localIP = router;//= "172.28.81.180"; // change to 'router' in release version


            // start of telnet function
            Console.WriteLine(localIP);
            totalOutput.Add(Environment.NewLine);
            totalOutput.Add(localIP);
            totalOutput.Add(Environment.NewLine);
            totalOutput.Add(Environment.NewLine);
            string output;
            output = new TelnetConnection().telnetClientTCP(localIP, commands, username, password, true);
            indexOfCommand++;
            totalOutput.Add(output); // add output to totalOutput
            totalOutput.Add(Environment.NewLine);
            totalOutput.Add("--------------");
            totalOutput.Add(Environment.NewLine);                                
                        
            // uncommand the following code to get output box in logfile
            log.Debug("Output...");
            foreach (string line in totalOutput)
            {
                log.Debug(line);
            }
            e.Result = totalOutput;
        }

        private void sendCommandAsync_runCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (var str in (List<string>)e.Result)
            {
                OutputBox.Text += str;
            }
        }

        private void bugMeldenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start("https://gitreports.com/issue/MathijsBesten/UC-Systems-tool"); // report bug
        }

        private void logLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var logchangerDialog = new Views.ChangeLogLevelScreen();
            logchangerDialog.Location = new Point (this.DesktopLocation.X + 105, this.DesktopLocation.Y + 60); 
            DialogResult result = logchangerDialog.ShowDialog();
        }
    }
}
