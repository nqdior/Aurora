using Sgry.Azuki;
using System;

namespace Aurora.Forms
{
    public enum CharType : byte
    {
        Normal = 0,
        Number = 1,
        String = 2,
        Comment = 3,
        DocComment = 4,
        Keyword = 5,
        Keyword2 = 6,
        Keyword3 = 7,
        Macro = 8,
        Character = 9,
        Type = 10,
        Regex = 11,
        Annotation = 12,
        Selecter = 13,
        Property = 14,
        Value = 15,
        ElementName = 16,
        Entity = 17,
        Attribute = 18,
        AttributeValue = 19,
        EmbededScript = 20,
        Delimiter = 21,
        CDataSection = 22,
        LatexCommand = 23,
        LatexBracket = 24,
        LatexCurlyBracket = 25,
        LatexEquation = 26,
        Heading1 = 27,
        Heading2 = 28,
        Heading3 = 29,
        Heading4 = 30,
        Heading5 = 31,
        Heading6 = 32,
        Function = 33,
        Class = 34,
        Variable = 35,
        Label = 36,
        AddedLine = 37,
        RemovedLine = 38,
        ChangedLine = 39,
        ChangeCommandLine = 40,
        IndexLine = 41
    }

    internal static class ExtendCharType
    {
        internal static CharClass ToCharClass(this CharType type)
        {
            return (CharClass)Enum.ToObject(typeof(CharClass), (int)type);
        }
    }
}
