using System.Windows.Forms;
using System.Drawing;

namespace Aurora.Forms
{
    public class AuroraTabControl : CustomTabControl
    {
        public AuroraTabControl()
        {
            Dock = DockStyle.Fill;
            DisplayStyleProvider.FocusColor = Color.AliceBlue;
            DisplayStyle = TabStyle.Default;
            DisplayStyleProvider.ShowTabCloser = true;
        }
    }
}
