using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Cisco_Tool.Functions.Netwerk
{
    class Sockethelper
    {
        public static bool doesTheSocketShitWorks()
        {
            Socket postbode = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            byte[] bytes = new byte[1024];


            string ip = "80.60.93.171";
            int port = 3333;
            postbode.ReceiveTimeout = 2000;
            var parsedIP = IPAddress.Parse(ip);
            var remoteEndPoint = new IPEndPoint(parsedIP, port);
            postbode.Connect(remoteEndPoint);
            Console.WriteLine("Socket connected to {0}",postbode.RemoteEndPoint.ToString());
            byte[] msg = Encoding.ASCII.GetBytes("ifconfig");
            int bytessend = postbode.Send(msg);
            int bytesRec = postbode.Receive(bytes);
            Console.WriteLine("Back from test: {0}"
                , Encoding.ASCII.GetString(bytes,0,bytesRec));

            return true; // if it works

        }

        public static bool tcpclientTest()
        {
            var ip = "192.168.1.1";
            var port = 22;
            var message = "";


            TcpClient client = new TcpClient(ip, port);
            byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);
            Console.WriteLine("Sent; {0}",message);
            data = new byte[256];
            //sending data to server
            string responseData = string.Empty;
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);
            return true;
        }
    }
}
