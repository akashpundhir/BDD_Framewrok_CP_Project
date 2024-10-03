using Core.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.Base
{
    public class BasePage
    {
        protected IWebDriver Browser;
        protected WebDriverWait BrowserWait;

        public BasePage()
        {
            Browser = Driver.Browser;
            BrowserWait = Driver.BrowserWait;
        }
    }
}
