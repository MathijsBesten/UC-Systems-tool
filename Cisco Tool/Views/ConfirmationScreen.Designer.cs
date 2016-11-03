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
            this.summaryPanel = new System.Windows.Forms.Panel();
            this.summaryPanelTabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.summaryTitle = new System.Windows.Forms.Label();
            this.summaryOutputBox = new System.Windows.Forms.RichTextBox();
            this.summaryPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // summaryPanel
            // 
            this.summaryPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.summaryPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.summaryPanel.Controls.Add(this.summaryOutputBox);
            this.summaryPanel.Controls.Add(this.summaryPanelTabel);
            this.summaryPanel.Controls.Add(this.cancelButton);
            this.summaryPanel.Controls.Add(this.continueButton);
            this.summaryPanel.ForeColor = System.Drawing.Color.White;
            this.summaryPanel.Location = new System.Drawing.Point(46, 75);
            this.summaryPanel.Name = "summaryPanel";
            this.summaryPanel.Size = new System.Drawing.Size(525, 622);
            this.summaryPanel.TabIndex = 23;
            // 
            // summaryPanelTabel
            // 
            this.summaryPanelTabel.AutoSize = true;
            this.summaryPanelTabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.summaryPanelTabel.ForeColor = System.Drawing.Color.White;
            this.summaryPanelTabel.Location = new System.Drawing.Point(27, 21);
            this.summaryPanelTabel.Name = "summaryPanelTabel";
            this.summaryPanelTabel.Size = new System.Drawing.Size(90, 25);
            this.summaryPanelTabel.TabIndex = 29;
            this.summaryPanelTabel.Text = "overzicht";
            // 
            // cancelButton
            // 
            this.cancelButton.ForeColor = System.Drawing.Color.Black;
            this.cancelButton.Location = new System.Drawing.Point(386, 562);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 29);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Annuleren";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // continueButton
            // 
            this.continueButton.ForeColor = System.Drawing.Color.Black;
            this.continueButton.Location = new System.Drawing.Point(281, 562);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(94, 29);
            this.continueButton.TabIndex = 1;
            this.continueButton.Text = "Doorgaan";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // summaryTitle
            // 
            this.summaryTitle.AutoSize = true;
            this.summaryTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.summaryTitle.ForeColor = System.Drawing.Color.White;
            this.summaryTitle.Location = new System.Drawing.Point(22, 33);
            this.summaryTitle.Name = "summaryTitle";
            this.summaryTitle.Size = new System.Drawing.Size(379, 25);
            this.summaryTitle.TabIndex = 24;
            this.summaryTitle.Text = "Commando uitvoeren op meerdere routers";
            // 
            // summaryOutputBox
            // 
            this.summaryOutputBox.Location = new System.Drawing.Point(32, 64);
            this.summaryOutputBox.Name = "summaryOutputBox";
            this.summaryOutputBox.Size = new System.Drawing.Size(450, 470);
            this.summaryOutputBox.TabIndex = 30;
            this.summaryOutputBox.Text = "";
            // 
            // ConfirmationScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(645, 756);
            this.Controls.Add(this.summaryTitle);
            this.Controls.Add(this.summaryPanel);
            this.Name = "ConfirmationScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "confirmationScreen";
            this.summaryPanel.ResumeLayout(false);
            this.summaryPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel summaryPanel;
        private System.Windows.Forms.Label summaryTitle;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Label summaryPanelTabel;
        private System.Windows.Forms.RichTextBox summaryOutputBox;
    }
}