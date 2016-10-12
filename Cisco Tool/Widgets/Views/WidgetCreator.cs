using Cisco_Tool.Widgets.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Cisco_Tool.Widgets.Classes;

namespace Cisco_Tool.Widgets.Views
{
    public partial class WidgetCreator : Form
    {
        public WidgetCreator()
        {
            InitializeComponent();
            selectionPanel.Hide();
        }

        widget newWidget = new widget();
        bool selectionHasRun = false;

        private void outputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string completeResponse = outputBox.Text; 
                string selectedString = outputBox.SelectedText;
                int startIndex = completeResponse.IndexOf(selectedString);
                int endIndex = startIndex + selectedString.Length;
                string[] substring = Regex.Split(completeResponse, selectedString);
                var enterCountInfront = Regex.Matches(substring[0], "\\r\\n").Count; // will be saved in xml file
                var enterCountInSelectedString = Regex.Matches(selectedString, "\\r\\n").Count; // will be saved in xml file

                newWidget.widgetEnterCountBeforeString = enterCountInfront;
                newWidget.WidgetEnterCountInString = enterCountInSelectedString;
                selectionHasRun = true;
                MessageBox.Show("Je hebt "  + selectedString +" gekozen");
            }
        }

        private void NewWidgetAddButton_Click(object sender, EventArgs e)
        {
            if (NewWidgetName.Text == "")
            {
                widgetCreatorErrorProvider.SetError(NewWidgetName, "Naam is verplicht");
            }
            else
            {
                widgetCreatorErrorProvider.SetError(NewWidgetName, "");
            }
            if (NewWidgetCommand.Text == "")
            {
                widgetCreatorErrorProvider.SetError(NewWidgetCommand, "commando is verplicht");
            }
            else
            {
                widgetCreatorErrorProvider.SetError(NewWidgetCommand, "");
            }
            if (NewWidgetCommandtype.Text == "")
            {
                widgetCreatorErrorProvider.SetError(NewWidgetCommandtype, "commando type is verplicht");
            }
            else
            {
                widgetCreatorErrorProvider.SetError(NewWidgetCommandtype, "");
            }
            if (selectionHasRun == false && newWidgetUseSelectionCheckbox.Checked == true)
            {
                widgetCreatorErrorProvider.SetError(outputBox, "maak een selectie");
            }
            else
            {
                widgetCreatorErrorProvider.SetError(outputBox, "");
            }
            if (NewWidgetName.Text != "" && NewWidgetCommand.Text != "" && NewWidgetCommandtype.Text != "" && ((selectionHasRun == true && newWidgetUseSelectionCheckbox.Checked == true) || (selectionHasRun == false && newWidgetUseSelectionCheckbox.Checked == false )))
            {
                newWidget.widgetName = NewWidgetName.Text;
                newWidget.widgetCommand = NewWidgetCommand.Text;
                newWidget.widgetUseSelection = newWidgetUseSelectionCheckbox.Checked;
                newWidget.widgetType = NewWidgetCommandtype.Text;
                List<widget> widgets = new List<Classes.widget>();
                widgets.Add(newWidget);
                JSON.writeJSON(widgets);
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void newWidgetUseSelectionCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (newWidgetUseSelectionCheckbox.Checked)
            {
                selectionPanel.Show();
            }
            else
            {
                selectionPanel.Hide();
            }
        }
    }
}
