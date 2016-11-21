using System;
using System.Collections.Generic;
using System.Net;

using Cisco_Tool.Functions.Stream;


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
                    log.Error("ERROR - Could not connect to " + IPAddressString + " using telnet");
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
        public static string findPID(string originalstring)
        {
            string searchPattern = "PID: "; // this string is infront of the CHASSIS serial number
            if (originalstring != null)
            {
                if (originalstring.Contains(searchPattern))
                {
                    int indexPattern = originalstring.IndexOf(searchPattern);
                    int startIndex = indexPattern + searchPattern.Length;
                    int indexOfNextComma = (originalstring.IndexOf(@",", startIndex)) - startIndex;
                    string PID = originalstring.Substring(startIndex, indexOfNextComma);
                    return PID;
                }
                else
                {
                    log.Error("could not find Device type using substring method");
                    return null;
                }
            }
            else
            {
                log.Error("could not find Device type using substring method - original response was empty");
                return null;
            }
        }
    }
}
