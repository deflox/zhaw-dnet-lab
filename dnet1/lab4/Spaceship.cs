using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN4
{
    class Spaceship : Orb
    {
        public Spaceship(string name, double x, double y, double vx, double vy, double m) : base(name, x, y, vx, vy, m)
        {

        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(bitmap, (int)pos[0], (int)pos[1], bitmap.Width / 2, bitmap.Height / 2);
        }
    }
}
