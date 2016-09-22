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

namespace Cisco_Tool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<router> routerlist = Data.getDataFromMicrosoftSQL(Connections.OwnDB(), PrivateValues.OwnServerServerQuery);
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("status", typeof(Image));
            dataTable.Columns.Add("name", typeof(string));
            dataTable.Columns.Add("ipAddress", typeof(string));
            dataTable.Columns.Add("statusInfo", typeof(string));
            DataRow newRow = dataTable.NewRow();
            foreach (var router in routerlist)
            {
                newRow[1] = router.routerName;
                newRow[2] = router.routerAddress;
                newRow[3] = "Statusje";
                dataTable.ImportRow(newRow);
            }
            MainGridView.DataSource = dataTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RouterDetails test = new Cisco_Tool.Views.RouterDetails();
            test.ShowDialog();
        }
    }
}
