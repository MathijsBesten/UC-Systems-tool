using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CiscoDatabaseProgram.Functions.Main
{
    class Timers
    {
        public static Timer TimerMain = new Timer();
        public static Timer TimerSerial = new Timer();
        public static void MainCodeTimer(int seconds)
        {
            TimerMain.Elapsed += new ElapsedEventHandler(Main.MainCode);
            TimerMain.Interval = seconds * 1000; // from milliseconds to seconds
            TimerMain.Enabled = true;

        }
        public static void SerialCodeTimer(int seconds)
        {
            //TimerSerial.Elapsed += new ElapsedEventHandler(Main.keepSerialNumbersUpToDate);
            TimerSerial.Interval = seconds * 1000; // from milliseconds to seconds
            TimerSerial.Enabled = true;
        }
    }
}
