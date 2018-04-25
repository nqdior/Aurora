using System;
using Aurora.Data;
using Aurora.Forms;

namespace Aurora.Viewer
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private new void InitializeComponent()
        {
            SuspendLayout();

            Load += new EventHandler(MainForm_Load);
            ClientSize = new System.Drawing.Size(640, 396);

            var Select_Database = new AuroraToolStripComboBox();
            TitleBar.Items.Add(Select_Database);

            var Select_Server = new AuroraToolStripComboBox(Enum.GetValues(typeof(Engine)));
            TitleBar.Items.Add(Select_Server);

            Title = "Aurora XIS";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
