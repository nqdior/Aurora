using System.Windows.Forms;

namespace Aurora.Forms
{
    public class AuroraDataGridView: DataGridView
    {
        public AuroraDataGridView()
        {
            Dock = DockStyle.Fill;
            EnableHeadersVisualStyles = false;
        }
    }
}
