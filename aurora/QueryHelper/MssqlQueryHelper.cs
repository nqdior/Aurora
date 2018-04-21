using Aurora.Properties;

namespace Aurora
{
    public static class MssqlQueryHelper
    {
        public static string DatabaseListQuery => Resources.MSSQL_DATABASES;

        public static string TableListQuery => Resources.MSSQL_TABLES;

        public static string ColumnListQuery => Resources.MSSQL_COLUMNS;
    }
}
