namespace Cisco_Tool.Views
{
    partial class ChangeLogLevelScreen
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.debugLevel = new System.Windows.Forms.RadioButton();
            this.infoLevel = new System.Windows.Forms.RadioButton();
            this.errorLevel = new System.Windows.Forms.RadioButton();
            this.OkPanel = new System.Windows.Forms.Panel();
            this.OKLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.OkPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(145, 56);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "Log level";
            this.titleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleLabel_MouseDown);
            this.titleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titleLabel_MouseMove);
            this.titleLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.titleLabel_MouseUp);
            // 
            // debugLevel
            // 
            this.debugLevel.AutoSize = true;
            this.debugLevel.BackColor = System.Drawing.Color.Transparent;
            this.debugLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debugLevel.ForeColor = System.Drawing.Color.White;
            this.debugLevel.Location = new System.Drawing.Point(12, 127);
            this.debugLevel.Name = "debugLevel";
            this.debugLevel.Size = new System.Drawing.Size(75, 24);
            this.debugLevel.TabIndex = 7;
            this.debugLevel.Text = "Debug";
            this.debugLevel.UseVisualStyleBackColor = false;
            // 
            // infoLevel
            // 
            this.infoLevel.AutoSize = true;
            this.infoLevel.BackColor = System.Drawing.Color.Transparent;
            this.infoLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLevel.ForeColor = System.Drawing.Color.White;
            this.infoLevel.Location = new System.Drawing.Point(12, 93);
            this.infoLevel.Name = "infoLevel";
            this.infoLevel.Size = new System.Drawing.Size(99, 24);
            this.infoLevel.TabIndex = 6;
            this.infoLevel.Text = "Informatie";
            this.infoLevel.UseVisualStyleBackColor = false;
            // 
            // errorLevel
            // 
            this.errorLevel.AutoSize = true;
            this.errorLevel.BackColor = System.Drawing.Color.Transparent;
            this.errorLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLevel.ForeColor = System.Drawing.Color.White;
            this.errorLevel.Location = new System.Drawing.Point(12, 59);
            this.errorLevel.Name = "errorLevel";
            this.errorLevel.Size = new System.Drawing.Size(62, 24);
            this.errorLevel.TabIndex = 4;
            this.errorLevel.Text = "Error";
            this.errorLevel.UseVisualStyleBackColor = false;
            // 
            // OkPanel
            // 
            this.OkPanel.BackColor = System.Drawing.Color.PowderBlue;
            this.OkPanel.Controls.Add(this.OKLabel);
            this.OkPanel.Controls.Add(this.pictureBox1);
            this.OkPanel.Location = new System.Drawing.Point(12, 182);
            this.OkPanel.Name = "OkPanel";
            this.OkPanel.Size = new System.Drawing.Size(120, 50);
            this.OkPanel.TabIndex = 8;
            this.OkPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OkPanel_MouseClick);
            // 
            // OKLabel
            // 
            this.OKLabel.AutoSize = true;
            this.OKLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKLabel.ForeColor = System.Drawing.Color.Black;
            this.OKLabel.Location = new System.Drawing.Point(10, 15);
            this.OKLabel.Name = "OKLabel";
            this.OKLabel.Size = new System.Drawing.Size(63, 18);
            this.OKLabel.TabIndex = 1;
            this.OKLabel.Text = "Opslaan";
            this.OKLabel.Click += new System.EventHandler(this.OKLabel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cisco_Tool.Properties.Resources.checked_1;
            this.pictureBox1.Location = new System.Drawing.Point(81, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.OKpictureBox_Click);
            // 
            // ChangeLogLevelScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(145, 245);
            this.Controls.Add(this.OkPanel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.debugLevel);
            this.Controls.Add(this.infoLevel);
            this.Controls.Add(this.errorLevel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(100, 28);
            this.Name = "ChangeLogLevelScreen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Log level veranderen";
            this.OkPanel.ResumeLayout(false);
            this.OkPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.RadioButton debugLevel;
        private System.Windows.Forms.RadioButton infoLevel;
        private System.Windows.Forms.RadioButton errorLevel;
        private System.Windows.Forms.Panel OkPanel;
        private System.Windows.Forms.Label OKLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}