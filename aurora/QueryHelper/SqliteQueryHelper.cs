using Aurora.Properties;

namespace Aurora
{
    public static class SqliteQueryHelper
    {
        public static string TableListQuery => Resources.SQLITE_TABLES;

        public static string ColumnListQuery(string tableName) => string.Format(Resources.SQLITE_COLUMNS, tableName);
    }
}
