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
        public static void executeTimer (int seconds)
        {
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(Main.MainCode);
            timer.Interval = seconds * 1000; // from milliseconds to minutes
            timer.Enabled = true;
        }
    }
}
