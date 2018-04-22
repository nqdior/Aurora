using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace aurora
{
    public abstract class BaseOperater : IOperater
    {

        protected DbCommand _command;

        protected DbDataAdapter _adapter;

        protected DbTransaction _transaction;

        public DataSet Stacker => new DataSet();

        public DbConnection Connection { get; set; }

        public DataTableCollection Tables { get { return Stacker.Tables; } }


        public BaseOperater(DbConnection connection)
        {
            Connection = connection;
        }


        public bool Connect()
        {
            Connection.Open();
            return Connection.State == ConnectionState.Open ? true : false;
        }


        public virtual int GetData(string selectCommand, string tableName)
        {
            _command.Connection = Connection;
            _command.CommandText = selectCommand;
            _adapter.SelectCommand = _command;

            return GetDataAsync(tableName).GetAwaiter().GetResult();
        }


        private async Task<int> GetDataAsync(string tableName) => await Task.Run(() =>
            {   
                _adapter.FillSchema(Stacker, SchemaType.Mapped);
                return _adapter.Fill(Stacker, tableName);
            }
        ).ConfigureAwait(false);           
                 

        public virtual int Execute(string executeCommand)
        {
            _command.Connection = Connection;
            _command.CommandText = executeCommand;
            _command.Transaction = _transaction;

            return ExecuteAsync().GetAwaiter().GetResult();
        }


        private async Task<int> ExecuteAsync()
        {
            return await _command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }


        public int Update(string tableName) => _adapter.Update(Stacker.Tables[tableName]);


        public void ChangeDatabase(string databaseName) => Connection.ChangeDatabase(databaseName);


        public void Disconnect() => Connection.Close();


        public void BeginTransaction() => _transaction = Connection.BeginTransaction();


        public void CommitTransaction() => _transaction.Commit();


        public void RollbackTransaction() => _transaction.Rollback();
    }
}
