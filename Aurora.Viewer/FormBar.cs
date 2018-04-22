using System;
using System.Drawing;
using System.Windows.Forms;

namespace  Aurora.Viewer
{
    public partial class FormBar : UserControl
    {
        public bool isMultiMode
        {
            set { SVCombo.Visible = value; }
        }

        public bool isController
        {
            get
            {
                return iscontroller;
            }
            set
            {
                iscontroller = value;
                DBcombo.Visible = value;
            }
        }

        private bool iscontroller = false;


        public FormBar()
        {
            InitializeComponent();                     
        }


        private void FormBar_Load(object sender, EventArgs e)
        {
            title.Text = " " + ((Form)Parent).Text;
        }


        private void FormBar_MouseDown(object sender, MouseEventArgs e)
        {
            FormManager.ConvertMessageMove(e, Parent.Handle);
        }


        private void minBtn_Click(object sender, EventArgs e)
        {
            if (isController)
            {
                ((Form)Parent).WindowState = FormWindowState.Minimized;
            }
            else
            {
                ((Form)Parent).Close();
            }
        }


        private void closeBtn_Click(object sender, EventArgs e) => ((Form)Parent).Close();
        


        private void title_Click(object sender, EventArgs e)
        {
            ((Form)Parent).WindowState =
                ((Form)Parent).WindowState == FormWindowState.Normal
                ? FormWindowState.Maximized : FormWindowState.Normal;
        }


        private void topMost_Click(object sender, EventArgs e)
        {
            ((Form)Parent).TopMost = !((Form)Parent).TopMost;
            ((ToolStripMenuItem)sender).BackColor =
                ((Form)Parent).TopMost
                ? SystemColors.MenuHighlight : Color.Black;
        }


        public event EventHandler DBComboIndexChanged;

        private void DBcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBComboIndexChanged?.Invoke(sender, e);
        }


        public event EventHandler SVComboIndexChanged;

        private void SVCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SVComboIndexChanged?.Invoke(sender, e);
        }
    }
}
