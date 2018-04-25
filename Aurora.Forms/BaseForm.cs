using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Aurora.Forms
{
    public partial class BaseForm : Form
    {
        private ToolStripMenuItem Item_Title;

        [Category("Design")]
        public string Title
        {
            get { return Item_Title.Text; }
            set { Item_Title.Text = value; }
        }

        [Category("Design")]
        public MenuStrip TitleBar { get; set; }

        public BaseForm() 
        {
            ControlBox = false;
            InitializeComponent();        
        }

        public void InitializeComponent()
        {
            SuspendLayout();

            var resource = new ComponentResourceManager(typeof(BaseForm));

            var Item_Min = new ToolStripMenuItem((Image)resource.GetObject("Min"));
            Item_Min.Alignment = ToolStripItemAlignment.Right;

            var Item_Max = new ToolStripMenuItem((Image)resource.GetObject("Max"));
            Item_Max.Alignment = ToolStripItemAlignment.Right;

            var Item_Close = new ToolStripMenuItem((Image)resource.GetObject("Close"));
            Item_Close.Alignment = ToolStripItemAlignment.Right;

            Item_Title = new ToolStripMenuItem();
            Item_Title.Alignment = ToolStripItemAlignment.Left;

            TitleBar = new MenuStrip();
            TitleBar.Items.AddRange(new ToolStripItem[] { Item_Close, Item_Max, Item_Min, Item_Title });
            Controls.Add(TitleBar);

            Item_Min.Click += (sender, e) => WindowState = FormWindowState.Minimized;
            Item_Max.Click += (sender, e) =>
            {
                WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
                Item_Max.Image = (Image)(WindowState == FormWindowState.Maximized ? resource.GetObject("Normal") : resource.GetObject("Max"));
            };
            Item_Close.Click += (sender, e) => Close();
            TitleBar.MouseDown += (sender, e) => FormManager.ConvertMessageMove(e, Handle);
            // why not correct action XD
            // TitleBar.DoubleClick += (sender, e) => Item_Max.PerformClick();

            ResumeLayout();
        }
    }
}
