﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Cisco_Tool.Functions.Stream
{
    class Networkstreams
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [Obsolete]
        public static string TalkToCiscoRouterAndGetResponse(string IPAddress,string command,string username,string password, bool useLongProcessTime)
        {
            int sleepMSAfterSend = 50;
            if (useLongProcessTime == true)
            {
                sleepMSAfterSend = 1000;
            }
            int bytes = 0;
            int lastBytes  = 1;
            string response = "";
            byte[] lastBytesArray = new byte[4096];
            byte[] responseInBytes = new byte[4096];
            bool itIsTheEnd = false;
            string message = username + "\r\n" + password + "\r\n" + command + "\r\n"; // command with excape characters

            var client = new TcpClient();
            client.ConnectAsync(IPAddress, 23).Wait(TimeSpan.FromSeconds(10));
            if (client.Connected == true)
            {
                log.Info("Connected to router IP address: " + IPAddress);
                log.Info("Running command - " + command);

                client.ReceiveTimeout = 1000;
                client.Client.ReceiveTimeout = 1000; // socket

                client.SendTimeout = 1;
                client.Client.SendTimeout = 1; // socket
                byte[] messageInBytes = Encoding.ASCII.GetBytes(message);
                NetworkStream stream = client.GetStream();
                Console.WriteLine();
                using (var writer = new BinaryWriter(client.GetStream(), Encoding.ASCII, true))
                {
                    writer.Write(messageInBytes);
                    Thread.Sleep(sleepMSAfterSend);
                }

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
                client.Close();
                log.Info("Connection to router correcly closed - IP address: " + IPAddress);
                return response;
            }
            log.Error("Router was not connected and could not get send command - IP address: " + IPAddress);
            return null;
        }
    }
}
