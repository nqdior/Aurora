using System.Windows.Forms;

namespace Aurora.Forms
{
    public class AuroraTabPage : TabPage
    {
        public AuroraTabPage()
        {
            InitializeComponent();
        }

        public AuroraTabPage(string text = "") : base(text)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            var splitter = new SplitContainer()
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal
            };
            var textBox = new AuroraTextBox();
            var dataGridView = new AuroraDataGridView();

            splitter.Panel1.Controls.Add(dataGridView);
            splitter.Panel2.Controls.Add(textBox);

            Controls.Add(splitter);
        }
    }
}
