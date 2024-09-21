using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ClassHierarchy
{
    internal class Real : SupportedType
    {
        internal const string TypeValue = "real";

        public Real() { }
        public Real(string input)
        {
            if (double.TryParse(input, out double v))
                Value = v;
        }
        public bool Equals(SupportedType p)
        {
            if (p.Type != Type || p == null)
                return false;
            return Value == (p as Real)!.Value;

        }
        public bool isInvalid() { return Value == null; }

        public string stringOutput()
        {
            if (isInvalid()) return string.Empty;

            return Value!.ToString()!;
        }

        public string Type { get; } = TypeValue;
        public double? Value { get; set; } = null;
    }
}
