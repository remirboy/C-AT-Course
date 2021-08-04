using System;
using NUnit.Framework;
using System.Threading;
using address_book_web.Managers;
using address_book_web.Models;

namespace address_book_web.Tests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        [SetUp]
        public void GlobalSetup() 
        {
            ApplicationManager app = ApplicationManager.GetInstance();


            app.NavigationHelper.OpenHomePage();

            AccountData user = new AccountData();
            user.Login = "admin";
            user.Password = "secret";
            app.LoginHelper.Login(user);
        }
    }
}
