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

namespace Cisco_Tool.Functions.Telnet
{
    class TelnetConnection
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string telnetClientTCP(string IPAddressString,string command, string username,string password)
        {

            log.Info("Telnet function was been started");
            IPAddress address; 
            string response =""; 

            bool convertIP = IPAddress.TryParse(IPAddressString, out address);
            if (convertIP == true)
            {
                try
                {
                    response = Networkstreams.TalkToCiscoRouterAndGetResponse(IPAddressString,command,username,password);
                    log.Info("response from " + IPAddressString + ": " + response);
                }
                catch (Exception ex)
                {
                    log.Error("ERROR - Could not connect to " + IPAddressString + " using telnet to get serialnumber ");
                    log.Error("errormessage - " + ex.Message);
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
                log.Error("ERROR - could not find serialnumber using substring method");
                return null;
            }
        }
    }
}
