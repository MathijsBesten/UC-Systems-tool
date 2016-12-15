using CiscoDatabaseProgram.Functions.Logging;
using System;
using System.Threading;

namespace CiscoDatabaseProgram.Functions.Main
{
    class Main
    {
        public static void MainFunction()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("       Database Checker       ");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
            Console.WriteLine("Welkom op op de console applicatie, ");
            Console.WriteLine("elke 20 minuten zal de database worden gecontroleerd");
            Console.WriteLine("Deze applicatie is ter ondersteuing van de Cisco Tool");
            Console.WriteLine();


            //MainCode.updateDatabase();
            Timers.DatabaseUpdateTimer();
            //MainCode.updateSerials(); // enable this line to get all serial codes
            //Timers.SerialCodeTimer(); // enable this line to get all serial codes


            Console.ReadKey();
            Console.WriteLine("bezig met afsluiten...");
            Thread.Sleep(1000); // sleeps for userexperience
            Environment.Exit(ErrorCodes.errorExitID); 
        }
    }
}
