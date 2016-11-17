namespace Cisco_Tool.Views
{
    partial class ConfirmationScreen
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
            this.summaryOutputBox = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.summaryTitle = new System.Windows.Forms.Label();
            this.cancelPanel = new System.Windows.Forms.Panel();
            this.cancelPicturebox = new System.Windows.Forms.PictureBox();
            this.cancelLabel = new System.Windows.Forms.Label();
            this.confirmPicturebox = new System.Windows.Forms.PictureBox();
            this.confirmLabel = new System.Windows.Forms.Label();
            this.continuePanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.cancelPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cancelPicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirmPicturebox)).BeginInit();
            this.continuePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // summaryOutputBox
            // 
            this.summaryOutputBox.BackColor = System.Drawing.Color.White;
            this.summaryOutputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.summaryOutputBox.ForeColor = System.Drawing.Color.Black;
            this.summaryOutputBox.Location = new System.Drawing.Point(30, 89);
            this.summaryOutputBox.Margin = new System.Windows.Forms.Padding(10);
            this.summaryOutputBox.Name = "summaryOutputBox";
            this.summaryOutputBox.Size = new System.Drawing.Size(385, 458);
            this.summaryOutputBox.TabIndex = 33;
            this.summaryOutputBox.TabStop = false;
            this.summaryOutputBox.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.summaryTitle);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 70);
            this.panel1.TabIndex = 36;
            // 
            // summaryTitle
            // 
            this.summaryTitle.AutoSize = true;
            this.summaryTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.summaryTitle.ForeColor = System.Drawing.Color.White;
            this.summaryTitle.Location = new System.Drawing.Point(12, 20);
            this.summaryTitle.Name = "summaryTitle";
            this.summaryTitle.Size = new System.Drawing.Size(313, 25);
            this.summaryTitle.TabIndex = 25;
            this.summaryTitle.Text = "Commando\'s uitvoeren - Overzicht";
            // 
            // cancelPanel
            // 
            this.cancelPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(110)))), ((int)(((byte)(103)))));
            this.cancelPanel.Controls.Add(this.cancelPicturebox);
            this.cancelPanel.Controls.Add(this.cancelLabel);
            this.cancelPanel.Location = new System.Drawing.Point(168, 560);
            this.cancelPanel.Name = "cancelPanel";
            this.cancelPanel.Size = new System.Drawing.Size(132, 42);
            this.cancelPanel.TabIndex = 39;
            this.cancelPanel.Click += new System.EventHandler(this.cancelPanel_Click);
            // 
            // cancelPicturebox
            // 
            this.cancelPicturebox.Image = global::Cisco_Tool.Properties.Resources.close;
            this.cancelPicturebox.Location = new System.Drawing.Point(90, 8);
            this.cancelPicturebox.Name = "cancelPicturebox";
            this.cancelPicturebox.Size = new System.Drawing.Size(25, 25);
            this.cancelPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cancelPicturebox.TabIndex = 1;
            this.cancelPicturebox.TabStop = false;
            this.cancelPicturebox.Click += new System.EventHandler(this.cancelPicturebox_Click);
            // 
            // cancelLabel
            // 
            this.cancelLabel.AutoSize = true;
            this.cancelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelLabel.Location = new System.Drawing.Point(21, 13);
            this.cancelLabel.Name = "cancelLabel";
            this.cancelLabel.Size = new System.Drawing.Size(63, 15);
            this.cancelLabel.TabIndex = 0;
            this.cancelLabel.Text = "Annuleren";
            this.cancelLabel.Click += new System.EventHandler(this.cancelLabel_Click);
            // 
            // confirmPicturebox
            // 
            this.confirmPicturebox.Image = global::Cisco_Tool.Properties.Resources._checked;
            this.confirmPicturebox.Location = new System.Drawing.Point(90, 8);
            this.confirmPicturebox.Name = "confirmPicturebox";
            this.confirmPicturebox.Size = new System.Drawing.Size(25, 25);
            this.confirmPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.confirmPicturebox.TabIndex = 1;
            this.confirmPicturebox.TabStop = false;
            this.confirmPicturebox.Click += new System.EventHandler(this.confirmPicturebox_Click);
            // 
            // confirmLabel
            // 
            this.confirmLabel.AutoSize = true;
            this.confirmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmLabel.Location = new System.Drawing.Point(15, 12);
            this.confirmLabel.Name = "confirmLabel";
            this.confirmLabel.Size = new System.Drawing.Size(62, 15);
            this.confirmLabel.TabIndex = 0;
            this.confirmLabel.Text = "Doorgaan";
            this.confirmLabel.Click += new System.EventHandler(this.confirmLabel_Click);
            // 
            // continuePanel
            // 
            this.continuePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(206)))), ((int)(((byte)(104)))));
            this.continuePanel.Controls.Add(this.confirmPicturebox);
            this.continuePanel.Controls.Add(this.confirmLabel);
            this.continuePanel.Location = new System.Drawing.Point(30, 560);
            this.continuePanel.Name = "continuePanel";
            this.continuePanel.Size = new System.Drawing.Size(132, 42);
            this.continuePanel.TabIndex = 40;
            this.continuePanel.Click += new System.EventHandler(this.continuePanel_Click);
            // 
            // ConfirmationScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(450, 625);
            this.Controls.Add(this.continuePanel);
            this.Controls.Add(this.cancelPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.summaryOutputBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfirmationScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "confirmationScreen";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cancelPanel.ResumeLayout(false);
            this.cancelPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cancelPicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirmPicturebox)).EndInit();
            this.continuePanel.ResumeLayout(false);
            this.continuePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox summaryOutputBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label summaryTitle;
        private System.Windows.Forms.Panel cancelPanel;
        private System.Windows.Forms.PictureBox cancelPicturebox;
        private System.Windows.Forms.Label cancelLabel;
        private System.Windows.Forms.PictureBox confirmPicturebox;
        private System.Windows.Forms.Label confirmLabel;
        private System.Windows.Forms.Panel continuePanel;
    }
}