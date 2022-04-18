using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sep
{
    class Fraction
    {
        readonly int x, y;
        public Fraction(int x, int y) { this.x = x; this.y = y; }
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.x * b.x, a.y * b.y);
        }
    }
}
