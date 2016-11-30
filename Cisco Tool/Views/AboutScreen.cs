using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using log4net;

namespace Cisco_Tool.Views
{
    public partial class AboutScreen : Form
    {
        private static readonly ILog Log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public AboutScreen()
        {
            InitializeComponent();
            string version = Assembly.GetExecutingAssembly()
                                           .GetName()
                                           .Version
                                           .ToString();
            versionNumber.Text = version;
            Log.Info("Launched About Screen");
            Log.Info(version);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void linkLabelAuthor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/MathijsBesten");
        }

        private void UCSystemsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://ucsystems.nl/");
        }

        private void aboutInfo_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
    }
}
