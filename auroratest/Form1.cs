using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aurora;
using Aurora.Data;
using Aurora.Data.Client.Connection;

namespace auroratest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var server = new Server("test", Engine.SqlServer);
            server.Connection.ConnectionString = CommandBuilderFactory
        }
    }
}
