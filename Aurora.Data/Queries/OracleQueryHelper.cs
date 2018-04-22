using Aurora.Data.Properties;

namespace Aurora.Data.Queries
{
    public static class OracleQueryHelper
    {
        public static string TableListQuery() => Resources.ORACLE_TABLES;

        public static string ColumnListQuery() => Resources.ORACLE_COLUMNS;
    }
}
