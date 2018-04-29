using Aurora.Data;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace Aurora.Model
{
    public sealed class SchemaModel
    {
        private TableController _controller;

        private QueryHelper _query;

        public SchemaModel(Server server)
        {
            _controller = new TableController(server);
            _query = new QueryHelper(server.Engine);
        }

        public List<dynamic> GetDatabaseList() => _controller.GetData(_query.DatabaseListQuery()).Select(v => v.name).ToList();

        public List<dynamic> GetTableList() => _controller.GetData(_query.TableListQuery()).Select(v => v.name).ToList();
    }
}
