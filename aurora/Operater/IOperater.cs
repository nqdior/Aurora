using System.Data;
using System.Data.Common;

namespace aurora
{
    public interface IOperater
    {
        DataSet Stacker { get; }

        DataTableCollection Tables { get; }

        DbConnection Connection { get; }

        bool Connect();

        int GetData(string query, string tableName);

        int Execute(string query);

        int Update(string tableName);

        void ChangeDatabase(string databaseName);

        void Disconnect();

        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();
    }
}
