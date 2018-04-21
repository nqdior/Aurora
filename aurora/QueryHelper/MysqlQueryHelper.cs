using Aurora.Properties;

namespace Aurora
{
    public static class MysqlQueryHelper
    {
        public static string DatabaseListQuery => Resources.MYSQL_DATABASES;

        public static string TableListQuery(string databaseName) => string.Format(Resources.MYSQL_TABLES, databaseName);

        public static string ColumnListQuery => Resources.MYSQL_COLUMNS;
    }
}
