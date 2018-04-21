using Dapper;
using System.Collections.Generic;
using System.Data.Common;

namespace Aurora
{
    public class Manager
    {
        private readonly DbConnection _connection;

        public Manager(Server server)
        {
            _connection = server.Connection;
        }

        private void Open() => _connection.Open();

        private void Close() => _connection.Close();

        public void ChangeDatabase(string databaseName) => _connection.ChangeDatabase(databaseName);

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
            catch (DbException exception)
            {
                transaction.Rollback();
                throw exception;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
