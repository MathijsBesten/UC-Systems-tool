using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Configuration;

namespace CiscoDatabaseProgram.Functions.Main
{
    class Timers
    {
        public static Timer TimerDatabaseUpdate = new Timer();
        public static Timer TimerSerial = new Timer();
        public static void DatabaseUpdateTimer()
        {
            int minutes = Int32.Parse(ConfigurationManager.AppSettings["TimerDatabaseUpdate"]);
            TimerDatabaseUpdate.Elapsed += new ElapsedEventHandler(MainCode.updateDatabase);
            TimerDatabaseUpdate.Interval = minutes * 1000; // from milliseconds to seconds
            TimerDatabaseUpdate.Enabled = true;

        }
        public static void SerialCodeTimer()
        {
            int minutes = Int32.Parse(ConfigurationManager.AppSettings["TimerSerialnumbers"]);
            TimerSerial.Elapsed += new ElapsedEventHandler(MainCode.updateSerials);
            TimerSerial.Interval = minutes * 1000; // from milliseconds to minutes
            TimerSerial.Enabled = true;
        }
    }
}
