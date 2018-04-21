using Aurora;
using System;
using System.Windows.Forms;

namespace tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var server = new Server("test", Engine.SQLServer);
            server.Connection.ConnectionString = ConnectionString;
            var manager = new Manager(server);
            var list = manager.GetData(MssqlQueryHelper.DatabaseListQuery);
            var list2 = manager.GetData(MssqlQueryHelper.TableListQuery);
            var list3 = manager.GetData(MssqlQueryHelper.ColumnListQuery);
        }

        private string ConnectionString
        {
            get
            {
                var connectionString = BuilderProvider.SqlConnectionStringBuilder();
                connectionString.DataSource = "localhost";
                connectionString.InitialCatalog = "Centipede";
                connectionString.IntegratedSecurity = true;
                return connectionString.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Server server = new Server("test2", Engine.SQLServer);
            
        }
    }
}
