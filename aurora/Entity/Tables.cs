using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Aurora
{
    [Serializable]
    public class Tables : Dictionary<string, string>
    {
        /*
         * TODO:Add(string key, DBCommand query);
         */
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
