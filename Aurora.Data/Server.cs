﻿using Aurora.Data.Client.Connection;
using System.Data.Common;

namespace Aurora.Data
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

        public Server Clone()
        {
            var clone = new Server(Name, Engine);
            clone.Connection = new ConnectionFactory(clone.Engine).CreateConnection();
            clone.Connection.ConnectionString = Connection.ConnectionString;
            
            return clone;
        }
    }
}
