using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using address_book_web.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace address_book_web.Helpers
{
    public class GroupHelper:HelperBase
    {
        public GroupHelper(IWebDriver driver) : base(driver) { }

        public GroupHelper Create(GroupData group)
        {
            InitGroupCreation();
            FillNewGroup(group);
            SubmitGroupCreation();
            return this;
        }

        public GroupHelper UpdateName(GroupData group)
        {
            ChooseGroup();
            UpdateClick();
            EditGroupName(group);
            SubmitGroupNameUpdate();
            return this;
        }

        public GroupHelper Delete()
        {
            ChooseGroup();
            DeleteClick();
            ReturnToGroupsPage();
            return this;
        }


        private GroupHelper FillNewGroup(GroupData group)
        {
            FindGroupForm();
            InputGroupName(group.GroupName);
            InputGroupHeader(group.GroupHeader);
            InputGroupFooter(group.GroupFooter);
            return this;
        }

        private GroupHelper EditGroupName(GroupData group)
        {
            FindGroupForm();
            InputGroupName(group.GroupName);
            return this;
        }

        private void InputGroupName(string groupName)
        {
            InputText("group_name", groupName);
        }

        private void InputGroupHeader(string groupHeader)
        {
            InputText("group_header", groupHeader);
        }

        private void InputGroupFooter(string groupFooter)
        {
            InputText("group_footer", groupFooter);
        }

        private GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        private GroupHelper SubmitGroupNameUpdate()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private GroupHelper ChooseGroup()
        {
            driver.FindElement(By.XPath("/html/body/div/div[4]/form/span[1]/input")).Click();
            return this;
        }

        private GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        private GroupHelper DeleteClick()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        private GroupHelper UpdateClick()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        private GroupHelper FindGroupForm()
        {
            driver.FindElement(By.XPath("//form[@action='/addressbook/group.php']")).Click();
            return this;
        }

        private void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }
    }
}
//