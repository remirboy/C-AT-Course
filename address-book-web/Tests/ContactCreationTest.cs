using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using address_book_web.Models;

namespace address_book_web 
{
    [TestFixture]
    public class ContactsCreationTest : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            Contact contact = new Contact();
            contact.Name = "Remir";
            contact.MiddleName = "Ziyatdinov";

            app.NavigationHelper.OpenContactCreationPage();
            app.ContactHelper.Create(contact);
            Thread.Sleep(3000);
            app.LoginHelper.LogOut();
        }
    }
}
