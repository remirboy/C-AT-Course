using address_book_web.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace address_book_web.Helpers
{
    public  class LoginHelper : HelperBase 
    {
        
        public LoginHelper(IWebDriver driver) : base(driver) { }

        public void Login(AccountData user)
        {
            if (IsLoggedIn())
            {
                if (IsUserLoggedIn(user)) {
                    return;
                }

                LogOut();
            }
            CredentialsInput(user);
            LoginSubmit();
        }

        public void LogOut()
        {
            if (IsLoggedIn())
            {
                ClickLogOut();
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.LinkText("Logout"));
        }

        public bool IsUserLoggedIn(AccountData User)
        {
            return IsLoggedIn() && 
               driver.FindElement(By.XPath("/html/body/div/div[1]/form/b")).Text
               == "(" + User.Login+")"
               ;
        }

        //this methods works with UI

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
