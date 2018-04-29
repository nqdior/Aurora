using System;
using System.Collections.Generic;

namespace Aurora.Data
{
    [Serializable]
    public sealed class Servers : Dictionary<string, Server>
    {
        public void Add(Server server) => Add(server.Name, server);

        public Servers Clone()
        {
            var clone = new Servers();
            foreach (var server in this)
            {
                clone.Add(server.Value.Clone());
            }
            return clone;
        }
    }
}
