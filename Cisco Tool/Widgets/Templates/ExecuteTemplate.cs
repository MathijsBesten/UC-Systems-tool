﻿using System.Drawing;
using System.Windows.Forms;

namespace Cisco_Tool.Widgets.Templates
{
    // This widget will be used in the MainTableLayoutPanel
    // This control can also be added from the toolbox 
    public sealed class ExecuteTemplate : Panel
    {
        //public variables

        public Panel TemplatePanel = new Panel();
        public Panel TopBar = new Panel();
        public Label TitleWidgetLabel = new Label();
        public PictureBox MaxWidgetPicturebox = new PictureBox();
        public PictureBox CloseWidgetPicturebox = new PictureBox();
        public Panel InformationPanel = new Panel();
        public Label CommandName = new Label();
        public TextBox Outputbox = new TextBox();
        public Button RunButton = new Button();

        // new sort of control
        public ExecuteTemplate()
        {
            TopBar.Height = 32;
            TopBar.Width = 250;
            TopBar.BackColor = Color.FromArgb(255, 72, 201, 176);
            TopBar.Location = new Point(0, 0);

            TitleWidgetLabel.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
            TitleWidgetLabel.Location = new Point(3, 8);
            TitleWidgetLabel.Size = new Size(180, 25);

            InformationPanel.Size = new Size(250, 208);
            InformationPanel.BackColor = Color.FromArgb(255, 163, 228, 215);
            InformationPanel.BorderStyle = BorderStyle.None;
            InformationPanel.Location = new Point(0, 32);

            MaxWidgetPicturebox.Image = Properties.Resources.windows;
            MaxWidgetPicturebox.BorderStyle = BorderStyle.None;
            MaxWidgetPicturebox.Height = 20;
            MaxWidgetPicturebox.Width = 20;
            MaxWidgetPicturebox.SizeMode = PictureBoxSizeMode.Zoom;
            MaxWidgetPicturebox.Location = new Point(197, 6);

            CloseWidgetPicturebox.Image = Properties.Resources.multiply_1;
            CloseWidgetPicturebox.BorderStyle = BorderStyle.None;
            CloseWidgetPicturebox.Height = 20;
            CloseWidgetPicturebox.Width = 20;
            CloseWidgetPicturebox.SizeMode = PictureBoxSizeMode.Zoom;
            CloseWidgetPicturebox.Location = new Point(225, 6);

            CommandName.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            CommandName.ForeColor = Color.White;
            CommandName.BackColor = Color.Transparent;
            CommandName.Location = new Point(3, 8);
            CommandName.Size = new Size(240, 25);

            RunButton.BackColor = Color.DimGray;
            RunButton.Size = new Size(139, 42);
            RunButton.Location = new Point(44, 140);
            RunButton.ForeColor = Color.White;

            Outputbox.BackColor = Color.Gray;
            Outputbox.ForeColor = Color.White;
            Outputbox.Size = new Size(218, 100);
            Outputbox.Location = new Point(11, 35);
            Outputbox.Multiline = true;
            Outputbox.ScrollBars = ScrollBars.Vertical;
            Outputbox.BorderStyle = BorderStyle.None;
            Outputbox.ReadOnly = true;
            Outputbox.Cursor = Cursors.Arrow;
            Outputbox.Visible = false;

            this.BackColor = Color.Gray;
            this.ForeColor = Color.White;
            this.Size = new Size(250, 230);
            this.Margin = new Padding(0);
            this.Visible = true;

            //assign controls to panels
            TopBar.Controls.Add(TitleWidgetLabel);
            TopBar.Controls.Add(MaxWidgetPicturebox);
            TopBar.Controls.Add(CloseWidgetPicturebox);

            InformationPanel.Controls.Add(CommandName);
            InformationPanel.Controls.Add(Outputbox);
            InformationPanel.Controls.Add(RunButton);

            this.Controls.Add(TopBar);
            this.Controls.Add(InformationPanel);
        }
    }
}
