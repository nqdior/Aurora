/*
 * http://d.hatena.ne.jp/hnx8/20160131/1454254349
 */

using System.Drawing;
using System.Windows.Forms;

namespace Aurora.Forms
{
    internal class WatermarkTextBox : TextBox
    {
        private string _watermarkText = "";

        public string WatermarkText
        {
            get { return _watermarkText; }
            set
            {
                _watermarkText = value;
                Invalidate();
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_PAINT = 0x000F;
            base.WndProc(ref m);
            if (m.Msg != WM_PAINT || !string.IsNullOrEmpty(Text) || string.IsNullOrEmpty(WatermarkText) != false)
            {
                return;
            }
            using (var g = Graphics.FromHwnd(Handle))
            {
                var rect = ClientRectangle;
                rect.Offset(1, -5);
                TextRenderer.DrawText(g, WatermarkText, Font, rect, SystemColors.ControlDark, TextFormatFlags.Bottom | TextFormatFlags.Left);
            }            
        }
    }
}
