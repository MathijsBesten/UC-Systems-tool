using System;
using System.Collections.Generic;

namespace Cisco_Tool.Functions.Scripting
{
    class Read
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static List<string> ReadScript(string filePath)
        {
            try
            {
                string[] allStrings = System.IO.File.ReadAllLines(filePath);
                List<string> allCommands = new List<string>(allStrings);
                Log.Info("script correcly loaded");
                return allCommands;
            }
            catch (Exception e)
            {
                Log.Error("Could not read scriptfile");
                Log.Error("error - " + e.Message);
                return null;
            }
        }
    }
}
