using System;

namespace DN3
{
	public struct Vector
	{
		double x, y, z;

		public Vector(double x, double y, double z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public static Vector operator +(Vector a, Vector b)
		{
			return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
		}

		public static Vector operator -(Vector a, Vector b)
		{
			return new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
		}

		public static Vector operator *(Vector a, Vector b)
		{
			return new Vector(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
		}

		public static Vector operator *(Vector a, double d)
		{
			return new Vector(a.x * d, a.y * d, a.z * d);
		}

		public static Vector operator *(double d, Vector a)
		{
			return new Vector(a.x * d, a.y * d, a.z * d);
		}

		public static Vector operator /(Vector a, double d)
		{
			return new Vector(a.x / d, a.y / d, a.z / d);
		}

		public double this[int idx]
		{
			get
			{
				switch (idx)
				{
					case 0:
						return x;
					case 1:
						return y;
					case 2:
						return z;
					default:
						return 0;
				}
			}
			set
			{
				switch (idx)
				{
					case 0:
						x = value;
						break;
					case 1:
						y = value;
						break;
					case 2:
						z = value;
						break;
				}
			}
		}

		public static implicit operator Vector(double x)
		{
			return new Vector(x, 0, 0);
		}

		public static explicit operator double(Vector v)
		{
			return Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
		}

		public override string ToString()
		{
			return "[" + x + " " + y + " " + z + "]";
		}

		private static bool nearlyEqual(double a, double b)
		{
			const double epsilon = 1E-10;
			const double MinNormal = 2.2250738585072014E-308d;
			double absA = Math.Abs(a);
			double absB = Math.Abs(b);
			double diff = Math.Abs(a - b);
			if (a.Equals(b))
			{ // shortcut,	handles	infinities
				return true;
			}
			else if (a == 0 || b == 0 || absA + absB < MinNormal)
			{
				// a or	b is zero or both are extremely	close to it
				// relative	error is less meaningful here
				return diff < (epsilon * MinNormal);
			}
			else
			{ // use relative error
				return diff / (absA + absB) < epsilon;
			}
		}

		public static bool operator ==(Vector a, Vector b)
		{
			return nearlyEqual(a.x, b.x) && nearlyEqual(a.y, b.y) && nearlyEqual(a.z, b.z);
		}

		public static bool operator !=(Vector a, Vector b)
		{
			return !(a == b);
		}

		public override bool Equals(object v)
		{
			Vector v1 = new Vector(x, y, z);
			Vector v2 = (Vector)v;
			return v1 == v2;
		}
		public override int GetHashCode()
		{
			return x.GetHashCode() + y.GetHashCode() + z.GetHashCode();
		}
	}
}
