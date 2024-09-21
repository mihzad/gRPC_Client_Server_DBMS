using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("DBMStest")]

namespace Client.ClassHierarchy
{
    internal class StringInvl : SupportedType
    {
        internal const string TypeValue = "stringinvl";
        public StringInvl() { }
        public StringInvl(string input) // intervals: "a,b; c, d; e,f; "
        {
            var splitted = input.Split(';');
            if (splitted != null && splitted.Length > 0)
                foreach (var s in splitted)
                    Str.Add(new CharInvl(s));

        }
        public bool Equals(SupportedType p)
        {
            if (p.Type != Type || p == null)
                return false;
            //p != null and p is StringInvl
            var pstr = (p as StringInvl)!.Str;

            if (Str != null)
                return Str.Equals(pstr);

            if (pstr == null) return true; // both are null
            return false;//this.str is null and pstr is not null.
        }

        public bool isInvalid()
        {
            if (Str == null) return true;
            foreach (var chinvl in Str)
                if (chinvl.isInvalid()) return true;
            return false;
        }

        public string stringOutput()
        {
            if (isInvalid() || Str.Count == 0) return string.Empty;

            var s = "";
            for (int i = 0; i < Str.Count - 1; i++)
            {
                s += Str[i].stringOutput() + "; ";
            }
            return s + Str.Last().stringOutput();
        }
        public string Type { get; } = TypeValue;
        public List<CharInvl> Str { get; set; } = new List<CharInvl>();
    }
}
