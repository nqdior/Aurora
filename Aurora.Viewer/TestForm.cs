using System;
using Aurora.Data;
using Aurora.Forms;
using Aurora.Model;
using Aurora.Data.Client.Connection;
using System.Windows.Forms;
using Aurora.Viewer.Properties;
using System.Linq;

namespace Aurora.Viewer
{
    public partial class TestForm : BaseForm
    {
        private Servers _servers = new Servers();

        private AuroraToolStripComboBox select_Server;
        private AuroraToolStripComboBox select_Database;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newPageToolStripMenuItem;
        private AuroraTabControl TabControl;

        public TestForm()
        {
            UserInitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load Servers Setting
            
            if (_servers.Count == 0)
            {
                _servers = new ConnectionForm(_servers).ShowDialog();
            }
            select_Server.Items.AddRange(_servers.Select(s => s.Key).ToArray());

            // if none setting => create default & show setting
        }

        private void GetDatabase()
        {
            try
            {
                var server = _servers[select_Server.Text];
                var databases = new SchemaModel(server).GetDatabaseList();
                select_Database.Items.AddRange(databases.ToArray());

                if (!select_Database.Items.Contains(server.Connection.Database))
                {
                    return;
                }
                select_Database.Text = server.Connection.Database;         
            }
            catch
            {
                select_Database.Items.Clear();
            }
        }

        private void UserInitializeComponent()
        {
            SuspendLayout();

            TabControl = new AuroraTabControl();
            TabControl.Controls.Add(new AuroraTabPage("default"));
            Controls.Add(TabControl);

            Load += new EventHandler(MainForm_Load);
            ClientSize = new System.Drawing.Size(640, 396);

            select_Database = new AuroraToolStripComboBox();
            TitleBar.Items.Add(select_Database);

            select_Server = new AuroraToolStripComboBox();
            select_Server.SelectedIndexChanged += (sender, e) => GetDatabase();        
            TitleBar.Items.Add(select_Server);

            Text = "Aurora";

            ResumeLayout(false);
            PerformLayout();
        }

        /*
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPageToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newPageToolStripMenuItem
            // 
            this.newPageToolStripMenuItem.Name = "newPageToolStripMenuItem";
            this.newPageToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.newPageToolStripMenuItem.Text = "NewPage";
            // 
            // TestForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 284);
            this.Controls.Add(this.menuStrip1);
            this.Name = "TestForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        */
    }
}
