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

        private bool disposed = false;

        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

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
