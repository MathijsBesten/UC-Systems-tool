using Cisco_Tool.Functions.Telnet;
using Cisco_Tool.Widgets.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cisco_Tool.Widgets.Functions
{

    public delegate void WidgetLoadedEventHandler(object sender, EventArgs e);
    class BackgroundWidgetLoader : BackgroundWorker
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public event WidgetLoadedEventHandler widgetLoader;
        public int count;
        public Classes.widget widget;
        public string ip;
        public string username;
        public string password;

        public BackgroundWidgetLoader(int count, Classes.widget widget,string ip,string username,string password  ) : base()
        {
            this.DoWork += this.makeWidgetsTask;
            this.count = count;
            this.widget = widget;
            this.ip = ip;
            this.username = username;
            this.password = password;
        }
        protected virtual void onWidgetComplete(EventArgs e)
        {
            if (widgetLoader != null)
            {
                widgetLoader(this, e);
            }
        }
        public void makeWidgetsTask(object sender,DoWorkEventArgs e)
        {
            if (widget.widgetType == "Informatie")
            {
                var newPanel = new InfoTemplate();
                newPanel.Name = "Panel" + count.ToString();
                newPanel.Tag = count.ToString();
                newPanel.titleWidgetLabel.Text = widget.widgetName;
                newPanel.commandName.Text = widget.widgetCommand;
                //newPanel.closeWidgetPicturebox.Click += new EventHandler(removeWidget);
                //newPanel.maxWidgetPicturebox.Click += new EventHandler(maximizeWidget);

                if (count % 2 == 0 || count == 0)
                {
                    newPanel.topBar.BackColor = Color.FromArgb(255, 64, 14, 14);
                    newPanel.informationPanel.BackColor = Color.FromArgb(255, 76, 17, 17);
                    newPanel.BackColor = Color.FromArgb(255, 76, 17, 17);

                }
                else
                {
                    newPanel.topBar.BackColor = Color.FromArgb(255, 140, 32, 32);
                    newPanel.informationPanel.BackColor = Color.FromArgb(255, 153, 35, 35);
                    newPanel.BackColor = Color.FromArgb(255, 153, 35, 35);
                }



                if (widget.widgetCommand != "")
                {
                    string command = widget.widgetCommand;
                    bool usesLongProcessTime = widget.widgetUseLongProcessTime;
                    string output = TelnetConnection.telnetClientTCP(ip, command, username, password, usesLongProcessTime);
                    if (output != null)
                    {
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
                    }
                    else
                    {
                        newPanel.outputbox.Font = new Font("Microsoft Sans Serif", 15);
                        newPanel.outputbox.Text = @"Commando '" + widget.widgetCommand + @"'  is niet geldig";
                        log.Info(@"Commando '" + widget.widgetCommand + @"'  is not a valid command");
                    }
                    ReadyPanels.readyInfoWidget = newPanel;
                    onWidgetComplete(EventArgs.Empty);
                }
                else
                {
                    log.Info("cannot connect to router - username and/or password is wrong");
                }
            }
            else //button
            {
                var newPanel = new ExecuteTemplate();
                newPanel.Name = "Panel" + count.ToString();
                newPanel.Tag = count.ToString();
                newPanel.titleWidgetLabel.Text = widget.widgetName;
                newPanel.commandName.Text = widget.widgetCommand;
                //newPanel.closeWidgetPicturebox.Click += new EventHandler(removeWidget);
                //newPanel.runButton.Click += new EventHandler(runCommand);
                //newPanel.maxWidgetPicturebox.Click += new EventHandler(maximizeWidget);


                if (count % 2 == 0 || count == 0)
                {
                    newPanel.topBar.BackColor = Color.FromArgb(255, 64, 14, 14);
                    newPanel.informationPanel.BackColor = Color.FromArgb(255, 76, 17, 17);
                    newPanel.BackColor = Color.FromArgb(255, 76, 17, 17);

                }
                else
                {
                    newPanel.topBar.BackColor = Color.FromArgb(255, 140, 32, 32);
                    newPanel.informationPanel.BackColor = Color.FromArgb(255, 153, 35, 35);
                    newPanel.BackColor = Color.FromArgb(255, 153, 35, 35);
                }
                newPanel.runButton.Text = "Uitvoeren";
                ReadyPanels.readyExecuteWidget = newPanel;
                onWidgetComplete(EventArgs.Empty);
            }
        }
    }
}
