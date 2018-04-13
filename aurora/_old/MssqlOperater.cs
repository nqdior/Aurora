using System.Data.Common;
using System.Data.SqlClient;

namespace aurora
{
    public class MssqlOperater : BaseOperater
    {

        public MssqlOperater(DbConnection connection) : base(connection)
        {
            _adapter = new SqlDataAdapter();
        }


        public override int GetData(string selectCommand, string tableName)
        {
            using (_command = new SqlCommand(selectCommand))
            {
                return base.GetData(selectCommand, tableName);
            }            
        }


        public override int Execute(string executeCommand)
        {
            using (_command = new SqlCommand(executeCommand))
            {
                return base.Execute(executeCommand);
            }
        }

    }
}
