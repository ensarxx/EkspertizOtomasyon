using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoEkspertizForm
{
    public class DbConnection
    {
        private static string connectionString = "Server=localhost;Database=otoekspertiz;Uid=root;Pwd=root;";
        private static MySqlConnection connection;

        public static MySqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new MySqlConnection(connectionString);
            }
            return connection;
        }

        public static void OpenConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public static void CloseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
