using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cisco_Tool.Widgets.Views
{
    class Templates
    {
        public static Panel defaultPanel()
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
            TextBox outputbox = new TextBox();

            //properties
            topBar.Height = 32;
            topBar.Width = 250;
            topBar.BackColor = Color.Gray;
            topBar.Location = new Point(0, 0);

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

            commandName.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);
            commandName.ForeColor = Color.White;
            commandName.BackColor = Color.Transparent;
            commandName.Location = new Point(2, 11);
            commandName.Size = new Size(240, 25);
            commandName.TextAlign = ContentAlignment.MiddleCenter;

            outputbox.BackColor = Color.Gray;
            outputbox.ForeColor = Color.White;
            outputbox.Size = new Size(200, 150);
            outputbox.Location = new Point(20, 35);
            outputbox.Multiline = true;
            outputbox.ReadOnly = true;

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
    }
}
