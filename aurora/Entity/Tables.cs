using System.Collections.Generic;
using System.Linq;

namespace aurora
{
    public class Tables : Dictionary<string, string>
    {
        public new void Add(string key, string query)
        {
            if (Keys.Contains(key))
            {
                Remove(key);
            }
            Add(key, query);          
        }
    }
}
