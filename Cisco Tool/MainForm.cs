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

namespace Cisco_Tool
{
    public partial class MainForm : Form
    {
        #region properties
        private static List<router> allRouters;
        private string selectedScriptPath = "";
        public List<string> allCommands = new List<string>();
        public List<string> selectedIPAddresses = new List<string>(); 

        private string SQLIP = Properties.Settings.Default.CiscoToolServerIP;
        private string SQLDatabase = Properties.Settings.Default.CiscoToolServerDatabase;
        private string SQLUsername = Properties.Settings.Default.CiscoToolServerUsername;
        private string SQLPassword = Properties.Settings.Default.CiscoToolServerPassword;
        #endregion

        public MainForm()
        {
            InitializeComponent();
            if (SQLIP == "" && SQLDatabase == "" && SQLUsername == "" && SQLPassword == "")
            {
                var sqlDialog = new SQLConfigScreen();
                sqlDialog.ShowDialog();
            }

        }
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private void MainForm_Load(object sender, EventArgs e)
        {
            SqlConnection connection = Connections.OwnDB();
            allRouters = Data.getDataFromMicrosoftSQL(connection, PrivateValues.OwnServerServerQuery);
            if (allRouters != null)
            {
                foreach (var router in allRouters)
                {
                    MainDataGridView.Rows.Add(false, router.routerAlias, router.routerAddress, "", router.routerMainDB); //  false is for checkbox is not checked
                }
            }
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainTableLayoutPanel.Controls.Clear();
            var widgets = JSON.readJSON(); // 7ms for reading a empty file
            if (script.SelectedIndex == 1 && widgets != null) // if user switched to router tab
            {
                Task  shit = WidgetGenerator.makeAllWidgets();
                MainTableLayoutPanel.Controls.Clear();
                shit.Wait();


                foreach (var panel in WidgetGenerator.readyPanels)
                {
                    MainTableLayoutPanel.Controls.Add(panel);
                }
                WidgetGenerator.readyPanels.Clear();


                PictureBox addButton = new PictureBox();
                addButton.Size = new Size(100, 100);
                addButton.BackColor = Color.Transparent;
                addButton.Image = Properties.Resources.add_1;
                addButton.SizeMode = PictureBoxSizeMode.Zoom;
                addButton.Anchor = AnchorStyles.None;
                addButton.Click += new EventHandler(addButtonClick);
                MainTableLayoutPanel.Controls.Add(addButton);
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

        public void minMaxButton_Click(object sender, EventArgs e)
        {
            PictureBox realSender = ((PictureBox)sender);
            var parentPanel = realSender.Parent.Parent; // get widget panel
            MessageBox.Show(parentPanel.Name.ToString());
        }
        public void closeButton_Click(object sender, EventArgs e)
        {
            PictureBox realSender = ((PictureBox)sender);
            var parentPanel = realSender.Parent.Parent; // get widget panel
            int indexToRemove;
            try
            {
                indexToRemove = Int32.Parse(parentPanel.Tag.ToString());
            }
            catch (Exception)
            {
                indexToRemove = -1;
                MessageBox.Show("There was a problem with converting the widget tag");
            }
            if (indexToRemove >= 0) 
            {
                JSON.removeWidgetFromWidgetList(indexToRemove);
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
            if (Username.Text != "" && Password.Text != "" && (Command1.Text != "" || allCommands.Count != 0))
            {
                if (selectedIPAddresses.Count == 0)
                {
                    MessageBox.Show("geen routers geselecteerd, vink de router(s) aan die je wilt aansturen");
                }
                else
                {
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
                        string stringIfPasswordIsWrong = "Password: ";
                        string username = Username.Text;
                        string password = Password.Text;

                        foreach (var IPAddress in selectedIPAddresses)
                        {
                            if (passwordFailedThreeTimes < 3)
                            {
                                bool passwordIsStillWrong = false;
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
                                            output = Networkstreams.TalkToCiscoRouterAndGetResponse(localIP, command, username, password, true);
                                        }
                                        else
                                        {
                                            output = Networkstreams.TalkToCiscoRouterAndGetResponse(localIP, command, username, password, false);
                                        }
                                        indexOfCommand++;
                                        var splittedOutput = Regex.Split(output, stringIfPasswordIsWrong);
                                        if (splittedOutput[1] == "")
                                        {
                                            if (selectedIPAddresses.Count < 3)
                                            {
                                                ipWherePasswordIsWrong = localIP;
                                                passwordFailedThreeTimes = 3;
                                                OutputBox.Text += Environment.NewLine;
                                                OutputBox.Text += "Gebruikersnaam en/of wachtwoord is waarschijnlijk fout";
                                                OutputBox.Text += Environment.NewLine;

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
                                                OutputBox.Text +=  @"'" + command + @"'"  + " -  GEEN GELDIG COMMANDO";
                                                OutputBox.Text += Environment.NewLine;
                                                OutputBox.Text += "--------------";
                                                OutputBox.Text += Environment.NewLine;
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
                                        // continues to fail
                                        string output;
                                        if (commands[indexOfCommand].ToLower() == "show running-config" || commands[indexOfCommand].ToLower() == "write")
                                        {
                                            output = Networkstreams.TalkToCiscoRouterAndGetResponse(localIP, commands[indexOfCommand], username, password, true);
                                        }
                                        else
                                        {
                                            output = Networkstreams.TalkToCiscoRouterAndGetResponse(localIP, commands[indexOfCommand], username, password, false);
                                        }
                                        var splittedOutput = Regex.Split(output, stringIfPasswordIsWrong);
                                        if (splittedOutput[1] == "")
                                        {
                                            passwordIsStillWrong = true;
                                            OutputBox.Text += Environment.NewLine;
                                            OutputBox.Text += "Gebruikersnaam en/of wachtwoord is waarschijnlijk fout";
                                            OutputBox.Text += Environment.NewLine;
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


        private void ClearOutputFieldButton_Click(object sender, EventArgs e)
        {
            if (OutputBox.Text != "")
            {
                DialogResult confirm = MessageBox.Show("Als u op OK drukt zal alle output worden verwijderd," + Environment.NewLine + "DIT IS ONOMKEERBAAR!", "Waarschuwing", MessageBoxButtons.OKCancel);
                if (confirm == DialogResult.OK)
                {
                    OutputBox.Clear();
                }
            }
        }


        private void sQLServerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var dialog = new SQLConfigScreen();
            dialog.ShowDialog();
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
                if (OutputBox.Text.Length >= 10)
                {
                    while (OutputBox.Width != 174)
                    {
                        OutputBox.Width--;
                    }
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
            process.StartInfo.Arguments = "172.28.81.180";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.Start();
        }

        private void CMDTelnetPanel_MouseHover(object sender, EventArgs e)
        {
            CMDTelnetPanel.BorderStyle = BorderStyle.None;
        }

        private void CMDTelnetPanel_MouseLeave(object sender, EventArgs e)
        {
            CMDTelnetPanel.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
