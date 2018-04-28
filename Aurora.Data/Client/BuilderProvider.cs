using MySql.Data.MySqlClient;
using Npgsql;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Aurora.Data.Client.Connection
{
    public static class BuilderProvider
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder() => new SqlConnectionStringBuilder();

        public static MySqlConnectionStringBuilder MySqlConnectionStringBuilder() => new MySqlConnectionStringBuilder();

        public static NpgsqlConnectionStringBuilder PGSqlConnectionStringBuilder() => new NpgsqlConnectionStringBuilder();

        public static MySqlConnectionStringBuilder MariaDBConnectionStringBuilder() => new MySqlConnectionStringBuilder();

        public static SQLiteConnectionStringBuilder SqliteConnectionStringBuilder() => new SQLiteConnectionStringBuilder();

        #pragma warning disable CS0618
        public static OracleConnectionStringBuilder OracleConnectionStringBuilder() => new OracleConnectionStringBuilder();

        public static SqlConnectionStringBuilder SqlConnectionStringBuilder(string connection) => new SqlConnectionStringBuilder(connection);

        public static MySqlConnectionStringBuilder MySqlConnectionStringBuilder(string connection) => new MySqlConnectionStringBuilder(connection);

        public static NpgsqlConnectionStringBuilder PGSqlConnectionStringBuilder(string connection) => new NpgsqlConnectionStringBuilder(connection);

        public static MySqlConnectionStringBuilder MariaDBConnectionStringBuilder(string connection) => new MySqlConnectionStringBuilder(connection);

        public static SQLiteConnectionStringBuilder SqliteConnectionStringBuilder(string connection) => new SQLiteConnectionStringBuilder(connection);

        #pragma warning disable CS0618
        public static OracleConnectionStringBuilder OracleConnectionStringBuilder(string connection) => new OracleConnectionStringBuilder(connection);
    }
}
