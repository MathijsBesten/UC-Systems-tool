using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;

using CiscoDatabaseProgram.Functions;
using MySql.Data.MySqlClient;
using CiscoDatabaseProgram.Values;
using CiscoDatabaseProgram.Functions.MySQL;
using CiscoDatabaseProgram.Functions.Logging;
using System.Data.SqlClient;
using CiscoDatabaseProgram.Functions.Main;

namespace CiscoDatabaseProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Settings.Default.CiscoToolServerIP == "" || Settings.Default.CiscoToolServerIP == "Enter value here")
            {
                Settings.Default.CiscoToolServerIP = "Enter value here";
                Settings.Default.CiscoToolServerDatabase = "Enter value here";
                Settings.Default.CiscoToolServerUsername = "Enter value here";
                Settings.Default.CiscoToolServerPassword = "Enter value here";

                Settings.Default.MainServerIP = "Enter value here";
                Settings.Default.MainServerDatabase = "Enter value here";
                Settings.Default.MainServerUsername = "Enter value here";
                Settings.Default.MainServerPassword = "Enter value here";

                Settings.Default.username = "Enter value here";
                Settings.Default.password = "Enter value here";
                Settings.Default.Save();

                Console.WriteLine("Er waren geen instellingen gevonden");
                Console.WriteLine("Graag alle gegevens invullen in het configuratie bestand");
                Console.WriteLine(@"Het configuratie bestand kunt u vinden in APPDATA/LOCAL/ciscoDatabaseProgram/user.config");
                Console.WriteLine();
                Console.WriteLine("Herstart de applicatie en probeer het opnieuw");
                Console.WriteLine();
                Console.ReadLine();
            }
            else
            {
                Functions.Main.Main.MainFunction();
            }
        }
    }
}