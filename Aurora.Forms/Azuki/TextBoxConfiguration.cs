using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Sgry.Azuki;

namespace Aurora.Forms.Azuki
{
    internal static class AzukiConfiguration
    {
        private static List<string> SqlKeywords = new List<string>();

        internal static SQLKeywordHighlighter LoadHighlighter()
        {
            SqlKeywords = new List<string>();
            LoadKeywordFile();

            var hilighter = new SQLKeywordHighlighter();
            hilighter.AddKeywordSet(SqlKeywords.ToArray(), CharClass.Keyword, true);

            return hilighter;
        }

        private static List<string> LoadKeywordFile()
        {
            try
            {
                if (!File.Exists($@"{Application.StartupPath}\SQLKeyword.xml"))
                {
                    return null;
                }

                var doc = new XmlDocument();
                doc.Load($@"{Application.StartupPath}\SQLKeyword.xml");
                XmlNodeList nodeKeywords = doc.SelectNodes("/keywords/keyword");

                if (nodeKeywords == null)
                {
                    return null;
                }

                foreach (XmlNode nodeKeyword in nodeKeywords)
                {
                    string value = string.Empty;
                    if (nodeKeyword.ChildNodes.Count > 0)
                    {
                        value = nodeKeyword.ChildNodes[0].Value;
                    }
                    if (value != string.Empty)
                    {
                        SqlKeywords.Add(value);
                    }
                }               
                
                return SqlKeywords;
            }
            catch
            {
                return null;
            }
        }
    }
}
