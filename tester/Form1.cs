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
            manager.GetData("select * from Centipede.dbo.be;");
        }

        private string ConnectionString
        {
            get
            {
                var connectionString = Builder.SqlConnectionBuilder();
                connectionString.DataSource = "localhost";
                connectionString.IntegratedSecurity = true;
                return connectionString.ToString();
            }
        }
    }
}
