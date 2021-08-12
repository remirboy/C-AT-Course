using System;
using NUnit.Framework;
using address_book_web.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace address_book_web.Tests
{
    [TestFixture]
    public class ContactsCreationTest : AuthTestBase
    {

        private static IEnumerable<Contact> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<Contact>>(
                File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTest(Contact contact)
        {
            app.NavigationHelper.OpenContactCreationPage();
            List<Contact> oldContacts = app.ContactHelper.GetContactsList();
            app.ContactHelper.Create(contact);

            app.NavigationHelper.OpenHomePage();
            List<Contact> newContacts = app.ContactHelper.GetContactsList();

            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);

            oldContacts.Add(contact);
            newContacts.Sort();
            oldContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }

        [Test]
        public void ContactDeleteTest()
        {

            List<Contact> oldContacts = app.ContactHelper.GetContactsList();
            app.ContactHelper.Delete(3);
            app.NavigationHelper.OpenHomePage();
            List<Contact> newContacts = app.ContactHelper.GetContactsList();

            Assert.AreEqual(oldContacts.Count - 1, newContacts.Count);

        }

        [Test]
        public void ContactNameAndMiddleNameUpdateTest()
        {
            Contact contact = new Contact();
            contact.Name = "Dima";
            contact.LastName = "Morozov";
            List<Contact> oldContacts = app.ContactHelper.GetContactsList();
            app.ContactHelper.UpdateContactNameAndMiddleName(contact);
            app.NavigationHelper.OpenHomePage();
            List<Contact> newContacts = app.ContactHelper.GetContactsList();

            Assert.AreEqual(oldContacts.Count, newContacts.Count);
        }

        [Test]
        public void CompareContactTableAndContactFormInformation()
        {
            app.NavigationHelper.OpenHomePage();

            Contact contactForm = app.ContactHelper.GetContactInformationFromEditForm();
           
            app.NavigationHelper.OpenHomePage();
            Contact contactTable = app.ContactHelper.GetContactInformationFromTable();
            Assert.AreEqual(contactForm, contactTable);
        }

        [Test]
        public void CompareContactTableAndContactPageInformation()
        {
            app.NavigationHelper.OpenHomePage();

            Contact contactForm = app.ContactHelper.GetContactInformationFromContactPage();

            app.NavigationHelper.OpenHomePage();
            Contact contactTable = app.ContactHelper.GetContactInformationFromTable();
            Assert.AreEqual(contactForm, contactTable);
        }
    }
}
