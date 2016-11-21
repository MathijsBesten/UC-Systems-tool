using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Cisco_Tool.Functions.Stream
{
    class Networkstreams
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [Obsolete]
        public static string TalkToCiscoRouterAndGetResponse(string IPAddress, List<string> commands, string username,string password, bool useLongProcessTime)
        {
            int sleepMSAfterSend = 50;
            if (useLongProcessTime == true)
            {
                sleepMSAfterSend = 1000;
            }
            string response = "";
            byte[] lastBytesArray = new byte[(commands.Count * 4096)]; // buffer size increases 
            byte[] responseInBytes = new byte[(commands.Count * 4096)];
            string messageStart = username + "\r\n" + password;// command with excape characters

            var client = new TcpClient();
            client.ReceiveTimeout = 1000;
            client.Client.ReceiveTimeout = 1000; // socket
            client.SendTimeout = 1;
            client.Client.SendTimeout = 1; // socket

            client.ConnectAsync(IPAddress, 23).Wait(TimeSpan.FromSeconds(1));              // connect
            if (client.Connected == true)
            {
                int count = 0;
                foreach (string command in commands)
                {
                    log.Info("Connected to router IP address: " + IPAddress);
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
                log.Info("Connection to router correcly closed - IP address: " + IPAddress);
                return response;
            }
            log.Info("Router was not connected and could not get send command - IP address: " + IPAddress);
            return null;
        }
    }
}
