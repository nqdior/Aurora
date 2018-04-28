using Sgry.Azuki;
using Sgry.Azuki.Highlighter;

namespace Aurora.Forms.Azuki
{
    internal sealed class SQLKeywordHighlighter : KeywordHighlighter
    {
        public SQLKeywordHighlighter()
        {
            AddEnclosure("'", "'", CharClass.String, '\\');
            AddEnclosure("@\"", "\"", CharClass.String, '\"');
            AddEnclosure("\"", "\"", CharClass.String, '\\');

            AddEnclosure("/*", "*/", CharClass.Comment);
            AddLineHighlight("--", CharClass.Comment);
        }

        public override void Highlight(Document doc)
        {
            int begin = -1;
            int end = -1;

            try
            {
                base.Highlight(doc);
                HighlightBracket(doc, out begin, out end);
            }
            catch
            {
            }
        }

        public override void Highlight(Document doc, ref int dirtyBegin, ref int dirtyEnd)
        {
            int begin = -1;
            int end = -1;

            try
            {
                base.Highlight(doc, ref dirtyBegin, ref dirtyEnd);
                HighlightBracket(doc, out begin, out end);
            }
            catch
            {
            }
        }

        public bool HighlightBracket(Document doc, out int begin, out int end)
        {
            begin = -1;
            end = -1;

            // "(" のハイライト
            if ((doc.Text.Length > doc.CaretIndex) && (doc.CaretIndex > 0))
            {
                if (doc.Text[doc.CaretIndex - 1] == '(')
                {
                    int match = doc.FindMatchedBracket(doc.CaretIndex - 1);
                    if (match < 0)
                    {
                        return false;
                    }

                    begin = doc.CaretIndex - 1;
                    end = match;

                    doc.SetCharClass(begin, CharClass.Keyword2);
                    doc.SetCharClass(end, CharClass.Keyword2);
                }
            }

            // ")" のハイライト
            if (doc.CaretIndex <= 0)
            {
                return true;
            }

            if (doc.Text[doc.CaretIndex - 1] == ')')
            {
                int match = doc.FindMatchedBracket(doc.CaretIndex - 1);
                if (match < 0)
                {
                    return false;
                }

                begin = match;
                end = doc.CaretIndex - 1;

                doc.SetCharClass(begin, CharClass.Keyword2);
                doc.SetCharClass(end, CharClass.Keyword2);
            }          

            return true;
        }
    }
}
