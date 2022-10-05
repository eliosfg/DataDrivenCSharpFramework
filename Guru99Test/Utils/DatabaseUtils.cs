using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Guru99Test.Utils
{
    public class DatabaseUtils
    {
        private MySqlConnection connection;
        public DatabaseUtils(string server, string database, string username, string password)
        {
            string connectionString = $"server={server};database={database};uid={username};pwd={password}";

            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.Write("Cannot connect to the server");
                    break;

                    case 1045:
                        Console.Write("Invalid users");
                    break;
                }
                return false;
            }
        }

        public void ExecuteSqlQuery(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ExecuteSelectSqlQuery(string query)
        {
            DataTable datatable = new DataTable();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                datatable.Load(dataReader);

                dataReader.Close();
            }

            return datatable;
        }

        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}