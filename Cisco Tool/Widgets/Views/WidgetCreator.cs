using Cisco_Tool.Functions.Telnet;
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
            log.Info("Launched widgetcreator Screen");
        }

        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
                log.Info("User Chose substring");
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
                newWidget.widgetUseLongProcessTime = NewWidgetUsesLongProcessTime.Checked;
                List<widget> widgets = new List<Classes.widget>();
                widgets.Add(newWidget);
                JSON.writeJSON(widgets);
                log.Info("widget is added from widget creator");
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void newWidgetUseSelectionCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (newWidgetUseSelectionCheckbox.Checked && NewWidgetCommandtype.Text == "Informatie")
            {
                selectionPanel.Show();
            }
            else
            {
                selectionPanel.Hide();
            }
        }

        private void SelectionWizard_Click(object sender, EventArgs e)
        {
            var wizardScreen = new selctionWizard();
            var result = wizardScreen.ShowDialog();
            if (result == DialogResult.OK)
            {
                List<string> command = new List<string>() { this.NewWidgetCommand.Text };
                string completeResponse = new TelnetConnection().telnetClientTCP(wizardScreen.ipadres, command, wizardScreen.username, wizardScreen.password,NewWidgetUsesLongProcessTime.Checked);
                outputBox.Text = completeResponse;
            }
            else
            {
                MessageBox.Show("Geen resultaat gevonden, probeer handmatig een selectie te maken of kies voor de complete output");
                log.Info("user cancelled the selection wizard - if this happens multiple times, Please report to development team");
            }
        }

        private void NewWidgetCommandtype_TextChanged(object sender, EventArgs e)
        {
            if (newWidgetUseSelectionCheckbox.Checked && NewWidgetCommandtype.Text == "Informatie")
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
