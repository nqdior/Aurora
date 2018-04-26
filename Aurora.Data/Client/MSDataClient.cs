using Aurora.Data.Client.Connection;
using System;
using System.Data;
using System.Data.Common;
using System.Globalization;

namespace Aurora.Data.Client
{
    public sealed class MSDataClient : DataClient
    {
        private readonly Server _server;

        private readonly DataSet _dataSet;

        public DataTableCollection Tables => _dataSet.Tables;

        public MSDataClient(Server server) : base(server)
        {
            _server = server;
            _dataSet = new DataSet()
            {
                Locale = CultureInfo.InvariantCulture
            };
        }

        public DataTable FillData(string query, string tableName)
        {
            using (var command = new CommandFactory(_server.Engine).CreateCommand(query))
            {
                command.Connection = _server.Connection;
                return FillData(command, tableName);
            }
        }

        private DataTable FillData(DbCommand command, string tableName)
        {
            using (var adapter = new AdapterFactory(_server.Engine).CreateAdapter())
            {
                adapter.SelectCommand = command;
                adapter.FillSchema(_dataSet, SchemaType.Mapped);
                adapter.Fill(_dataSet, tableName);
                return _dataSet.Tables[tableName];
            }
        }

        public int Update(string query, string tableName)
        {
            using (var command = new CommandFactory(_server.Engine).CreateCommand(query))
            {
                command.Connection = _server.Connection;
                return Update(command, tableName);
            }
        }

        private int Update(DbCommand command, string tableName)
        {
            using (var builder = new CommandBuilderFactory(_server.Engine).CreateCommandBuilder())
            using (var adapter = new AdapterFactory(_server.Engine).CreateAdapter())
            {
                adapter.SelectCommand = command;
                builder.DataAdapter = adapter;
                builder.GetUpdateCommand();
                return adapter.Update(Tables[tableName]);
            }
        }

        public new void Dispose()
        {
            _dataSet.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

