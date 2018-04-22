using Aurora.Data;
using System;
using System.Windows.Forms;

namespace tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var a = 1;
            a.ToEngine();

            var b = Engine.SQLite;
            b.ToIndex();

           var z = Aurora.Data.Queries.MysqlQueryHelper.TableListQuery("master");        
        }

        private string ConnectionString
        {
            get
            {
                return "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
