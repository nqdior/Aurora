using MySql.Data.MySqlClient;
using Npgsql;
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

        public DbCommand CreateCommand(string command)
        {
            switch (_engine)
            {
                case Engine.SQLServer:
                    return new SqlCommand(command);

                case Engine.PostgreSQL:
                    return new NpgsqlCommand(command);

                case Engine.MySQL:
                    return new MySqlCommand(command);

                case Engine.MariaDB:
                    return new MySqlCommand(command);

                case Engine.SQLite:
                    return new SQLiteCommand(command);

                case Engine.Oracle:
                    #pragma warning disable CS0618
                    return new OracleCommand(command);

                default:
                    throw new System.Exception();
            }
        }

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
                    throw new System.Exception();
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
                    throw new System.Exception();
            }
        }
    }
}
