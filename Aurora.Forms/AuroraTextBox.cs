using System.Windows.Forms;
using System.Drawing;
using Aurora.Forms.Azuki;

namespace Aurora.Forms
{
    public partial class AuroraTextBox : Sgry.Azuki.WinForms.AzukiControl
    {
        public AuroraTextBox()
        {
            InitializeComponent();
            Highlighter = AzukiConfiguration.LoadHighlighter();
        }

        private void InitializeComponent()
        {
            Sgry.Azuki.FontInfo fontInfo1 = new Sgry.Azuki.FontInfo();
            SuspendLayout();
            // 
            // azukiControl
            // 
            BackColor = Color.Black;
            BorderStyle = BorderStyle.FixedSingle;
            Cursor = Cursors.IBeam;
            DrawingOption = (((((Sgry.Azuki.DrawingOption.DrawsFullWidthSpace
            | Sgry.Azuki.DrawingOption.DrawsTab)
            | Sgry.Azuki.DrawingOption.DrawsEol)
            | Sgry.Azuki.DrawingOption.HighlightCurrentLine)
            | Sgry.Azuki.DrawingOption.ShowsDirtBar)
            | Sgry.Azuki.DrawingOption.HighlightsMatchedBracket);
            FirstVisibleLine = 0;
            Font = new Font("Consolas", 9F);
            fontInfo1.Name = "Consolas";
            fontInfo1.Size = 9;
            fontInfo1.Style = FontStyle.Regular;
            FontInfo = fontInfo1;
            ForeColor = Color.White;
            ImeMode = ImeMode.Alpha;
            Location = new Point(0, 0);
            ScrollPos = new Point(0, 0);
            ShowsLineNumber = false;
            ShowsVScrollBar = false;
            Size = new Size(0, 0);
            TabIndex = 0;
            UseCtrlTabToMoveFocus = false;
            ViewType = Sgry.Azuki.ViewType.WrappedProportional;
            ViewWidth = 4101;
            Dock = DockStyle.Fill;
            ShowsHScrollBar = false;
            ImeMode = ImeMode.Alpha;

            MinimumSize = new Size(256, 128);
            ColorScheme.SetColor(Sgry.Azuki.CharClass.Keyword, Color.Aqua, Color.Black);
            ColorScheme.SetColor(Sgry.Azuki.CharClass.String, Color.Red, Color.Black);
            ColorScheme.SetColor(Sgry.Azuki.CharClass.Comment, Color.Lime, Color.Black);
            ColorScheme.SetColor(Sgry.Azuki.CharClass.Number, Color.Yellow, Color.Black);

            // 
            // CommandBox
            // 
            Size = new Size(230, 62);
            ResumeLayout(false);
        }
    }
}
