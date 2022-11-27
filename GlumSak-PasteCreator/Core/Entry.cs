using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlumSak_PasteCreator.Core
{
    public struct Entry
    {
        public string Value { get; private set; }
        public int Index { get; private set; }

        public Entry(string value, int index)
        {
            Value = value;
            Index = index;
        }

        public void ChangeValue(string value)
        {
            Value = value;
        }

        public void ChangeIndex(int index)
        {
            Index = index;
        }
    }
}