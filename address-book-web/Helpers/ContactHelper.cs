using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using address_book_web.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace address_book_web.Helpers
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(IWebDriver driver) : base(driver) { }

        public ContactHelper Create(Contact contact)
        {
            InitContactCreation();
            FillContact(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper UpdateContactNameAndMiddleName(Contact contact)
        {
            ChooseContact();
            InputName(contact.Name);
            InputMiddleName(contact.MiddleName);
            SubmitContactUpdate();
            return this;
        }

        public ContactHelper Delete()
        {
            ChooseContact();
            SubmitContactDelete();
            return this;
        }


        private ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        private ContactHelper FillContact(Contact contact)
        {
            InputName(contact.Name);
            InputMiddleName(contact.MiddleName);
            return this;
        }

        private void InputName(string name)
        {
            InputText("firstname", name);
        }

        private void InputMiddleName(string middleName)
        {
            InputText("middlename", middleName);
        }

        private ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }

        private ContactHelper ChooseContact()
        {
          
            driver.FindElement(By.XPath("//*[@id=\"16\"]")).Click();
            driver.FindElement(By.XPath("/html/body/div/div[4]/form[2]/table/tbody/tr[2]/td[8]/a")).Click();
            return this;
        }

        private ContactHelper SubmitContactUpdate()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private ContactHelper SubmitContactDelete()
        {
          
            driver.FindElement(By.XPath("/html/body/div/div[4]/form[2]/input[2]")).Click();
            return this;
        }

    }
}
