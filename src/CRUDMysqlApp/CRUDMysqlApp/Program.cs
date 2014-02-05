using System;
using System.Linq;

namespace CRUDMysqlApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CrudDemo app = new CrudDemo("localhost", "mydatabase", "user", "password");
            app.TestConnection();
            app.CreateData();
            app.ReadData();
            app.UpdateData(7); // change idproduct based on your data

            app.ReadData();
            app.DeleteData(8); // change idproduct based on your data
            app.ReadData();

            app.BulkData();
        }
    }
}
