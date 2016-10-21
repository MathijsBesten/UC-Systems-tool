using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cisco_Tool.Views
{
    public partial class SQLConfigScreen : Form
    {
        public SQLConfigScreen()
        {
            InitializeComponent();
            string ip = Properties.Settings.Default.CiscoToolServerIP;
            string database = Properties.Settings.Default.CiscoToolServerDatabase;
            string username =  Properties.Settings.Default.CiscoToolServerUsername; 
            string password = Properties.Settings.Default.CiscoToolServerPassword;

            SQLIPAddress.Text = ip;
            SQLDatabase.Text = database;
            SQLUsername.Text = username;
            SQLPassword.Text = password;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (SQLIPAddress.Text == "")
            {
                mainErrorProvider.SetError(SQLIPAddress, "gebruikersnaam vereist");
            }
            else
            {
                mainErrorProvider.SetError(SQLIPAddress, "");
            }
            if (SQLDatabase.Text == "")
            {
                mainErrorProvider.SetError(SQLDatabase, "Database vereist");
            }
            else
            {
                mainErrorProvider.SetError(SQLDatabase, "");
            }
            if (SQLUsername.Text == "")
            {

                mainErrorProvider.SetError(SQLUsername, "Gebruikersnaam vereist");
            }
            else
            {
                mainErrorProvider.SetError(SQLUsername, "");
            }
            if (SQLPassword.Text == "")
            {

                mainErrorProvider.SetError(SQLPassword, "Wachtwoord vereist");
            }
            else
            {
                mainErrorProvider.SetError(SQLPassword, "");
            }
            if (SQLIPAddress.Text != "" && SQLDatabase.Text != "" && SQLUsername.Text != "" && SQLPassword.Text != "")
            {
                // save shit
                Properties.Settings.Default.CiscoToolServerIP = SQLIPAddress.Text;
                Properties.Settings.Default.CiscoToolServerDatabase = SQLDatabase.Text;
                Properties.Settings.Default.CiscoToolServerUsername = SQLUsername.Text;
                Properties.Settings.Default.CiscoToolServerPassword = SQLPassword.Text;

                Properties.Settings.Default.Save();

                this.DialogResult = DialogResult.OK;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
