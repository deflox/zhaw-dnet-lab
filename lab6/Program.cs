using System;
using DN6;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Contact contact1 = new Contact("t1", "t2", "t3", "t4", "t5", "t6", "t7");
            foreach (string c in contact1)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
