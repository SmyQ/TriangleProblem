using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisraGries
{
    class Triple
    {
        private int[] values;

        public int[] Values
        {
            get { return values; }
        }

        public Triple(int a1, int a2, int a3)
        {
            this.values = new int[] { a1, a2, a3 };
        }

        public override bool Equals(object obj)
        {
            Triple tr = (Triple)obj;
            return this.values[0] == tr.values[0] &&
                this.values[1] == tr.values[1] &&
                this.values[2] == tr.values[2];
        }

        public override int GetHashCode()
        {
            return values[0].GetHashCode() + values[1].GetHashCode() + values[2].GetHashCode();
        }
    }
}
