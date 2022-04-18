using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace DN6 {
    public class Contact : IEnumerable<String>, IComparable<Contact> {
        public String Name {get;set;}
        public String Kurz {get;set;}
        public String Standort{get;set;}
        public String Kategorie{get;set;}
        public String EMail{get;set;}
        public String Tel{get;set;}
        public String Departement{get;set;}
        
        public override String ToString() {
            StringBuilder builder = new StringBuilder();
            foreach (string c in this)
            {
                builder.Append(c + ";");
            }
            return builder.ToString();
        }
        
        public String ToVcf () {
            StringBuilder result = new StringBuilder();
            result.Append("BEGIN:VCARD").AppendLine();
            result.Append("VERSION: 3.0").AppendLine();
            result.Append($"N;CHARSET=ISO-8859-1:{Name};;;;").AppendLine();
            result.Append($"FN;CHARSET=ISO-8859-1:{Name}").AppendLine();
            result.Append($"X-ABShowAs:COMPANY").AppendLine();
            result.Append($"ADR;TYPE=work,pref;CHARSET=ISO-8859-1:ADDRESSE").AppendLine();
            result.Append($"TEL;TYPE=work,voice,pref:{Tel}").AppendLine();
            result.Append($"EMAIL; TYPE = INTERNET:{EMail}").AppendLine();
            result.Append("END:VCARD");
            return result.ToString();
        }

        public Contact(string name, string kurz, string standort, string kategorie, string eMail, string tel, string dep)  {
            this.Name = name;
            this.Kurz = kurz;
            this.Standort = standort;
            this.Kategorie = kategorie;
            this.EMail = eMail;
            this.Tel = tel;
            this.Departement = dep;
        }

        public int CompareTo(Contact other)
        {
            return other.Name.CompareTo(this.Name);
        }

        public IEnumerator<string> GetEnumerator()
        {
            yield return Name;
            yield return Kurz;
            yield return Standort;
            yield return Kategorie;
            yield return EMail;
            yield return Tel;
            yield return Departement;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}
