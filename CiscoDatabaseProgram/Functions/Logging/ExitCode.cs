using CiscoDatabaseProgram.Functions.Main;
using CiscoDatabaseProgram.Functions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CiscoDatabaseProgram.Functions.Logging
{
    class ExitCode
    {
        public static void exitByMySQL(string originalErrorMessage) // main MySQL database
        {
            List<string> log = new List<string>();
            Console.WriteLine("");
            Console.WriteLine("Applicatie kon geen verbinding maken met MySQL (main) database");
            Console.WriteLine("Hestart de applicatie en probeer het opnieuw");
            Console.WriteLine("Mocht dit probleem aanhouden, raadpleeg de applicatie ontwikkelaar");
            Console.WriteLine("");
            Console.WriteLine("Druk op een knop om af te sluiten...");

            log.Add("ERROR - Could not reach MySQL database");
            log.Add("Errormessage - " + originalErrorMessage );
            log.Add("Terminating application");
            log.Add(ErrorCodes.generalErrorShutdown);
            Logs.writeToLogfile(log);
            Timers.timer.Enabled = false; // stops the timer to prevent the function from running

            Console.ReadKey(); // waits for the user to notice the error
            //Environment.Exit(ErrorCodes.errorExitID);

        }
        public static void exitBySQL(string originalErrorMessage) // Own SQL database
        {
            List<string> log = new List<string>();
            Console.WriteLine("");
            Console.WriteLine("Applicatie kon geen verbinding maken met SQL (Own) database");
            Console.WriteLine("Hestart de applicatie en probeer het opnieuw");
            Console.WriteLine("Mocht dit probleem aanhouden, raadpleeg de applicatie ontwikkelaar");
            Console.WriteLine("");
            Console.WriteLine("Druk op een knop om af te sluiten...");

            log.Add("ERROR - Could not reach SQL database");
            log.Add("Errormessage - " + originalErrorMessage);
            log.Add("Terminating application");
            log.Add(ErrorCodes.generalErrorShutdown);
            Logs.writeToLogfile(log);
            Timers.timer.Enabled = false; // stops the timer to prevent the function from running

            Console.ReadKey(); // waits for the user to notice the error
            Console.WriteLine("bezig met afsluiten...");
            Thread.Sleep(1000);
            Environment.Exit(ErrorCodes.errorExitID);
        }

        public static void defaultExit() // Own SQL database
        {
            List<string> log = new List<string>();
            log.Add("Terminating application");
            log.Add(ErrorCodes.generalErrorShutdown);
            Logs.writeToLogfile(log);
            Timers.timer.Enabled = false; // stops the timer to prevent the function from running

            Console.ReadKey(); // waits for the user to notice the error
            Console.WriteLine("bezig met afsluiten...");
            Thread.Sleep(1000);
            //Environment.Exit(ErrorCodes.errorExitID);
        }
    }
}
