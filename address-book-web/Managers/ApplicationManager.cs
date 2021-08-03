using address_book_web.Helpers;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace address_book_web.Managers
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL; 

        protected LoginHelper loginHelper;

        public LoginHelper LoginHelper
        {
            get
            {
                return loginHelper;
            }
            set
            {
                loginHelper = value;
            }
        }

        protected NavigationHelper navigationHelper;

        public NavigationHelper NavigationHelper
        {
            get
            {
                return navigationHelper;
            }
            set
            {
                navigationHelper = value;
            }
        }

        protected GroupHelper groupHelper;

        public GroupHelper GroupHelper
        {
            get
            {
                return groupHelper;
            }
            set
            {
                groupHelper = value;
            }
        }

        protected ContactHelper contactHelper;

        public ContactHelper ContactHelper
        {
            get
            {
                return contactHelper;
            }
            set
            {
                contactHelper = value;
            }
        }


        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/";

            loginHelper = new LoginHelper(driver);
            groupHelper = new GroupHelper(driver);
            navigationHelper = new NavigationHelper(driver, baseURL);
            contactHelper = new ContactHelper(driver);
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            } 
        } 
    }
}
