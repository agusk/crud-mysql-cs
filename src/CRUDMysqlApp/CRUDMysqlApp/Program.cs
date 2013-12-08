using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDMysqlApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CrudDemo app = new CrudDemo("localhost", "mydatabase", "user", "password");
            app.TestConnection();
            app.CreateData();
            app.UpdateData(7);
            app.ReadData();
            
        }
    }
}
