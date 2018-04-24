using Aurora.Data;
using System;
using System.Windows.Forms;

namespace Aurora.Viewer
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();
            var Select_Server = new ToolStripComboBox()
            {
                Alignment = ToolStripItemAlignment.Right,
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat
            };
            Select_Server.Items.Add("SQLServer");
            TitleBar.Items.Add(Select_Server);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
