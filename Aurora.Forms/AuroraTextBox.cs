using System.Windows.Forms;
using System.Drawing;
using Aurora.Forms.Azuki;
using Sgry.Azuki;
using FreeView.Sql;

namespace Aurora.Forms
{
    public partial class AuroraTextBox : Sgry.Azuki.WinForms.AzukiControl
    {
        public void SetColor(CharType charType, Color foreColor, Color backColor) => ColorScheme.SetColor(charType.ToCharClass(), foreColor, backColor);

        public AuroraTextBox()
        {
            InitializeComponent();
            Highlighter = AzukiConfiguration.LoadHighlighter();
        }

        private void InitializeComponent()
        {
            BorderStyle = BorderStyle.FixedSingle;
            DrawingOption = (((((DrawingOption.DrawsFullWidthSpace
            | DrawingOption.DrawsTab)
            | DrawingOption.DrawsEol)
            | DrawingOption.HighlightCurrentLine)
            | DrawingOption.ShowsDirtBar)
            | DrawingOption.HighlightsMatchedBracket);
            FirstVisibleLine = 0;
            ShowsLineNumber = false;
            ShowsVScrollBar = false;
            ShowsHScrollBar = false;
            UseCtrlTabToMoveFocus = false;

            ViewType = ViewType.WrappedProportional;
            Dock = DockStyle.Fill;
            ColorScheme.SetColor(CharClass.Keyword, Color.Blue, Color.White);
            ColorScheme.SetColor(CharClass.String, Color.Red, Color.White);
            ColorScheme.SetColor(CharClass.Comment, Color.Green, Color.White);
            ColorScheme.SetColor(CharClass.Number, Color.Yellow, Color.White);

            ResumeLayout(false);
        }

        public void ClearText() => Text = string.Empty;

        public void FormatText(bool isUseNewline = false)
        {
            var rule = new SqlRule();
            rule.IndentString = isUseNewline ? "    " : "";
            var formatter = new SqlFormatter(rule);
            var formattedText = formatter.Format(Text);

            if (!isUseNewline)
            {
                formattedText = formattedText.Replace(System.Environment.NewLine, " ");
            };
            Text = formattedText;
        }
    }
}
