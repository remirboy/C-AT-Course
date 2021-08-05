using address_book_web.Models;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace address_book_web.Helpers
{
    public class ContactHelper : HelperBase
    {

        private Contact contactReserve = new Contact("Name","MiddleName");

        public ContactHelper(IWebDriver driver) : base(driver) { }

        public ContactHelper Create(Contact contact)
        {
            InitContactCreation();
            FillContact(contact);
            SubmitContactCreation();
            return this;
        }

        public void UpdateContactNameAndMiddleName(Contact contact)
        {
            if (IsElementPresent(By.XPath("/html/body/div/div[4]/form[2]/table/tbody/tr[2]")))
            {
                ChooseContact();
                InputName(contact.Name);
                InputMiddleName(contact.MiddleName);
                SubmitContactUpdate();
            }
            else
            {
                Create(contactReserve);
                OpenHomePage();
                UpdateContactNameAndMiddleName(contact);
            }

        }

        public void Delete()
        {
            if (IsElementPresent(By.XPath("/html/body/div/div[4]/form[2]/table/tbody/tr[2]")))
            {
                ChooseContact();
                SubmitContactDelete();
            }
            else
            {
                Create(contactReserve);
                OpenHomePage();
                Delete();
            }

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
          
            driver.FindElement(By.XPath("//table/tbody//input[1]")).Click();
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

        private void OpenHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }

        public List<Contact> GetContactsList()
        {
            List<Contact> contacts = new List<Contact>();
            driver.FindElement(By.LinkText("home")).Click();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("/html/body/div/div[4]/form[2]/table/tbody/tr[@name='entry']"));
            foreach (IWebElement element in elements)
                contacts.Add(new Contact(element.Text));
            return contacts;
        }

    }
}
