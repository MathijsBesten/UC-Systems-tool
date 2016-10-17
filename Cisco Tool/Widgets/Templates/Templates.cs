using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cisco_Tool.Widgets.Views
{
    class Templates
    {
        public Panel defaultWidgetTemplate()
        {
            //main panel
            Panel templatePanel = new Panel();

            //controls
            Panel topBar = new Panel();
            Label titleWidgetLabel = new Label();
            PictureBox minMaxWidgetPicturebox = new PictureBox();
            PictureBox closeWidgetPicturebox = new PictureBox();
            Panel informationPanel = new Panel();
            Label commandName = new Label();
            RichTextBox outputbox = new RichTextBox();

            //properties
            topBar.Height = 32;
            topBar.Width = 250;
            topBar.BackColor = Color.Gray;
            topBar.Location = new Point(0, 0);

            titleWidgetLabel.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
            titleWidgetLabel.Location = new Point(3, 8);
            titleWidgetLabel.Size = new Size(175,25);

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

            outputbox.BackColor = Color.Gray;
            outputbox.ForeColor = Color.White;
            outputbox.Size = new Size(200, 150);
            outputbox.Location = new Point(20, 35);
            outputbox.Multiline = true;
            outputbox.ScrollBars = RichTextBoxScrollBars.Both;
            outputbox.ReadOnly = true;
            outputbox.Cursor = Cursors.Arrow;

            templatePanel.BackColor = Color.Gray;
            templatePanel.Size = new Size(250, 230);
            templatePanel.Margin = new System.Windows.Forms.Padding(0);

            //assign controls to panels
            topBar.Controls.Add(titleWidgetLabel);
            topBar.Controls.Add(minMaxWidgetPicturebox);
            topBar.Controls.Add(closeWidgetPicturebox);

            informationPanel.Controls.Add(commandName);
            informationPanel.Controls.Add(outputbox);

            templatePanel.Controls.Add(topBar);
            templatePanel.Controls.Add(informationPanel);
            return templatePanel;
        }

        public Panel executeWidgetTemplate()
        {
            //main panel
            Panel templatePanel = new Panel();

            //controls
            Panel topBar = new Panel();
            Label titleWidgetLabel = new Label();
            PictureBox minMaxWidgetPicturebox = new PictureBox();
            PictureBox closeWidgetPicturebox = new PictureBox();
            Panel informationPanel = new Panel();
            Label commandName = new Label();
            RichTextBox outputbox = new RichTextBox();
            Button runButton = new Button();

            //properties
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

            templatePanel.BackColor = Color.Gray;
            templatePanel.Size = new Size(250, 230);
            templatePanel.Margin = new System.Windows.Forms.Padding(0);

            //assign controls to panels
            topBar.Controls.Add(titleWidgetLabel);
            topBar.Controls.Add(minMaxWidgetPicturebox);
            topBar.Controls.Add(closeWidgetPicturebox);

            informationPanel.Controls.Add(commandName);
            informationPanel.Controls.Add(outputbox);
            informationPanel.Controls.Add(runButton);

            templatePanel.Controls.Add(topBar);
            templatePanel.Controls.Add(informationPanel);
            return templatePanel;
        }
    }
}
