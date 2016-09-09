using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using MySql.Data.MySqlClient.Properties;

namespace CiscoDatabaseProgram.Functions.Logging
{
    class Logs
    {
        public static void writeToLogfile(string[] totalStrings)
        {
            StreamWriter sw = new StreamWriter("Files/Logfile.txt", true);
            foreach (var textString in totalStrings)
            {
                string text = textString + Environment.NewLine;
                sw.Write(text);
            }
            sw.Close();
        }
    }
}
