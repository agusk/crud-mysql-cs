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

                string query = "insert into product(name,price,created) values(@name,@price,@created)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add("@name", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@price", MySqlDbType.Float);
                cmd.Parameters.Add("@created", MySqlDbType.DateTime);

                Console.Write("Inserting 10 data....");
                DateTime now = DateTime.Now;
                for (int i = 1; i <= 10;i++ )
                {
                    cmd.Parameters[0].Value = "product-" + i;
                    cmd.Parameters[1].Value = 0.26 * i;
                    cmd.Parameters[2].Value = now;

                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Done");

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

                string query = "select idproduct,name,price,created from product";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader rd = cmd.ExecuteReader();
                while(rd.Read())
                {
                    Console.WriteLine("Id: " + rd["idproduct"].ToString());
                    Console.WriteLine("Name: " + rd["name"].ToString());
                    Console.WriteLine("Price: " + rd["price"].ToString());
                    Console.WriteLine("Created: " + rd["created"].ToString());
                    Console.WriteLine("---------------------------");
                }
                rd.Close();

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
