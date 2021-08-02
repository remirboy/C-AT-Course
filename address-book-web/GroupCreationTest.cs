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
            OpenHomePage();
            AccountData user = new AccountData();
            user.Login = "admin";
            user.Password = "secret";
            UserAutharization(user);
            OpenGroupsPage();
            OpenNewGroupCreationPage();
            GroupData group = new GroupData();
            group.GroupName = "Name";
            group.GroupHeader = "Header";
            group.GroupFooter = "Footer";
            FillGroup(group);
            LogOut();
        }
    }
}