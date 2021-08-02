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
            OpenContactCreationPage();
            AccountData user = new AccountData();
            user.Login = "admin";
            user.Password = "secret";
            UserAutharization(user);
            Contact contact = new Contact();
            contact.Name = "Remir";
            contact.MiddleName = "Ziyatdinov";
            EnterName(contact.Name);
            EnterMiddleName(contact.MiddleName);
            SubmitContactCreation();
            Thread.Sleep(3000);
            LogOut();
        }
    }
}
