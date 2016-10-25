using Cisco_Tool.Functions.Telnet;
using Cisco_Tool.Widgets.Templates;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cisco_Tool.Widgets.Functions
{
    class WidgetGenerator
    {
        public static List<Control> readyPanels = new List<Control>();

        public static async Task makeAllWidgets()
        {
            var result =  await widgetMaker();
            string test = "test";
            MessageBox.Show("Test");
        }
        public static async Task<int> widgetMaker()
        {
            var widgets = JSON.readJSON(); // 7ms for reading a empty file
            //getting widget infromation and setting up template details
            Size templateSize = new Size(250, 230);
            Color templateBackColor = Color.Gray; //backcolor
            Color templateForeColor = Color.White; // font color
            Padding templateMargin = new System.Windows.Forms.Padding(0); // margin
            int count = 0;
            foreach (var widget in widgets)
            {
                if (widget.widgetType == "Informatie")
                {
                    var newPanel = new InfoTemplate();
                    newPanel.Name = "Panel" + count.ToString();
                    newPanel.Tag = count.ToString();
                    newPanel.titleWidgetLabel.Text = widget.widgetName;
                    newPanel.commandName.Text = widget.widgetCommand;
                    //newPanel.minMaxWidgetPicturebox.Click += new System.EventHandler(EventHandlers.EventHandlers.minMaxButton_Click);
                    //newPanel.closeWidgetPicturebox.Click += new System.EventHandler(MainForm.closeButton_Click);
                    if (widget.widgetCommand != "")
                    {
                        string username = "mathijs";
                        string password = "denbesten";
                        string command = widget.widgetCommand;
                        bool usesLongProcessTime = widget.widgetUseLongProcessTime;
                        string output = TelnetConnection.telnetClientTCP("172.28.81.180", command, username, password, usesLongProcessTime);
                        if (!output.Contains(@"% Invalid input detected at '^' marker")) // check if command was valid
                        {
                            if (widget.widgetUseSelection == true)
                            {
                                string finalResult = Widgets.Functions.Responses.getStringFromResponse(output, widget.widgetEnterCountBeforeString, widget.WidgetEnterCountInString);
                                newPanel.outputbox.Text = finalResult.ToString();
                            }
                            else
                            {
                                newPanel.outputbox.Text = output;
                            }
                        }
                        else
                        {
                            newPanel.outputbox.Font = new Font("Microsoft Sans Serif", 15);
                            newPanel.outputbox.Text = @"Commando '" + widget.widgetCommand + @"'  is niet geldig";
                        }
                        readyPanels.Add(newPanel);
                    }
                }
                else //button
                {
                    var newPanel = new ExecuteTemplate();
                    newPanel.Name = "Panel" + count.ToString();
                    newPanel.Tag = "Panel" + count.ToString();
                    newPanel.titleWidgetLabel.Text = widget.widgetName;
                    newPanel.commandName.Text = widget.widgetCommand;
                    // newPanel.minMaxWidgetPicturebox.Click += new System.EventHandler(MainForm.minMaxButton_Click);
                    // newPanel.closeWidgetPicturebox.Click += new System.EventHandler(MainForm.closeButton_Click);

                    if (widget.widgetCommand != "")
                    {
                        string username = "mathijs";
                        string password = "denbesten";
                        string command = widget.widgetCommand;
                        bool usesLongProcessTime = widget.widgetUseLongProcessTime;
                        string output = TelnetConnection.telnetClientTCP("172.28.81.180", command, username, password, usesLongProcessTime);
                        if (!output.Contains(@"% Invalid input detected at '^' marker")) // check if command was valid
                        {
                            if (widget.widgetUseSelection == true)
                            {
                                string finalResult = Widgets.Functions.Responses.getStringFromResponse(output, widget.widgetEnterCountBeforeString, widget.WidgetEnterCountInString);
                                newPanel.outputbox.Text = finalResult.ToString();
                            }
                            else
                            {
                                newPanel.outputbox.Text = output;
                            }
                        }
                        else
                        {
                            newPanel.outputbox.Font = new Font("Microsoft Sans Serif", 15);
                            newPanel.outputbox.Text = @"Commando '" + widget.widgetCommand + @"' is niet geldig ";
                        }
                    }
                    newPanel.runButton.Text = "Uitvoeren";
                    //make new onclick event
                    readyPanels.Add(newPanel);
                    }
                count++;
            }
            MessageBox.Show("Test");
            return 1;
        }
    } 
}
