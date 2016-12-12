﻿using System;

namespace CiscoDatabaseProgram
{
    class Program
    {
        static void Main()
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
            else // userdetails are entered in config file
            {
                Functions.Main.Main.MainFunction();
            }
        }
    }
}