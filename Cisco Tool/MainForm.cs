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
using Cisco_Tool.Views;
using MySql.Data.MySqlClient;
using Cisco_Tool.Functions.SQL;
using Cisco_Tool.Values;
using static Cisco_Tool.Values.PrivateValues;
using System.Data.SqlClient;
using Cisco_Tool.Functions.Network;

namespace Cisco_Tool
{
    public partial class MainForm : Form
    {
        private static List<router> allRouters;

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

        private void button2_Click(object sender, EventArgs e)
        {
            RouterDetails test = new Cisco_Tool.Views.RouterDetails();
            test.ShowDialog();
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
            MessageBox.Show("Aan deze functie wordt gewerkt");
        }

        private void RunCommands_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aan deze functie wordt gewerkt");
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

        private void allSelectedRoutersLabel_MouseHover(object sender, EventArgs e)
        {
            if (allSelectedRouters.Items.Count >= 1)
            {
                while (allSelectedRouters.Width < 400)
                {
                    this.allSelectedRouters.Width++;
                }
            }
        }
        private void allSelectedRouters_MouseLeave(object sender, EventArgs e)
        {
            while (allSelectedRouters.Width != 189)
            {
                this.allSelectedRouters.Width--;
            }
        }
    }
}
