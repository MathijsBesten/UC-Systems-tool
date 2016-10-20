using System;
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
        public static string TalkToCiscoRouterAndGetResponse(string IPAddress,string command,string username,string password, bool useLongProcessTime)
        {
            int sleepMSAfterSend = 25;
            if (useLongProcessTime == true)
            {
                sleepMSAfterSend = 1000;
            }
            int bytes = 0;
            int lastBytes = 0;
            string response = "";
            byte[] lastBytesArray = new byte[4096];
            byte[] responseInBytes = new byte[4096];
            bool itIsTheEnd = false;
            string message = username + "\r\n" + password + "\r\n" + command + "\r\n"; // command with excape characters

            var client = new TcpClient();
            client.ConnectAsync(IPAddress, 23).Wait(TimeSpan.FromSeconds(10));
            if (client.Connected == true)
            {
                client.ReceiveTimeout = 10000;
                client.Client.ReceiveTimeout = 10000; // socket

                client.SendTimeout = 1;
                client.Client.SendTimeout = 1; // socket
                byte[] messageInBytes = Encoding.ASCII.GetBytes(message);
                NetworkStream stream = client.GetStream();
                Console.WriteLine();
                using (var writer = new BinaryWriter(client.GetStream(), Encoding.ASCII, true))
                {
                    writer.Write(messageInBytes);
                    Thread.Sleep(25);
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
                        bytes = reader.Read(responseInBytes, 0, responseInBytes.Count());
                        lastBytesArray = responseInBytes;
                        lastBytes = bytes;
                        Thread.Sleep(sleepMSAfterSend);
                    }
                }
                response = Encoding.ASCII.GetString(responseInBytes);
                response = response.Replace("\0", "");
                client.Close();
                return response;
            }
            return null;
        }
    }
}
