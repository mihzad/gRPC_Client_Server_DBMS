using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("DBMStest")]

namespace Client.ClassHierarchy
{
    internal class CharInvl : SupportedType
    {
        internal const string TypeValue = "charinvl";
        public CharInvl() { }
        public CharInvl(string input) //interval "a, d" "b , q"
        {
            string noWhitespaceInterval = string.Concat(input.Where(c => !char.IsWhiteSpace(c)));
            if (noWhitespaceInterval == null) return;

            var s = noWhitespaceInterval.Split(',');
            if (s.Length == 2)
            {
                if (s[0].Length == 1)
                {
                    LeftVal = s[0][0];
                }
                if (s[1].Length == 1)
                {
                    RightVal = s[1][0];
                }
            }

        }


        public bool Equals(SupportedType p)
        {
            if (p.Type != Type || p == null)
                return false;
            CharInvl pch = (p as CharInvl)!;

            return LeftVal.Equals(pch.LeftVal) && RightVal.Equals(pch.RightVal);

        }
        public bool isInvalid() { return LeftVal == null || RightVal == null; }

        public string stringOutput()
        {
            return $"{LeftVal},{RightVal}";
        }
        public string Type { get; } = TypeValue;
        public char? LeftVal { get; set; } = null;
        public char? RightVal { get; set; } = null;
    }
}
