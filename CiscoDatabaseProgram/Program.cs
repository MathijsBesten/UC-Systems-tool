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
            if (Settings.Default.CiscoToolServerIP == "")
            {
                Settings.Default.CiscoToolServerIP = "";
                Settings.Default.CiscoToolServerDatabase = "";
                Settings.Default.CiscoToolServerUsername = "";
                Settings.Default.CiscoToolServerPassword = "";

                Settings.Default.MainServerIP = "";
                Settings.Default.MainServerDatabase = "";
                Settings.Default.MainServerUsername = "";
                Settings.Default.MainServerPassword = "";

                Settings.Default.TestRouterIP = "";
                Settings.Default.TestRouterUsername = "";
                Settings.Default.TestRouterPassword = "";

                Settings.Default.username = "";
                Settings.Default.password = "";
                Settings.Default.Save();

                Console.WriteLine("Er was geen instellingen gevonden");
                Console.WriteLine("Graag alle gegevens invullen, in het configuratie bestand");
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