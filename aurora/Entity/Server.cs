using System.Data.Common;

namespace Aurora
{
    public class Server
    {
        public DbConnection Connection;

        public string Name { get; }

        public Engine Engine { get; }

        public Tables Tables => new Tables();

        public Server(string name, Engine engine)
        {
            Name = name;
            Engine = engine;

            var factory = new InstanceProvider(engine);
            Connection = factory.CreateConnection();
        }
    }
}
