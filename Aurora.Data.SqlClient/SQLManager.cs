using Aurora.Data.Client;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace Aurora.Data.SqlClient
{
    public class SQLManager
    {
        private readonly MSDataClient _client;

        public DataTableCollection Tables => _client.Tables;

        public SQLManager(Server server)
        {
            _client = new MSDataClient(server);
        }

        public int GetData(string query, string tableName) => GetData(_client.FillData, query, tableName);

        private int GetData(Func<string, string, int> function, string query, string tableName)
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

        public void Execute(string query) => Execute(_client.Execute, new Collection<string>() { query });

        public void Execute(Collection<string> queries) => Execute(_client.Execute, queries);

        private void Execute(Action<Collection<string>> function, Collection<string> queries)
        {
            try
            {
                _client.Open();

                _client.BeginTransaction();
                function.Invoke(queries);
                _client.CommitTransaction();
            }
            catch
            {
                _client.RollbackTransaction();
            }
            finally
            {   
                _client.Close();
            }
        }
    }
}
