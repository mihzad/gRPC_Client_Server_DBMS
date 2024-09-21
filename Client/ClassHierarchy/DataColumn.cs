using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ClassHierarchy
{
    internal class DataColumn
    {
        public DataColumn()
        {
            Name = "def";
            SupportedDataType = Int.TypeValue;
        }

        public DataColumn(DataColumnSO c)
        {
            Name = c.Name;
            SupportedDataType = c.SupportedType;
        }
        public DataColumn(string name, string typeToSupport)
        {
            Name = name; SupportedDataType = typeToSupport;
        }
        public string Name { get; set; }
        public string SupportedDataType { get; set; }
    }
}
