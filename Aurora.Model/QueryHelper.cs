using System;
using Aurora.Data;
using Aurora.Model.Properties;

namespace Aurora.Model
{
    internal sealed class QueryHelper
    {
        private readonly Engine _engine;

        internal QueryHelper(Engine engine)
        {
            _engine = engine;
        }

        internal string DatabaseListQuery()
        {
            switch (_engine)
            {
                case Engine.SqlServer:
                    return Resources.MSSQL_DATABASES;

                case Engine.PostgreSql:
                    return Resources.PGSQL_DATABASES;

                case Engine.MySql:
                    return Resources.MYSQL_DATABASES;

                case Engine.MariaDB:
                    return Resources.MYSQL_DATABASES;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal string TableListQuery(string databaseName = null)
        {
            switch (_engine)
            {
                case Engine.SqlServer:
                    return Resources.MSSQL_TABLES;

                case Engine.PostgreSql:
                    return Resources.PGSQL_TABLES;

                case Engine.MySql:
                    return string.Format(Resources.MYSQL_TABLES, databaseName);

                case Engine.MariaDB:
                    return Resources.MYSQL_TABLES;

                case Engine.SQLite:
                    return Resources.SQLITE_TABLES;

                case Engine.Oracle:
                    #pragma warning disable CS0618
                    return Resources.ORACLE_TABLES;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal string ColumnsListQuery(string tableName = null)
        {
            switch (_engine)
            {
                case Engine.SqlServer:
                    return Resources.MSSQL_COLUMNS;

                case Engine.PostgreSql:
                    return string.Format(Resources.PGSQL_COLUMNS, tableName);

                case Engine.MySql:
                    return Resources.MYSQL_COLUMNS;

                case Engine.MariaDB:
                    return Resources.MYSQL_COLUMNS;

                case Engine.SQLite:
                    return string.Format(Resources.SQLITE_COLUMNS, tableName);

                case Engine.Oracle:
                    #pragma warning disable CS0618
                    return Resources.ORACLE_COLUMNS;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

    }
}