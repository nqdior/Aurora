﻿using Dapper;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.Data;
using System.Linq;
using System.Collections.ObjectModel;

namespace Aurora.Data.Client
{
    public class DataClient : IDisposable
    {
        private readonly DbConnection _connection;
        
        public DataClient(Server server)
        { 
            _connection = server.Connection;
        }

        public void Open() => _connection.Open();

        public void Close() => _connection.Close();

        public ConnectionState State => _connection.State;

        public void Execute(string query) => Execute(new Collection<string>() { query });

        public void Execute(Collection<string> queries) => queries.ToList().ForEach(query => _connection.Execute(query));

        public IEnumerable<dynamic> GetData(string query) => GetData<dynamic>(query);

        public IEnumerable<T>GetData<T>(string query) => _connection.Query<T>(query);

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