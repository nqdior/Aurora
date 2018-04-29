using System.Collections.Generic;
using System.Data;

namespace Aurora.Data
{
    public class DataTables : Dictionary<string, DataTable>
    {
        public void Add(DataTable value) => Add(value.TableName, value);   
    }
}
