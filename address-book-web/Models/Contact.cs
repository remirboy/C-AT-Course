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
        private string middleName;

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

        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                middleName = value;
            }
        }

        public Contact(string name, string middleName)
        {
            this.name = name;
            this.middleName = middleName;
        }
        public Contact() { }

    }
}
