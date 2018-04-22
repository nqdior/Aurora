namespace Aurora.Data.Queries
{
    public static class MariadbQueryHelper
    {
        public static string DatabaseListQuery() => MysqlQueryHelper.DatabaseListQuery();

        public static string TableListQuery(string databaseName) => MysqlQueryHelper.TableListQuery(databaseName);

        public static string ColumnListQuery() => MysqlQueryHelper.ColumnListQuery();
    }
}
