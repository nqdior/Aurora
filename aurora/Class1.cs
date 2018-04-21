using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aurora
{
    class Class1
    {
        static void Main()
        {
            var sv = new Server("test", Engine.SQLServer);
            var con = new SqlConnectionStringBuilder()
            {
                DataSource = "localhost",
                IntegratedSecurity = true
            };
            sv.Connection = new SqlConnection(con.ToString());

            var manager = new ServerManager(sv);
            Console.WriteLine(manager.Connect());
            Console.Read();
        }
    }
}
