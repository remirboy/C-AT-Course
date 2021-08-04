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
            InputText("user", user.Login);
            InputText("pass", user.Password);
            return this;
        }

        private LoginHelper LoginSubmit()
        {
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            return this;
        }
    }
}
