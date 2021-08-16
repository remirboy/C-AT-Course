using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using address_book_web.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace address_book_web.Helpers
{
    public class NavigationHelper : HelperBase
    {

        private string baseURL;

        public NavigationHelper(IWebDriver driver, string baseURL) : base(driver)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            if (!IsPageOpen("addressbook/"))
                driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }

        public void OpenGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void OpenContactCreationPage()
        {
            if(!IsPageOpen("addressbook/edit.php"))
                driver.Navigate().GoToUrl(baseURL + "addressbook/edit.php");
        }

        public void OpenNoneContactsPage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/?group=[none]");
        }



        private bool IsPageOpen(string page)
        {
            if (driver.Url == baseURL + page)
                return true;
            else
                return false;
        }


    }
}
