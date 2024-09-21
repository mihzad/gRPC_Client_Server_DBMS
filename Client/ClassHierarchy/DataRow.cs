using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ClassHierarchy
{
    internal class DataRow
    {
        public DataRow() { }
        internal DataRow(List<SupportedType> d) { data = d; }

        private List<SupportedType> data = new List<SupportedType>();
        public List<SupportedType> Data
        {
            get { return data; }
            set { data = value; }
        }

    }
}
