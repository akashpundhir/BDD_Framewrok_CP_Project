using Core.Base;
using Core.Drivers;
using OpenQA.Selenium;

namespace Lilial.PageObjects.B2CLogin
{
    public class LoginPage : BasePage
    {
        public LoginPage() : base()
        {
        }

        public IWebElement Email => Browser.FindElement(By.Id("email"), 30);
        public IWebElement Password => Browser.FindElement(By.Id("password"));
        public IWebElement LoginBtn => Browser.FindElement(By.Id("next"));
    }

}
