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
            var list = manager.GetData(new QueryProvider(Engine.SQLServer).DatabaseListQuery());             
        }

        private string ConnectionString
        {
            get
            {
                var connectionString = BuilderProvider.SqlConnectionStringBuilder();
                connectionString.DataSource = "localhost";
                connectionString.IntegratedSecurity = true;
                return connectionString.ToString();
            }
        }
    }
}
