﻿using CiscoDatabaseProgram.Functions.Main;
using CiscoDatabaseProgram.Functions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CiscoDatabaseProgram.Functions.Logging
{
    class Exit
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void exitByMySQL(string originalErrorMessage) 
        {
            Console.WriteLine("");
            Console.WriteLine("Applicatie kon geen verbinding maken met MySQL (main) database");
            Console.WriteLine("Hestart de applicatie en probeer het opnieuw");
            Console.WriteLine("Mocht dit probleem aanhouden, raadpleeg de applicatie ontwikkelaar");
            Console.WriteLine("");
            Console.WriteLine("Druk op een knop om af te sluiten...");

            log.Error("ERROR - Could not reach MySQL database");
            log.Error("Errormessage - " + originalErrorMessage );
            log.Error("Terminating application");
            log.Error(ErrorCodes.generalErrorShutdown);
            if (Timers.TimerDatabaseUpdate.Enabled != false)
            {
                Timers.TimerDatabaseUpdate.Stop(); 
                Timers.TimerSerial.Stop(); 
            }
            else
            {
                Console.ReadKey(); 
                Console.WriteLine("bezig met afsluiten...");
                Thread.Sleep(1000); // sleeps for userexperience
                Environment.Exit(ErrorCodes.errorExitID); 
            }


        }
        public static void exitBySQL(string originalErrorMessage) // Own SQL database
        {
            Console.WriteLine("");
            Console.WriteLine("Applicatie kon geen verbinding maken met SQL (Own) database");
            Console.WriteLine("Hestart de applicatie en probeer het opnieuw");
            Console.WriteLine("Mocht dit probleem aanhouden, raadpleeg de applicatie ontwikkelaar");
            Console.WriteLine("");
            Console.WriteLine("Druk op een knop om af te sluiten...");

            log.Error("ERROR - Could not reach SQL database");
            log.Error("Errormessage - " + originalErrorMessage);
            log.Error("Terminating application");
            log.Error(ErrorCodes.generalErrorShutdown);
            if (Timers.TimerDatabaseUpdate.Enabled != false)
            {
                Timers.TimerDatabaseUpdate.Stop(); // stops the timer to prevent the function from running
                Timers.TimerSerial.Stop(); // stops timer from more runs
            }
            else
            {
                Console.ReadKey(); // waits for the user to notice the error
                Console.WriteLine("bezig met afsluiten...");
                Thread.Sleep(1000); // sleeps for userexperience
                Environment.Exit(ErrorCodes.errorExitID); //exit application
            }
        }

        public static void defaultExit() // Own SQL database
        {
            log.Error("Terminating application");
            log.Error(ErrorCodes.generalErrorShutdown);
            if (Timers.TimerDatabaseUpdate.Enabled != false)
            {
                Timers.TimerDatabaseUpdate.Stop(); // stops the timer to prevent the function from running
                Timers.TimerSerial.Stop(); // stops timer from more runs
            }
            else
            {
                Console.ReadKey(); // waits for the user to notice the error
                Console.WriteLine("bezig met afsluiten...");
                Thread.Sleep(1000); // sleeps for userexperience
                Environment.Exit(ErrorCodes.errorExitID); //exit application
            }
        }
    }
}
