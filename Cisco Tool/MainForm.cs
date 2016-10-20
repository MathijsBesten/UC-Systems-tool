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

namespace Cisco_Tool
{
    public partial class MainForm : Form
    {
        #region properties
        private static List<router> allRouters;
        private Point mouseLocation;
        private string selectedScriptPath = "";
        public List<string> allCommands = new List<string>();
        public List<string> selectedIPAddresses = new List<string>();
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private void MainForm_Load(object sender, EventArgs e)
        {
            SqlConnection connection = Connections.OwnDB();
            allRouters = Data.getDataFromMicrosoftSQL(connection, PrivateValues.OwnServerServerQuery);
            foreach (var router in allRouters)
            {
                MainDataGridView.Rows.Add(false, router.routerAlias, router.routerAddress, "", router.routerMainDB); //  false is for checkbox is not checked
            }
        }
        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainTableLayoutPanel.Controls.Clear();
            var widgets = JSON.readJSON(); // 7ms for reading a empty file
            if (script.SelectedIndex == 1 && widgets != null) // if user switched to router tab
            {
                //getting widget infromation and setting up template details
                Size templateSize = new Size(250, 230);
                Color templateBackColor = Color.Gray; //backcolor
                Color templateForeColor = Color.White; // font color
                Padding templateMargin = new System.Windows.Forms.Padding(0); // margin
                int count = 0;
                foreach (var widget in widgets)
                {
                    if (widget.widgetType == "Informatie")
                    {
                        var newPanel = new InfoTemplate();
                        newPanel.Name = "Panel" + count.ToString();
                        newPanel.Tag = "Panel" + count.ToString();
                        newPanel.titleWidgetLabel.Text = widget.widgetName;
                        newPanel.commandName.Text = widget.widgetCommand;
                        newPanel.minMaxWidgetPicturebox.Click += new System.EventHandler(this.minMaxButton_Click);
                        newPanel.closeWidgetPicturebox.Click += new System.EventHandler(this.closeButton_Click);
                        if (widget.widgetCommand != "")
                        {
                            string username = "mathijs";
                            string password = "denbesten";
                            string command = widget.widgetCommand;
                            bool usesLongProcessTime = widget.widgetUseLongProcessTime;
                            string output = Functions.Telnet.TelnetConnection.telnetClientTCP("172.28.81.180", command, username, password, usesLongProcessTime);
                            if (!output.Contains(@"% Invalid input detected at '^' marker")) // check if command was valid
                            {
                                if (widget.widgetUseSelection == true)
                                {
                                    string finalResult = Widgets.Functions.Responses.getStringFromResponse(output, widget.widgetEnterCountBeforeString, widget.WidgetEnterCountInString);
                                    newPanel.outputbox.Text = finalResult.ToString();
                                }
                                else
                                {
                                    newPanel.outputbox.Text = output;
                                }
                            }
                            else
                            {
                                newPanel.outputbox.Font = new Font("Microsoft Sans Serif", 15);
                                newPanel.outputbox.Text = @"Commando '" + widget.widgetCommand + @"'  is niet geldig";
                            }
                            MainTableLayoutPanel.Controls.Add(newPanel);
                        }
                    }
                    else //button
                    {
                        var newPanel = new ExecuteTemplate();
                        newPanel.Name = "Panel" + count.ToString();
                        newPanel.Tag = "Panel" + count.ToString();
                        newPanel.titleWidgetLabel.Text = widget.widgetName;
                        newPanel.commandName.Text = widget.widgetCommand;
                        newPanel.minMaxWidgetPicturebox.Click += new System.EventHandler(this.minMaxButton_Click);
                        newPanel.closeWidgetPicturebox.Click += new System.EventHandler(this.closeButton_Click);

                        if (widget.widgetCommand != "")
                        {
                            string username = "mathijs";
                            string password = "denbesten";
                            string command = widget.widgetCommand;
                            bool usesLongProcessTime = widget.widgetUseLongProcessTime;
                            string output = Functions.Telnet.TelnetConnection.telnetClientTCP("172.28.81.180", command, username, password, usesLongProcessTime);
                            if (!output.Contains(@"% Invalid input detected at '^' marker")) // check if command was valid
                            {
                                if (widget.widgetUseSelection == true)
                                {
                                    string finalResult = Widgets.Functions.Responses.getStringFromResponse(output, widget.widgetEnterCountBeforeString, widget.WidgetEnterCountInString);
                                    newPanel.outputbox.Text = finalResult.ToString();
                                }
                                else
                                {
                                    newPanel.outputbox.Text = output;
                                }
                            }
                            else
                            {
                                newPanel.outputbox.Font = new Font("Microsoft Sans Serif", 15);
                                newPanel.outputbox.Text = @"Commando '" + widget.widgetCommand + @"' is niet geldig ";
                            }
                        }
                        newPanel.runButton.Text = "Uitvoeren";
                        //make new onclick event
                        MainTableLayoutPanel.Controls.Add(newPanel);
                    }
                    count++;
                }
                if (MainTableLayoutPanel.Controls.Count < 8)
                {
                    PictureBox addButton = new PictureBox();
                    addButton.Size = new Size(100, 100);
                    addButton.BackColor = Color.Transparent;
                    addButton.Image = Properties.Resources.add_1;
                    addButton.SizeMode = PictureBoxSizeMode.Zoom;
                    addButton.Anchor = AnchorStyles.None;
                    addButton.Click += new EventHandler(addButtonClick);
                    MainTableLayoutPanel.Controls.Add(addButton);
                }
            }
            else
            {
                PictureBox addButton = new PictureBox();
                addButton.Size = new Size(100, 100);
                addButton.BackColor = Color.Transparent;
                addButton.Image = Properties.Resources.add_1;
                addButton.SizeMode = PictureBoxSizeMode.Zoom;
                addButton.Anchor = AnchorStyles.None;
                addButton.Click += new EventHandler(addButtonClick);
                MainTableLayoutPanel.Controls.Add(addButton);
            }
        }




