// dotnet add package MySql.Data

using MySql.Data.MySqlClient;
using System.Data;

namespace con
{
    class Program
    {
        static void Main(string[] args)
        {
            var dt = new DataTable();

            string connectionString =
                "server=host.docker.internal;port=3333;uid=root;pwd=a;database=testdb;";

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var da = new MySqlDataAdapter(
                    "select * from person;", connection))
                {
                    da.Fill(dt);
                }
            }

            Console.WriteLine(
                (string)dt.Rows[0]["name"] + " " + (int)dt.Rows[0]["age"] + "\n" +
                (string)dt.Rows[1]["name"] + " " + (int)dt.Rows[1]["age"]
            );
        }
    }
}
