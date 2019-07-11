using Dapper;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Runtime.InteropServices;

namespace Aurora
{
    public class Server : IDisposable
    {
        internal DbConnection _connection;

        private DbTransaction _transaction;

        public string Name { get; }

        public Engine Engine { get; }

        public string ConnectionString
        {
            get => _connection.ConnectionString;
            set => _connection.ConnectionString = value;
        }

        public Server(string name, Engine engine, string connectionString = "")
        {
            Name = name;
            Engine = engine;
            _connection = new ConnectionFactory(engine).CreateConnection();
            _connection.ConnectionString = connectionString;
        }

        public void Open() => _connection.Open();

        public void Close() => _connection.Close();

        public void BeginTransaction(IsolationLevel isolationLevel) => _transaction = _connection.BeginTransaction(isolationLevel);

        public void CommitTransaction() => _transaction.Commit();

        public void RollbackTransaction() => _transaction.Rollback();

        public ConnectionState State => _connection.State;

        public int Execute(string query, object param = null, IDbTransaction transaction = null) => _connection.Execute(query, param, transaction);

        public IEnumerable<dynamic> GetData(string query, object param = null, IDbTransaction transaction = null) => _connection.Query<dynamic>(query, param, transaction);

        public IEnumerable<T> GetData<T>(string query, object param = null, IDbTransaction transaction = null) => _connection.Query<T>(query, param, transaction);

        public DataTable Fill(string query, string tableName)
        {
            using (var command = new CommandFactory(Engine).CreateCommand(query))
            {
                command.Connection = _connection;
                return Fill(command, tableName);
            }
        }

        private DataTable Fill(DbCommand query, string tableName)
        {
            var dataTable = new DataTable(tableName);
            using (var adapter = new AdapterFactory(Engine).CreateAdapter())
            {
                adapter.SelectCommand = query;
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public int Update(string selectQuery, DataTable table)
        {
            using (var command = new CommandFactory(Engine).CreateCommand(selectQuery))
            {
                command.Connection = _connection;
                return Update(command, table);
            }
        }

        private int Update(DbCommand selectQuery, DataTable table)
        {
            using (var builder = new CommandBuilderFactory(Engine).CreateCommandBuilder())
            using (var adapter = new AdapterFactory(Engine).CreateAdapter())
            {
                adapter.SelectCommand = selectQuery;
                builder.DataAdapter = adapter;
                builder.GetUpdateCommand();
                return adapter.Update(table);
            }
        }

        private bool disposed = false;

        private readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            _connection.Close();
            _transaction.Dispose();

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                handle.Dispose();
            }
            disposed = true;
        }

        public Server Clone()
        {
            var clone = new Server(Name, Engine);
            clone._connection = new ConnectionFactory(clone.Engine).CreateConnection();
            clone._connection.ConnectionString = _connection.ConnectionString;
            
            return clone;
        }
    }
}
