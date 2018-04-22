using Aurora.Data.Properties;
using System.Globalization;

namespace Aurora.Data.Queries
{
    public static class SqliteQueryHelper
    {
        public static string TableListQuery() => Resources.SQLITE_TABLES;

        public static string ColumnListQuery(string tableName) => string.Format(new CultureInfo("query"), Resources.SQLITE_COLUMNS, tableName);
    }
}
