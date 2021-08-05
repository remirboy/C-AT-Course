using OpenQA.Selenium;

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

     

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}
