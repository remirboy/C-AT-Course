using address_book_web.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;

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
                OpenEditContactPage(2);
                InputName(contact.Name);
                InputMiddleName(contact.LastName);
                SubmitContactUpdate();
            }
            else
            {
                Create(contactReserve);
                OpenHomePage();
                UpdateContactNameAndMiddleName(contact);
            }

        }

        public void Delete(int contactIndex)
        {
            if (IsElementPresent(By.XPath("/html/body/div/div[4]/form[2]/table/tbody/tr[2]")))
            {
                OpenEditContactPage(contactIndex);
                SubmitContactDelete();
            }
            else
            {
                Create(contactReserve);
                OpenHomePage();
                Delete(contactIndex);
            }
        }

        public Contact GetContactInformationFromTable()
        {
            Contact contact = new Contact();
            contact.Name = FindContactAttributeInformationFromTable(3);
            contact.LastName = FindContactAttributeInformationFromTable(2);
            contact.Address = FindContactAttributeInformationFromTable(4);
            contact.Email1 = FindContactAttributeInformationFromTable(5);
            contact.MobilePhone = FindContactAttributeInformationFromTable(6);
            return contact;
        }

        public Contact GetContactInformationFromEditForm()
        {
            Contact contact = new Contact();
            OpenEditContactPage(2);
            contact.Name = FindContactAttributeInformationFromEditForm("firstname");
            contact.LastName = FindContactAttributeInformationFromEditForm("lastname");
            contact.Address = FindContactAttributeInformationFromEditForm("address");
            contact.HomePhone = FindContactAttributeInformationFromEditForm("home");
            contact.MobilePhone = FindContactAttributeInformationFromEditForm("mobile");
            contact.WorkPhone = FindContactAttributeInformationFromEditForm("work");
            contact.Email1 = FindContactAttributeInformationFromEditForm("email");
            contact.Email2 = FindContactAttributeInformationFromEditForm("email2");
            contact.Email3 = FindContactAttributeInformationFromEditForm("email3");
            return contact;
        }

        public Contact GetContactInformationFromContactPage()
        {
            Contact contact = new Contact();
            OpenContactPage(3);
            string contactInfo = driver.FindElement(By.XPath("//*[@id=\"content\"]")).Text;
            string[] contactInfoArray = contactInfo.Split(' ');

            contact.Name = contactInfoArray[0];

            string[] nameAndAddress = contactInfoArray[1].Split();

            contact.LastName = nameAndAddress[0];
            contact.Address = nameAndAddress[2];


            string phonePattern = @"\d{1,}";

            Match mHomePhone = Regex.Match(contactInfoArray[2], phonePattern);
            Match mMobilePhone = Regex.Match(contactInfoArray[3], phonePattern);
            Match mWorkPhone = Regex.Match(contactInfoArray[4], phonePattern);

            contact.HomePhone = mHomePhone.Value;
            contact.MobilePhone = mMobilePhone.Value;
            contact.WorkPhone = mWorkPhone.Value;


            string emailPattern = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";

            MatchCollection emails = Regex.Matches(contactInfoArray[4], emailPattern);   
            Match[] emailsStr = new Match[emails.Count];
            emails.CopyTo(emailsStr, 0);
            contact.Email1 = emailsStr[0].ToString();
            contact.Email2 = emailsStr[1].ToString();
            contact.Email3 = emailsStr[2].ToString();
            return contact;
        }

        public void AddContactToGroup(Contact contact, GroupData group)
        {
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAddContact(group.GroupName);
            SubmitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(40))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void DeleteContactFromGroup(Contact contact, GroupData group)
        {
            ClearGroupFilter();
            SelectGroupFilter(group.GroupName);
            SelectContact(contact.Id);
            SubmitDeletingContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(40))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }


        // Helps methods

        private void SubmitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAddContact(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void SelectContact (string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[none]");
        }

        private void SelectGroupFilter(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        private void SubmitDeletingContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }


        private ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        private ContactHelper FillContact(Contact contact)
        {
            InputName(contact.Name);
            InputMiddleName(contact.LastName);
            return this;
        }

        // UI\UX block

        private void InputName(string name)
        {
            InputText("firstname", name);
        }

        private void InputMiddleName(string middleName)
        {
            InputText("lastname", middleName);
        }

        private string FindContactAttributeInformationFromTable(int elementIndex)
        {
           return driver.FindElement(By.XPath("/html/body/div/div[4]/form[2]/table/tbody/tr[3]/td["+elementIndex+"]")).Text;
        }

        private string FindContactAttributeInformationFromEditForm(string name)
        {
            return driver.FindElement(By.Name(name)).GetAttribute("value");
        }

        private ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
        }

        private ContactHelper OpenEditContactPage(int contactIndex)
        {
            driver.FindElement(By.XPath("/html/body/div/div[4]/form[2]/table/tbody/tr[" + contactIndex + "]/td[8]/a")).Click();
            return this;
        }

        private ContactHelper OpenContactPage(int contactIndex)
        {
            driver.FindElement(By.XPath("/html/body/div/div[4]/form[2]/table/tbody/tr[" + contactIndex + "]/td[7]/a")).Click();
            return this;
        }

        private ContactHelper SubmitContactUpdate()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        private ContactHelper SubmitContactDelete()
        {
          
            driver.FindElement(By.XPath("/html/body/div/div[4]/form[2]/input[2]")).Click();
            contactCache = null;
            return this;
        }

        private void OpenHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }



        // Contact list block

        private List<Contact> contactCache = null;

        public List<Contact> GetContactsList()
        {
            contactCache = new List<Contact>();
            driver.FindElement(By.LinkText("home")).Click();

            ICollection<IWebElement> names = driver.FindElements(By.XPath("/html/body/div/div[4]/form[2]/table/tbody/tr[@name='entry']/td[3]"));
            IWebElement[] namesArray = new IWebElement[names.Count];
            names.CopyTo(namesArray, 0);

            ICollection<IWebElement> lastNames = driver.FindElements(By.XPath("/html/body/div/div[4]/form[2]/table/tbody/tr[@name='entry']/td[2]"));
            IWebElement[] lastNamesArray = new IWebElement[lastNames.Count];
            lastNames.CopyTo(lastNamesArray, 0);

            if (names.Count == lastNames.Count)        
                for (int i=0;i<namesArray.Length;i++)
                    contactCache.Add(new Contact() { Name = namesArray[i].Text, LastName = lastNamesArray[i].Text});
            return new List<Contact>(contactCache);
        }
    }
}
