using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Data.Common;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Aurora
{
    internal sealed class CommandFactory
    {
        private readonly Engine _engine;

        internal CommandFactory(Engine engine) => _engine = engine;     

        public DbCommand CreateCommand(string command)
        {
            switch (_engine)
            {
                case Engine.SqlServer:
                    return new SqlCommand(command);

                case Engine.PostgreSql:
                    return new NpgsqlCommand(command);

                case Engine.MySql:
                    return new MySqlCommand(command);

                case Engine.MariaDB:
                    return new MySqlCommand(command);

                case Engine.SQLite:
                    return new SQLiteCommand(command);

                case Engine.Oracle:
                    #pragma warning disable CS0618
                    return new OracleCommand(command);

                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}
