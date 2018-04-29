using Aurora.Data;
using Aurora.Data.Client.Connection;
using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Windows.Forms;

namespace Aurora.Forms
{
    /// <summary>
    /// TODO:OK,Cancel
    /// </summary>
    public partial class ConnectionForm : BaseForm
    {
        private Servers _servers;

        private Servers _default;

        private string _oldKey = "";

        private string selectedKey => listBox.SelectedItem?.ToString().Split('<')[0].Trim();

        private void ChangeSelectServer(Server value)
        {
            watermarkTextBox1.Text = value.Name;
            comboBox1.Text = value.Engine.ToString();
        }

        public new Servers ShowDialog()
        {
            base.ShowDialog();
            if (selectedKey != null)
            {
                _servers[selectedKey].Connection.ConnectionString = ((DbConnectionStringBuilder)propertyGrid.SelectedObject).ToString();
            }
            return _servers;
        }

        public ConnectionForm(Servers servers)
        {
            InitializeComponent();

            _servers = servers;
            _default = _servers.Clone();
        }

        private void ConnectionForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Enum.GetValues(typeof(Engine));
            _servers.Select(server => listBox.Items.Add($"{server.Value.Name} <{server.Value.Engine.ToString()}>")).ToList();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox.SelectedIndex == -1)
            {
                ChangeSelectServer(new Server("", Engine.SqlServer));
                return;
            }
            if (propertyGrid.SelectedObject != null)
            {
                _servers[_oldKey].Connection.ConnectionString = ((DbConnectionStringBuilder)propertyGrid.SelectedObject).ToString();
            }
            _oldKey = selectedKey;

            var server = _servers[selectedKey];
            ChangeSelectServer(server);
            SetPropertyObject(server);
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(watermarkTextBox1.Text)) return;
            var server = new Server(watermarkTextBox1.Text, comboBox1.Text.ToEngine());

            try
            {
                _servers.Add(server);
                listBox.Items.Add($"{server.Name} <{server.Engine.ToString()}>");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            if (selectedKey == null) return;
            ChangeSelectServer(new Server("", Engine.SqlServer));
            propertyGrid.SelectedObject = null;
            _servers.Remove(selectedKey);
            listBox.Items.RemoveAt(listBox.SelectedIndex);
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
