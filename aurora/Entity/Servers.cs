using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Aurora
{
    [Serializable]
    public class Servers : Dictionary<string, Server>
    {
        public void Add(Server server)
        {
            if (Keys.Contains(server.Name))
            {
                Remove(server.Name);
            }       
            Add(server.Name, server);       
        }       
    }
}
