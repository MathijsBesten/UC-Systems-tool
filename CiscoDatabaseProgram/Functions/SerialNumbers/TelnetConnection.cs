using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;

using CiscoDatabaseProgram.Values;
using CiscoDatabaseProgram.Network.Stream;
using System.Configuration;

namespace CiscoDatabaseProgram.Functions.SerialNumbers
{
    class TelnetConnection
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void telnetClientSockets(string IPAddressString) // function will not work for cisco router
        {
            IPAddress address;
            byte[] message;
            byte[] responseInBytes = new byte[]{ };
            string response;
            bool convertIP = IPAddress.TryParse(IPAddressString, out address);
            if (convertIP == true)
            {
                IPEndPoint endpoint = new IPEndPoint(address, 23);
                Socket socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
                socket.ReceiveTimeout = 3;
                try
                {
                    socket.Connect(endpoint);
                    string testmessage = "test";
                    message = Encoding.ASCII.GetBytes(testmessage);
                    socket.Send(message);
                    socket.Receive(responseInBytes);
                    response = Encoding.ASCII.GetString(responseInBytes);
                    Console.WriteLine(response);
                    socket.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error - kon niet verbinden met " + IPAddressString +" via telnet om serienummer op te halen ");
                    Console.WriteLine("errormessage - " + ex.Message);
                    log.Error("ERROR - Could not connect to "+ IPAddressString +" using telnet to get serialnumber ");
                    log.Error("errormessage - " + ex.Message);
                    throw;
                }

            }
            else
            {
                Console.WriteLine("error - Er was een probleem met het controleren van het ip adres ");
                Console.WriteLine("probleem ontstond bij : " + IPAddressString);
                log.Error("ERROR - could not verify " + IPAddressString);
                Logging.Exit.defaultExit();
            }
        }
        public static string telnetClientTCP(string IPAddressString,string username,string password) // telnet client using tcp client
        {

            log.Info("Telnet function was been started");
            //initialze all values
            IPAddress address; // will be filled after conversion
            string command = "sh diag | inc Serial"; // command to get serialnumber
            string message = username + "\r\n"+ password + "\r\n"+ command + "\r\n"; // command to run
            byte[] messageInBytes; // message in bytes
            byte[] responseInBytes = new byte[4096]; // need a big byte array because much data
            string response; // response in string
            string chassisSerialNumber = "";
            NetworkStream stream;

            log.Info("Getting serialnumber...");
            bool convertIP = IPAddress.TryParse(IPAddressString, out address); //Try convert ip address
            if (convertIP == true) // if conversion was successfull
            {
                string endpoint = IPAddressString; // this is the designation
                try // tries to get the info from router
                {
                    response = Networkstreams.TalkToCiscoRouterAndWaitForResponse(IPAddressString, message); // networksteam function
                    chassisSerialNumber = findCereal(response); // serialnumber will be received by using substring method
                    Console.WriteLine(IPAddressString + " serienummer: " + chassisSerialNumber); // serialnumber is echo't
                    log.Info("Serialnumber received - IP Address: " + IPAddressString + " Serialnumber: " + chassisSerialNumber);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error - kon niet verbinden met " + IPAddressString + " via telnet om serienummer op te halen ");
                    Console.WriteLine("errormessage - " + ex.Message);
                    log.Error("ERROR - Could not connect to " + IPAddressString + " using telnet to get serialnumber ");
                    log.Error("errormessage - " + ex.Message);
                }

            }
            else
            {
                Console.WriteLine("error - Er was een probleem met het controleren van het ip adres ");
                Console.WriteLine("probleem ontstond bij : " + IPAddressString);
                log.Error("ERROR - could not verify " + IPAddressString);
                Logging.Exit.defaultExit();
            }
            return chassisSerialNumber;
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
