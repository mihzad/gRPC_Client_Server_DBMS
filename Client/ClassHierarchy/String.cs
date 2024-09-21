using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("DBMStest")]

namespace Client.ClassHierarchy
{
    internal class String : SupportedType
    {
        internal const string TypeValue = "string";

        public String() { }
        public String(string input) { Value = input; }
        public bool Equals(SupportedType p)
        {
            if (p.Type != Type || p == null)
                return false;
            return Value == (p as String)!.Value;

        }
        public bool isInvalid() { return Value == null; }

        public string stringOutput()
        {
            if (isInvalid()) return string.Empty;

            return Value!;
        }

        public string Type { get; } = TypeValue;
        public string? Value { get; set; } = null;
    }
}
