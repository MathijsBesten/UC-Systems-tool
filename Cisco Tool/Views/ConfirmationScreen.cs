using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using log4net;

namespace Cisco_Tool.Views
{
    public partial class ConfirmationScreen : Form
    {

        private static readonly ILog Log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static int TotalCommandsToRun;
        public static double TotalRunTime;
        public ConfirmationScreen(List<string> ipAddressList, List<string> commandList)
        {
            Log.Info("Launched confirm screen");
            InitializeComponent();
            

            TotalCommandsToRun = ipAddressList.Count* commandList.Count;
            TotalRunTime = TotalCommandsToRun * 0.7;

            summaryOutputBox.Text += @"Commando's";
            summaryOutputBox.Text += Environment.NewLine;
            summaryOutputBox.Text += "----------";
            summaryOutputBox.Text += Environment.NewLine;
            foreach (string command in commandList)
            {
                summaryOutputBox.Text += command;
                summaryOutputBox.Text += Environment.NewLine;
            }
            summaryOutputBox.Text += Environment.NewLine;
            summaryOutputBox.Text += @"Routers";
            summaryOutputBox.Text += Environment.NewLine;
            summaryOutputBox.Text += "---------";
            summaryOutputBox.Text += Environment.NewLine;
            foreach (string ip in ipAddressList)
            {
                summaryOutputBox.Text += ip;
                summaryOutputBox.Text += Environment.NewLine;
            }
            summaryOutputBox.Text += Environment.NewLine;
            summaryOutputBox.Text += @"Totaal uit te voeren commando's : " + TotalCommandsToRun;
            summaryOutputBox.Text += Environment.NewLine;
            summaryOutputBox.Text += Environment.NewLine;
            summaryOutputBox.Text += "Totaal geschatte tijd: ";
            if (TotalRunTime > 60)
            {
                TotalRunTime = TotalRunTime / 60;
                summaryOutputBox.Text += TotalRunTime + " minuten";
            }
            else
            {
                summaryOutputBox.Text += TotalRunTime + " seconden";
            }

            Log.Info("Screenshot of confirm screen");
            Log.Info("----------");
            foreach (var line in summaryOutputBox.Lines)
            {
                Log.Info(line);
            }
            Log.Info("----------");
        }
        public void Confirm()
        {
            DialogResult = DialogResult.OK;
            Log.Info("User confirmed to run commands");
        }
        public void Cancel()
        {
            DialogResult = DialogResult.Cancel;
            Log.Info("User closed the confirm window - commands wil not run");
        }

        private void continuePanel_Click(object sender, EventArgs e)
        {
            Confirm();
        }

        private void cancelPanel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void confirmLabel_Click(object sender, EventArgs e)
        {
            Confirm();
        }

        private void confirmPicturebox_Click(object sender, EventArgs e)
        {
            Confirm();
        }

        private void cancelLabel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void cancelPicturebox_Click(object sender, EventArgs e)
        {
            Cancel();
        }
    }
}
