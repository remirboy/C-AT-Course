using NUnit.Framework;
using address_book_web.Models;
using System.Collections.Generic;

namespace address_book_web.Tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData();
            group.GroupName = "Name";
            group.GroupHeader = "Header";
            group.GroupFooter = "Footer";

            app.NavigationHelper.OpenGroupsPage();
            List<GroupData> oldGroups = app.GroupHelper.GetGroupsList();
            app.GroupHelper.Create(group);

            List<GroupData> newGroups = app.GroupHelper.GetGroupsList();
            app.NavigationHelper.OpenHomePage();

            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void GroupDeleteTest()
        {
            app.NavigationHelper.OpenGroupsPage();

            List<GroupData> oldGroups = app.GroupHelper.GetGroupsList();
            app.GroupHelper.Delete();

            List<GroupData> newGroups = app.GroupHelper.GetGroupsList();
            app.NavigationHelper.OpenHomePage();

            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);
        }

        [Test]
        public void GroupNameUpdateTest()
        {
            GroupData group = new GroupData();
            group.GroupName = "Name2";
           
            app.NavigationHelper.OpenGroupsPage();
            List<GroupData> oldGroups = app.GroupHelper.GetGroupsList();
            app.GroupHelper.UpdateName(group);

            List<GroupData> newGroups = app.GroupHelper.GetGroupsList();
            app.NavigationHelper.OpenHomePage();

            Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }
    }
}