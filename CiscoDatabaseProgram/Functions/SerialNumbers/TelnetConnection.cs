﻿using System;
using CiscoDatabaseProgram.Values;
using CiscoDatabaseProgram.Functions.Network.Stream;

namespace CiscoDatabaseProgram.Functions.SerialNumbers
{
    class TelnetConnection
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string telnetClientTCP(router router,string username,string password) // telnet client using tcp client
        {
            log.Info("Telnet function was been started");
            //initialze all values
            string command = "sh diag | inc Serial";                    // command to get serialnumber
            string message = username + "\r\n"+ password + "\r\n"+ command + "\r\n"; 
            string response = ""; 
            string chassisSerialNumber = "";

            log.Info("Getting serialnumber...");
            bool convertIP = Network.validation.validateIPv4(router.routerAddress); 
            if (convertIP == true && router.routerActivate == "1")
            {
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
                            chassisSerialNumber = General.findCereal(response); //get serialcode from response
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
