using System.Drawing;
using System.Windows.Forms;

namespace Cisco_Tool.Widgets.Templates
{    
    // This widget will be used in the MainTableLayoutPanel
    // This control can also be added from the toolbox 


    public sealed class InfoTemplate : Panel 
    {
        public Panel templatePanel = new Panel();
        public Panel topBar = new Panel();
        public Label titleWidgetLabel = new Label();
        public PictureBox maxWidgetPicturebox = new PictureBox();
        public PictureBox closeWidgetPicturebox = new PictureBox();
        public Panel informationPanel = new Panel();
        public Label commandName = new Label();
        public RichTextBox outputbox = new RichTextBox();

        public InfoTemplate()
        {
            topBar.Height = 32;
            topBar.Width = 250;
            topBar.BackColor = Color.FromArgb(255, 72, 201, 176);
            topBar.Location = new Point(0, 0);

            titleWidgetLabel.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
            titleWidgetLabel.Location = new Point(3, 8);
            titleWidgetLabel.Size = new Size(180, 25);

            informationPanel.Size = new Size(250, 208);
            informationPanel.BackColor = Color.FromArgb(255, 118, 215, 196);
            informationPanel.BorderStyle = BorderStyle.None;
            informationPanel.Location = new Point(0, 32);


            maxWidgetPicturebox.Image = Properties.Resources.windows;
            maxWidgetPicturebox.BorderStyle = BorderStyle.None;
            maxWidgetPicturebox.Height = 20;
            maxWidgetPicturebox.Width = 20;
            maxWidgetPicturebox.SizeMode = PictureBoxSizeMode.Zoom;
            maxWidgetPicturebox.Location = new Point(197, 6);

            closeWidgetPicturebox.Image = Properties.Resources.multiply_1;
            closeWidgetPicturebox.BorderStyle = BorderStyle.None;
            closeWidgetPicturebox.Height = 20;
            closeWidgetPicturebox.Width = 20;
            closeWidgetPicturebox.SizeMode = PictureBoxSizeMode.Zoom;
            closeWidgetPicturebox.Location = new Point(225, 6);


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
            outputbox.BorderStyle = BorderStyle.None;
            outputbox.ScrollBars = RichTextBoxScrollBars.Both;
            outputbox.ReadOnly = true;
            outputbox.Cursor = Cursors.Arrow;

            this.BackColor = Color.Gray;
            this.Size = new Size(250, 230);
            this.Margin = new Padding(0);
            this.Visible = true;

            //assign controls to panels
            topBar.Controls.Add(titleWidgetLabel);
            topBar.Controls.Add(maxWidgetPicturebox);
            topBar.Controls.Add(closeWidgetPicturebox);

            informationPanel.Controls.Add(commandName);
            informationPanel.Controls.Add(outputbox);

            this.Controls.Add(topBar);
            this.Controls.Add(informationPanel);
        }
    }
}
