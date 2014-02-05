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

        public void BulkData()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                Console.WriteLine("Connected");

                MySqlBulkLoader bulk = new MySqlBulkLoader(conn);
                bulk.TableName = "product";
                bulk.FieldTerminator = "\t";
                bulk.LineTerminator = "\n";
                bulk.FileName = "D:/product.txt"; // change with your file
                bulk.NumberOfLinesToSkip = 0;
                bulk.Columns.Add("name");
                bulk.Columns.Add("price");
                bulk.Columns.Add("created");
                
                Console.Write("Inserting bulk data....");
                int count = bulk.Load();
                Console.WriteLine("Done-" + count.ToString());

                conn.Close();
                Console.WriteLine("Closed");
            }
            catch (MySqlException e)
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
        public void UpdateData(int id)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                Console.WriteLine("Connected");

                string query = "update product set name=@name,price=@price where idproduct=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add("@name", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@price", MySqlDbType.Float);
                cmd.Parameters.Add("@id", MySqlDbType.Int32);

                Console.Write("Updating data....");
                cmd.Parameters[0].Value = "product-update";
                cmd.Parameters[1].Value = 0.75;
                cmd.Parameters[2].Value = id;

                cmd.ExecuteNonQuery();
                Console.WriteLine("Done");


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

                string query = "delete from product where idproduct=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32);

                Console.Write("Deleting data....");
                cmd.Parameters[0].Value = id;

                cmd.ExecuteNonQuery();
                Console.WriteLine("Done");


                conn.Close();
                Console.WriteLine("Closed");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
