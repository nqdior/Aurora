using Aurora.Data.Properties;
using System.Globalization;

namespace Aurora.Data.Queries
{
    public static class MysqlQueryHelper
    {
        public static string DatabaseListQuery() => Resources.MYSQL_DATABASES;

        public static string TableListQuery(string databaseName) => string.Format(new CultureInfo("query"), Resources.MYSQL_TABLES, databaseName);
        
        public static string ColumnListQuery() => Resources.MYSQL_COLUMNS;
    }
}
