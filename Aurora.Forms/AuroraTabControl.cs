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

            TabClosing += (sender, e) =>
            {
                var control = (CustomTabControl)sender;
                if (control.TabCount <= 1) e.Cancel = true;
            };
        }

        public new IEnumerable<AuroraTabPage> TabPages => base.TabPages.Cast<TabPage>().Select(t => (AuroraTabPage)t);

        public new AuroraTabPage ActiveTab => (AuroraTabPage)base.ActiveTab;

        public new AuroraTabPage SelectedTab => TabPages.ToList()[SelectedIndex];

        public virtual AuroraTabPage this[int index] => (AuroraTabPage)base.TabPages[index];

        public virtual AuroraTabPage this[string key] => (AuroraTabPage)base.TabPages[key];
         
    }
}
