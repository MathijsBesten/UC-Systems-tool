using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CiscoDatabaseProgram.Functions.Network.Stream
{
    class Networkstreams
    {
        public static string TalkToCiscoRouterAndWaitForResponse(string IPAddress,string message)
        {
            int bytes;
            string response = "";

            byte[] responseInBytes = new byte[4096];
            var client = new TcpClient();
            client.ConnectAsync(IPAddress, 23).Wait(TimeSpan.FromSeconds(2));
            if (client.Connected == true)
            {
                client.ReceiveTimeout = 3;
                client.SendTimeout = 3;
                byte[] messageInBytes = Encoding.ASCII.GetBytes(message);
                NetworkStream stream = client.GetStream();
                Console.WriteLine();
                stream.Write(messageInBytes, 0, messageInBytes.Count());    //send data to router
                Thread.Sleep(50);                                           // temporary way to let the router fill his tcp response
                bytes = stream.Read(responseInBytes, 0, responseInBytes.Length);
                response = Encoding.ASCII.GetString(responseInBytes, 0, bytes);
                return response;                                            //whole command output
            }
            return null;
        }
    }
}
