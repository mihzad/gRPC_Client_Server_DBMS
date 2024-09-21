using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ClassHierarchy;

namespace Client
{
    public static class SupportMethods
    {
        public static SupportedType? createSupportedTypeInstance(string type, string input)
        {
            SupportedType v;
            switch (type)
            {
                case Int.TypeValue: v = new Int(input); break;
                case Real.TypeValue: v = new Real(input); break;
                case Client.ClassHierarchy.Char.TypeValue: v = new Client.ClassHierarchy.Char(input); break;
                case Client.ClassHierarchy.String.TypeValue: v = new Client.ClassHierarchy.String(input); break;
                case CharInvl.TypeValue: v = new CharInvl(input); break;
                case StringInvl.TypeValue: v = new StringInvl(input); break;
                default: return null;
            }
            return v;
        }
    }
}
