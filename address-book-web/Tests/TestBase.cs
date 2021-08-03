using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using address_book_web.Managers;
using address_book_web.Models;

namespace address_book_web
{
    [TestClass]
    public class TestBase 
    {

        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            app.NavigationHelper.OpenHomePage();

            AccountData user = new AccountData();
            user.Login = "admin";
            user.Password = "secret";
            app.LoginHelper.Login(user);
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }

    }
}
