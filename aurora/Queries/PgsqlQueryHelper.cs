using Aurora.Data.Properties;
using System.Globalization;

namespace Aurora.Data.Queries
{
    public static class PgsqlQueryHelper
    {
        public static string DatabaseListQuery() => Resources.PGSQL_DATABASES;

        public static string TableListQuery() => Resources.PGSQL_TABLES;

        public static string ColumnListQuery(string tableName) => string.Format(new CultureInfo("query"), Resources.PGSQL_COLUMNS, tableName);
    }
}