        #region widget layout
        private void MainGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MainDataGridView.CurrentCell is DataGridViewCheckBoxCell)
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
                script.TabPages[1].Refresh();
            }
        }

        private void minMaxButton_Click(object sender, EventArgs e)
        {
            PictureBox realSender = ((PictureBox)sender);
            var parentPanel = realSender.Parent.Parent; // get widget panel
            MessageBox.Show(parentPanel.Name.ToString());
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            PictureBox realSender = ((PictureBox)sender);
            var parentPanel = realSender.Parent.Parent; // get widget panel
            MessageBox.Show(parentPanel.Name.ToString());
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
                if (IPisValid)
                {
                    MessageBox.Show("De functie zal een nieuw tabje boven \'handmatig verbinden\' maken en de stying kopieeren van \'router connection\'");
                }
                else
                {
                    mainErrorProvider.SetError(ManualIPAddress, "Geen geldig ip adres");
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
            if (Username.Text != "" && Password.Text != "" && (Command1.Text != "" || selectedIPAddresses.Count != 0))
            {
                if (selectedIPAddresses.Count == 0)
                {
                    MessageBox.Show("geen routers geselecteerd, vink de router(s) aan die je wilt aansturen");
                }
                else
                {
                    if (Command1.Text != "") { allCommands.Add(Command1.Text); }
                    if (Command2.Text != "") { allCommands.Add(Command2.Text); }
                    if (Command3.Text != "") { allCommands.Add(Command3.Text); }
                    if (Command4.Text != "") { allCommands.Add(Command4.Text); }

                    var confirmDialog = new Views.ConfirmationScreen(allSelectedRouters.Items.Cast<string>().ToList(), allCommands);
                    confirmDialog.ShowDialog();
                    if (confirmDialog.DialogResult == DialogResult.OK)
                    {
                        foreach (var IPAddress in selectedIPAddresses)
                        {
                            string localIP = "172.28.81.180";
                            Console.WriteLine(localIP);
                            string username = Username.Text;
                            string password = Password.Text;

                            OutputBox.Text += Environment.NewLine;
                            OutputBox.Text += localIP;
                            OutputBox.Text += Environment.NewLine;
                            OutputBox.Text += Environment.NewLine;
                            foreach (var command in allCommands)
                            {
                                string output;
                                if (command.ToLower() == "show running-config" || command.ToLower() == "write")
                                {
                                    output = Networkstreams.TalkToCiscoRouterAndGetResponse(localIP, command, username, password, true);
                                }
                                else
                                {
                                    output = Networkstreams.TalkToCiscoRouterAndGetResponse(localIP, command, username, password, false);
                                }
                                OutputBox.Text += output;
                                OutputBox.Text += Environment.NewLine;
                                OutputBox.Text += "--------------";
                                OutputBox.Text += Environment.NewLine;
                            }
                        }
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
                while (allSelectedRouters.Width != 171) //171
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
            filterRoutersInList();
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
                filterRoutersInList();
                e.Handled = true;
            }
        }
        #endregion

        #region scriptbutton
        private void ScriptButton_Click(object sender, EventArgs e)
        {
            if (ScriptButton.Text == "Verwijder script")
            {
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

        private void SQLServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SQLConfigScreen();
            dialog.ShowDialog();
        }
    }
}
