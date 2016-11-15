using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;

using Cisco_Tool.Values;
using Cisco_Tool.Functions.Stream;
using System.Configuration;
using System.ComponentModel;
using static Cisco_Tool.Widgets.Classes;

namespace Cisco_Tool.Functions.Telnet
{
    class TelnetConnection
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string telnetClientTCP(string IPAddressString,List<string> command, string username,string password, bool useLongProcessTime) 
        {

            log.Info("Telnet function was been started");
            IPAddress address; 
            string response =""; 

            bool convertIP = IPAddress.TryParse(IPAddressString, out address);
            if (convertIP == true)
            {
                try
                {
#pragma warning disable CS0612 // Type or member is obsolete
                    response = Networkstreams.TalkToCiscoRouterAndGetResponse(IPAddressString,command,username,password, useLongProcessTime);
#pragma warning restore CS0612 // Type or member is obsolete
                }
                catch (Exception ex)
                {
                    log.Error("ERROR - Could not connect to " + IPAddressString + " using telnet to get serialnumber ");
                    log.Error("errormessage - " + ex.Message);
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }

            }
            else
            {
                Console.WriteLine("error - Er was een probleem met het controleren van het ip adres ");
                Console.WriteLine("probleem ontstond bij : " + IPAddressString);

                log.Error("ERROR - IP address was not legit - IP:" + IPAddressString + " *If not ip address is show, please contact app developer*");
            }
            return response;
        }
        public static string findCereal(string originalstring) //find serialnumber
        {
            string searchPattern = "Chassis Serial Number    :"; // this string is infront of the CHASSIS serial number
            if (originalstring.Contains(searchPattern)) 
            {
                int indexPattern = originalstring.IndexOf(searchPattern); 
                int startIndex = indexPattern + searchPattern.Length + 1; 
                string chassisSerialNumber = originalstring.Substring(startIndex, 11);
                return chassisSerialNumber;
            }
            else
            {
                Console.WriteLine("Serienummber kon niet worden achterhaalt");
                log.Error("could not find serialnumber using substring method");
                return null;
            }
        }
        public void async_telnetClientTCP(string IPAddressString, string command, string username, string password, bool useLongProcessTime)
        {
            BackgroundWorker backgroundWorkerTelnet= new BackgroundWorker();
            backgroundWorkerTelnet.DoWork += backgroundWorkerTelnet_Work;
            backgroundWorkerTelnet.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerTelnet_runCompleted);
            var telnetDetails = new Widgets.Classes.telnetDetails();
            telnetDetails.command = command;
            telnetDetails.IPAddress = IPAddressString;
            telnetDetails.username = username;
            telnetDetails.password = password;
            telnetDetails.useLongProcessTime = useLongProcessTime; 
            backgroundWorkerTelnet.RunWorkerAsync(telnetDetails);
        }

        private void backgroundWorkerTelnet_runCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (PublicValues. totalAsyncTelnetExcutions == PublicValues.readyTelnetOutputs.Count)
            {

            }
        }

        private void backgroundWorkerTelnet_Work(object sender, DoWorkEventArgs e)
        {
            telnetDetails details = (telnetDetails)e.Argument;
            List<string> command = new List<string> { details.command };
            string output = new TelnetConnection().telnetClientTCP(details.IPAddress, command , details.username, details.password, details.useLongProcessTime);
            if (output == null)
            {
                log.Info(@"Commando '" + details.command + @"'  is not a valid command");
            }
            details.output = output;
            //PublicValues.readyTelnetOutputs.Add(details);
        }

        public static string findPID(string originalstring)
        {
            string searchPattern = "PID: "; // this string is infront of the CHASSIS serial number
            if (originalstring.Contains(searchPattern))
            {
                int indexPattern = originalstring.IndexOf(searchPattern);
                int startIndex = indexPattern + searchPattern.Length;
                int indexOfNextComma = (originalstring.IndexOf(@",",startIndex)) - startIndex;
                string PID = originalstring.Substring(startIndex, indexOfNextComma);
                return PID;
            }
            else
            {
                Console.WriteLine("apparaat type kon niet worden achterhaalt");
                log.Error("could not find Device type using substring method");
                return null;
            }
        }
    }
}
