namespace Cisco_Tool.Widgets.Views
{
    partial class WidgetCreator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WidgetCreator));
            this.NewWidgetChoicePanel = new System.Windows.Forms.Panel();
            this.newWidgetUseSelectionCheckbox = new System.Windows.Forms.CheckBox();
            this.useSelectionLabel = new System.Windows.Forms.Label();
            this.NewWidgetCommandtype = new System.Windows.Forms.ComboBox();
            this.AddNewCommandTitle = new System.Windows.Forms.Label();
            this.NewWidgetAddButton = new System.Windows.Forms.Button();
            this.NewWidgetCommandLabel = new System.Windows.Forms.Label();
            this.NewWidgetCommand = new System.Windows.Forms.TextBox();
            this.NewWidgetNameLabel = new System.Windows.Forms.Label();
            this.NewWidgetName = new System.Windows.Forms.TextBox();
            this.NewWidgetCommandtypeLabel = new System.Windows.Forms.Label();
            this.NewWidgetInformationPanel = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.newWidgetInformationLabel = new System.Windows.Forms.Label();
            this.choosenWidgetType = new System.Windows.Forms.Label();
            this.selectionPanel = new System.Windows.Forms.Panel();
            this.SelectionWizard = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.widgetCreatorErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.NewWidgetChoicePanel.SuspendLayout();
            this.NewWidgetInformationPanel.SuspendLayout();
            this.selectionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.widgetCreatorErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // NewWidgetChoicePanel
            // 
            this.NewWidgetChoicePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NewWidgetChoicePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NewWidgetChoicePanel.Controls.Add(this.newWidgetUseSelectionCheckbox);
            this.NewWidgetChoicePanel.Controls.Add(this.useSelectionLabel);
            this.NewWidgetChoicePanel.Controls.Add(this.NewWidgetCommandtype);
            this.NewWidgetChoicePanel.Controls.Add(this.AddNewCommandTitle);
            this.NewWidgetChoicePanel.Controls.Add(this.NewWidgetAddButton);
            this.NewWidgetChoicePanel.Controls.Add(this.NewWidgetCommandLabel);
            this.NewWidgetChoicePanel.Controls.Add(this.NewWidgetCommand);
            this.NewWidgetChoicePanel.Controls.Add(this.NewWidgetNameLabel);
            this.NewWidgetChoicePanel.Controls.Add(this.NewWidgetName);
            this.NewWidgetChoicePanel.Controls.Add(this.NewWidgetCommandtypeLabel);
            this.NewWidgetChoicePanel.ForeColor = System.Drawing.Color.White;
            this.NewWidgetChoicePanel.Location = new System.Drawing.Point(30, 12);
            this.NewWidgetChoicePanel.Name = "NewWidgetChoicePanel";
            this.NewWidgetChoicePanel.Size = new System.Drawing.Size(386, 211);
            this.NewWidgetChoicePanel.TabIndex = 14;
            // 
            // newWidgetUseSelectionCheckbox
            // 
            this.newWidgetUseSelectionCheckbox.AutoSize = true;
            this.newWidgetUseSelectionCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newWidgetUseSelectionCheckbox.Location = new System.Drawing.Point(147, 132);
            this.newWidgetUseSelectionCheckbox.Name = "newWidgetUseSelectionCheckbox";
            this.newWidgetUseSelectionCheckbox.Size = new System.Drawing.Size(173, 17);
            this.newWidgetUseSelectionCheckbox.TabIndex = 19;
            this.newWidgetUseSelectionCheckbox.Text = "Laat leeg voor complete output";
            this.newWidgetUseSelectionCheckbox.UseVisualStyleBackColor = true;
            this.newWidgetUseSelectionCheckbox.CheckedChanged += new System.EventHandler(this.newWidgetUseSelectionCheckbox_CheckedChanged);
            // 
            // useSelectionLabel
            // 
            this.useSelectionLabel.AutoSize = true;
            this.useSelectionLabel.Location = new System.Drawing.Point(41, 132);
            this.useSelectionLabel.Name = "useSelectionLabel";
            this.useSelectionLabel.Size = new System.Drawing.Size(85, 13);
            this.useSelectionLabel.TabIndex = 18;
            this.useSelectionLabel.Text = "Gebruik Selectie";
            // 
            // NewWidgetCommandtype
            // 
            this.NewWidgetCommandtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NewWidgetCommandtype.FormattingEnabled = true;
            this.NewWidgetCommandtype.Items.AddRange(new object[] {
            "Informatie",
            "Uitvoeren"});
            this.NewWidgetCommandtype.Location = new System.Drawing.Point(147, 79);
            this.NewWidgetCommandtype.Name = "NewWidgetCommandtype";
            this.NewWidgetCommandtype.Size = new System.Drawing.Size(208, 21);
            this.NewWidgetCommandtype.TabIndex = 17;
            this.NewWidgetCommandtype.TextChanged += new System.EventHandler(this.NewWidgetCommandtype_TextChanged);
            // 
            // AddNewCommandTitle
            // 
            this.AddNewCommandTitle.AutoSize = true;
            this.AddNewCommandTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.AddNewCommandTitle.Location = new System.Drawing.Point(16, 17);
            this.AddNewCommandTitle.Name = "AddNewCommandTitle";
            this.AddNewCommandTitle.Size = new System.Drawing.Size(171, 25);
            this.AddNewCommandTitle.TabIndex = 10;
            this.AddNewCommandTitle.Text = "Widget toevoegen";
            // 
            // NewWidgetAddButton
            // 
            this.NewWidgetAddButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.NewWidgetAddButton.ForeColor = System.Drawing.Color.Black;
            this.NewWidgetAddButton.Location = new System.Drawing.Point(21, 167);
            this.NewWidgetAddButton.Name = "NewWidgetAddButton";
            this.NewWidgetAddButton.Size = new System.Drawing.Size(100, 23);
            this.NewWidgetAddButton.TabIndex = 5;
            this.NewWidgetAddButton.Text = "Toevoegen";
            this.NewWidgetAddButton.UseVisualStyleBackColor = true;
            this.NewWidgetAddButton.Click += new System.EventHandler(this.NewWidgetAddButton_Click);
            // 
            // NewWidgetCommandLabel
            // 
            this.NewWidgetCommandLabel.AutoSize = true;
            this.NewWidgetCommandLabel.Location = new System.Drawing.Point(41, 108);
            this.NewWidgetCommandLabel.Name = "NewWidgetCommandLabel";
            this.NewWidgetCommandLabel.Size = new System.Drawing.Size(60, 13);
            this.NewWidgetCommandLabel.TabIndex = 16;
            this.NewWidgetCommandLabel.Text = "Commando";
            // 
            // NewWidgetCommand
            // 
            this.NewWidgetCommand.Location = new System.Drawing.Point(147, 105);
            this.NewWidgetCommand.Name = "NewWidgetCommand";
            this.NewWidgetCommand.Size = new System.Drawing.Size(208, 20);
            this.NewWidgetCommand.TabIndex = 4;
            // 
            // NewWidgetNameLabel
            // 
            this.NewWidgetNameLabel.AutoSize = true;
            this.NewWidgetNameLabel.Location = new System.Drawing.Point(41, 56);
            this.NewWidgetNameLabel.Name = "NewWidgetNameLabel";
            this.NewWidgetNameLabel.Size = new System.Drawing.Size(70, 13);
            this.NewWidgetNameLabel.TabIndex = 14;
            this.NewWidgetNameLabel.Text = "Widget naam";
            // 
            // NewWidgetName
            // 
            this.NewWidgetName.Location = new System.Drawing.Point(147, 53);
            this.NewWidgetName.Name = "NewWidgetName";
            this.NewWidgetName.Size = new System.Drawing.Size(208, 20);
            this.NewWidgetName.TabIndex = 2;
            // 
            // NewWidgetCommandtypeLabel
            // 
            this.NewWidgetCommandtypeLabel.AutoSize = true;
            this.NewWidgetCommandtypeLabel.Location = new System.Drawing.Point(41, 82);
            this.NewWidgetCommandtypeLabel.Name = "NewWidgetCommandtypeLabel";
            this.NewWidgetCommandtypeLabel.Size = new System.Drawing.Size(86, 13);
            this.NewWidgetCommandtypeLabel.TabIndex = 12;
            this.NewWidgetCommandtypeLabel.Text = "Type commando";
            // 
            // NewWidgetInformationPanel
            // 
            this.NewWidgetInformationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NewWidgetInformationPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NewWidgetInformationPanel.Controls.Add(this.textBox3);
            this.NewWidgetInformationPanel.Controls.Add(this.textBox2);
            this.NewWidgetInformationPanel.Controls.Add(this.label1);
            this.NewWidgetInformationPanel.Controls.Add(this.textBox1);
            this.NewWidgetInformationPanel.Controls.Add(this.newWidgetInformationLabel);
            this.NewWidgetInformationPanel.Controls.Add(this.choosenWidgetType);
            this.NewWidgetInformationPanel.ForeColor = System.Drawing.Color.White;
            this.NewWidgetInformationPanel.Location = new System.Drawing.Point(488, 12);
            this.NewWidgetInformationPanel.Name = "NewWidgetInformationPanel";
            this.NewWidgetInformationPanel.Size = new System.Drawing.Size(317, 469);
            this.NewWidgetInformationPanel.TabIndex = 15;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(34, 321);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(211, 56);
            this.textBox3.TabIndex = 21;
            this.textBox3.Text = "Voer zelf je commando uit, kopieer en plak de uitkomst van dat commando in de sel" +
    "ectie output. Selecteer het gedeelte wat je zou willen als output en druk dan op" +
    " enter.";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(34, 260);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(201, 55);
            this.textBox2.TabIndex = 20;
            this.textBox2.Text = "Het is mogelijk om een gedeelte van output te selecteren zodat je altijd in één o" +
    "ogopslag kan zien wat de uitkomst is van een commando";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "SELECTIE";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(34, 97);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 93);
            this.textBox1.TabIndex = 18;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // newWidgetInformationLabel
            // 
            this.newWidgetInformationLabel.AutoSize = true;
            this.newWidgetInformationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.newWidgetInformationLabel.Location = new System.Drawing.Point(16, 17);
            this.newWidgetInformationLabel.Name = "newWidgetInformationLabel";
            this.newWidgetInformationLabel.Size = new System.Drawing.Size(97, 25);
            this.newWidgetInformationLabel.TabIndex = 10;
            this.newWidgetInformationLabel.Text = "Informatie";
            // 
            // choosenWidgetType
            // 
            this.choosenWidgetType.AutoSize = true;
            this.choosenWidgetType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choosenWidgetType.Location = new System.Drawing.Point(31, 73);
            this.choosenWidgetType.Name = "choosenWidgetType";
            this.choosenWidgetType.Size = new System.Drawing.Size(113, 15);
            this.choosenWidgetType.TabIndex = 12;
            this.choosenWidgetType.Text = "TYPE COMMANDO";
            // 
            // selectionPanel
            // 
            this.selectionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.selectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.selectionPanel.Controls.Add(this.SelectionWizard);
            this.selectionPanel.Controls.Add(this.outputBox);
            this.selectionPanel.Controls.Add(this.label2);
            this.selectionPanel.ForeColor = System.Drawing.Color.White;
            this.selectionPanel.Location = new System.Drawing.Point(30, 229);
            this.selectionPanel.Name = "selectionPanel";
            this.selectionPanel.Size = new System.Drawing.Size(386, 252);
            this.selectionPanel.TabIndex = 16;
            // 
            // SelectionWizard
            // 
            this.SelectionWizard.ForeColor = System.Drawing.Color.Black;
            this.SelectionWizard.Location = new System.Drawing.Point(22, 203);
            this.SelectionWizard.Name = "SelectionWizard";
            this.SelectionWizard.Size = new System.Drawing.Size(105, 28);
            this.SelectionWizard.TabIndex = 12;
            this.SelectionWizard.Text = "use selction wizard";
            this.SelectionWizard.UseVisualStyleBackColor = true;
            this.SelectionWizard.Click += new System.EventHandler(this.SelectionWizard_Click);
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(21, 57);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputBox.Size = new System.Drawing.Size(334, 117);
            this.outputBox.TabIndex = 11;
            this.outputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.outputBox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(16, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Selectie output";
            // 
            // widgetCreatorErrorProvider
            // 
            this.widgetCreatorErrorProvider.ContainerControl = this;
            // 
            // WidgetCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 521);
            this.Controls.Add(this.selectionPanel);
            this.Controls.Add(this.NewWidgetInformationPanel);
            this.Controls.Add(this.NewWidgetChoicePanel);
            this.Name = "WidgetCreator";
            this.Text = "WidgetCreator";
            this.NewWidgetChoicePanel.ResumeLayout(false);
            this.NewWidgetChoicePanel.PerformLayout();
            this.NewWidgetInformationPanel.ResumeLayout(false);
            this.NewWidgetInformationPanel.PerformLayout();
            this.selectionPanel.ResumeLayout(false);
            this.selectionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.widgetCreatorErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel NewWidgetChoicePanel;
        private System.Windows.Forms.Label AddNewCommandTitle;
        private System.Windows.Forms.Button NewWidgetAddButton;
        private System.Windows.Forms.Label NewWidgetCommandLabel;
        private System.Windows.Forms.TextBox NewWidgetCommand;
        private System.Windows.Forms.Label NewWidgetNameLabel;
        private System.Windows.Forms.TextBox NewWidgetName;
        private System.Windows.Forms.Label NewWidgetCommandtypeLabel;
        private System.Windows.Forms.ComboBox NewWidgetCommandtype;
        private System.Windows.Forms.Panel NewWidgetInformationPanel;
        private System.Windows.Forms.Label newWidgetInformationLabel;
        private System.Windows.Forms.Label choosenWidgetType;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Panel selectionPanel;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox newWidgetUseSelectionCheckbox;
        private System.Windows.Forms.Label useSelectionLabel;
        private System.Windows.Forms.ErrorProvider widgetCreatorErrorProvider;
        private System.Windows.Forms.Button SelectionWizard;
    }
}