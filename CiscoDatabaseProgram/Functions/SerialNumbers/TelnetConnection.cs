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

namespace CiscoDatabaseProgram.Functions.SerialNumbers
{
    class TelnetConnection
    {
        public static void telnetClientSockets(string IPAddressString) // function will not work for cisco router
        {
            List<string> log = new List<string>();
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
                    log.Add("ERROR - Could not connect to "+ IPAddressString +" using telnet to get serialnumber ");
                    log.Add("errormessage - " + ex.Message);
                    Logging.Logs.writeToLogfile(log);
                    throw;
                }

            }
            else
            {
                Console.WriteLine("error - Er was een probleem met het controleren van het ip adres ");
                Console.WriteLine("probleem ontstond bij : " + IPAddressString);
                log.Add("ERROR - could not verify " + IPAddressString);
                Logging.Logs.writeToLogfile(log);
                Logging.Exit.defaultExit();
            }
        }
        public static void telnetClientTCP(string IPAddressString) // telnet client using tcp client
        {
            //initialze all values
            List<string> log = new List<string>(); // list for log
            IPAddress address; // will be filled after conversion
            string command = "sh diag | inc Serial"; // command to get serialnumber
            string message = PrivateValues.testRouterUsername + "\r\n"+ PrivateValues.testRouterPassword +"\r\n"+ command + "\r\n"; // command to run
            byte[] messageInBytes; // message in bytes
            byte[] responseInBytes = new byte[4096]; // need a big byte array because much data
            string response; // response in string
            NetworkStream stream;

            log.Add("Getting serialnumber...");
            Logging.Logs.writeToLogfile(log);
            log.Clear();
            bool convertIP = IPAddress.TryParse(IPAddressString, out address); //Try convert ip address
            if (convertIP == true) // if conversion was successfull
            {
                string endpoint = IPAddressString; // this is the designation
                TcpClient client = new TcpClient(IPAddressString,23); // new tcp Client
                client.ReceiveTimeout = 3; //after 3 seconds
                try // tries to get the info from router
                {
                    messageInBytes = Encoding.ASCII.GetBytes(message); // encodes the message to byte array
                    stream = client.GetStream(); // talking line of client
                    stream.Write(messageInBytes, 0, messageInBytes.Count()); // send data to router
                    // data send
                    Thread.Sleep(50); // temporarily solution to the incomplete data  
                    int bytes = stream.Read(responseInBytes, 0, responseInBytes.Length); // read data is put in byte[] responseInBytes
                    response = Encoding.ASCII.GetString(responseInBytes, 0, bytes); // byte array is decoded to string using ascii code
                    Console.WriteLine(response); // response string will be echo't
                    string chassisSerialNumber = findCereal(response); // serialnumber will be received by using substring method
                    Console.WriteLine(chassisSerialNumber); // serialnumber is echo't
                    log.Add("Serialnumber received - IP Address: " + IPAddressString + " Serialnumber: " + chassisSerialNumber);
                    Logging.Logs.writeToLogfile(log);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error - kon niet verbinden met " + IPAddressString + " via telnet om serienummer op te halen ");
                    Console.WriteLine("errormessage - " + ex.Message);
                    log.Add("ERROR - Could not connect to " + IPAddressString + " using telnet to get serialnumber ");
                    log.Add("errormessage - " + ex.Message);
                    Logging.Logs.writeToLogfile(log);
                    throw;
                }

            }
            else
            {
                Console.WriteLine("error - Er was een probleem met het controleren van het ip adres ");
                Console.WriteLine("probleem ontstond bij : " + IPAddressString);
                log.Add("ERROR - could not verify " + IPAddressString);
                Logging.Logs.writeToLogfile(log);
                Logging.Exit.defaultExit();
            }
        }
        public static string findCereal(string originalstring) // Find chassis serial number ** command: show diag **
        {
            List<string> log = new List<string>();
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
                log.Add("ERROR - could not find serialnumber using substring method");
                Logging.Logs.writeToLogfile(log);                
            }
            return null;
        }
    }
}
