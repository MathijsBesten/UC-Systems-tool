using System;
using System.Collections.Generic;
using System.Net;

using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Linq;

namespace Cisco_Tool.Functions.Telnet
{
    class TelnetConnection
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string telnetClientTCP(string IPAddressString,List<string> commands, string username,string password, bool useLongProcessTime) 
        {

            log.Info("Telnet function was been started");
            IPAddress address; 
            string response =""; 

            bool convertIP = IPAddress.TryParse(IPAddressString, out address);
            if (convertIP == true)
            {
                try // start telnet function
                {
                    int sleepMSAfterSend = 50;
                    if (useLongProcessTime == true)
                    {
                        sleepMSAfterSend = 1000;
                    }
                    byte[] lastBytesArray = new byte[(commands.Count * 8192)]; // buffer size increases 
                    byte[] responseInBytes = new byte[(commands.Count * 8192)];
                    string messageStart = username + "\r\n" + password;// command with excape characters

                    var client = new TcpClient();
                    client.ReceiveTimeout = 1000;
                    client.Client.ReceiveTimeout = 1000; // socket
                    client.SendTimeout = 1;
                    client.Client.SendTimeout = 1; // socket

                    client.ConnectAsync(IPAddressString, 23).Wait(TimeSpan.FromSeconds(1));              // connect
                    if (client.Connected == true)
                    {
                        int count = 0;
                        foreach (string command in commands)
                        {
                            log.Info("Connected to router IP address: " + IPAddressString);
                            log.Info("Running command - " + command);
                            string messageEnd = command + "\r\n";
                            string message = messageStart + "\r\n" + messageEnd;
                            if (count >= 1)
                            {
                                message = messageEnd;
                            }

                            byte[] messageInBytes = Encoding.ASCII.GetBytes(message);
                            NetworkStream stream = client.GetStream();
                            using (var writer = new BinaryWriter(client.GetStream(), Encoding.ASCII, true))
                            {
                                writer.Write(messageInBytes);
                                Thread.Sleep(sleepMSAfterSend);
                            }
                            count++;
                        }
                        int bytes = 0;
                        int lastBytes = 1;
                        bool itIsTheEnd = false;
                        using (var reader = new BinaryReader(client.GetStream(), Encoding.ASCII, true))
                        {
                            while (itIsTheEnd == false)
                            {
                                //keep this if statement in front of the read part
                                if (bytes == lastBytes)
                                {
                                    itIsTheEnd = true;
                                }
                                else
                                {
                                    bytes = reader.Read(responseInBytes, 0, responseInBytes.Count());
                                    if (bytes > 500) { sleepMSAfterSend = 250; }
                                    lastBytesArray = responseInBytes;
                                    lastBytes = bytes;
                                    Thread.Sleep(sleepMSAfterSend);
                                }
                            }
                        }
                        response = Encoding.ASCII.GetString(responseInBytes);
                        response = response.Replace("\0", "");
                        client.Close();                                                            // close connection
                        log.Info("Connection to router correcly closed - IP address: " + IPAddressString);
                    }
                    else
                    {
                        log.Info("Router was not connected and could not get send command - IP address: " + IPAddressString);
                        return null;
                    }

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
