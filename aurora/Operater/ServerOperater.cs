using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace aurora
{
    public class ServerOperater : IOperater
    {

        private DbCommand _command;

        private DbDataAdapter _adapter;

        private DbTransaction _transaction;

        private InstrumentFactory _factory;

        public DbConnection Connection { get; }

        public DataSet Stacker => new DataSet();

        public DataTableCollection Tables { get { return Stacker.Tables; } }


        public ServerOperater(Server server)
        {
            _factory = new InstrumentFactory(server.Engine);
            _adapter = _factory.CreateAdapter();

            Connection = server.Connection;
        }


        public bool Connect()
        {
            Connection.Open();
            return Connection.State == ConnectionState.Open ? true : false;
        }


        public int GetData(string selectCommand, string tableName)
        {
            using (_command = _factory.CreateCommand(selectCommand))
            {
                _command.Connection = Connection;
                _adapter.SelectCommand = _command;
            }
            return GetDataAsync(tableName).GetAwaiter().GetResult();
        }


        private async Task<int> GetDataAsync(string tableName) => await Task.Run(() =>
            {   
                _adapter.FillSchema(Stacker, SchemaType.Mapped);
                return _adapter.Fill(Stacker, tableName);
            }
        ).ConfigureAwait(false);           
                 

        public int Execute(string executeCommand)
        {
            using (_command = _factory.CreateCommand(executeCommand))
            {
                _command.Connection = Connection;
                _command.Transaction = _transaction;
            }
            return ExecuteAsync().GetAwaiter().GetResult();
        }


        private async Task<int> ExecuteAsync() => await _command.ExecuteNonQueryAsync().ConfigureAwait(false);       


        public int Update(string tableName) => _adapter.Update(Stacker.Tables[tableName]);


        public void ChangeDatabase(string databaseName) => Connection.ChangeDatabase(databaseName);


        public void Disconnect() => Connection.Close();


        public void BeginTransaction() => _transaction = Connection.BeginTransaction();


        public void CommitTransaction() => _transaction.Commit();


        public void RollbackTransaction() => _transaction.Rollback();
    }
}
