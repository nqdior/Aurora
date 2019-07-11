using Aurora.Properties;
using System;

namespace Aurora
{
    internal sealed class QueryFactory
    {
        private readonly Engine _engine;

        internal QueryFactory(Engine engine) => _engine = engine;       

        internal string SchemaListCommand()
        {
            switch (_engine)
            {
                case Engine.SqlServer:
                    return ""; //Resources.MSSQL_DATABASES;

                case Engine.PostgreSql:
                    return ""; // Resources.PGSQL_DATABASES;

                case Engine.MySql:
                    return MyResource.SCHEMAS;

                case Engine.MariaDB:
                    return ""; //  Resources.MYSQL_DATABASES;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal string TableListCommand(string schemaName)
        {
            switch (_engine)
            {
                case Engine.SqlServer:
                    return ""; //  Resources.MSSQL_TABLES;

                case Engine.PostgreSql:
                    return ""; //  Resources.PGSQL_TABLES;

                case Engine.MySql:
                    return string.Format(MyResource.TABLES, schemaName);

                case Engine.MariaDB:
                    return ""; //  Resources.MYSQL_TABLES;

                case Engine.SQLite:
                    return ""; //  Resources.SQLITE_TABLES;

                case Engine.Oracle:
#pragma warning disable CS0618
                    return ""; //  Resources.ORACLE_TABLES;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}