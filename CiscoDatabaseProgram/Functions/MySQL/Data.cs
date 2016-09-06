using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CiscoDatabaseProgram.Functions.MySQL;
using CiscoDatabaseProgram.Values;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace CiscoDatabaseProgram.Functions.MySQL
{
    class Data
    {
        public static void getDataFromDatabase()
        {
            var connection = MySQL.General.MakeMySQLConnnection(PrivateValues.NIETAANZITTENserver, PrivateValues.NIETAANZITTENserverDB, PrivateValues.NIETAANZITTENserverUsername, PrivateValues.NIETAANZITTENserverPassword);
            try
            {
                connection.Open();
                Debug.WriteLine("connected to server");
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

            string query = "SELECT * FROM host";
            List<string>[] list = new List<string>[41];
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            int count = 1;
            while (dataReader.Read())
            {
                list[count].Add(dataReader[count] + "");
            }
            Console.ReadLine();
        }
    }
}
