using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using address_book_web.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace address_book_web
{
    [TestClass]
    public class TestBase 

    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;
        private bool acceptNextAlert = true;


        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();
        }


        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            NUnit.Framework.Assert.AreEqual("", verificationErrors.ToString());
        }

        protected void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }

        protected void UserAutharization(AccountData user)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).SendKeys(user.Login);
            driver.FindElement(By.XPath("//*/text()[normalize-space(.)='']/parent::*")).Click();
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).SendKeys(user.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        protected void OpenGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }


        protected void LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        protected void OpenNewGroupCreationPage()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        protected void OpenContactCreationPage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/edit.php");
        }


        protected void FillGroup(GroupData group)
        {
            driver.FindElement(By.XPath("//form[@action='/addressbook/group.php']")).Click();
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.GroupName);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.GroupHeader);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.GroupFooter);
            driver.FindElement(By.Name("submit")).Click();
        }

        protected void EnterName(string name)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(name);
        }

        protected void EnterMiddleName(string middleName)
        {
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(middleName);
        }

        protected void SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
        }

    }
}
