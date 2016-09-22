using System;
using System.Collections.Generic;
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
        public static string TalkToCiscoRouterAndWaitForResponse(string IPAddress,string message)
        {
            int bytes;
            string response = "";

            byte[] responseInBytes = new byte[4096]; // byte array for response
            TcpClient client = new TcpClient(IPAddress, 23); // new tcp Client
            client.ReceiveTimeout = 3; //after 3 seconds
            byte[] messageInBytes = Encoding.ASCII.GetBytes(message); // encodes the message to byte array
            NetworkStream stream = client.GetStream(); // talking line of client
            Console.WriteLine();
            stream.Write(messageInBytes, 0, messageInBytes.Count()); // send data to router
            Thread.Sleep(50); // temporary way to let the router fill his tcp response
            bytes = stream.Read(responseInBytes, 0, responseInBytes.Length); // read data is put in byte[] responseInBytes
            response = Encoding.ASCII.GetString(responseInBytes, 0, bytes); // byte array is decoded to string using ascii code
            return response;
        }
    }
}
