using System;
using System.Collections.Generic;

namespace Aurora
{
    [Serializable]
    public sealed class Servers : Dictionary<string, Server>
    {
        public void Add(Server server) => Add(server.Name, server);
    }
}
