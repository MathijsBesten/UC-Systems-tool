using System;
using System.Reflection;
using System.Windows.Forms;
using log4net;

namespace Cisco_Tool.Views
{
    public partial class SplashScreen : Form
    {
        private static readonly ILog Log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public SplashScreen()
        {
            InitializeComponent();
            Log.Info("Launched spash screen");
        }
        Timer _mainTimer;
        MainForm _mainform;

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            _mainTimer = new Timer();
            _mainTimer.Interval =250;
            _mainTimer.Start();
            _mainTimer.Tick += mianTimer_Tick;
            _mainform = new MainForm();
        }
        void mianTimer_Tick (object sender,EventArgs e)
        {
            _mainTimer.Stop();
            _mainform.Show();
            Hide();
        }
    }
}
