using System;
using Aurora.Data;
using Aurora.Forms;
using Aurora.Model;
using Aurora.Data.Client.Connection;
using System.Windows.Forms;
using Aurora.Viewer.Properties;

namespace Aurora.Viewer
{
    public partial class TestForm : BaseForm
    {
        private AuroraToolStripComboBox Select_Server;
        private AuroraToolStripComboBox Select_Database;
        private AuroraTabControl TabControl;

        public TestForm()
        {
            UserInitializeComponent();
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

            TabControl.SelectedTab.Server = server;
        }

        private void GetAllControls(Control form)
        {
            foreach (Control c in form.Controls)
            {
                c.Font = Settings.Default.Font;
                GetAllControls(c);
            }
        }
          
        private void UserInitializeComponent()
        {
            SuspendLayout();

            TabControl = new AuroraTabControl();
            TabControl.Controls.Add(new AuroraTabPage("test"));
            Controls.Add(TabControl);

            Load += new EventHandler(MainForm_Load);
            ClientSize = new System.Drawing.Size(640, 396);

            Select_Database = new AuroraToolStripComboBox();
            TitleBar.Items.Add(Select_Database);

            Select_Server = new AuroraToolStripComboBox(Enum.GetValues(typeof(Engine)));
            TitleBar.Items.Add(Select_Server);

            Text = "Aurora";

            var testbutton = new Button();
            testbutton.Text = "testする";
            testbutton.Click += (sender, e) =>
            {
                TableController table = new TableController(TabControl.SelectedTab.Server);
//                tabControl.TabPages[0].
            };
            Controls.Add(testbutton);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
