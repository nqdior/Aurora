using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Data.Common;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Aurora
{
    public sealed class Factory
    {
        private readonly Engine _engine;

        public Factory(Engine engine)
        {
            _engine = engine;
        }

        public DbCommand CreateCommand(string query)
        {
            switch (_engine)
            {
                case Engine.SQLServer:
                    return new SqlCommand(query);

                case Engine.PostgreSQL:
                    return new NpgsqlCommand(query);

                case Engine.MySQL:
                    return new MySqlCommand(query);

                case Engine.MariaDB:
                    return new MySqlCommand(query);

                case Engine.SQLite:
                    return new SQLiteCommand(query);

                case Engine.Oracle:
                    #pragma warning disable CS0618
                    return new OracleCommand(query);

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        [Obsolete("this method will delete.")]
        public DbDataAdapter CreateAdapter()
        {
            switch (_engine)
            {
                case Engine.SQLServer:
                    return new SqlDataAdapter();

                case Engine.PostgreSQL:
                    return new NpgsqlDataAdapter();

                case Engine.MySQL:
                    return new MySqlDataAdapter();

                case Engine.MariaDB:
                    return new MySqlDataAdapter();

                case Engine.SQLite:
                    return new SQLiteDataAdapter();

                case Engine.Oracle:
                    #pragma warning disable CS0618
                    return new OracleDataAdapter();

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public DbConnection CreateConnection()
        {
            switch (_engine)
            {
                case Engine.SQLServer:
                    return new SqlConnection();

                case Engine.PostgreSQL:
                    return new NpgsqlConnection();

                case Engine.MySQL:
                    return new MySqlConnection();

                case Engine.MariaDB:
                    return new MySqlConnection();

                case Engine.SQLite:
                    return new SQLiteConnection();

                case Engine.Oracle:
                #pragma warning disable
                    return new OracleConnection();

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
