using System.Data.Common;

namespace Aurora
{
    public class Server
    {
        public DbConnection Connection;

        public string Name { get; }

        public Engine Engine { get; }

        public Server(string name, Engine engine)
        {
            Name = name;
            Engine = engine;
            Connection = new ConnectionFactory(engine).CreateConnection();
        }
    }
}
