using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cisco_Tool.Functions.Scripting
{
    class Read
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static List<string> readScript(string filePath)
        {
            try
            {
                string[] allStrings = System.IO.File.ReadAllLines(filePath);
                List<string> allCommands = new List<string>(allStrings);
                return allCommands;
            }
            catch (Exception e)
            {

                log.Error("Could not read scriptfile");
                log.Error("error - " + e.Message);
                return null;

            }
        }
    }
}
