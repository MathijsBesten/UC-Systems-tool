using System;
using System.Reflection;
using System.Windows.Forms;
using log4net;

namespace Cisco_Tool.Views
{
    public partial class SplashScreen : Form
    {
        private static readonly ILog log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public SplashScreen()
        {
            InitializeComponent();
            log.Info("Launched spash screen");
        }
        Timer mainTimer;
        MainForm mainform;

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            mainTimer = new Timer();
            mainTimer.Interval =250;
            mainTimer.Start();
            mainTimer.Tick += mianTimer_Tick;
            mainform = new MainForm();
        }
        void mianTimer_Tick (object sender,EventArgs e)
        {
            mainTimer.Stop();
            mainform.Show();
            Hide();
        }
    }
}
