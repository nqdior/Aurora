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

        public int FillData(string query, string tableName)
        {
            using (var _command = new CommandFactory(_server.Engine).CreateCommand(query))
            {
                _command.Connection = _server.Connection;
                return FillData(_command, tableName);
            }
        }

        private int FillData(DbCommand command, string tableName)
        {
            using (var _adapter = new AdapterFactory(_server.Engine).CreateAdapter())
            {
                _adapter.SelectCommand = command;
                _adapter.FillSchema(_dataSet, SchemaType.Mapped);
                return _adapter.Fill(_dataSet, tableName);
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

