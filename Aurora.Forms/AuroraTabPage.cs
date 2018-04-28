using Aurora.Data;
using System.Windows.Forms;

namespace Aurora.Forms
{
    public class AuroraTabPage : TabPage
    {
        public Server Server { get; set; }

        public AuroraTextBox TextBox { get; set; } = new AuroraTextBox();

        public AuroraDataGridView DataGridView { get; set; } = new AuroraDataGridView();

        public AuroraTabPage(string text) : base(text)
        {
            InitializeComponent();
            Server = new Server(Text, Engine.SqlServer);
        }

        private void InitializeComponent()
        {
            var splitter = new SplitContainer()
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal
            };

            splitter.Panel1.Controls.Add(DataGridView);
            splitter.Panel2.Controls.Add(TextBox);

            Controls.Add(splitter);
        }
    }
}
