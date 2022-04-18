using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

/// <summary>
/// Sieb des Eratosthenes
/// Autor: Karl Rege 
/// </summary>

namespace DN1
{
    public enum PrimeType { Prime, NotPrime };

    public class Eratosthenes
    {
        public PrimeType[] Sieve(int maxPrime)
        {
            PrimeType[] result = new PrimeType[maxPrime];
            result[0] = PrimeType.NotPrime;
            result[1] = PrimeType.Prime;

            for (int i = 1; i < maxPrime; i++)
            {
                if (result[i] == PrimeType.NotPrime)
                    continue;

                int m = (i + 1) * 2;
                while (m <= maxPrime)
                {
                    result[m-1] = PrimeType.NotPrime;
                    m += (i + 1);
                }


            }

            return result;
        }

        public int[] PrimesAsArray(PrimeType[] primes)
        {
            int size = 0;
            for (int i = 0; i < primes.Length; i++)
            {
                if (primes[i] == PrimeType.Prime) size++;
            }

            int[] result = new int[size];
            int c = 0;
            for (int i = 0; i < primes.Length; i++)
            {
                if (primes[i] == PrimeType.Prime) result[c++] = i + 1;
            }

            return result;
        }

        public List<int> PrimesAsList(PrimeType[] primes)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < primes.Length; i++)
            {
                if (primes[i] == PrimeType.Prime)  result.Add(i+1);
            }
            return result;
        }

        public Dictionary<int, int> PrimesAsDictionary(PrimeType[] primes)
        {
            Dictionary<int, int> primesDictonary = new Dictionary<int, int>();
            for (int i = 0; i < primes.Length; i++)
            {
                if (primes[i] == PrimeType.Prime) primesDictonary[i] = i + 1;
            }
            return primesDictonary;
        }

        public void printAll(IEnumerable<int> collection)
        {
            int i = 0;
            foreach (int p in collection)
            {
                Console.Write((i++) + "->" + p + " ");
                if ((i + 1) % 5 == 0) Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int maxPrime = 100;
            Eratosthenes eratosthenes = new Eratosthenes();
            if (args.Length >= 1)
                maxPrime = Int32.Parse(args[0]);
            
            PrimeType[] primes = eratosthenes.Sieve(maxPrime);
            Console.WriteLine("Aufgabe 1");
            for (int i = 0; i < maxPrime; i++)
            {
                Console.Write(i + ":" + primes[i] + " ");
                if ((i + 1) % 5 == 0) Console.WriteLine();
            }
            Console.WriteLine("\nAufgabe 2");
            eratosthenes.printAll(eratosthenes.PrimesAsArray(primes));
            Console.WriteLine("\nAufgabe 3");
            eratosthenes.printAll(eratosthenes.PrimesAsList(primes));
            Console.WriteLine("\nAufgabe 4");
            eratosthenes.printAll(eratosthenes.PrimesAsDictionary(primes).Select(z => z.Value).ToArray());
            
            Console.ReadLine();
        }
    }
}