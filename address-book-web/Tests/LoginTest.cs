﻿using NUnit.Framework;
using address_book_web.Models;


namespace address_book_web.Tests
{
    [TestFixture]
    public class LoginTest : TestBase
    {

        [Test]
        public void LogoutTest()
        {
            app.NavigationHelper.OpenHomePage();
            app.LoginHelper.LogOut();
        }
    }
}