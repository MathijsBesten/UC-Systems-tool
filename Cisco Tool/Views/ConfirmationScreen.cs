﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cisco_Tool.Views
{
    public partial class ConfirmationScreen : Form
    {
        public static int totalCommandsToRun;
        public static double totalRunTime;
        public ConfirmationScreen(List<string> IPAddressList, List<string> commandList)
        {
            InitializeComponent();
            totalCommandsToRun = IPAddressList.Count* commandList.Count;
            totalRunTime = totalCommandsToRun * 0.4;

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
            foreach (string ip in IPAddressList)
            {
                summaryOutputBox.Text += ip;
                summaryOutputBox.Text += Environment.NewLine;
            }
            summaryOutputBox.Text += Environment.NewLine;
            summaryOutputBox.Text += @"Totaal uit te voeren commando's : " + totalCommandsToRun;
            summaryOutputBox.Text += Environment.NewLine;
            summaryOutputBox.Text += Environment.NewLine;
            summaryOutputBox.Text += "Totaal geschatte tijd: ";
            if (totalRunTime > 60)
            {
                totalRunTime = totalRunTime / 60;
                summaryOutputBox.Text += totalRunTime + " minuten";
            }
            else
            {
                summaryOutputBox.Text += totalRunTime + " seconden";
            }
        }
    }
}
