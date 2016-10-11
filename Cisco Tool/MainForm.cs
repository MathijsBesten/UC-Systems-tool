using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using MySql.Data.MySqlClient;
using Cisco_Tool.Functions.SQL;
using Cisco_Tool.Values;
using static Cisco_Tool.Values.PrivateValues;
using System.Data.SqlClient;
using Cisco_Tool.Functions.Network;
using Cisco_Tool.Widgets.Views;
using Cisco_Tool.Widgets.Functions;
using static Cisco_Tool.Widgets.Classes;

namespace Cisco_Tool
{
    public partial class MainForm : Form
    {
        private static List<router> allRouters;
        private Point mouseLocation;
        private int originalLocationWidgetLeft;
        private int originalLocationWidgetTop;
        private int originalTopBarWidth;
        private int originalMainInfoWidth;
        private int originalMainInfoHeight;
        private int originalLocationRemoveLeft;
        private int originalLocationMinMaxLeft;


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
                this.MainDataGridView.Rows.Add(false, router.routerAlias, router.routerAddress, "", router.routerMainDB); //  false is for checkbox is not checked
            }

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            filterRoutersInList();
        }
        private void checkEnterKeyPressed(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                filterRoutersInList();
                e.Handled = true;
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

        private void ManualConnect_Click(object sender, EventArgs e)
        {
            if (ManualIPAddress.Text == "")
            {
                mainErrorProvider.SetError(ManualIPAddress, "ip adres verplicht");
            }
            else
            {
                mainErrorProvider.SetError(ManualIPAddress, "");
            }
            if (ManualUsername.Text == "")
            {
                mainErrorProvider.SetError(ManualUsername, "Gebruikersnaam verplicht");
            }
            else
            {
                mainErrorProvider.SetError(ManualUsername, "");
            }
            if (ManualPassword.Text == "")
            {
                mainErrorProvider.SetError(ManualPassword, "Wachtwoord verplicht");
            }
            else
            {
                mainErrorProvider.SetError(ManualPassword, "");
            }
            if (ManualIPAddress.Text !="" && ManualUsername.Text !="" && ManualPassword.Text != "")
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

        private void ScriptButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = ("Text Files|*.txt");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName;
                List<string> allCommands = Functions.Scripting.Read.readScript(path);
                foreach (var command in allCommands)
                {
                    // run command on router
                    // get response
                    // put response in output box
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
                mainErrorProvider.SetError(Command1, "commando of script vereist");
            }
            else
            {
                mainErrorProvider.SetError(Command1, "");
            }
            if (Username.Text != "" && Password.Text !="" && Command1.Text != "" )
            {
                MessageBox.Show("executing command");
            }
        }

        private void MainGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MainDataGridView.CurrentCell is DataGridViewCheckBoxCell)
            {
                string nameOfRouter = MainDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (allSelectedRouters.Items.Contains(nameOfRouter))
                {
                    allSelectedRouters.Items.Remove(nameOfRouter);
                }
                else
                {
                    allSelectedRouters.Items.Add(nameOfRouter);
                }
            }
        }
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
                    this.allSelectedRouters.Width++;
                }
            }
        }

        private void allSelectedRouters_MouseLeave(object sender, EventArgs e)
        {
            if (allSelectedRouters.Items.Count >= 1)
            {
                while (allSelectedRouters.Width != 171) //171
                {
                    this.allSelectedRouters.Width--;
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

                        MessageBox.Show(row.Index.ToString());
                    }
                }
                this.MainDataGridView.Refresh();
                allSelectedRouters.Items.RemoveAt(index); // functions as jquery
                MainContextMenuStrip.Close();
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseLocation = e.Location;
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && MainTemplatePanel.Size.Width < 500)
            {
                MainTemplatePanel.Left = e.X + MainTemplatePanel.Left - mouseLocation.X;
                MainTemplatePanel.Top = e.Y + MainTemplatePanel.Top - mouseLocation.Y;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainTemplatePanel.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MainTemplatePanel.Size.Width < 500)
            {
                originalLocationWidgetLeft = MainTemplatePanel.Left;
                originalLocationWidgetTop = MainTemplatePanel.Top;
                originalLocationRemoveLeft = removeWidget.Left;
                originalLocationMinMaxLeft = minMaxWidget.Left;
                originalTopBarWidth = widgetTopBar.Width;
                originalMainInfoHeight = widgetInformationBlock.Height;
                originalMainInfoWidth = widgetInformationBlock.Width;

                MainTemplatePanel.Left = 0;
                MainTemplatePanel.Top = 0;
                MainTemplatePanel.Height = 631;
                MainTemplatePanel.Width = 1227;
                widgetInformationBlock.Width = 1227;
                widgetInformationBlock.Height = 594;
                widgetTopBar.Width = 1227;
                removeWidget.Left = 1194;
                minMaxWidget.Left = 1155;

            }
            else
            {
                MainTemplatePanel.Height = 230;
                MainTemplatePanel.Width = 250;
                MainTemplatePanel.Left = originalLocationWidgetLeft;
                MainTemplatePanel.Top = originalLocationWidgetTop;
                removeWidget.Left = originalLocationRemoveLeft;
                minMaxWidget.Left = originalLocationMinMaxLeft;
                widgetTopBar.Width = originalTopBarWidth;
                widgetInformationBlock.Height = originalMainInfoHeight;
                widgetInformationBlock.Width = originalMainInfoWidth;
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            WidgetCreator widgetMaker = new Widgets.Views.WidgetCreator();
            widgetMaker.ShowDialog();
            JSON.readJSON();
            //load all widgets using json
        }

        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex == 1)
            {
                //getting widget infromation and setting up template details

                var widgets = JSON.readJSON();
                Panel templatePanel = Widgets.Views.Templates.defaultPanel();
                Panel[] templateControls = new Panel[widgets.Count];
                templatePanel.Controls.CopyTo(templateControls, 0); // copy controls to array for use in other panels
                Size templateSize = new Size(250, 230);
                Color templateBackColor = Color.Gray; //backcolor
                Color templateForeColor = Color.White; // font color
                Padding templateMargin = new System.Windows.Forms.Padding(0); // margin

                RouterTab.Controls.Add(new Panel());
                RouterTab.Controls.Add(templatePanel);
                RouterTab.Controls.Add(templatePanel);
                RouterTab.Controls.Add(templatePanel);
                RouterTab.Controls.Add(templatePanel);


                int count = 0;
                foreach (var widget in widgets)
                {
                    if (count == 0)
                    {
                        Panel panel0 = new Panel();
                        panel0.Name = "0";
                        panel0.Controls.AddRange(templateControls);
                        panel0.Size = templateSize;
                        panel0.BackColor = templateBackColor;
                        panel0.ForeColor = templateForeColor;
                        panel0.Margin = templateMargin;
                    }
                    if (count == 1)
                    {
                        Panel panel1 = new Panel();
                        panel1.Name = "1";
                        panel1.Controls.Add(new Panel());      
                        panel1.Size = templateSize;
                        panel1.BackColor = templateBackColor;
                        panel1.ForeColor = templateForeColor;
                        panel1.Margin = templateMargin;
                        MainTableLayoutPanel.Controls.Add(panel1, 1, 0);
                    }
                    if (count == 2)
                    {
                        Panel panel2 = new Panel();
                        panel2.Name = "2";
                        panel2.Controls.AddRange(templateControls);
                        panel2.Size = templateSize;
                        panel2.BackColor = templateBackColor;
                        panel2.ForeColor = templateForeColor;
                        panel2.Margin = templateMargin;
                        MainTableLayoutPanel.Controls.Add(panel2, 2, 0);
                    }
                    if (count == 3)
                    {
                        Panel panel3 = new Panel();
                        panel3.Controls.AddRange(templateControls);
                        panel3.Size = templateSize;
                        panel3.BackColor = templateBackColor;
                        panel3.ForeColor = templateForeColor;
                        panel3.Margin = templateMargin;
                        MainTableLayoutPanel.Controls.Add(panel3, 3, 0);
                    }
                    if (count == 4)
                    {
                        Panel panel4 = new Panel();
                        panel4.Controls.AddRange(templateControls);
                        panel4.Size = templateSize;
                        panel4.BackColor = templateBackColor;
                        panel4.ForeColor = templateForeColor;
                        panel4.Margin = templateMargin;
                        MainTableLayoutPanel.Controls.Add(panel4, 0, 1);
                    }
                    if (count == 5)
                    {
                        Panel panel5 = new Panel();
                        panel5.Controls.AddRange(templateControls);
                        panel5.Size = templateSize;
                        panel5.BackColor = templateBackColor;
                        panel5.ForeColor = templateForeColor;
                        panel5.Margin = templateMargin;
                        MainTableLayoutPanel.Controls.Add(panel5, 1, 1);
                    }
                    if (count == 6)
                    {
                        Panel panel6 = new Panel();
                        panel6.Controls.AddRange(templateControls);
                        panel6.Size = templateSize;
                        panel6.BackColor = templateBackColor;
                        panel6.ForeColor = templateForeColor;
                        panel6.Margin = templateMargin;
                        MainTableLayoutPanel.Controls.Add(panel6, 2, 1);
                    }
                    if (count == 7)
                    {
                        Panel panel7 = new Panel();
                        panel7.Controls.AddRange(templateControls);
                        panel7.Size = templateSize;
                        panel7.BackColor = templateBackColor;
                        panel7.ForeColor = templateForeColor;
                        panel7.Margin = templateMargin;
                        MainTableLayoutPanel.Controls.Add(panel7, 3, 1);
                    }
                    count++;
                }
            }
        }
        public void setWidgets(int count, Panel templatePanel)
        {
            
        }
    }
}
