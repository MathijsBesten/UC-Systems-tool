using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Cisco_Tool.Functions.SQL;
using static Cisco_Tool.Values.PrivateValues;
using System.Data.SqlClient;
using Cisco_Tool.Functions.Network;
using Cisco_Tool.Widgets.Views;
using Cisco_Tool.Widgets.Functions;
using Cisco_Tool.Widgets.Templates;
using System.ComponentModel;
using System.Linq;
using System.Diagnostics;
using Cisco_Tool.Views;
using System.Text.RegularExpressions;
using Cisco_Tool.Functions.Telnet;
using static Cisco_Tool.Widgets.Classes;
using System.Reflection;

namespace Cisco_Tool
{
    public partial class MainForm : Form
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region properties
        private static List<Router> _allRouters;
        private string _selectedScriptPath = "";
        public List<string> AllCommands = new List<string>();
        public static int loopCount = 1;
        public List<string> SelectedIpAddresses = new List<string>();
        public static List<Control> ReadyPanels = new List<Control>();
        public static List<Widget> ReadyWidgets = new List<Widget>();
        public int WidgetTag = 0;
        public bool LoginDetailsChanged = false;
        List<WidgetResult> _listOfWidgetItems = new List<WidgetResult>();
        public int IndexOfRunWidget = 0;
        public CheckBox selectAllCheckbox;


        private readonly string _sqlip = Properties.Settings.Default.CiscoToolServerIP;
        private readonly string _sqlDatabase = Properties.Settings.Default.CiscoToolServerDatabase;
        private readonly string _sqlUsername = Properties.Settings.Default.CiscoToolServerUsername;
        private readonly string _sqlPassword = Properties.Settings.Default.CiscoToolServerPassword;
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
            Log.Info("Current version: " + version);

            if (_sqlip == "" && _sqlDatabase == "" && _sqlUsername == "" && _sqlPassword == "")
            {
                Log.Info("No database details available - asking user to enter database details");
                var firstRunDialog = new FirstRunScreen();
                firstRunDialog.ShowDialog();
            }
            mainMenu.TabPages.Remove(RouterTab);
            try
            {
                SqlConnection connection = Connections.OwnDb();
                _allRouters = Data.GetDataFromMicrosoftSql(connection, OwnServerServerQuery);
                if (_allRouters != null)
                {
                    foreach (var router in _allRouters)
                    {
                        MainDataGridView.Rows.Add(false, router.RouterAlias, router.RouterAddress, "", router.RouterMainDb); //  false is for checkbox is not checked
                    }
                    Log.Info("Loaded all routers to the application");
                    CommandoGB.Enabled = true;


                    //select all box in header column
                    Rectangle rectangle = this.MainDataGridView.GetCellDisplayRectangle(0,-1, true);
                    selectAllCheckbox = new CheckBox()
                    {
                        Size = new Size(18, 18),
                        Location = new Point(rectangle.Location.X + 9, rectangle.Location.Y + 3),                        
                    };
                    selectAllCheckbox.CheckedChanged += new EventHandler(selectAllCheckbox_checkedChanged);
                    this.MainDataGridView.Controls.Add(selectAllCheckbox);
                    //End of select all code
                }
                else
                {
                    Log.Info("Database details are wrong");
                    Log.Info("Please try entering the correct details using the sql wizard from the menubar");
                    MessageBox.Show("Er is geen sql database gevonden - herstart de applicatie of controleer de sql gegevens");
                    CommandoGB.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Log.Error("Database details are wrong - could not load routers from routerlist");
                Log.Error("error message - " + ex.Message);
                Log.Error("Please try entering the correct details using the sql wizard from the menubar");
                MessageBox.Show("Er is geen sql database gevonden - herstart de applicatie of controleer de sql gegevens");
                CommandoGB.Enabled = false;
            }
        }

