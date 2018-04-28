using Aurora.Data;
using Aurora.Data.Client.Connection;
using System;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace Aurora.Forms
{
    /// <summary>
    /// TODO:OK,Cancel
    /// </summary>
    public partial class ConnectionForm : BaseForm
    {
        private Servers _servers;

        private int _oldIndex = 0;

        public new Servers ShowDialog()
        {
            base.ShowDialog();
            return _servers;
        }

        public ConnectionForm(Servers servers)
        {
            InitializeComponent();
            _servers = servers;
        }

        private void ConnectionForm_Load(object sender, EventArgs e)
        {
            _servers.Select(server => listBox.Items.Add($"{server.Name} <{server.Engine.ToString()}>")).ToList();
        }

        private void listBox1_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(listBox.SelectedIndex == -1)
            {
                return;
            }
            if (propertyGrid.SelectedObject != null)
            {
                _servers[_oldIndex].Connection.ConnectionString = ((DbConnectionStringBuilder)propertyGrid.SelectedObject).ToString();
            }
            _oldIndex = listBox.SelectedIndex;

            var server = _servers[listBox.SelectedIndex];
            SetPropertyObject(server);
        }

        private void SetPropertyObject(Server server)
        {
            switch (server.Engine)
            {
                case Engine.SqlServer:
                    propertyGrid.SelectedObject = BuilderProvider.SqlConnectionStringBuilder(server.Connection.ConnectionString);
                    break;
                case Engine.MySql:
                    propertyGrid.SelectedObject = BuilderProvider.MySqlConnectionStringBuilder(server.Connection.ConnectionString);
                    break;
                case Engine.PostgreSql:
                    propertyGrid.SelectedObject = BuilderProvider.PGSqlConnectionStringBuilder(server.Connection.ConnectionString);
                    break;
                case Engine.MariaDB:
                    propertyGrid.SelectedObject = BuilderProvider.MySqlConnectionStringBuilder(server.Connection.ConnectionString);
                    break;
                case Engine.SQLite:
                    propertyGrid.SelectedObject = BuilderProvider.SqliteConnectionStringBuilder(server.Connection.ConnectionString);
                    break;
                case Engine.Oracle:
                    propertyGrid.SelectedObject = BuilderProvider.OracleConnectionStringBuilder(server.Connection.ConnectionString);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
