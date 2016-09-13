﻿using System;
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
        public static void writeToLogfile(List<string> listAllStrings)
        {
            try
            {
                StreamWriter sw = new StreamWriter("Files/Logfile.txt", true);
                foreach (var textString in listAllStrings)
                {
                    string text = textString + Environment.NewLine;
                    sw.Write(text);
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error - Kan logboek niet wegschrijven");
                Console.WriteLine("Error message: " + ex.Message);
                throw;
            }
        }
    }
}
