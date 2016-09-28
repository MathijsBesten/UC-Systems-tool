using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;

using CiscoDatabaseProgram.Values;
using CiscoDatabaseProgram.Functions.Network.Stream;
using CiscoDatabaseProgram.Functions.SerialNumbers;
using System.Configuration;

namespace CiscoDatabaseProgram.Functions.SerialNumbers
{
    class TelnetConnection
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void telnetClientSockets(string IPAddressString) // function will not work for cisco router
        {
            IPAddress address;
            byte[] message;
            byte[] responseInBytes = new byte[]{ };
            string response;
            bool convertIP = IPAddress.TryParse(IPAddressString, out address);
            if (convertIP == true)
            {
                IPEndPoint endpoint = new IPEndPoint(address, 23);
                Socket socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
                socket.ReceiveTimeout = 3;
                try
                {
                    socket.Connect(endpoint);
                    string testmessage = "test";
                    message = Encoding.ASCII.GetBytes(testmessage);
                    socket.Send(message);
                    socket.Receive(responseInBytes);
                    response = Encoding.ASCII.GetString(responseInBytes);
                    Console.WriteLine(response);
                    socket.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error - kon niet verbinden met " + IPAddressString +" via telnet om serienummer op te halen ");
                    Console.WriteLine("errormessage - " + ex.Message);
                    log.Error("ERROR - Could not connect to "+ IPAddressString +" using telnet to get serialnumber ");
                    log.Error("errormessage - " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("error - Er was een probleem met het controleren van het ip adres ");
                Console.WriteLine("probleem ontstond bij : " + IPAddressString);
                log.Error("ERROR - could not verify " + IPAddressString);
                Logging.Exit.defaultExit();
            }
        }
        public static string telnetClientTCP(router router,string username,string password) // telnet client using tcp client
        {

            log.Info("Telnet function was been started");
            //initialze all values
            string command = "sh diag | inc Serial";                    // command to get serialnumber
            string message = username + "\r\n"+ password + "\r\n"+ command + "\r\n"; 
            byte[] responseInBytes = new byte[4096];                    // cisco responses are big - 4096 bytes big
            string response = ""; 
            string chassisSerialNumber = "";

            log.Info("Getting serialnumber...");
            bool convertIP = Network.validation.validateIPv4(router.routerAddress); 
            if (convertIP == true && router.routerActivate == "1")
            {
                string endpoint = router.routerAddress; //destination
                try 
                {
                    response = Networkstreams.TalkToCiscoRouterAndWaitForResponse(router.routerAddress, message); 
                    if (response != null)
                    {
                        if (!response.Contains("Chassis Serial Number"))
                        {
                            Console.WriteLine("error - kon niet verbinden met " + router.routerAddress + " via telnet om serienummer op te halen ");
                            Console.WriteLine("Error, gebruikersnaam en/of wachtwoord is onjuist");
                            log.Error("ERROR - Could not connect to " + router.routerAddress + " using telnet to get serialnumber ");
                            log.Error("errormessage - username and/or password invalid");
                        }
                        else
                        {
                            chassisSerialNumber = General.findCereal(response); 
                            Console.WriteLine(router.routerAddress + " serienummer: " + chassisSerialNumber);
                            log.Info("Serialnumber received - IP Address: " + router.routerAddress + " Serialnumber: " + chassisSerialNumber);
                        }
                    }
                    else
                    {
                        Console.WriteLine("error - kon niet verbinden met " + router.routerAddress + " via telnet om serienummer op te halen ");
                        Console.WriteLine("Error, er vond een timeout plaats");
                        log.Error("ERROR - Could not connect to " + router.routerAddress + " using telnet to get serialnumber ");
                        log.Error("errormessage - Timeout, client did not respond within 2 seconds  ");
                    }
                }
                catch (Exception ex)
                {
                    if (response.Contains("Login invalid"))
                    {
                        Console.WriteLine("error - kon niet verbinden met " + router.routerAddress + " via telnet om serienummer op te halen ");
                        Console.WriteLine("Error, gebruikersnaam en/of wachtwoord is onjuist");
                        log.Error("ERROR - Could not connect to " + router.routerAddress + " using telnet to get serialnumber ");
                        log.Error("errormessage - username and/or password invalid");
                    }
                    else if (router.routerActivate == "0")
                    {
                        Console.WriteLine( router.routerAddress + " is niet actief en zal niet worden voorzien van een serienummer");
                        log.Info(router.routerAddress + " is marked as not active, serialnumber will not be received");
                    }
                    else
                    {
                        Console.WriteLine("error - kon niet verbinden met " + router.routerAddress + " via telnet om serienummer op te halen ");
                        Console.WriteLine("errormessage - " + ex.Message);
                        log.Error("ERROR - Could not connect to " + router.routerAddress + " using telnet to get serialnumber ");
                        log.Error("errormessage - " + ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("error - Er was een probleem met het controleren van het ip adres ");
                Console.WriteLine("probleem ontstond bij : " + router.routerAddress);

                log.Error("ERROR - IP address was not legit - IP:" + router.routerAddress + " *If ip address is not shown, please contact app developer*");
            }
            return chassisSerialNumber;
        }
    }
}
