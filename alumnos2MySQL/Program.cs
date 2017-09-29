using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace alumnos2MySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && File.Exists(args[0]))
            {

                string server, db, uid, pwd, table;

                Console.WriteLine("Parsing: " + args[0]);

                Console.Write("Server: ");
                server = Console.ReadLine();
                Console.Write("database: ");
                db = Console.ReadLine();
                Console.Write("Tabla: ");
                table = Console.ReadLine();
                Console.Write("user: ");
                uid = Console.ReadLine();
                Console.Write("password: ");
                pwd = Console.ReadLine();

                string connectionString = "server="+server+";database="+db+";uid="+uid+";pwd="+pwd+";";
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();

            

                MySqlBulkLoader bulk = new MySqlBulkLoader(conn);
                bulk.TableName = table;
                bulk.FieldTerminator = ",";
                bulk.LineTerminator = "\r\n";
                bulk.FileName = args[0];
                bulk.NumberOfLinesToSkip = 1;
                var inserted = bulk.Load();
                Console.WriteLine(inserted + " rows inserted.");

            }

            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();
        }

        
    }

}
