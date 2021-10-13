using System;
using System.Collections.Generic;
using System.Text;

namespace DN3 {

    public class Space {
        
        static void Main(string[] args) {
            Vector omegaEarth,omegaSun, omegaGalaxy;
            Vector rEarth, rSun, rGalaxy;
            
            InitOmegaVectors(out omegaEarth,out omegaSun, out omegaGalaxy);
            InitRVectors(out rEarth, out rSun, out rGalaxy);
            double speed = CalcSpeed(omegaEarth,omegaSun, omegaGalaxy,rEarth, rSun, rGalaxy);
            Console.WriteLine("Speed is "+speed+" km/s");
            Console.ReadLine();
        }

        public static void InitOmegaVectors(out Vector omegaEarth, out Vector omegaSun, out Vector omegaGalaxy) {
            Vector unitVector = new Vector(0, 1, 0);
            omegaEarth = (2 * Math.PI / (86400)) * unitVector;
            omegaSun = (2 * Math.PI / (365.25 * 86400)) * unitVector;
            omegaGalaxy = (2 * Math.PI / ((365.25 * (225 * Math.Pow(10, 6))) * 86400)) * unitVector;
        }

        public static void InitRVectors(out Vector rEarth, out Vector rSun, out Vector rGalaxy) {
            rEarth = 6370.0;
            rSun = 149.6 * Math.Pow(10, 6);
            rGalaxy = 25000 * 9.46 * Math.Pow(10, 12);
        }

        public static double CalcSpeed(Vector omegaEarth, Vector omegaSun, Vector omegaGalaxy, Vector rEarth, Vector rSun, Vector rGalaxy)
        {
            return (double)(omegaEarth * rEarth + omegaSun * rSun + omegaGalaxy * rGalaxy);
        }
    }

}
