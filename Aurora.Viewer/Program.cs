using System;
using System.Windows.Forms;

namespace Aurora.Viewer
{
    static class Program
    {
        /// <summary>
        /// test
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BaseForm());
        }
    }
}
