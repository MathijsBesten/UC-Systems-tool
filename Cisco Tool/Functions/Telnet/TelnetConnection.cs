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

namespace CiscoDatabaseProgram.Functions.SerialNumbers
{
    class TelnetConnection
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string telnetClientTCP(string IPAddressString,string command, string username,string password) // telnet client using tcp client
        {

            log.Info("Telnet function was been started");
            //initialze all values
            IPAddress address; // will be filled after conversion
            string message = username + "\r\n"+ password + "\r\n"+ command + "\r\n"; // command to run
            byte[] responseInBytes = new byte[4096]; // need a big byte array because much data
            string response =""; // response in string

            bool convertIP = IPAddress.TryParse(IPAddressString, out address); //Try convert ip address
            if (convertIP == true) // if conversion was successfull
            {
                string endpoint = IPAddressString; // this is the designation
                try // tries to get the info from router
                {
                    response = Networkstreams.TalkToCiscoRouterAndWaitForResponse(IPAddressString, message); // networksteam function
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
        public static string findCereal(string originalstring) // Find chassis serial number ** command: show diag **
        {
            string searchPattern = "Chassis Serial Number    :"; // this string is infront of the CHASSIS serial number
            if (originalstring.Contains(searchPattern))// checks 
            {
                int indexPattern = originalstring.IndexOf(searchPattern); // index of the pattern
                int startIndex = indexPattern + searchPattern.Length + 1; // adding 1 for space after :
                string chassisSerialNumber = originalstring.Substring(startIndex, 11); //serialnumber is received by substring orignalstring
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
