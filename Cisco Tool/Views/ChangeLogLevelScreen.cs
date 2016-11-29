using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using log4net;
using log4net.Core;
using log4net.Repository.Hierarchy;

namespace Cisco_Tool.Views
{
    public partial class ChangeLogLevelScreen : Form
    {
        private static readonly ILog log =
         LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private bool dragging;
        private Point startPoint = new Point(0, 0);
        public TextBox disclaimerTextbox = new TextBox();
        public Panel closedisclaimerPanel = new Panel();
        public Label closedisclaimerText = new Label();

        public ChangeLogLevelScreen()
        {
            InitializeComponent();
            disclaimerTextbox.Multiline = true;
            disclaimerTextbox.Size = new Size(145,189);
            disclaimerTextbox.Text = "Het veranderen van het logniveau heeft een tijdelijk effect - het logniveau zal worden teruggezet bij het afsluiten";
            disclaimerTextbox.ReadOnly = true;
            disclaimerTextbox.TabStop = false;
            disclaimerTextbox.Font = new Font("Microsoft Sans Serif", 10);
            disclaimerTextbox.BackColor = Color.White;
            disclaimerTextbox.ForeColor = Color.Black;
            disclaimerTextbox.BorderStyle = BorderStyle.None;
            disclaimerTextbox.Location = new Point(0, 56);
            Controls.Add(disclaimerTextbox);
            disclaimerTextbox.BringToFront();



            closedisclaimerPanel.Location = new Point(0, 195);
            closedisclaimerPanel.Size = new Size(145, 50);
            closedisclaimerPanel.BackColor = Color.WhiteSmoke;
            closedisclaimerPanel.ForeColor = Color.Black;
            closedisclaimerPanel.Click += ClosedisclaimerPanel_Click;
            closedisclaimerPanel.BorderStyle = BorderStyle.None;

            closedisclaimerText.Text = "Doorgaan";
            closedisclaimerText.Font = new Font("Microsoft Sans Serif", 11);
            closedisclaimerText.AutoSize = false;
            closedisclaimerText.TextAlign = ContentAlignment.MiddleCenter;
            closedisclaimerText.Dock = DockStyle.Fill;

            closedisclaimerText.Click += ClosedisclaimerText_Click;
            

            Controls.Add(closedisclaimerPanel);
            closedisclaimerPanel.Controls.Add(closedisclaimerText);
            closedisclaimerPanel.BringToFront();

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
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }
        private void returnOK()
        {
            if (debugLevel.Checked)
                ((Hierarchy)LogManager.GetRepository()).Root.Level = Level.Debug;
            else if (infoLevel.Checked)
                ((Hierarchy)LogManager.GetRepository()).Root.Level = Level.Info;
            else if (errorLevel.Checked)
                ((Hierarchy)LogManager.GetRepository()).Root.Level = Level.Error;
            ((Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);
            DialogResult = DialogResult.OK;
        }
        private void closeDisclaimer()
        {
            closedisclaimerText.Visible = false;
            closedisclaimerPanel.Visible = false;
            disclaimerTextbox.Visible = false;
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
        private void ClosedisclaimerText_Click(object sender, EventArgs e)
        {
            closeDisclaimer();
        }

        private void ClosedisclaimerPanel_Click(object sender, EventArgs e)
        {
            closeDisclaimer();
        }
    }
}
