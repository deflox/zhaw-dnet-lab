using System;
using System.Text;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Reflection;
using System.Collections;

namespace DN6
{
    public class Contact : IEnumerable<String>, IComparable<Contact>
    {
        public String Name { get; set; }
        public String Kurz { get; set; }
        public String Standort { get; set; }
        public String Kategorie { get; set; }
        public String EMail { get; set; }
        public String Tel { get; set; }
        public String Departement { get; set; }

        public override String ToString()
        {
            StringBuilder b = new StringBuilder();
            foreach (String s in this) { b.Append(s); b.Append(";"); }
            return b.ToString();
        }

        public String ToVcf()
        {
            string res = "BEGIN:VCARD\n" +
                      "VERSION:3.0\n" +
                      "N;CHARSET=ISO-8859-1:" + Name + ";;;;\n" +
                      "FN;CHARSET=ISO-8859-1:" + Name + "\n" +
                      "ADR;TYPE=work,pref;CHARSET=ISO-8859-1:;/" + Standort + "\n" +
                      "TEL;TYPE=work,voice,pref:+" + Tel + "\n" +
                      "EMAIL;TYPE=INTERNET:natalie.lynch@pencloud.com\n" +
                      "END:VCARD";
            return res;
        }

        private static string GetTelNumber(String kurz)
        {
            String url = "https://www.zhaw.ch/de/ueber-uns/person/" + kurz;
            WebRequest rq = WebRequest.Create(url);
            WebResponse rsp;
            try
            {
                rsp = rq.GetResponse();
            } catch (WebException ex)
            {
                return "";
            }

            bool telFound = false;
            StreamReader r = new StreamReader(rsp.GetResponseStream());

            try
            {
                for (string line = r.ReadLine(); line != null; line = r.ReadLine())
                {
                    if (telFound)
                    {
                        return line.Substring(line.IndexOf(">") + 1, (line.IndexOf("<") - line.IndexOf(">")) - 1);
                    }

                    if (line.Contains("telephone")) telFound = true;
                }
            } finally
            {
                r.Close();
            }            

            return "";
        }

        public void addPhoneNumber()
        {
            Tel = GetTelNumber(Kurz).Replace("(0)", "").Replace(" ", "");
        }

        public IEnumerator<String> GetEnumerator()
        {
            PropertyInfo[] pis = this.GetType().GetProperties();

            foreach (PropertyInfo pi in pis) 
            {
                yield return (string)pi.GetValue(this);
            }
        }

        public IEnumerator<String> GetFieldNames()
        {
            PropertyInfo[] pis = this.GetType().GetProperties();

            foreach (PropertyInfo pi in pis)
            {
                yield return pi.Name;
            }
        }

        public Contact(string name, string kurz, string standort, string kategorie, string eMail, string tel, string dep)
        {
            Name = name;
            Kurz = kurz;
            Standort = standort;
            Kategorie = kategorie;
            EMail = eMail;
            Tel = tel;
            Departement = dep;
        }

        public int CompareTo(Contact other)
        {
            return other.Name.CompareTo(Name);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}