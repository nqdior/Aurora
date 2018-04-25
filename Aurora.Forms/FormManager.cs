using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Aurora.Forms
{
    public static class FormManager
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        public static void ConvertMessageMove(MouseEventArgs e, IntPtr Handle)
        {
            if (!e.Button.Equals(MouseButtons.Left)) { return; }

            ReleaseCapture();
            // 0xA1:WM_NCLBUTTON    0x2:HT_CAPTION
            SendMessage(Handle, 0xA1, (IntPtr)0x2, IntPtr.Zero);
        }

        public static void ConvertMessagePoint(ref Message m, Form form)
        {
            if (m.Msg != 0x84) return;

            // Point Calclation
            int x = (m.LParam.ToInt32() % 65536);
            int y = (m.LParam.ToInt32() / 65536);
            Point p = form.PointToClient(new Point(x, y));

            if (p.X < form.ClientRectangle.Left) return;
            if (p.X > form.ClientRectangle.Right) return;
            if (p.Y < form.ClientRectangle.Top) return;
            if (p.Y > form.ClientRectangle.Bottom) return;

            if (p.X < form.ClientRectangle.Left + 5)
            {
                if (p.Y < form.ClientRectangle.Top + 5)
                {
                    m.Result = (IntPtr)13;
                    return;
                }
                if (p.Y > form.ClientRectangle.Bottom - 5)
                {
                    m.Result = (IntPtr)16;
                    return;
                }
                m.Result = (IntPtr)10;
                return;
            }

            if (p.X > form.ClientRectangle.Right - 5)
            {
                if (p.Y < form.ClientRectangle.Top + 5)
                {
                    m.Result = (IntPtr)14;
                    return;
                }
                if (p.Y > form.ClientRectangle.Bottom - 5)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
                m.Result = (IntPtr)11;
                return;
            }

            if (p.Y < form.ClientRectangle.Top + 5)
            {
                m.Result = (IntPtr)12;
                return;
            }
            if (p.Y > form.ClientRectangle.Bottom - 5)
            {
                m.Result = (IntPtr)15;
                return;
            }

            return;
        }
    }
}
