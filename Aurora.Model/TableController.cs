using Aurora.Data;
using Aurora.Data.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace Aurora.Model
{
    public class TableController
    {
        private readonly MSDataClient _client;

        public DataTableCollection Tables => _client.Tables;

        public TableController(Server server)
        {
            _client = new MSDataClient(server);
        }

        public IEnumerable<dynamic> GetData(string query) => _client.GetData(query);

        public DataTable FillData(string query, string tableName) => FillData(_client.FillData, query, tableName);

        private DataTable FillData(Func<string, string, DataTable> function, string query, string tableName)
        {
            try
            {
                _client.Open();
                return function.Invoke(query, tableName);
            }
            finally
            {
                _client.Close();
            }
        }

        public int Execute(string query)
        {
            try
            {
                _client.Open();
                _client.BeginTransaction();
                var result = _client.Execute(query);
                _client.CommitTransaction();

                return result;
            }
            catch
            {
                _client.RollbackTransaction();
                throw;
            }
            finally
            {   
                _client.Close();
            }
        }

        public void Update(string query, string tableName)
        {
            try
            {
                _client.Open();
                _client.BeginTransaction();
                _client.Update(query, tableName);
                _client.CommitTransaction();
            }
            catch
            {
                _client.RollbackTransaction();
                throw;
            }
            finally
            {
                _client.Close();
            }
        }
    }
}
