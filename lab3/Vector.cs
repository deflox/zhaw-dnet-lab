using System;

namespace DN3 {
    public struct Vector {
        double x,y,z;

        public Vector(double x, double y, double z) {
            this.x=x;
            this.y=y;
            this.z=z;
        }
        
        public override string ToString(){
            return "["+x+" "+y+" "+z+"]";
        }

        public static Vector operator + (Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector operator - (Vector a, Vector b)
        {
            return new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector operator * (Vector a, Vector b)
        {
            return new Vector((a.y*b.z)-(a.z*b.y), (a.z*b.x) - (a.x*b.z), (a.x*b.y) - (a.y*b.x));
        }

        public static Vector operator * (double scalar, Vector v)
        {
            return new Vector(scalar * v.x, scalar * v.y, scalar * v.z);
        }

        public static Vector operator *(Vector v, double scalar)
        {
            return new Vector(scalar * v.x, scalar * v.y, scalar * v.z);
        }

        public static Vector operator / (Vector v, double scalar)
        {
            return new Vector(v.x / scalar, v.y / scalar, v.z / scalar);
        }

        // is called when: double scalar = (double) vector;
        public static explicit operator double (Vector v)
        {
            return Math.Sqrt(v.x*v.x + v.y*v.y + v.z*v.z);
        }

        // is called when: Vector v = 3.0;
        public static implicit operator Vector (double scalar)
        {
            return new Vector(scalar, 0, 0);
        }

        public static bool operator == (Vector a, Vector b)
        {
            return NearlyEqual(a.x, b.x) && NearlyEqual(a.y, b.y) && NearlyEqual(a.z, b.z);
        }

        public static bool operator != (Vector a, Vector b)
        {
            return !(a == b);
        }

        public override bool Equals(object other)
        {
            Vector otherv = (Vector) other;
            return other != null && NearlyEqual(x, otherv.x) && NearlyEqual(y, otherv.y) && NearlyEqual(z, otherv.z);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y, z);
        }

        public double this[int index]
        {
            get
            {
                if (index == 0)
                {
                    return x;
                } 
                else if (index == 1)
                {
                    return y;
                } 
                else if (index == 2)
                {
                    return z;
                }

                return 0;
            }
            set
            {
                if (index == 0)
                {
                    x = value;
                }
                else if (index == 1)
                {
                    y = value;
                }
                else if (index == 2)
                {
                    z = value;
                }
            }
        }

        private static bool NearlyEqual(double a, double b)
        {
            const double epsilon = 1E-10; // depends, usually parameter
            const double MinNormal = 2.2250738585072014E-308d;
            double absA = Math.Abs(a);
            double absB = Math.Abs(b);
            double diff = Math.Abs(a - b);
            if (a.Equals(b))
            {
                // shortcut, also handles infinities
                return true;
            }
            else if (a == 0 || b == 0 || absA + absB < MinNormal)
            {
                // a or b is zero or both are extremely close to it
                // relative error is less meaningful here
                return diff < (epsilon * MinNormal);
            }
            else
            { // use relative error
                return diff / (absA + absB) < epsilon;
            }
        }
    }

    internal class MainClass {

        public static void Test() {
            Vector a = new Vector(1,2,3);
            Vector b = new Vector(4,5,6);
            Vector c = a * b;
            Console.WriteLine(c);
        }

        public static void Main(string[] args) {
            Test();
        }
    }
}
