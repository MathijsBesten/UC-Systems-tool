namespace Cisco_Tool.Views
{
    partial class AboutScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutScreen));
            this.applicationName = new System.Windows.Forms.Label();
            this.UCLogo = new System.Windows.Forms.PictureBox();
            this.aboutInfo = new System.Windows.Forms.RichTextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.linkLabelAuthor = new System.Windows.Forms.LinkLabel();
            this.authorLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UCSystemsLink = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.UCLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // applicationName
            // 
            this.applicationName.AutoSize = true;
            this.applicationName.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applicationName.Location = new System.Drawing.Point(52, 208);
            this.applicationName.Name = "applicationName";
            this.applicationName.Size = new System.Drawing.Size(126, 29);
            this.applicationName.TabIndex = 5;
            this.applicationName.Text = "Cisco Tool";
            // 
            // UCLogo
            // 
            this.UCLogo.Image = ((System.Drawing.Image)(resources.GetObject("UCLogo.Image")));
            this.UCLogo.Location = new System.Drawing.Point(47, 65);
            this.UCLogo.Name = "UCLogo";
            this.UCLogo.Size = new System.Drawing.Size(131, 139);
            this.UCLogo.TabIndex = 4;
            this.UCLogo.TabStop = false;
            // 
            // aboutInfo
            // 
            this.aboutInfo.Location = new System.Drawing.Point(261, 133);
            this.aboutInfo.Name = "aboutInfo";
            this.aboutInfo.ReadOnly = true;
            this.aboutInfo.Size = new System.Drawing.Size(481, 306);
            this.aboutInfo.TabIndex = 7;
            this.aboutInfo.TabStop = false;
            this.aboutInfo.Text = resources.GetString("aboutInfo.Text");
            this.aboutInfo.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.aboutInfo_LinkClicked);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(426, 467);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(122, 38);
            this.OKButton.TabIndex = 8;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // linkLabelAuthor
            // 
            this.linkLabelAuthor.AutoSize = true;
            this.linkLabelAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelAuthor.Location = new System.Drawing.Point(353, 65);
            this.linkLabelAuthor.Name = "linkLabelAuthor";
            this.linkLabelAuthor.Size = new System.Drawing.Size(121, 16);
            this.linkLabelAuthor.TabIndex = 9;
            this.linkLabelAuthor.TabStop = true;
            this.linkLabelAuthor.Text = "Mathijs den Besten";
            this.linkLabelAuthor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAuthor_LinkClicked);
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorLabel.Location = new System.Drawing.Point(258, 65);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(52, 16);
            this.authorLabel.TabIndex = 10;
            this.authorLabel.Text = "Author :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(258, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Homepage :";
            // 
            // UCSystemsLink
            // 
            this.UCSystemsLink.AutoSize = true;
            this.UCSystemsLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UCSystemsLink.Location = new System.Drawing.Point(353, 99);
            this.UCSystemsLink.Name = "UCSystemsLink";
            this.UCSystemsLink.Size = new System.Drawing.Size(128, 16);
            this.UCSystemsLink.TabIndex = 11;
            this.UCSystemsLink.TabStop = true;
            this.UCSystemsLink.Text = "https://ucsystems.nl/";
            this.UCSystemsLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UCSystemsLink_LinkClicked);
            // 
            // AboutScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UCSystemsLink);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.linkLabelAuthor);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.aboutInfo);
            this.Controls.Add(this.applicationName);
            this.Controls.Add(this.UCLogo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About CIsco Tool";
            ((System.ComponentModel.ISupportInitialize)(this.UCLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label applicationName;
        private System.Windows.Forms.PictureBox UCLogo;
        private System.Windows.Forms.RichTextBox aboutInfo;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.LinkLabel linkLabelAuthor;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel UCSystemsLink;
    }
}