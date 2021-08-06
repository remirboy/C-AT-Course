using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace address_book_web.Models
{
    public class Contact
    {
        private string name;
        private string lastName;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public Contact(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
        }

        public Contact(string name)
        {
            this.name = name;
        }

        public Contact() { }
        public override string ToString()
        {
            return base.ToString() + ": " + name + lastName;
        }
    }

}
