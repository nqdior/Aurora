using System;
using Aurora.Data;
using Aurora.Forms;
using Aurora.Model;
using Aurora.Data.Client.Connection;
using System.Windows.Forms;
using Aurora.Viewer.Properties;

namespace Aurora.Viewer
{
    public partial class MainForm : BaseForm
    {
        private AuroraToolStripComboBox Select_Server;

        private AuroraToolStripComboBox Select_Database;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var server = new Server("test", Engine.SqlServer);
            var builder = BuilderProvider.SqlConnectionStringBuilder();
            builder.DataSource = "localhost";
            builder.IntegratedSecurity = true;
            server.Connection.ConnectionString = builder.ToString();

            var databases = new SchemaModel(server).GetDatabaseList();
            Select_Database.Items.AddRange(databases.ToArray());
            Select_Database.SelectedIndex = 0;

            GetAllControls(this);
        }

        private void GetAllControls(Control form)
        {
            foreach (Control c in form.Controls)
            {
                c.Font = Settings.Default.Font;
                GetAllControls(c);
            }
        }

        private new void InitializeComponent()
        {
            SuspendLayout();

            Load += new EventHandler(MainForm_Load);
            ClientSize = new System.Drawing.Size(640, 396);

            Select_Database = new AuroraToolStripComboBox();
            TitleBar.Items.Add(Select_Database);

            Select_Server = new AuroraToolStripComboBox(Enum.GetValues(typeof(Engine)));
            TitleBar.Items.Add(Select_Server);

            Text = "Aurora";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
