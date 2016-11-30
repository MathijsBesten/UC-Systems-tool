using System;
using System.Windows.Forms;

using Cisco_Tool.Functions.Network;

namespace Cisco_Tool.Widgets.Views
{
    public partial class SelctionWizard : Form
    {
        public SelctionWizard()
        {
            InitializeComponent();
            Log.Info("Launched selection wizard Screen");
        }
        public string Ipadres  { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        private static readonly log4net.ILog Log =
             log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private void LoginButton_Click(object sender, EventArgs e)
        {
            bool ipIsValid = false;
            if (LoginIPAddress.Text != "")
            {
                ipIsValid = Validation.ValidateIPv4(LoginIPAddress.Text);
                loginScreenErrorHandler.SetError(LoginIPAddress,
                    !ipIsValid ? "Ip adres is niet een correct IPv4 adres" : "");
            }
            else
            {
                loginScreenErrorHandler.SetError(LoginIPAddress, "Geef IPv4 ip adres op van een cisco router");
            }
            loginScreenErrorHandler.SetError(LoginUsername, LoginUsername.Text != "" ? "" : "Geef gebruikersnaam op");
            loginScreenErrorHandler.SetError(LoginPassword, LoginPassword.Text != "" ? "" : "Geef wachtwoord op");
            if ((loginIPLabel.Text != "" && ipIsValid == true) && LoginUsername.Text != "" && LoginPassword.Text != "")
            {
                Ipadres =  LoginIPAddress.Text;
                Username = LoginUsername.Text;
                Password = LoginPassword.Text;

                Log.Info("User details are correcly saved for widget creator");
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }
    }
}
