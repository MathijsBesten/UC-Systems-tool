using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cisco_Tool.Widgets.Templates
{
    //control is part of control
    public class ExecuteTemplate : Panel
    {
        //public variables

        public Panel templatePanel = new Panel();
        public Panel topBar = new Panel();
        public Label titleWidgetLabel = new Label();
        public PictureBox minMaxWidgetPicturebox = new PictureBox();
        public PictureBox closeWidgetPicturebox = new PictureBox();
        public Panel informationPanel = new Panel();
        public Label commandName = new Label();
        public RichTextBox outputbox = new RichTextBox();
        public Button runButton = new Button();

        // new sort of control
        public ExecuteTemplate()
        {
            topBar.Height = 32;
            topBar.Width = 250;
            topBar.BackColor = Color.Gray;
            topBar.Location = new Point(0, 0);

            titleWidgetLabel.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
            titleWidgetLabel.Location = new Point(3, 8);
            titleWidgetLabel.Size = new Size(175, 25);

            informationPanel.Size = new Size(244, 193);
            informationPanel.BackColor = Color.Gray;
            informationPanel.BorderStyle = BorderStyle.Fixed3D;
            informationPanel.Location = new Point(3, 33);

            minMaxWidgetPicturebox.Image = Properties.Resources.windows_1;
            minMaxWidgetPicturebox.Height = 25;
            minMaxWidgetPicturebox.Width = 25;
            minMaxWidgetPicturebox.SizeMode = PictureBoxSizeMode.Zoom;
            minMaxWidgetPicturebox.Location = new Point(185, 3);

            closeWidgetPicturebox.Image = Properties.Resources.close;
            closeWidgetPicturebox.Height = 25;
            closeWidgetPicturebox.Width = 25;
            closeWidgetPicturebox.SizeMode = PictureBoxSizeMode.Zoom;
            closeWidgetPicturebox.Location = new Point(219, 3);

            commandName.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            commandName.ForeColor = Color.White;
            commandName.BackColor = Color.Transparent;
            commandName.Location = new Point(3, 8);
            commandName.Size = new Size(240, 25);

            runButton.BackColor = Color.DimGray;
            runButton.Size = new Size(139, 42);
            runButton.Location = new Point(44, 128);
            runButton.ForeColor = Color.White;

            outputbox.BackColor = Color.Gray;
            outputbox.ForeColor = Color.White;
            outputbox.Size = new Size(218, 57);
            outputbox.Location = new Point(11, 35);
            outputbox.Multiline = true;
            outputbox.ScrollBars = RichTextBoxScrollBars.Both;
            outputbox.ReadOnly = true;
            outputbox.Cursor = Cursors.Arrow;
            outputbox.Visible = false;

            this.BackColor = Color.Gray;
            this.ForeColor = Color.White;
            this.Size = new Size(250, 230);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Visible = true;

            //assign controls to panels
            topBar.Controls.Add(titleWidgetLabel);
            topBar.Controls.Add(minMaxWidgetPicturebox);
            topBar.Controls.Add(closeWidgetPicturebox);

            informationPanel.Controls.Add(commandName);
            informationPanel.Controls.Add(outputbox);
            informationPanel.Controls.Add(runButton);

            this.Controls.Add(topBar);
            this.Controls.Add(informationPanel);
        }
    }
}
