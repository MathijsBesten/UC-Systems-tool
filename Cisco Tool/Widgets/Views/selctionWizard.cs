using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Cisco_Tool.Functions.Network;

namespace Cisco_Tool.Widgets.Views
{
    public partial class selctionWizard : Form
    {
        public selctionWizard()
        {
            InitializeComponent();
            log.Info("Launched selection wizard Screen");
        }
        public string ipadres  { get; set; }
        public string username { get; set; }
        public string password { get; set; }


        private static readonly log4net.ILog log =
             log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private void LoginButton_Click(object sender, EventArgs e)
        {
            bool ipIsValid = false;
            if (LoginIPAddress.Text != "")
            {
                ipIsValid = validation.validateIPv4(LoginIPAddress.Text);
                if (!ipIsValid)
                {
                    loginScreenErrorHandler.SetError(LoginIPAddress,"Ip adres is niet een correct IPv4 adres");
                }
                else // ip is valid and should connect
                {
                    loginScreenErrorHandler.SetError(LoginIPAddress, "");
                }
            }
            else
            {
                loginScreenErrorHandler.SetError(LoginIPAddress, "Geef IPv4 ip adres op van een cisco router");
            }
            if (LoginUsername.Text != "")
            {
                loginScreenErrorHandler.SetError(LoginUsername, "");
            }
            else
            {
                loginScreenErrorHandler.SetError(LoginUsername, "Geef gebruikersnaam op");
            }
            if (LoginPassword.Text != "")
            {
                loginScreenErrorHandler.SetError(LoginPassword, "");
            }
            else
            {
                loginScreenErrorHandler.SetError(LoginPassword, "Geef wachtwoord op");
            }
            if ((loginIPLabel.Text != "" && ipIsValid == true) && LoginUsername.Text != "" && LoginPassword.Text != "")
            {
                ipadres =  LoginIPAddress.Text;
                username = LoginUsername.Text;
                password = LoginPassword.Text;

                log.Info("User details are correcly saved for widget creator");
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }
    }
}
