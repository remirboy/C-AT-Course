using NUnit.Framework;
using address_book_web.Models;
using System;
using System.Threading;

namespace address_book_web.Tests
{
    [TestFixture]
    public class LoginTest : TestBase
    {

        [Test]
        public void LoginWithValidCredentials()
        {
//            app.LoginHelper.LogOut();

            AccountData user = new AccountData();
            user.Login = "admin";
            user.Password = "secret";
            app.LoginHelper.Login(user);

            Assert.IsTrue(app.LoginHelper.IsUserLoggedIn(user));
        }

        [Test]
        public void LogoutTest()
        {
            AccountData user = new AccountData();
            app.LoginHelper.LogOut();

            user.Login = "admin";
            user.Password = "secret";
            app.LoginHelper.Login(user);

            app.LoginHelper.LogOut();
            Thread.Sleep(5000);
            Assert.IsFalse(app.LoginHelper.IsLoggedIn());
        }
    }
}
