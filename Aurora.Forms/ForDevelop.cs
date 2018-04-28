using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sgry.Azuki;

namespace Aurora.Forms
{
    public partial class ForDevelop : Form
    {
        public ForDevelop()
        {
            InitializeComponent();
            new Sgry.Azuki.WinForms.AzukiControl();
        }

        private void ForDevelop_Load(object sender, EventArgs e)
        {
        }
    }
}
