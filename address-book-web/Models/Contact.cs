using address_book_web.DBModels;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace address_book_web.Models
{
    [Table(Name = "addressbook")]
    public class Contact : IEquatable<Contact>, IComparable<Contact>
    {
        [Column(Name = "id"),PrimaryKey,Identity]
        public string Id { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string HomePhone {get;set;}

        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "email")]
        public string Email1 { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

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

        [Column(Name = "firstname")]
        public string Name { get; set; }

        [Column(Name = "lastname")]
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

        public static List<Contact> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
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
