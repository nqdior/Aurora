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
        private AuroraTabControl auroraTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private AuroraToolStripComboBox Select_Database;

        public MainForm()
        {
            UserInitializeComponent();
            new ForDevelop().Show();
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

        /// <summary>
        /// 自動生成
        /// </summary>
        private new void InitializeComponent()
        {
            this.auroraTabControl1 = new Aurora.Forms.AuroraTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.auroraTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // auroraTabControl1
            // 
            this.auroraTabControl1.Controls.Add(this.tabPage2);
            this.auroraTabControl1.Controls.Add(this.tabPage1);
            this.auroraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.auroraTabControl1.Location = new System.Drawing.Point(0, 24);
            this.auroraTabControl1.Name = "auroraTabControl1";
            this.auroraTabControl1.SelectedIndex = 0;
            this.auroraTabControl1.Size = new System.Drawing.Size(284, 260);
            this.auroraTabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(276, 234);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(0, 0);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 284);
            this.Controls.Add(this.auroraTabControl1);
            this.Name = "MainForm";
            this.auroraTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void UserInitializeComponent()
        {
            SuspendLayout();

            // beta

            this.auroraTabControl1 = new Aurora.Forms.AuroraTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.auroraTabControl1.SuspendLayout();
            // 
            // auroraTabControl1
            // 
            this.auroraTabControl1.Controls.Add(this.tabPage1);
            this.auroraTabControl1.Controls.Add(this.tabPage2);
            this.auroraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.auroraTabControl1.Location = new System.Drawing.Point(0, 24);
            this.auroraTabControl1.Name = "auroraTabControl1";
            this.auroraTabControl1.SelectedIndex = 0;
            this.auroraTabControl1.Size = new System.Drawing.Size(284, 260);
            this.auroraTabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(276, 234);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(0, 0);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;

            this.Controls.Add(this.auroraTabControl1);


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
