using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace CRUDMysqlApp
{
    public class CrudDemo
    {
        private string connString;

        public CrudDemo(string server,string database,string uid,string password)
        {
            connString = string.Format("server={0};database={1};user={2};password={3}", 
                server, database, uid, password);
        }

        public void TestConnection()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                Console.WriteLine("Connected");
                conn.Close();
                Console.WriteLine("Closed");
            }catch(MySqlException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }
        public void CreateData()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                Console.WriteLine("Connected");
                conn.Close();
                Console.WriteLine("Closed");
            }catch(MySqlException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public void ReadData()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                Console.WriteLine("Connected");
                conn.Close();
                Console.WriteLine("Closed");
            }catch(MySqlException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public void UpdateData()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                Console.WriteLine("Connected");
                conn.Close();
                Console.WriteLine("Closed");
            }catch(MySqlException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public void DeleteData(int id)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                Console.WriteLine("Connected");
                conn.Close();
                Console.WriteLine("Closed");
            }catch(MySqlException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
