using System;
using System.Collections.Generic;
using System.Drawing;
using DN3;
using lab4.Properties;

namespace DN4
{
    abstract class Orb
    {
        protected const double G = 30; //6.673e-11

        protected Bitmap bitmap;
        protected Vector posNew, pos;
        protected Vector v0;
        protected string name;
        protected double mass;

        public Vector Pos
        {
            get { return pos; }
        }

        public Vector Velocity
        {
            get { return v0; }
        }

        public double Mass
        {
            get { return mass; }
        }

        public abstract void Draw(Graphics g);

        public void Move()
        {
            pos = posNew;
        }

        public Orb(string name, double x, double y, double vx, double vy, double m)
        {
            pos = new Vector(x, y, 0);
            v0 = new Vector(vx, vy, 0);
            mass = m;
            this.name = name;
            bitmap = (Bitmap)Resources.ResourceManager.GetObject(name);
        }

        public virtual void CalcPosNew(IList<Orb> space)
        {
            Vector a = new Vector(0,0,0);
            foreach (Orb orb in space)
            {
                if (orb == this)
                {
                    continue;
                }

                // calculate r to other orb
                Vector r = orb.pos - this.pos;

                // calculate distance to other orb
                double distance = (double)r;

                // calculate F to other orb
                double F = (G * (this.Mass * orb.Mass)) / (distance * distance);

                // calculate a to other orb
                double aScalar = F / this.Mass;

                // calculate a vector to other orb
                a += Math.Abs(aScalar) * (r / ((double)r));
            }

            double t = 3;
            posNew = pos + v0 * t + (t * t) * a;
            v0 = v0 + t * a;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
