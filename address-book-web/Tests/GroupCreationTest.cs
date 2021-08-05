using NUnit.Framework;
using address_book_web.Models;

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
            app.GroupHelper.Create(group);
            app.NavigationHelper.OpenHomePage();
        }

        [Test]
        public void GroupDeleteTest()
        {
            app.NavigationHelper.OpenGroupsPage();
            app.GroupHelper.Delete();
            app.NavigationHelper.OpenHomePage();
        }

        [Test]
        public void GroupNameUpdateTest()
        {
            GroupData group = new GroupData();
            group.GroupName = "Name2";
           
            app.NavigationHelper.OpenGroupsPage();
            app.GroupHelper.UpdateName(group);
            app.NavigationHelper.OpenHomePage();
        }
    }
}