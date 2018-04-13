using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace aurora
{
    class ConnectionStringPattern
    {
        public Dictionary<Engine, DbConnectionStringBuilder> Builder = new Dictionary<Engine, DbConnectionStringBuilder>()
        {
            { Engine.SQLServer, new SqlConnectionStringBuilder() }
        };

        public ConnectionStringPattern()
        {
            Builder.Add(Engine.SQLServer, new SqlConnectionStringBuilder());
        }
    }
}
