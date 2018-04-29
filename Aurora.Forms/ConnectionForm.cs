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
    /// Setting connection string informations. 
    /// </summary>
    public partial class ConnectionForm : BaseForm
    {
        /// <summary>
        /// servers setting.
        /// </summary>
        private Servers _servers;

        /// <summary>
        /// original servers setting.
        /// </summary>
        private Servers _default;

        /// <summary>
        /// pre selected server.
        /// </summary>
        private Server _oldKey;

        /// <summary>
        /// selected server.
        /// </summary>
        private Server selectedServer => _servers[listBox.SelectedItem?.ToString().Split('<')[0].Trim()];

        /// <summary>
        /// Return changed servers information when this closed.
        /// </summary>
        /// <returns>Changed _servers</returns>
        public new Servers ShowDialog()
        {
            base.ShowDialog();
            if (selectedServer != null)
            {
                selectedServer.Connection.ConnectionString = ((DbConnectionStringBuilder)propertyGrid.SelectedObject).ToString();
            }
            return _servers;
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="servers"></param>
        public ConnectionForm(Servers servers)
        {
            InitializeComponent();

            _servers = servers;
            _default = _servers.Clone();
        }

        /// <summary>
        /// Add _servers object to listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectionForm_Load(object sender, EventArgs e)
        {
            select_Engine.DataSource = Enum.GetValues(typeof(Engine));
            _servers.Select(server => listBox.Items.Add($"{server.Value.Name} <{server.Value.Engine.ToString()}>")).ToList();
        }

        /// <summary>
        /// PropertyGrid's setting write to _servers when listbox's item has focus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox.SelectedIndex == -1)
            {
                ChangeSelectServer(new Server("", Engine.SqlServer));
                return;
            }
            if (propertyGrid.SelectedObject != null)
            {
                _oldKey.Connection.ConnectionString = ((DbConnectionStringBuilder)propertyGrid.SelectedObject).ToString();
            }
            _oldKey = selectedServer;

            var server = selectedServer;
            ChangeSelectServer(server);
            SetPropertyObject(server);
        }

        /// <summary>
        /// Write selected listbox's item to input area.
        /// </summary>
        /// <param name="value"></param>
        private void ChangeSelectServer(Server value)
        {
            textBox_Name.Text = value.Name;
            select_Engine.Text = value.Engine.ToString();
        }

        /// <summary>
        /// Server add to listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Name.Text)) return;
            var server = new Server(textBox_Name.Text, select_Engine.Text.ToEngine());

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

        /// <summary>
        /// The server remove from listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_remove_Click(object sender, EventArgs e)
        {
            if (selectedServer == null) return;

            ChangeSelectServer(new Server("", Engine.SqlServer));
            propertyGrid.SelectedObject = null;
            _servers.Remove(selectedServer.Name);

            listBox.Items.RemoveAt(listBox.SelectedIndex);
        }

        /// <summary>
        /// PropertyGrid's datasource setting.
        /// </summary>
        /// <param name="server"></param>
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
