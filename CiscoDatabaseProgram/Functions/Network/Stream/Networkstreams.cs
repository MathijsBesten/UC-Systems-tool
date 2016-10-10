using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace CiscoDatabaseProgram.Functions.Network.Stream
{
    class Networkstreams
    {
        public static int intt = 0;
        public static string TalkToCiscoRouterAndWaitForResponse(string IPAddress,string message)
        {
            int bytes = 0;
            string response = "";
            byte[] lastBytesArray = new byte[4096];
            byte[] responseInBytes = new byte[4096];
            bool itIsTheEnd = false;
            var client = new TcpClient();
            client.ConnectAsync(IPAddress, 23).Wait(TimeSpan.FromSeconds(2));
            if (client.Connected == true)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                client.ReceiveTimeout = 3;
                client.SendTimeout = 3;
                byte[] messageInBytes = Encoding.ASCII.GetBytes(message);
                NetworkStream stream = client.GetStream();
                Console.WriteLine();
                using (var writer = new BinaryWriter(client.GetStream(),Encoding.ASCII,true))
                {
                    writer.Write(messageInBytes);
                    Thread.Sleep(15);
                }
                using (var reader = new BinaryReader(client.GetStream(),Encoding.ASCII, true))
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
                var elapsed = sw.ElapsedMilliseconds;
                sw.Stop();
                return response;
            }
            return null;
        }

    }
}
