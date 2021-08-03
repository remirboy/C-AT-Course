using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using address_book_web.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace address_book_web.Helpers
{
    public  class LoginHelper : HelperBase 
    {
        
        public LoginHelper(IWebDriver driver) : base(driver) { }

        public LoginHelper Login(AccountData user)
        {
            CredentialsInput(user);
            LoginSubmit();
            return this;
        }

        public LoginHelper LogOut()
        {
            ClickLogOut();
            return this;
        }

        private LoginHelper ClickLogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }

        private LoginHelper CredentialsInput(AccountData user)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).SendKeys(user.Login);
            driver.FindElement(By.XPath("//*/text()[normalize-space(.)='']/parent::*")).Click();
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).SendKeys(user.Password);
            return this;
        }

        private LoginHelper LoginSubmit()
        {
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            return this;
        }
    }
}
