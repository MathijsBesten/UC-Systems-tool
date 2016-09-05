using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CiscoDatabaseProgram.Functions.MySQL;
using CiscoDatabaseProgram.Values;
using MySql.Data.MySqlClient;

namespace CiscoDatabaseProgram.Functions.MySQL
{
    class Data
    {
        public static void getDataFromDatabase()
        {
            try
            {
                var connection = MySQL.General.MakeMySQLConnnection(PrivateValues.NIETAANZITTENserver, PrivateValues.NIETAANZITTENserverDB, PrivateValues.NIETAANZITTENserverUsername, PrivateValues.NIETAANZITTENserverPassword);
                connection.Open();
            }
            catch (MySqlException ex )
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("kan niet verbinden met server");
                        break;
                    case 1045:
                        Console.WriteLine("Gebruikersnaam en/of wachtwoord zijn fout, probeer het opnieuw");
                        break;
                    default:
                        Console.WriteLine("Geen foutafhandeling, deze code graag doorgeven aan de ontwikkelaar: " + ex.Number);
                        break;
                }
            }
        }
    }
}
