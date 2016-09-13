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
        public static Timer timer = new Timer();
        public static void executeTimer (int seconds)
        {
            timer.Elapsed += new ElapsedEventHandler(Main.MainCode);
            timer.Interval = seconds * 1000; // from milliseconds to minutes
            timer.Enabled = true;

        }
    }
}
