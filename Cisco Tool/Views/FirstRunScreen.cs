using System;
using System.Reflection;
using System.Windows.Forms;
using Cisco_Tool.Properties;
using log4net;

namespace Cisco_Tool.Views
{
    public partial class FirstRunScreen : Form
    {
        private static readonly ILog log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public FirstRunScreen()
        {
            InitializeComponent();
            tabs.TabPages.Remove(sqlPage);
            tabs.TabPages.Remove(summaryPage);
            BackButton.Text = "Annuleren";
            log.Info("Launched first run screen");
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
                    mainErrorProvider.SetError(SQLIPAddress, SQLIPAddress.Text == "" ? "gebruikersnaam vereist" : "");
                    mainErrorProvider.SetError(SQLDatabase, SQLDatabase.Text == "" ? "Database vereist" : "");
                    mainErrorProvider.SetError(SQLUsername, SQLUsername.Text == "" ? "Gebruikersnaam vereist" : "");
                    mainErrorProvider.SetError(SQLPassword, SQLPassword.Text == "" ? "Wachtwoord vereist" : "");

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

                        log.Info("Screenshot of user entered details");
                        log.Info("----------");
                        foreach (string line in summaryTextBox.Lines)
                        {
                            log.Info(line);
                        }
                        log.Info("----------");


                        tabs.TabPages.Add(summaryPage);
                        tabs.SelectedIndex = 2;
                    }
                    break;

                case 2:
                    Settings.Default.CiscoToolServerIP = SQLIPAddress.Text;
                    Settings.Default.CiscoToolServerDatabase = SQLDatabase.Text;
                    Settings.Default.CiscoToolServerUsername = SQLUsername.Text;
                    Settings.Default.CiscoToolServerPassword = SQLPassword.Text;

                    Settings.Default.Save();
                    log.Info("Database details are saved to local settings file");
                    DialogResult = DialogResult.OK;
                    break;

                default:
                    MessageBox.Show("iets gaat niet goed - graag dit doorgeven aan het onwtikkelteam - Wizard nextbutton selectedindex " + tabs.SelectedIndex);
                    log.Error("A error occurred while changing tabs - tabindex = " + tabs.SelectedIndex);
                    tabs.SelectedIndex = 0;
                    break;
            }        
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            switch (tabs.SelectedIndex)
            {
                case 0:
                    log.Info("User closed the first run screen ");
                    DialogResult = DialogResult.Cancel;
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
                    log.Error("A error occurred while changing tabs - tabindex = " + tabs.SelectedIndex);
                    tabs.SelectedIndex = 0;
                    break;
            }
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabs.SelectedIndex)
            {
                case 0:
                    BackButton.Text = "Annuleren";
                    NextButton.Text = "Volgende";
                    break;
                case 1:
                    BackButton.Text = "Vorige";
                    NextButton.Text = "Volgende";
                    break;
                case 2:
                    BackButton.Text = "Vorige";
                    NextButton.Text = "Voltooien";
                    break;
            }
        }
    }
}
