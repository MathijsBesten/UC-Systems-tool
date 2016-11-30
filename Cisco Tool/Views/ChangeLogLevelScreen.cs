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
        private static readonly ILog Log =
         LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private bool _dragging;
        private Point _startPoint = new Point(0, 0);
        public TextBox DisclaimerTextbox = new TextBox();
        public Panel ClosedisclaimerPanel = new Panel();
        public Label ClosedisclaimerText = new Label();

        public ChangeLogLevelScreen()
        {
            InitializeComponent();
            DisclaimerTextbox.Multiline = true;
            DisclaimerTextbox.Size = new Size(145,189);
            DisclaimerTextbox.Text = "Het veranderen van het logniveau heeft een tijdelijk effect - het logniveau zal worden teruggezet bij het afsluiten";
            DisclaimerTextbox.ReadOnly = true;
            DisclaimerTextbox.TabStop = false;
            DisclaimerTextbox.Font = new Font("Microsoft Sans Serif", 10);
            DisclaimerTextbox.BackColor = Color.White;
            DisclaimerTextbox.ForeColor = Color.Black;
            DisclaimerTextbox.BorderStyle = BorderStyle.None;
            DisclaimerTextbox.Location = new Point(0, 56);
            Controls.Add(DisclaimerTextbox);
            DisclaimerTextbox.BringToFront();



            ClosedisclaimerPanel.Location = new Point(0, 195);
            ClosedisclaimerPanel.Size = new Size(145, 50);
            ClosedisclaimerPanel.BackColor = Color.WhiteSmoke;
            ClosedisclaimerPanel.ForeColor = Color.Black;
            ClosedisclaimerPanel.Click += ClosedisclaimerPanel_Click;
            ClosedisclaimerPanel.BorderStyle = BorderStyle.None;

            ClosedisclaimerText.Text = "Doorgaan";
            ClosedisclaimerText.Font = new Font("Microsoft Sans Serif", 11);
            ClosedisclaimerText.AutoSize = false;
            ClosedisclaimerText.TextAlign = ContentAlignment.MiddleCenter;
            ClosedisclaimerText.Dock = DockStyle.Fill;

            ClosedisclaimerText.Click += ClosedisclaimerText_Click;
            

            Controls.Add(ClosedisclaimerPanel);
            ClosedisclaimerPanel.Controls.Add(ClosedisclaimerText);
            ClosedisclaimerPanel.BringToFront();

            if (Log.IsDebugEnabled)
                debugLevel.Select();
            else if (Log.IsInfoEnabled)
                infoLevel.Select();
            else if (Log.IsErrorEnabled)
                errorLevel.Select();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int csDropshadow = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= csDropshadow;
                return cp;
            }
        }


        private void titleLabel_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void titleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _startPoint = new Point(e.X, e.Y);
        }

        private void titleLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - _startPoint.X, p.Y - _startPoint.Y);
            }
        }
        private void ReturnOk()
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
        private void CloseDisclaimer()
        {
            ClosedisclaimerText.Visible = false;
            ClosedisclaimerPanel.Visible = false;
            DisclaimerTextbox.Visible = false;
        }
        private void OKLabel_Click(object sender, EventArgs e)
        {
            ReturnOk();
        }

        private void OKpictureBox_Click(object sender, EventArgs e)
        {
            ReturnOk();
        }

        private void OkPanel_MouseClick(object sender, MouseEventArgs e)
        {
            ReturnOk();
        }
        private void ClosedisclaimerText_Click(object sender, EventArgs e)
        {
            CloseDisclaimer();
        }

        private void ClosedisclaimerPanel_Click(object sender, EventArgs e)
        {
            CloseDisclaimer();
        }
    }
}
