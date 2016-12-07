using System;
using System.Collections.Generic;
using System.Net;

using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Cisco_Tool.Functions.Telnet
{
    class TelnetConnection
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static List<string> succesfullConnected = new List<string>();
        public static List<string> couldNotConnect = new List<string>();
        public string TelnetClientTcp(string ipAddressString,List<string> commands, string username,string password, bool useLongProcessTime) 
        {

            Log.Info("Telnet function was been started");
            IPAddress address; 
            string response =""; 

            bool convertIp = IPAddress.TryParse(ipAddressString, out address);
            if (convertIp == true)
            {
                try // start telnet function
                {
                    int sleepMsAfterSend = 50;
                    if (useLongProcessTime == true)
                    {
                        sleepMsAfterSend = 1000;
                    }
                    byte[] responseInBytes = new byte[(commands.Count * 8192)];
                    string messageStart = username + "\r\n" + password;// command with excape characters

                    TcpClient client = new TcpClient
                    {
                        ReceiveTimeout = 1000,
                        Client = {ReceiveTimeout = 1000},
                        SendTimeout = 1
                    };
                    // socket
                    client.Client.SendTimeout = 1; // socket

                    client.ConnectAsync(ipAddressString, 23).Wait(TimeSpan.FromSeconds(1));              // connect
                    if (client.Connected == true)
                    {
                        int count = 0;
                        foreach (string command in commands)
                        {
                            Log.Info("Connected to router IP address: " + ipAddressString);
                            Log.Info("Running command - " + command);
                            string messageEnd = command + "\r\n";
                            string message = messageStart + "\r\n" + messageEnd;
                            if (count >= 1)
                            {
                                message = messageEnd;
                            }

                            byte[] messageInBytes = Encoding.ASCII.GetBytes(message);
                            using (var writer = new BinaryWriter(client.GetStream(), Encoding.ASCII, true))
                            {
                                writer.Write(messageInBytes);
                                Thread.Sleep(sleepMsAfterSend);
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
                                    bytes = reader.Read(responseInBytes, 0, responseInBytes.Length);
                                    if (bytes > 500) { sleepMsAfterSend = 250; }
                                    lastBytes = bytes;
                                    Thread.Sleep(sleepMsAfterSend);
                                }
                            }
                        }
                        response = Encoding.ASCII.GetString(responseInBytes);
                        response = response.Replace("\0", "");
                        client.Close();                                                            // close connection
                        Log.Info("Connection to router correcly closed - IP address: " + ipAddressString);
                        succesfullConnected.Add(ipAddressString);
                    }
                    else
                    {
                        Log.Info("Router was not connected and could not get send command - IP address: " + ipAddressString);
                        couldNotConnect.Add(ipAddressString);
                        return null;
                    }

                }
                catch (Exception ex)
                {
                    Log.Error("ERROR - Could not connect to " + ipAddressString + " using telnet");
                    Log.Error("errormessage - " + ex.Message);
                    couldNotConnect.Add(ipAddressString);
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("error - Er was een probleem met het controleren van het ip adres ");
                Console.WriteLine("probleem ontstond bij : " + ipAddressString);
                couldNotConnect.Add(ipAddressString);
                Log.Error("ERROR - IP address was not legit - IP:" + ipAddressString + " *If not ip address is show, please contact app developer*");
            }
            return response;
        }
        public static string FindPid(string originalstring)
        {
            string searchPattern = "PID: "; // this string is infront of the CHASSIS serial number
            if (originalstring != null)
            {
                if (originalstring.Contains(searchPattern))
                {
                    int indexPattern = originalstring.IndexOf(searchPattern);
                    int startIndex = indexPattern + searchPattern.Length;
                    int indexOfNextComma = (originalstring.IndexOf(@",", startIndex)) - startIndex;
                    string pid = originalstring.Substring(startIndex, indexOfNextComma);
                    return pid;
                }
                else
                {
                    Log.Error("could not find Device type using substring method");
                    return null;
                }
            }
            else
            {
                Log.Error("could not find Device type using substring method - original response was empty");
                return null;
            }
        }
    }
}
