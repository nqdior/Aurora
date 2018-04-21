using Aurora.Properties;

namespace Aurora
{
    public static class PgsqlQueryHelper
    {
        public static string DatabaseListQuery => Resources.PGSQL_DATABASES;

        public static string TableListQuery => Resources.PGSQL_TABLES;

        public static string ColumnListQuery(string tableName) => string.Format(Resources.PGSQL_COLUMNS, tableName);
    }
}
