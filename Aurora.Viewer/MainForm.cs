using Aurora.Data;
using Aurora.Data.Client.Connection;
using Aurora.Forms;
using Aurora.Model;

namespace Aurora.Viewer
{
    public partial class MainForm : BaseForm
    {
        private Servers _servers = new Servers();

        public MainForm()
        {
            InitializeComponent();

            var server = new Server("てすと１", Engine.SqlServer);
            var builder = BuilderProvider.SqlConnectionStringBuilder();
            builder.DataSource = "localhost";
            builder.IntegratedSecurity = true;
            server.Connection.ConnectionString = builder.ToString();
            var server2 = new Server("てすと２", Engine.SQLite);
            var servers = new Servers()
            {
                server,
                server2
            };
            new ConnectionForm(servers).Show();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            var server = new Server("test", Engine.SqlServer);
            var builder = BuilderProvider.SqlConnectionStringBuilder();
            builder.DataSource = "localhost";
            builder.IntegratedSecurity = true;
            server.Connection.ConnectionString = builder.ToString();

            var databases = new SchemaModel(server).GetDatabaseList();
            //Select_Database.Items.AddRange(databases.ToArray());
            //Select_Database.SelectedIndex = 0;

            FormConfiguration.Apply(this);
        }

        private void SettingOpen()
        {
            if (_servers.Count == 0)
            {
                return;
            }
            _servers = new ConnectionForm(_servers).ShowDialog();
        }

    }
}
