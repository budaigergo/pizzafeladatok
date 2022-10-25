using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Pizza23_28
{
    class Pizza23_28
    {

        static void Main(string[] args)
        {

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();

            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "pizza";


            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
            Console.WriteLine("Válassz feladatot(23-28)");

            int asd = Convert.ToInt32(Console.ReadLine());
            Console.Clear();


            switch (asd)
            {
                case 23:
                    try
                    {
                        connection.Open();
                        MySqlCommand command = connection.CreateCommand();
                        command.CommandText = "SELECT fnev, COUNT(rendeles.fazon) FROM futar JOIN rendeles USING(fazon) GROUP BY fnev;";
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            Console.WriteLine("23.Hány házhoz szállítása volt az egyes futároknak?");
                            while (dr.Read())
                            {

                                string fnev = dr.GetString("fnev");
                                int countrfazon = dr.GetInt32("COUNT(rendeles.fazon)");
                                Console.WriteLine($"\t{fnev}, {countrfazon}");

                            }
                        }
                        connection.Close();
                    }
                    catch (MySqlException ex)
                    {

                        Console.WriteLine(ex.Message);
                        Environment.Exit(0);

                    }
                    break;

                case 24:
                    try
                    {
                        connection.Open();
                        MySqlCommand command = connection.CreateCommand();
                        command.CommandText = "SELECT pnev, SUM(tetel.db) FROM pizza JOIN tetel USING(pazon) GROUP BY pnev ORDER BY SUM(tetel.db) DESC";
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            Console.WriteLine("24.A fogyasztás alapján mi a pizzák népszerűségi sorrendje?");
                            while (dr.Read())
                            {

                                string pnev = dr.GetString("pnev");
                                int sumtdb = dr.GetInt32("SUM(tetel.db)");
                                Console.WriteLine($" \t{pnev}, {sumtdb}");

                            }


                        }
                        connection.Close();
                    }
                    catch (MySqlException ex)
                    {

                        Console.WriteLine(ex.Message);
                        Environment.Exit(0);

                    }
                    break;
                case 25:
                    try
                    {

                        connection.Open();

                        MySqlCommand command = connection.CreateCommand();
                        command.CommandText = "SELECT vnev, SUM(pizza.par*tetel.db) FROM tetel JOIN rendeles USING(razon) JOIN vevo USING(vazon) JOIN pizza USING(pazon) GROUP BY vevo.vnev ORDER BY SUM(pizza.par*tetel.db) DESC";
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            Console.WriteLine("25.A rendelések összértéke alapján mi a vevők sorrendje?");
                            while (dr.Read())
                            {

                                string vnev = dr.GetString("vnev");
                                int sumppartet = dr.GetInt32("SUM(pizza.par*tetel.db)");
                                Console.WriteLine($"\t{vnev}, {sumppartet}");

                            }


                        }
                        connection.Close();

                    }
                    catch (MySqlException ex)
                    {

                        Console.WriteLine(ex.Message);
                        Environment.Exit(0);

                    }
                    break;
                case 26:
                    try
                    {
                        connection.Open();

                        MySqlCommand command = connection.CreateCommand();
                        command.CommandText = "SELECT pizza.pnev, pizza.par FROM pizza WHERE pizza.par=(SELECT MAX(pizza.par) FROM pizza)";
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            Console.WriteLine("26.Melyik a legdrágább pizza?");
                            while (dr.Read())
                            {

                                string pnev = dr.GetString("pnev");
                                int par = dr.GetInt32("par");
                                Console.WriteLine($"\t{pnev}, {par}");

                            }


                        }
                        connection.Close();
                    }
                    catch (MySqlException ex)
                    {

                        Console.WriteLine(ex.Message);
                        Environment.Exit(0);
                    }
                    break;
                case 27:
                    try
                    {
                        connection.Open();

                        MySqlCommand command = connection.CreateCommand();
                        command.CommandText = "SELECT futar.fnev, SUM(tetel.db) FROM rendeles JOIN tetel USING(razon) JOIN futar USING(fazon) GROUP BY futar.fnev ORDER BY SUM(tetel.db) DESC LIMIT 1";
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            Console.WriteLine("27.Ki szállította házhoz a legtöbb pizzát?");
                            while (dr.Read())
                            {
                                string fnev = dr.GetString("fnev");
                                int sumtdb = dr.GetInt32("SUM(tetel.db)");
                                Console.WriteLine($"\t{fnev}, {sumtdb}");

                            }
                        }
                        connection.Close();
                    }
                    catch (MySqlException ex)
                    {

                        Console.WriteLine(ex.Message);
                        Environment.Exit(0);

                    }
                    break;
                case 28:
                    try
                    {
                        connection.Open();

                        MySqlCommand command = connection.CreateCommand();
                        command.CommandText = "SELECT vevo.vnev, SUM(tetel.db) FROM rendeles JOIN tetel USING(razon) JOIN vevo USING(vazon) GROUP BY vevo.vnev ORDER BY SUM(tetel.db) DESC LIMIT 1;";/*28.feldat*/
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            Console.WriteLine("28.Ki ette a legtöbb pizzát?");
                            while (dr.Read())
                            {

                                string vnev = dr.GetString("vnev");
                                int sumtdb = dr.GetInt32("SUM(tetel.db)");
                                Console.WriteLine($"\t{vnev}, {sumtdb}");

                            }


                        }
                        connection.Close();

                    }
                    catch (MySqlException ex)
                    {

                        Console.WriteLine(ex.Message);
                        Environment.Exit(0);

                    }
                    break;
            }
            Console.ReadKey();

        }
    }
}
