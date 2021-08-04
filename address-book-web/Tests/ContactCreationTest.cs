using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using address_book_web.Models;


namespace address_book_web.Tests
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
            app.NavigationHelper.OpenHomePage();
        }

        [Test]
        public void ContactDeleteTest()
        { 
            app.ContactHelper.Delete();
            app.NavigationHelper.OpenHomePage();
        }

        [Test]
        public void ContactNameAndMiddleNameUpdateTest()
        {
            Contact contact = new Contact();
            contact.Name = "Dima";
            contact.MiddleName = "Morozov";

            app.ContactHelper.UpdateContactNameAndMiddleName(contact);
            app.NavigationHelper.OpenHomePage();
        }
    }
}
