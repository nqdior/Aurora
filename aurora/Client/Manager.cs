using Dapper;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.Data;

namespace Aurora
{
    public class Manager : IDisposable
    {
        private readonly DbConnection _connection;
        
        public Manager(Server server)
        {
            _connection = server.Connection;
        }

        public void Open() => _connection.Open();

        public void Close() => _connection.Close();

        public ConnectionState State => _connection.State;

        public void Execute(string query) => Execute(new List<string>() { query });

        public void Execute(List<string> queries)
        {
            DbTransaction transaction = null;

            try
            {
                _connection.Open();
                transaction = _connection.BeginTransaction();
                queries.ForEach(query => _connection.Execute(query));
                transaction.Commit();                
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }

        public IEnumerable<dynamic> GetData(string query)
        {
            try
            {
                _connection.Open();
                return _connection.Query(query);
            }
            finally
            {
                _connection.Close();
            }
        }

        private bool disposed = false;
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
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
    }
}
