﻿using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace Aurora.Viewer
{
    public partial class BaseForm : Form
    {
        public BaseForm() 
        {
            ControlBox = false;
            InitializeComponent();        
        }

        public void InitializeComponent()
        {
            var resource = new ComponentResourceManager(typeof(BaseForm));
            var Button_Min = new ToolStripMenuItem((Image)resource.GetObject("Min"))
            {
                Alignment = ToolStripItemAlignment.Right
            };
            var Button_Max = new ToolStripMenuItem((Image)resource.GetObject("Max"))
            {
                Alignment = ToolStripItemAlignment.Right
            };
            var Button_Close = new ToolStripMenuItem((Image)resource.GetObject("Close"))
            {
                Alignment = ToolStripItemAlignment.Right
            };
            var FormBar = new MenuStrip();
            FormBar.Items.AddRange(new ToolStripItem[] { Button_Close, Button_Max, Button_Min });
            Controls.Add(FormBar);

            Button_Min.Click += (sender, e) => WindowState = FormWindowState.Minimized;
            Button_Max.Click += (sender, e) => WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            Button_Close.Click += (sender, e) => Close();
            FormBar.MouseDown += (sender, e) => FormManager.ConvertMessageMove(e, Handle);
            FormBar.MouseDoubleClick += (sender, e) => Button_Max.PerformClick();
        }
    }
}