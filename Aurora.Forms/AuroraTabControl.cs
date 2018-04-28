using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;

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

        public new IEnumerable<AuroraTabPage> TabPages => base.TabPages.Cast<TabPage>().Select(t => (AuroraTabPage)t);

        public new AuroraTabPage SelectedTab => TabPages.ToList()[SelectedIndex];
    }
}
