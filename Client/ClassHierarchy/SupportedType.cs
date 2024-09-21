using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ClassHierarchy
{
    public interface SupportedType
    {
        public string Type { get; }
        public bool Equals(SupportedType p);
        public bool isInvalid();

        public string stringOutput();
    }
}
