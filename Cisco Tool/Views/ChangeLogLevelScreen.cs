using log4net;
using log4net.Core;
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
    public partial class ChangeLogLevelScreen : Form
    {
        private static readonly log4net.ILog log =
         log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);
        public ChangeLogLevelScreen()
        {
            InitializeComponent();
            if (log.IsDebugEnabled)
                debugLevel.Select();
            else if (log.IsInfoEnabled)
                infoLevel.Select();
            else if (log.IsErrorEnabled)
                errorLevel.Select();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }


        private void titleLabel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void titleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void titleLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging == true)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }
        private void returnOK()
        {
            this.DialogResult = DialogResult.OK;
            if (debugLevel.Checked == true)
                LogManager.GetRepository().Threshold = Level.Debug;
            else if (infoLevel.Checked == true)
                LogManager.GetRepository().Threshold = Level.Info;
            else if (errorLevel.Checked == true)
                LogManager.GetRepository().Threshold = Level.Error;
        }
        private void OKLabel_Click(object sender, EventArgs e)
        {
            returnOK();
        }

        private void OKpictureBox_Click(object sender, EventArgs e)
        {
            returnOK();
        }

        private void OkPanel_MouseClick(object sender, MouseEventArgs e)
        {
            returnOK();
        }
    }
}
