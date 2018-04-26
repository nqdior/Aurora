using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Aurora.Forms
{
    public partial class BaseForm : Form
    {
        private ToolStripMenuItem Item_Title;

        [Category("Design")]
        public new string Text
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

            var Item_Min = new ToolStripMenuItem()
            {
                Alignment = ToolStripItemAlignment.Right,
                Image = (Image)resource.GetObject("Min")
            };

            var Item_Max = new ToolStripMenuItem()
            {
                Alignment = ToolStripItemAlignment.Right,
                Image = (Image)resource.GetObject("Max")
            };

            var Item_Close = new ToolStripMenuItem()
            {
                Alignment = ToolStripItemAlignment.Right,
                Image = (Image)resource.GetObject("Close")
            };

            Item_Title = new ToolStripMenuItem()
            {
                Alignment = ToolStripItemAlignment.Left,
            };

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
            TitleBar.DoubleClick += (sender, e) => Item_Max.PerformClick();
            Load += (sender, e) => TitleBar.SendToBack();

            ResumeLayout();
        }
    }
}
