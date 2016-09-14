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
        public static void telnetClientSockets(string IPAddressString)
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
        public static void telnetClientTCP(string IPAddressString)
        {
            //initialze all values
            List<string> log = new List<string>(); // list for log
            IPAddress address; // future ip
            string message = "test"; // message in string
            byte[] messageInBytes; // message in bytes
            byte[] responseInBytes = new byte[1024]; // response from router
            string response; // response in string
            NetworkStream stream;


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
                    Thread.Sleep(10); // temporarily solution to the incomplete data  
                    int bytes = stream.Read(responseInBytes, 0, responseInBytes.Length);
                    response = Encoding.ASCII.GetString(responseInBytes, 0, bytes);
                    Console.WriteLine(response);
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
    }
}
