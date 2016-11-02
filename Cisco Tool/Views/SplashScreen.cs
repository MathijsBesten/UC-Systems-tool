using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cisco_Tool.Views
{
    public partial class SplashScreen : Form
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
            this.Hide();
        }
    }
}
