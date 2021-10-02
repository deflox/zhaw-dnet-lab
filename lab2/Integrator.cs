using System;

namespace DN2
{
    class MainClass
    {
        const int STEPS = 100;
        const double EPS = 1E-5;

        public static void Main(string[] args)
        {
            Console.WriteLine("Linear fixed [0..10]: " + Integrator.Integrate(x => x, 0, 10, STEPS) + " steps: " + Integrator.Steps);
            Console.WriteLine("Linear fixed [5..15]: " + Integrator.Integrate(x => x, 5, 15, STEPS) + " steps: " + Integrator.Steps);
            Console.WriteLine("Linear adapt [0..10]: " + Integrator.Integrate(x => x, 0, 10, EPS) + " steps: " + Integrator.Steps);
            Console.WriteLine("Square fixed [0..10]: " + Integrator.Integrate(x => x * x, 0, 10, STEPS) + " steps: " + Integrator.Steps);
            Console.WriteLine("Square adapt [0..10]: " + Integrator.Integrate(x => x * x, 0, 10, EPS) + " steps: " + Integrator.Steps);
            Console.ReadLine();
        }
    }

    public class Integrator
    {
        public static int Steps;

        public static double Integrate(Func<double, double> f, double start, double end, int steps)
        {
            Steps = steps;
            return calc(f, start, end, steps);            
        }

        public static double Integrate(Func<double, double> f, double start, double end, double eps)
        {
            Steps = 1;

            double curr = calc(f, start, end, Steps);
            double prev = 0;

            do
            {
                prev = curr;
                
                Steps *= 2;
                curr = calc(f, start, end, Steps);

            } while (Math.Abs(curr - prev) > eps);

            return curr;
        }

        private static double calc(Func<double, double> f, double start, double end, int steps)
        {
            double sum = 0;
            double h = (end - start) / steps;
            for (int i = 1; i < steps; i++)
            {
                sum += f(start + i * h);
            }

            return h * ((f(start) + f(end)) / 2 + sum);
        }
    }

}