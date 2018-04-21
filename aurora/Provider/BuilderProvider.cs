using MySql.Data.MySqlClient;
using Npgsql;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Aurora
{
    public static class BuilderProvider
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder() => new SqlConnectionStringBuilder();

        public static MySqlConnectionStringBuilder MySqlConnectionStringBuilder() => new MySqlConnectionStringBuilder();

        public static NpgsqlConnectionStringBuilder PgSqlConnectionStringBuilder() => new NpgsqlConnectionStringBuilder();

        public static MySqlConnectionStringBuilder MariaDBConnectionStringBuilder() => new MySqlConnectionStringBuilder();

        public static SQLiteConnectionStringBuilder SqliteConnectionStringBuilder() => new SQLiteConnectionStringBuilder();

        #pragma warning disable CS0618
        public static OracleConnectionStringBuilder OracleConnectionStringBuilder() => new OracleConnectionStringBuilder();
    }
}
