using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cisco_Tool.Views
{
    public partial class FirstRunScreen : Form
    {
        public FirstRunScreen()
        {
            InitializeComponent();
            tabs.TabPages.Remove(sqlPage);
            tabs.TabPages.Remove(summaryPage);
            BackButton.Text = "Annuleren";
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            switch (tabs.SelectedIndex)
            {
                case 0:
                    tabs.TabPages.Add(sqlPage);
                    tabs.SelectedIndex = 1;
                    BackButton.Text = "Vorige";
                    break;

                case 1:
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
                        NextButton.Text = "Voltooien";
                        summaryTextBox.Text += @"SQL gegevens";
                        summaryTextBox.Text += Environment.NewLine;
                        summaryTextBox.Text += "----------";
                        summaryTextBox.Text += Environment.NewLine;
                        summaryTextBox.Text += Environment.NewLine;
                        summaryTextBox.Text += @"IP adres: ";
                        summaryTextBox.Text += SQLIPAddress.Text;
                        summaryTextBox.Text += Environment.NewLine;
                        summaryTextBox.Text += @"Database: ";
                        summaryTextBox.Text += SQLDatabase.Text;
                        summaryTextBox.Text += Environment.NewLine;
                        summaryTextBox.Text += @"Gebruikersnaam: ";
                        summaryTextBox.Text += SQLUsername.Text;
                        summaryTextBox.Text += Environment.NewLine;



                        tabs.TabPages.Add(summaryPage);
                        tabs.SelectedIndex = 2;
                    }
                    break;

                case 2:
                    Properties.Settings.Default.CiscoToolServerIP = SQLIPAddress.Text;
                    Properties.Settings.Default.CiscoToolServerDatabase = SQLDatabase.Text;
                    Properties.Settings.Default.CiscoToolServerUsername = SQLUsername.Text;
                    Properties.Settings.Default.CiscoToolServerPassword = SQLPassword.Text;

                    Properties.Settings.Default.Save();
                    this.DialogResult = DialogResult.OK;
                    break;

                default:
                    MessageBox.Show("iets gaat niet goed - graag dit doorgeven aan het onwtikkelteam - Wizard nextbutton selectedindex " + tabs.SelectedIndex);
                    tabs.SelectedIndex = 0;
                    break;
            }        
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            switch (tabs.SelectedIndex)
            {
                case 0:
                    this.DialogResult = DialogResult.Cancel;
                    break;
                case 1:
                    BackButton.Text = "Annuleren";
                    tabs.TabPages.Remove(sqlPage);
                    tabs.SelectedIndex = 0;
                    break;

                case 2:
                    tabs.TabPages.Remove(summaryPage);
                    summaryTextBox.Clear();
                    tabs.SelectedIndex = 1;
                    break;

                default:
                    MessageBox.Show("iets gaat niet goed - graag dit doorgeven aan het onwtikkelteam - Wizard backbutton selectedindex " + tabs.SelectedIndex);
                    tabs.SelectedIndex = 0;
                    break;
            }
        }
    }
}
