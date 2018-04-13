using System.Collections.Generic;
using System.Linq;

namespace aurora
{
    public class ServerRack : Dictionary<string, Server>
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
