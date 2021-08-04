using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using address_book_web.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace address_book_web.Helpers
{
    public class HelperBase
    {
        protected IWebDriver driver;
        
        public HelperBase(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected void InputText(string location, string text)
        {
            if (text != null)
            {
                driver.FindElement(By.Name(location)).Click();
                driver.FindElement(By.Name(location)).Clear();
                driver.FindElement(By.Name(location)).SendKeys(text);
            }
           
        }

    }
}
