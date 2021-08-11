using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace address_book_web.Models
{
    public class Contact : IEquatable<Contact>, IComparable<Contact>
    {
        public string Address { get; set; }
        public string HomePhone {get;set;}
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Emails
        {
            get
            {
                return Clean(Email1) + Clean(Email2) + Clean(Email3);
            }
            set
            {
                Emails = value;
            }
        }
              
        public string Phones
        {
            get
            {
                return Clean(HomePhone) + Clean(WorkPhone) + Clean(MobilePhone);
            }
            set
            {
                Phones = value;
            }
        }

        public string Name { get; set; }

        public string LastName { get; set; } 

        public Contact(string name, string lastName)
        {
            Name = name;
            LastName = lastName; 
        }

        public Contact(string name)
        {
            Name = name;
        }

        public Contact() { }

        private string Clean(string phone)
        {
            if (phone == null)
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("+", "");
        }

        public int CompareTo(Contact contact)
        {
            if (Object.ReferenceEquals(null, contact))
                return 1;
            return Name.CompareTo(contact.Name);

        }

        public bool Equals(Contact otherContact)
        {
            if (Object.ReferenceEquals(otherContact, null))
                return false;
            if (Object.ReferenceEquals(this, otherContact))
                return true;
            return Name == otherContact.Name && LastName == otherContact.LastName;
        }

        public override string ToString()
        {
            return  Name + " "+ LastName + " " + Address + " " + Emails + " " + Phones + ";";
        }
    }

}
