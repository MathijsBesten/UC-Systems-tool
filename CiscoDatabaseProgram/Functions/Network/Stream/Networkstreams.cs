using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CiscoDatabaseProgram.Functions.Network.Stream
{
    class Networkstreams
    {
        public static string TalkToCiscoRouterAndWaitForResponse(string IPAddress,string message)
        {
            byte[] lastBytesArray = new byte[4096];
            byte[] responseInBytes = new byte[4096];
            bool itIsTheEnd = false;
            var client = new TcpClient();
            client.ConnectAsync(IPAddress, 23).Wait(TimeSpan.FromSeconds(2));
            if (client.Connected == true)
            {
                client.ReceiveTimeout = 3;
                client.SendTimeout = 3;
                byte[] messageInBytes = Encoding.ASCII.GetBytes(message);
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
                        reader.Read(responseInBytes, 0, responseInBytes.Length);
                        if (lastBytesArray == responseInBytes)
                        {
                            itIsTheEnd = true;
                        }
                        lastBytesArray = responseInBytes;
                        Thread.Sleep(15);
                    }
                }
                string response = Encoding.ASCII.GetString(responseInBytes);
                response = response.Replace("\0", "");
                client.Close();
                return response;
            }
            return null;
        }

    }
}
