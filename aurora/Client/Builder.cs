using MySql.Data.MySqlClient;
using Npgsql;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Aurora
{
    public static class Builder
    {
        public static SqlConnectionStringBuilder SqlConnectionBuilder() => new SqlConnectionStringBuilder();

        public static MySqlConnectionStringBuilder MySqlConnectionBuilder() => new MySqlConnectionStringBuilder();

        public static NpgsqlConnectionStringBuilder PgSqlConnectionBuilder() => new NpgsqlConnectionStringBuilder();

        public static MySqlConnectionStringBuilder MariaDBConnectionBuilder() => new MySqlConnectionStringBuilder();

        public static SQLiteConnectionStringBuilder SqliteConnectionBuilder() => new SQLiteConnectionStringBuilder();

        #pragma warning disable CS0618
        public static OracleConnectionStringBuilder OracleConnectionBuilder() => new OracleConnectionStringBuilder();
    }
}
