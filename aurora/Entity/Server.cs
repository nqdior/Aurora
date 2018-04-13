using System;
using System.Data.Common;

namespace aurora
{
    /// <summary>
    /// Server情報 構造体
    /// </summary>
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

            var factory = new InstrumentFactory(engine);
            Connection = factory.CreateConnection();
        }
    }
}
