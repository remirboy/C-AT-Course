using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace address_book_web.Models
{
    class AccountData
    {
        private string login;
        private string password;

        public string Login {
            get
            {
                return login;
            }
            set {
                login = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public AccountData(string login, string password) { }
        public AccountData() { }
    }
}
