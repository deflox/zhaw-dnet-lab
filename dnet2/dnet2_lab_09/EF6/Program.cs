using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new FlughafenDBEntities())
            {
                // Display all Flights from the database
                var query = from flug in db.Flug
                            where flug.Flugnr.Equals("AF1413")
                            orderby flug.Abflug
                            select flug;
                Console.WriteLine("All flights in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Flug_ID + ", " + item.Flugnr + ", " + item.Von + ", " + item.Nach + ", "
                    + item.Abflug + ", " + item.Ankunft);
                }
                Console.WriteLine("Press any key to exit...");
                Console.Read();
            }
        }
    }
}
