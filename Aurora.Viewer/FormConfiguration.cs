using Aurora.Viewer.Properties;
using System.Windows.Forms;

namespace Aurora.Viewer
{
    internal static class FormConfiguration
    {
        internal static void Apply(Control form)
        {
            foreach (Control c in form.Controls)
            {
                c.Font = Settings.Default.Font;
                Apply(c);
            }
        }
    }
}
