using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DN6 {

    public class Contacts : List<Contact>  {

        public void readCsv(string file){
            String[] lines = File.ReadAllLines(file);
            foreach (var line in lines) {
                string[] split = line.Split(';');
                Add(new Contact(split[0], split[1], "", "", "", "", ""));
            }
        }

        public void writeCsv(string file) {
            StringBuilder b = new StringBuilder();
            foreach (Contact contact in this) {
                b.Append(contact+"\n");
            }
            File.WriteAllText(file,b.ToString());
        }

        public void writeVcf(Contact c)  {
        	File.WriteAllText(c.Name + ".vcf", c.ToVcf());
        }


    }
}
