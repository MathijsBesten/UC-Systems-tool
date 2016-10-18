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
            int sleepMSAfterSend = 15;
            if (useLongProcessTime == true)
            {
                sleepMSAfterSend = 1000;
            }
            int bytes = 0;
            string response = "";
            byte[] lastBytesArray = new byte[4096];
            byte[] responseInBytes = new byte[4096];
            bool itIsTheEnd = false;
            var client = new TcpClient();
            client.ConnectAsync(IPAddress, 23).Wait(TimeSpan.FromSeconds(2));
            if (client.Connected == true)
            {
                client.ReceiveTimeout = 3;
                client.SendTimeout = 3;
                byte[] messageInBytes = Encoding.ASCII.GetBytes(command);
                NetworkStream stream = client.GetStream();
                Console.WriteLine();
                using (var writer = new BinaryWriter(client.GetStream(), Encoding.ASCII, true))
                {
                    writer.Write(messageInBytes);
                    Thread.Sleep(15);
                }
                using (var reader = new BinaryReader(client.GetStream(), Encoding.ASCII, true))
                {
                    while (itIsTheEnd == false)
                    {
                        bytes = reader.Read(responseInBytes, 0, responseInBytes.Count());
                        if (lastBytesArray == responseInBytes)
                        {
                            itIsTheEnd = true;
                        }
                        lastBytesArray = responseInBytes;
                        Thread.Sleep(15);
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
