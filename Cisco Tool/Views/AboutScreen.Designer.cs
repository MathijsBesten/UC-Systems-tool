﻿using System.ComponentModel;
using System.Windows.Forms;

namespace Cisco_Tool.Views
{
    partial class AboutScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.linkLabelAuthor = new System.Windows.Forms.LinkLabel();
            this.authorLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UCSystemsLink = new System.Windows.Forms.LinkLabel();
            this.versionNumberLabel = new System.Windows.Forms.Label();
            this.versionNumber = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
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
            this.aboutInfo.Location = new System.Drawing.Point(261, 170);
            this.aboutInfo.Name = "aboutInfo";
            this.aboutInfo.ReadOnly = true;
            this.aboutInfo.Size = new System.Drawing.Size(481, 269);
            this.aboutInfo.TabIndex = 7;
            this.aboutInfo.TabStop = false;
            this.aboutInfo.Text = resources.GetString("aboutInfo.Text");
            this.aboutInfo.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.aboutInfo_LinkClicked);
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
            this.label2.Location = new System.Drawing.Point(258, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Homepage :";
            // 
            // UCSystemsLink
            // 
            this.UCSystemsLink.AutoSize = true;
            this.UCSystemsLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UCSystemsLink.Location = new System.Drawing.Point(353, 100);
            this.UCSystemsLink.Name = "UCSystemsLink";
            this.UCSystemsLink.Size = new System.Drawing.Size(128, 16);
            this.UCSystemsLink.TabIndex = 11;
            this.UCSystemsLink.TabStop = true;
            this.UCSystemsLink.Text = "https://ucsystems.nl/";
            this.UCSystemsLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UCSystemsLink_LinkClicked);
            // 
            // versionNumberLabel
            // 
            this.versionNumberLabel.AutoSize = true;
            this.versionNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionNumberLabel.Location = new System.Drawing.Point(258, 135);
            this.versionNumberLabel.Name = "versionNumberLabel";
            this.versionNumberLabel.Size = new System.Drawing.Size(98, 16);
            this.versionNumberLabel.TabIndex = 13;
            this.versionNumberLabel.Text = "Versienummer:";
            // 
            // versionNumber
            // 
            this.versionNumber.AutoSize = true;
            this.versionNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionNumber.Location = new System.Drawing.Point(353, 135);
            this.versionNumber.Name = "versionNumber";
            this.versionNumber.Size = new System.Drawing.Size(27, 16);
            this.versionNumber.TabIndex = 14;
            this.versionNumber.Text = "VN";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(441, 456);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(122, 39);
            this.OKButton.TabIndex = 42;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // AboutScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.versionNumber);
            this.Controls.Add(this.versionNumberLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UCSystemsLink);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.linkLabelAuthor);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About CIsco Tool";
            ((System.ComponentModel.ISupportInitialize)(this.UCLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label applicationName;
        private PictureBox UCLogo;
        private RichTextBox aboutInfo;
        private LinkLabel linkLabelAuthor;
        private Label authorLabel;
        private Label label2;
        private LinkLabel UCSystemsLink;
        private Label versionNumberLabel;
        private Label versionNumber;
        private Button OKButton;
    }
}