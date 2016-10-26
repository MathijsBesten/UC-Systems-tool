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
        public SplashScreen()
        {
            InitializeComponent();
        }
        Timer mainTimer;
        MainForm mainform;

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            mainTimer = new Timer();
            mainTimer.Interval =500;
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
