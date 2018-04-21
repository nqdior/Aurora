using System;
using Aurora.Properties;

namespace Aurora
{
    public sealed class QueryProvider
    {
        private readonly Engine _engine;

        public QueryProvider(Engine engine)
        {
            _engine = engine;
        }

        public string DatabaseListQuery()
        {
            switch (_engine)
            {
                case Engine.SQLServer:
                    return Resources.MSSQL_DATABASES;

                case Engine.PostgreSQL:
                    return Resources.PGSQL_DATABASES;

                case Engine.MySQL:
                    return Resources.MYSQL_DATABASES;

                case Engine.MariaDB:
                    return Resources.MYSQL_DATABASES;

                default:
                    throw new ArgumentOutOfRangeException();
            } 
        }

        public string TableListQuery(string databaseName = null)
        {
            switch (_engine)
            {
                case Engine.SQLServer:
                    return Resources.MSSQL_TABLES;

                case Engine.PostgreSQL:
                    return Resources.PGSQL_TABLES;

                case Engine.MySQL:
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

        public string ColumnsListQuery(string tableName = null)
        {
            switch (_engine)
            {
                case Engine.SQLServer:
                    return Resources.MSSQL_COLUMNS;

                case Engine.PostgreSQL:
                    return string.Format(Resources.PGSQL_COLUMNS, tableName);

                case Engine.MySQL:
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
