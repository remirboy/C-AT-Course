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
    }
}