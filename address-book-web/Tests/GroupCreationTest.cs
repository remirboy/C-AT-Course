using NUnit.Framework;
using address_book_web.Models;

namespace address_book_web
{
    [TestFixture]
    public class GroupCreationTests : TestBase
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
            app.LoginHelper.LogOut();  
        }

        [Test]
        public void GroupDeleteTest()
        {
            app.NavigationHelper.OpenGroupsPage();
            app.GroupHelper.Delete();
            app.LoginHelper.LogOut();
        }

        [Test]
        public void GroupNameUpdateTest()
        {
            GroupData group = new GroupData();
            group.GroupName = "Name2";
           
            app.NavigationHelper.OpenGroupsPage();
            app.GroupHelper.UpdateName(group);
            app.LoginHelper.LogOut();
        }
    }
}