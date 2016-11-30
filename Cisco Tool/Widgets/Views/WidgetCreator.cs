using Cisco_Tool.Functions.Telnet;
using Cisco_Tool.Widgets.Functions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
            Log.Info("Launched widgetcreator Screen");
        }

        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        readonly Widget _newWidget = new Widget();
        bool _selectionHasRun = false;

        private void outputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string completeResponse = outputBox.Text; 
                string selectedString = outputBox.SelectedText;
                string[] substring = Regex.Split(completeResponse, selectedString);
                var enterCountInfront = Regex.Matches(substring[0], "\\r\\n").Count; // will be saved in xml file
                var enterCountInSelectedString = Regex.Matches(selectedString, "\\r\\n").Count; // will be saved in xml file

                _newWidget.WidgetEnterCountBeforeString = enterCountInfront;
                _newWidget.WidgetEnterCountInString = enterCountInSelectedString;
                _selectionHasRun = true;
                MessageBox.Show("Je hebt "  + selectedString +" gekozen");
                Log.Info("User Chose substring");
            }
        }

        private void NewWidgetAddButton_Click(object sender, EventArgs e)
        {
            widgetCreatorErrorProvider.SetError(NewWidgetName, NewWidgetName.Text == "" ? "Naam is verplicht" : "");
            widgetCreatorErrorProvider.SetError(NewWidgetCommand, NewWidgetCommand.Text == "" ? "commando is verplicht" : "");
            widgetCreatorErrorProvider.SetError(NewWidgetCommandtype, NewWidgetCommandtype.Text == "" ? "commando type is verplicht" : "");
            if (_selectionHasRun == false && newWidgetUseSelectionCheckbox.Checked == true)
            {
                widgetCreatorErrorProvider.SetError(outputBox, "maak een selectie");
            }
            else
            {
                widgetCreatorErrorProvider.SetError(outputBox, "");
            }
            if (NewWidgetName.Text != "" && NewWidgetCommand.Text != "" && NewWidgetCommandtype.Text != "" && ((_selectionHasRun == true && newWidgetUseSelectionCheckbox.Checked == true) || (_selectionHasRun == false && newWidgetUseSelectionCheckbox.Checked == false )))
            {
                _newWidget.WidgetName = NewWidgetName.Text;
                _newWidget.WidgetCommand = NewWidgetCommand.Text;
                _newWidget.WidgetUseSelection = newWidgetUseSelectionCheckbox.Checked;
                _newWidget.WidgetType = NewWidgetCommandtype.Text;
                _newWidget.WidgetUseLongProcessTime = NewWidgetUsesLongProcessTime.Checked;
                List<Widget> widgets = new List<Widget>();
                widgets.Add(_newWidget);
                Json.WriteJson(widgets);
                Log.Info("widget is added from widget creator");
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
            var wizardScreen = new SelctionWizard();
            var result = wizardScreen.ShowDialog();
            if (result == DialogResult.OK)
            {
                List<string> command = new List<string>() { this.NewWidgetCommand.Text };
                string completeResponse = new TelnetConnection().TelnetClientTcp(wizardScreen.Ipadres, command, wizardScreen.Username, wizardScreen.Password,NewWidgetUsesLongProcessTime.Checked);
                outputBox.Text = completeResponse;
            }
            else
            {
                MessageBox.Show("Geen resultaat gevonden, probeer handmatig een selectie te maken of kies voor de complete output");
                Log.Info("user cancelled the selection wizard - if this happens multiple times, Please report to development team");
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
