using address_book_web.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace address_book_web.Tests
{
    [TestFixture]
    public class ContatsGroupsRelations : AuthTestBase
    {
        [Test]
        public void AddingContactToGroup()
        {

//            app.NavigationHelper.OpenHomePage();
            GroupData group = GroupData.GetAll()[0];
            List<Contact> oldList = group.GetContactsByGroup();
            Contact contact = Contact.GetAll().Except(oldList).First();

            app.ContactHelper.AddContactToGroup(contact, group);

            List<Contact> newList = group.GetContactsByGroup();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }

        [Test]
        public void DeletingContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<Contact> oldList = group.GetContactsByGroup();
            Contact contact = Contact.GetAll().Except(oldList).First();

            app.ContactHelper.AddContactToGroup(contact, group);

            List<Contact> newList = group.GetContactsByGroup();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }

    }
}
