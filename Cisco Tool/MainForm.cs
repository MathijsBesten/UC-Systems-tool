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
                this.MainGridView.Rows.Add(false, router.routerAlias, router.routerAddress, "", router.routerMainDB); //  false is for checkbox is not checked
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
            for (int i = 0; i < MainGridView.RowCount; i++)
            {
                MainGridView.Rows[i].Visible = true;

            }
            if (SearchBox.Text != "")
            {

                foreach (var router in allRouters)
                {
                    string routerAliasLowered = router.routerAlias.ToLower();
                    string searchBoxTextLowerer = SearchBox.Text.ToLower();
                    if (!routerAliasLowered.Contains(searchBoxTextLowerer))
                    {
                        MainGridView.Rows[count].Visible = false;
                    }
                    count++;
                }
            }
        }
    }
}
