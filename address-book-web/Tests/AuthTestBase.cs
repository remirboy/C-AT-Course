using NUnit.Framework;
using address_book_web.Models;

namespace address_book_web.Tests
{
  
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {

            AccountData user = new AccountData();
            user.Login = "admin";
            user.Password = "secret";
            app.LoginHelper.Login(user);
        }
    }
}
