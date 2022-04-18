using System;

namespace DN6
{
    class Program
    {
        static void Main(string[] args)
        {
            Contacts contacts = new Contacts();
            contacts.readCsv("C:\\Users\\Leo\\code\\projects\\zhaw-dnet1-lab\\lab7\\ZHAW-name-short.csv");

            foreach (String t in contacts[2])
            {
                Console.WriteLine(t);
            }

            /*
            foreach (Contact contact in contacts)
            {
                Console.WriteLine(contact.Name + " " + contact.Kurz);
            }*/
        }
    }
}
