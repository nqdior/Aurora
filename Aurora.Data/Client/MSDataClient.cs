using Aurora.Data.Client.Connection;
using System;
using System.Data;
using System.Data.Common;

namespace Aurora.Data.Client
{
    public sealed class MSDataClient : DataClient
    {
        private readonly Server _server;

        public MSDataClient(Server server) : base(server)
        {
            _server = server;
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
            var dataTable = new DataTable(tableName);
            using (var adapter = new AdapterFactory(_server.Engine).CreateAdapter())
            {
                adapter.SelectCommand = command;
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public int Update(string query, DataTable table)
        {
            using (var command = new CommandFactory(_server.Engine).CreateCommand(query))
            {
                command.Connection = _server.Connection;
                return Update(command, table);
            }
        }

        private int Update(DbCommand command, DataTable table)
        {
            using (var builder = new CommandBuilderFactory(_server.Engine).CreateCommandBuilder())
            using (var adapter = new AdapterFactory(_server.Engine).CreateAdapter())
            {
                adapter.SelectCommand = command;
                builder.DataAdapter = adapter;
                builder.GetUpdateCommand();
                return adapter.Update(table);
            }
        }

        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

