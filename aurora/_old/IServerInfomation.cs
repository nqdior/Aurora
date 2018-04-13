using System.Data;
using System.Data.Common;

namespace aurora
{
    public interface IServerInfomation
    {              
        string DataSource { get; set; }

        string Catalog { get; set; }

        string ID { get; set; }

        string Password { get; set; }

        bool Security { get; set; }

        DbConnection Connection { get; }

        //DbConnectionStringBuilder ConnectionStringBuilder { get; set; }

        string ToString();

        bool Load();
    }
}
