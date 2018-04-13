using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace aurora
{
    public class MssqlInfomation : IServerInfomation
    {
        private SqlConnection _connection;

        public DbConnection Connection
        {
            get
            {
                _connection.ConnectionString = ToString();
                return _connection;
            }
        }

        public SqlConnectionStringBuilder ConnectionStringBuilder { get; set; }

        public string DataSource
        {
            get { return ConnectionStringBuilder.DataSource; }
            set { ConnectionStringBuilder.DataSource = value; }
        }

        public string Catalog
        {
            get { return ConnectionStringBuilder.InitialCatalog; }
            set { ConnectionStringBuilder.InitialCatalog = value; }
        }

        public string ID
        {
            get { return ConnectionStringBuilder.UserID; }
            set { ConnectionStringBuilder.UserID = value; }
        }

        public string Password
        {
            get { return ConnectionStringBuilder.Password; }
            set { ConnectionStringBuilder.Password = value; }
        }

        public bool Security
        {
            get { return ConnectionStringBuilder.IntegratedSecurity; }
            set { ConnectionStringBuilder.IntegratedSecurity = value; }
        }


        public MssqlInfomation()
        {
            _connection = new SqlConnection();
            ConnectionStringBuilder = new SqlConnectionStringBuilder();
        }


        public new string ToString()
        {
            return ConnectionStringBuilder.ToString();
        }


        public bool Load()
        {
            ConnectionStringBuilder.ConnectionString = "Data Source=localhost;Initial Catalog=SPSDATA;Integrated Security=True;User ID=activeuser;Password=nsk;TransparentNetworkIPResolution=False";
            Connection.ConnectionString = ToString();
            return true;
        }
    }
}