        private void selectAllCheckbox_checkedChanged(object sender, EventArgs e)
        {
            if (selectAllCheckbox.Checked == true) // if user added checkmark
            {
                for (int i = 0; i < MainDataGridView.RowCount; i++)
                {
                    if (MainDataGridView[0, i].Visible == true)
                    {
                        MainDataGridView[0, i].Value = true;
                    }
                }
            }
            else if (selectAllCheckbox.Checked == false) // if user removed checkmark
            {
                for (int i = 0; i < MainDataGridView.RowCount; i++)
                {
                    if (MainDataGridView[0, i].Visible == true) // if user
                    {
                        MainDataGridView[0, i].Value = false;
                    }
                }
            }
            MainDataGridView.RefreshEdit();
           
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Log.Info("Closing application");
            Application.Exit();
        }
        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainMenu.SelectedIndex == 1) // if user switched to router tab
            {
                List<Widget> widgets = Json.ReadJson(); 
                if (LoginDetailsChanged == true)
                {
                    MainTableLayoutPanel.Controls.Clear();
                    Log.Info("Loading all router information...");
                    routerIPText.Text = ManualIPAddress.Text;

                    List<WidgetResult> listToRun = new List<WidgetResult>(); // list contains all widgets and other elements

                    WidgetResult pid = new WidgetResult
                    {
                        WidgetCommand = "show inventory",
                        UselongTime = false,
                        WidgetTag = "PID"
                    };
                    listToRun.Add(pid);

                    WidgetResult showRun = new WidgetResult
                    {
                        WidgetCommand = "show run",
                        UselongTime = true,
                        WidgetTag = "showRun"
                    };
                    listToRun.Add(showRun);
                    Log.Info("Loading all widgets / if available");
                    if (widgets == null || widgets.Count == 0) 
                    {
                        Log.Info("No widgets were found - adding plus sign");
                        PictureBox addButton = new PictureBox
                        {
                            Size = new Size(100, 100),
                            BackColor = Color.Transparent,
                            Image = Properties.Resources.add_1,
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Anchor = AnchorStyles.None
                        };
                        addButton.Click += new EventHandler(AddButtonClick);
                        MainTableLayoutPanel.Controls.Add(addButton);
                    }
                    else if (MainTableLayoutPanel.Controls.Count != widgets.Count + 1)
                    {
                        MainTableLayoutPanel.Enabled = true;
                        int count = 0;
                        foreach (Widget widget in widgets)
                        {
                            WidgetResult item = new WidgetResult
                            {
                                WidgetCommand = widget.WidgetCommand,
                                UselongTime = widget.WidgetUseLongProcessTime,
                                WidgetTag = count.ToString()
                            };
                            listToRun.Add(item);
                            count++;
                        }
                    }
                    BackgroundWorker widgetPageBackgroundWorker = new BackgroundWorker();
                    widgetPageBackgroundWorker.DoWork += getWidgetPageInfo_Work;
                    widgetPageBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(getWidgetPageInfo_runCompleted);
                    widgetPageBackgroundWorker.RunWorkerAsync(listToRun);
                    LoginDetailsChanged = false; // this will prevent reloading if user switches tabs
                }
            }
        }



        private void getWidgetPageInfo_Work(object sender, DoWorkEventArgs e)
        {
            List<WidgetResult> listToRun = (List<WidgetResult>)e.Argument;
            foreach (WidgetResult t in listToRun)
            {
                List<string> commands = t.WidgetCommand.Split(';').ToList();
                t.WidgetOutput = new TelnetConnection().TelnetClientTcp(ManualIPAddress.Text, commands, ManualUsername.Text, ManualPassword.Text, t.UselongTime); // find output
            }
            _listOfWidgetItems = listToRun;
            Log.Info("all items from the widget page has been loaded");
        }
        private void getWidgetPageInfo_runCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<Widget> widgets = Json.ReadJson();
            int indexWidget = 0;
            if (_listOfWidgetItems[0].WidgetOutput == null && _listOfWidgetItems[1].WidgetOutput == null)// check if command received timeout
            {
                MessageBox.Show("Er vond een timeout plaats - controleer de gegevens en probeer het opnieuw");
                Log.Info("A timeout has occured while trying to get widgets - check router details");
            }
            else
            {
                foreach (var item in _listOfWidgetItems)
                {
                    if (item.WidgetTag == "PID")
                    {
                        string totalOutput = item.WidgetOutput;
                        string pid = TelnetConnection.FindPid(totalOutput);
                        routerType.Text = pid;
                    }
                    else if (item.WidgetTag == "showRun")
                    {
                        runningConfigOutputField.Text = item.WidgetOutput;
                    }
                    else
                    {
                        int index = Int32.Parse(item.WidgetTag);
                        if (widgets[index].WidgetType == "Informatie")
                        {
                            var newPanel = new InfoTemplate
                            {
                                Name = "Panel" + indexWidget.ToString(),
                                Tag = indexWidget.ToString(),
                                TitleWidgetLabel = {Text = widgets[indexWidget].WidgetName},
                                CommandName = {Text = widgets[indexWidget].WidgetCommand}
                            };
                            newPanel.CloseWidgetPicturebox.Click += new EventHandler(RemoveWidget);
                            newPanel.MaxWidgetPicturebox.Click += new EventHandler(MaximizeWidget);

                            if (widgets[indexWidget].WidgetUseSelection == true)
                            {
                                string finalString = Responses.GetStringFromResponse(item.WidgetOutput, widgets[indexWidget].WidgetEnterCountBeforeString, widgets[indexWidget].WidgetEnterCountInString);
                                newPanel.Outputbox.Text = finalString;
                            }
                            else
                            {
                                newPanel.Outputbox.Text = item.WidgetOutput;
                            }


                            MainTableLayoutPanel.Controls.Add(newPanel);
                        }

                        else //execute widget
                        {
                            var newPanel = new ExecuteTemplate
                            {
                                Name = "Panel" + indexWidget.ToString(),
                                Tag = indexWidget.ToString(),
                                TitleWidgetLabel = {Text = widgets[indexWidget].WidgetName},
                                CommandName = {Text = widgets[indexWidget].WidgetCommand}
                            };
                            newPanel.CloseWidgetPicturebox.Click += new EventHandler(RemoveWidget);
                            newPanel.RunButton.Click += new EventHandler(RunCommand);
                            newPanel.MaxWidgetPicturebox.Click += new EventHandler(MaximizeWidget);
                            newPanel.RunButton.Text = "Uitvoeren";
                            MainTableLayoutPanel.Controls.Add(newPanel);
                        }
                        indexWidget++;
                    }
                }
                PictureBox addButton = new PictureBox
                {
                    Size = new Size(100, 100),
                    BackColor = Color.Transparent,
                    Image = Properties.Resources.add_1,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Anchor = AnchorStyles.None
                };
                addButton.Click += new EventHandler(AddButtonClick);
                MainTableLayoutPanel.Controls.Add(addButton);
                MainTableLayoutPanel.Enabled = true;
            }
        }

        #region widget layout
        // when user checks a router

        private void MainDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (MainDataGridView.CurrentCell is DataGridViewCheckBoxCell)
            {
                string nameOfRouter = MainDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                string ipAddress = MainDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (allSelectedRouters.Items.Contains(nameOfRouter))
                {
                    allSelectedRouters.Items.Remove(nameOfRouter);
                }
                else
                {
                    allSelectedRouters.Items.Add(nameOfRouter);
                }
                if (SelectedIpAddresses.Contains(ipAddress))
                {
                    SelectedIpAddresses.Remove(ipAddress);
                }
                else
                {
                    SelectedIpAddresses.Add(ipAddress);
                }
            }
        }
        private void MainDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (MainDataGridView.CurrentCell is DataGridViewCheckBoxCell)
            {
                MainDataGridView.EndEdit();
            }
        }
        public void checkIfAllRowsAreSelected()
        {
            int totalfilteredItems =  MainDataGridView.DisplayedRowCount(true);
            int totalSelectedItemsInSelection = 0;
            foreach (var item in MainDataGridView.Rows)
            {
                DataGridViewRow row = item as DataGridViewRow;
                if (row.Visible == true && Convert.ToBoolean(row.Cells[0].Value))
                {
                    totalSelectedItemsInSelection++;
                }
            }
            if (totalfilteredItems == totalSelectedItemsInSelection)
            {
                setSelectAllToTrue_WithoutEvent();
            }
        }


        private void MainDataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            SearchGroupBox.Refresh();
        }

        void AddButtonClick(object sender, EventArgs e)
        {
            var widgetCreator = new WidgetCreator();
            var result = widgetCreator.ShowDialog();
            if (result == DialogResult.OK)
            {
                Log.Info("user made a new widget");
                Log.Info("clearing and refilling MainTableLayoutPanel");
                MainTableLayoutPanel.Controls.Clear();
                ReadyPanels.Clear();
                GetWidgetsAsync(true);

            }
        }
        #endregion

        #region homescreen
        private void ManualConnect_Click(object sender, EventArgs e)
        {
            mainErrorProvider.SetError(ManualIPAddress, ManualIPAddress.Text != "" ? "" : "ip adres verplicht");
            mainErrorProvider.SetError(ManualUsername, ManualUsername.Text != "" ? "" : "Gebruikersnaam verplicht");
            mainErrorProvider.SetError(ManualPassword, ManualPassword.Text != "" ? "" : "Wachtwoord verplicht");


            if (ManualIPAddress.Text != "" && ManualUsername.Text != "" && ManualPassword.Text != "")
            {
                bool pisValid = Validation.ValidateIPv4(ManualIPAddress.Text);
                if (!pisValid)
                {
                    mainErrorProvider.SetError(ManualIPAddress, "Geen geldig ip adres");
                }
                else
                {
                    if (mainMenu.TabCount == 1)
                    {
                        mainMenu.TabPages.Add(RouterTab);
                        RouterTab.Text = ManualIPAddress.Text;
                        Log.Info("Router tab added to mainmenu");
                    }
                    else
                    {
                        mainMenu.TabPages.Remove(RouterTab);
                        mainMenu.TabPages.Add(RouterTab);
                        RouterTab.Text = ManualIPAddress.Text;
                        Log.Info("Router tab refresh in the mainmenu");
                    }
                    LoginDetailsChanged = true;
                }
            }
        }
        private void RunCommands_Click(object sender, EventArgs e)
        {
            mainErrorProvider.SetError(Username, Username.Text == "" ? "gebruikersnaam vereist" : "");
            mainErrorProvider.SetError(Password, Password.Text == "" ? "wachtwoord vereist" : "");
            if (Command1.Text == "")
            {
                mainErrorProvider.SetError(Command1, _selectedScriptPath != "" ? "" : "commando of script vereist");
            }
            else
            {
                mainErrorProvider.SetError(Command1, "");
            }
            if (Username.Text != "" && Password.Text != "" && (Command1.Text != "" || AllCommands.Count != 0))
            {
                if (SelectedIpAddresses.Count == 0)
                {
                    MessageBox.Show("geen routers geselecteerd, vink de router(s) aan die je wilt aansturen");
                }
                else
                {
                    Log.Info("start the executing commands function");
                    List<string> commands = new List<string>();
                    foreach (var item in AllCommands)
                    {
                        commands.Add(item);
                    }
                    if (Command1.Text != "") { commands.Add(Command1.Text); }
                    if (Command2.Text != "") { commands.Add(Command2.Text); }
                    if (Command3.Text != "") { commands.Add(Command3.Text); }
                    if (Command4.Text != "") { commands.Add(Command4.Text); }

                    var confirmDialog = new ConfirmationScreen(allSelectedRouters.Items.Cast<string>().ToList(), commands);
                    confirmDialog.ShowDialog();
                    if (confirmDialog.DialogResult == DialogResult.OK)
                    {
                        SendCommandsInBulkAsync(SelectedIpAddresses,commands);
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
                int maxwidth = Animations.Resizing.GetLongestStringInPixels(listOfRouters);
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
            int index = allSelectedRouters.SelectedIndex;
            int countSelectedRouters = allSelectedRouters.Items.Count;
            string selectedRouter = allSelectedRouters.Items[index].ToString();
            if (index != -1)
            {
                foreach (DataGridViewRow row in MainDataGridView.Rows)
                {
                    if (row.Cells[1].Value.ToString() == selectedRouter)
                    {
                        (row.Cells[0] as DataGridViewCheckBoxCell).Value = false;
                        break;
                    }
                }
                if (countSelectedRouters == allSelectedRouters.Items.Count)
                {
                    allSelectedRouters.Items.RemoveAt(index);
                }
                MainDataGridView.Refresh();
                MainContextMenuStrip.Close();
            }
        }

        #endregion

        #region searchbox
        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (MainDataGridView.RowCount != 0)
            {
                FilterRoutersInList();
            }
        }
        private void FilterRoutersInList()
        {
            int count = 0;
            for (int i = 0; i < MainDataGridView.RowCount; i++)
            {
                MainDataGridView.Rows[i].Visible = true;

            }
            if (SearchBox.Text != "")
            {
                bool setSelectAllCheckboxToTrue = false;
                foreach (var router in _allRouters)
                {
                    string routerAliasLowered = router.RouterAlias.ToLower();
                    string searchBoxTextLowerer = SearchBox.Text.ToLower();
                    if (!routerAliasLowered.Contains(searchBoxTextLowerer))
                    {
                        MainDataGridView.Rows[count].Visible = false;
                    }
                    if (routerAliasLowered.Contains(searchBoxTextLowerer) && Convert.ToBoolean(MainDataGridView.Rows[count].Cells[0].Value))
                    {
                        setSelectAllCheckboxToTrue = true;
                    }
                    count++;
                }
                if (setSelectAllCheckboxToTrue == true)
                {
                    setSelectAllToTrue_WithoutEvent();
                }
                else
                {
                    setSelectAllToFalse_WithoutEvent();
                }
            }

        }
        public void setSelectAllToTrue_WithoutEvent()
        {
            selectAllCheckbox.CheckedChanged -= selectAllCheckbox_checkedChanged;
            selectAllCheckbox.Checked = true;
            selectAllCheckbox.CheckedChanged += selectAllCheckbox_checkedChanged;
        }
        public void setSelectAllToFalse_WithoutEvent()
        {
            selectAllCheckbox.CheckedChanged -= selectAllCheckbox_checkedChanged;
            selectAllCheckbox.Checked = false;
            selectAllCheckbox.CheckedChanged += selectAllCheckbox_checkedChanged;
        }

        private void CheckEnterKeyPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (MainDataGridView.RowCount != 0)
                {
                    FilterRoutersInList();
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
                Log.Info("Script has been released from application");
                AllCommands.Clear(); //remove all commands from script
                _selectedScriptPath = ""; // removes path for futher if statements
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
                    Log.Info("Script has been loaded - location :" + _selectedScriptPath);
                    string path = dialog.FileName;
                    AllCommands = Functions.Scripting.Read.ReadScript(path);
                    _selectedScriptPath = path; // styling for the text
                    ScriptButton.Text = _selectedScriptPath;
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
            }
        }
        private void ScriptButton_MouseLeave(object sender, EventArgs e)
        {
            if (_selectedScriptPath != "")
            {
                ScriptButton.Text = _selectedScriptPath;
                ScriptButton.TextAlign = ContentAlignment.BottomLeft;
                ScriptButton.BackColor = Color.FromArgb(64, 64, 64);
                ScriptButton.ForeColor = Color.White;
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
                    Log.Info("Output box has been cleared by the user");
                    OutputBox.Text = "";
                }
            }
        }

        private void sQLServerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var wizard = new FirstRunScreen();
            wizard.ShowDialog();
            try
            {
                SqlConnection connection = Connections.OwnDb();
                _allRouters = Data.GetDataFromMicrosoftSql(connection, OwnServerServerQuery);
                if (_allRouters != null)
                {
                    foreach (var router in _allRouters)
                    {
                        MainDataGridView.Rows.Add(false, router.RouterAlias, router.RouterAddress, "", router.RouterMainDb); //  false is for checkbox is not checked
                    }
                    Log.Info("Loaded all routers to the application");
                    CommandoGB.Enabled = true;
                }
                else
                {
                    Log.Info("Database details are wrong");
                    Log.Info("Please try entering the correct details using the sql wizard from the menubar");
                    MessageBox.Show("Er is geen sql database gevonden - herstart de applicatie of controleer de sql gegevens");
                    CommandoGB.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Log.Error("Database details are wrong - could not load routers from routerlist");
                Log.Error("error message - " + ex.Message);
                Log.Error("Please try entering the correct details using the sql wizard from the menubar");
                MessageBox.Show("Er is geen sql database gevonden - herstart de applicatie of controleer de sql gegevens");
                CommandoGB.Enabled = false;
            }
        }

        private void aboutCiscoToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutScreen = new AboutScreen();
            aboutScreen.ShowDialog();
        }

        private void maxOutputWindow_Click(object sender, EventArgs e)
        {
            int minWidth = 171;
            int maxwidth = 850;
            if (OutputBox.Width == minWidth) // make bigger
            {
                if (OutputBox.Text.Length >= 10)
                {
                    while (OutputBox.Width < maxwidth)
                    {
                        OutputBox.Width = maxwidth;
                    }
                }
            }
            else // make smaller
            {
                while (OutputBox.Width != minWidth)
                {
                    OutputBox.Width = minWidth;
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
            Process process = new Process
            {
                StartInfo =
                {
                    FileName = @"C:\windows\sysnative\telnet.exe",
                    Arguments = ManualIPAddress.Text,
                    WindowStyle = ProcessWindowStyle.Normal
                }
            };
            process.Start();
            Log.Info("Telnet.exe has been started by the user");
        }

            

        private void MaximizeWidget(object sender, EventArgs e)
        {
            PictureBox realSender = ((PictureBox)sender);
            Control targetWidget = realSender.Parent.Parent; // first parent = top bar - second parent = widget
            var widgetOutputBox = targetWidget.Controls[1].Controls[1];// infopart - outputbox
            string outputText = widgetOutputBox.Text;
            bigOutputBox.Text = outputText;
            MainTableLayoutPanel.Enabled = false;
            bigOutputPanel.Visible = true;
            while (bigOutputPanel.Height != 550)
            {
                bigOutputPanel.Height++;
            }
        }

        private void RunCommand(object sender, EventArgs e)
        {
            Log.Info("Running command from execute widget");
            Button realsender = ((Button)sender);
            ExecuteTemplate widgetSender = (ExecuteTemplate)realsender.Parent.Parent;
            IndexOfRunWidget = Int32.Parse(widgetSender.Tag.ToString());
            var widgets = Json.ReadJson(); // 7ms for reading a empty file
            var widget = widgets[IndexOfRunWidget];
            string command = widgetSender.CommandName.Text;


            if (command != "")
            {
                Widget thisWidget = new Widget
                {
                    WidgetUseLongProcessTime = widget.WidgetUseLongProcessTime,
                    WidgetCommand = command
                };
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += getWidgetResult_doWork;
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(getWidgetResult_workFinished);
                bw.RunWorkerAsync(thisWidget);

                
            }
        }
        public void getWidgetResult_doWork(object sender, DoWorkEventArgs e)
        {
            Widget thisWidget = (Widget)e.Argument ;
            List<string> commands = thisWidget.WidgetCommand.Split(';').ToList();
            thisWidget.WidgetOutput = new TelnetConnection().TelnetClientTcp(ManualIPAddress.Text, commands, ManualUsername.Text, ManualPassword.Text, thisWidget.WidgetUseLongProcessTime);
            e.Result = e.Argument;
        }
        public void getWidgetResult_workFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            var outputbox = MainTableLayoutPanel.Controls[IndexOfRunWidget].Controls[1].Controls[1];
            string output = ((Widget)e.Result).WidgetOutput;
            outputbox.Visible = true;
            outputbox.Text = "";
            if (output != null)
            {
                if (!output.Contains(@"% Invalid input detected at '^' marker")) // check if command was valid
                {
                    outputbox.Text = output;
                }
                else
                {
                    outputbox.Font = new Font("Microsoft Sans Serif", 15);
                    outputbox.Text = @"Commando '" + output + @"' is niet geldig ";
                    Log.Info(@"Commando '" + output + @"'  is not a valid command");
                }
            }
            else
            {
                Log.Info("cannot connect to router - username and/or password is wrong");
                outputbox.Text = "Kan niet verbinden met router - controleer de gebruikersnaam en wachtwoord";
                MessageBox.Show("Kan niet verbinden met router - controleer de gebruikersnaam en wachtwoord");
            }
        }


        void RemoveWidget(object sender, EventArgs e)
        {
            Log.Info("removing widget from maintable");
            PictureBox realSender = ((PictureBox)sender);
            Control targetWidget = realSender.Parent.Parent; // first parent = top bar - second parent = widget
            DialogResult confirmRemove = MessageBox.Show("Wil je widget '" + realSender.Parent.Controls[0].Text + "' verwijderen?", "Widget verwijderen", MessageBoxButtons.YesNo);
            if (confirmRemove == DialogResult.Yes)
            {
                Json.RemoveWidgetFromWidgetList(Int32.Parse(targetWidget.Tag.ToString()));
                MainTableLayoutPanel.Controls.Clear();
                //readyPanels.Clear();
                GetWidgetsAsync(true);

                Log.Info("Widget is removed and the GUI is refreshed");
            }
        }

        private void CMDTelnetLabel_Click(object sender, EventArgs e)
        {
            Process process = new Process
            {
                StartInfo =
                {
                    FileName = @"C:\windows\sysnative\telnet.exe",
                    Arguments = ManualIPAddress.Text,
                    WindowStyle = ProcessWindowStyle.Normal
                }
            };
            process.Start();
            Log.Info("Telnet.exe has been started by the user");
        }

        private void manualTelnetPicture_Click(object sender, EventArgs e)
        {
            Process process = new Process
            {
                StartInfo =
                {
                    FileName = @"C:\windows\sysnative\telnet.exe",
                    Arguments = ManualIPAddress.Text,
                    WindowStyle = ProcessWindowStyle.Normal
                }
            };
            process.Start();
            Log.Info("Telnet.exe has been started by the user");
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

        // ReSharper disable once UnusedParameter.Local
        private void GetWidgetsAsync(bool addPlusButton)
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
            List<Widget> widgets = Json.ReadJson(); 
            foreach (Widget t in widgets)
            {
                List<string> commands = t.WidgetCommand.Split(';').ToList();
                t.WidgetOutput = new TelnetConnection().TelnetClientTcp(ManualIPAddress.Text, commands, ManualUsername.Text, ManualPassword.Text, t.WidgetUseLongProcessTime); // find output
            }
            ReadyWidgets = widgets;
            Log.Info("all items from the widget page has been loaded");
        }
        private void getWidgetsAsync_runCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int indexWidget = 0;
            foreach (var item in ReadyWidgets)
            {
              
                if (item.WidgetType == "Informatie")
                {
                    var newPanel = new InfoTemplate
                    {
                        Name = "Panel" + indexWidget,
                        Tag = indexWidget.ToString(),
                        TitleWidgetLabel = {Text = item.WidgetName},
                        CommandName = {Text = item.WidgetCommand}
                    };
                    newPanel.CloseWidgetPicturebox.Click += new EventHandler(RemoveWidget);
                    newPanel.MaxWidgetPicturebox.Click += new EventHandler(MaximizeWidget);

                    if (item.WidgetUseSelection == true)
                    {
                        string finalString = Responses.GetStringFromResponse(item.WidgetOutput, item.WidgetEnterCountBeforeString, item.WidgetEnterCountInString);
                        newPanel.Outputbox.Text = finalString;
                    }
                    else
                    {
                        newPanel.Outputbox.Text = item.WidgetOutput;
                    }
                    MainTableLayoutPanel.Controls.Add(newPanel);
                }

                else //execute widget
                {
                    var newPanel = new ExecuteTemplate
                    {
                        Name = "Panel" + indexWidget,
                        Tag = indexWidget.ToString(),
                        TitleWidgetLabel = {Text = item.WidgetName},
                        CommandName = {Text = item.WidgetCommand}
                    };
                    newPanel.CloseWidgetPicturebox.Click += new EventHandler(RemoveWidget);
                    newPanel.RunButton.Click += new EventHandler(RunCommand);
                    newPanel.MaxWidgetPicturebox.Click += new EventHandler(MaximizeWidget);
                    newPanel.RunButton.Text = "Uitvoeren";
                    MainTableLayoutPanel.Controls.Add(newPanel);
                }
                indexWidget++;
            }
            if ((bool)e.Result == true)
            {
                PictureBox addButton = new PictureBox
                {
                    Size = new Size(100, 100),
                    BackColor = Color.Transparent,
                    Image = Properties.Resources.add_1,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Anchor = AnchorStyles.None
                };
                addButton.Click += new EventHandler(AddButtonClick);
                MainTableLayoutPanel.Controls.Add(addButton);
                MainTableLayoutPanel.Enabled = true;

            }
        }
        public void SendCommandsInBulkAsync(List<string> routers,List<string> commands)
        {
            // foreach router a backgroundworker will be started
            // every backgroundworker will run all the commands
            // the backgroundworker will format all the output to a readable format
            // the output will be given as a eventArgs result

            foreach (var router in routers)
            {
                List<object> allArguments = new List<object> {router, commands};

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
            string localIp = router;


            // start of telnet function
            Console.WriteLine(localIp);
            totalOutput.Add(Environment.NewLine);
            totalOutput.Add(localIp);
            totalOutput.Add(Environment.NewLine);
            totalOutput.Add(Environment.NewLine);
            string output = new TelnetConnection().TelnetClientTcp(localIp, commands, username, password, true);
            totalOutput.Add(output); // add output to totalOutput
            totalOutput.Add(Environment.NewLine);
            totalOutput.Add("--------------");
            totalOutput.Add(Environment.NewLine);                                
                        
            // uncommand the following code to get output box in logfile
            Log.Debug("Output...");
            foreach (string line in totalOutput)
            {
                Log.Debug(line);
            }
            e.Result = totalOutput;
        }

        private void sendCommandAsync_runCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (var str in (List<string>)e.Result)
            {
                OutputBox.Text += str;
            }
            if ( loopCount== allSelectedRouters.Items.Count)
            {
                OutputBox.Text += "Aantal routers verbonden: " + TelnetConnection.succesfullConnected.Count;
                OutputBox.Text += Environment.NewLine;
                foreach (var item in TelnetConnection.succesfullConnected)
                {
                    OutputBox.Text += item;
                    OutputBox.Text += Environment.NewLine;
                }
                OutputBox.Text += Environment.NewLine;
                OutputBox.Text += "Aantal fout bij verbinden: " + TelnetConnection.couldNotConnect.Count;
                OutputBox.Text += Environment.NewLine;
                foreach (var item in TelnetConnection.couldNotConnect)
                {
                    OutputBox.Text += item;
                    OutputBox.Text += Environment.NewLine;
                }
                OutputBox.SelectionStart = OutputBox.Text.Length;
                OutputBox.ScrollToCaret();
                OutputBox.Refresh();
                loopCount = 0;
            }
            loopCount++;
        }

        private void bugMeldenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start("https://gitreports.com/issue/MathijsBesten/UC-Systems-tool"); // report
        }

        private void logLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var logchangerDialog = new ChangeLogLevelScreen
            {
                Location = new Point(this.DesktopLocation.X + 105, this.DesktopLocation.Y + 60)
            };

            logchangerDialog.ShowDialog();
        }
    }
}
