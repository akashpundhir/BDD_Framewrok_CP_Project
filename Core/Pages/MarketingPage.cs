using Core.Drivers;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Threading;
namespace Core.Pages
{
    public class MarketingPage
    {
        #region
        IWebElement keepMeInfromedBTN => Driver.Browser.FindElement(By.XPath("//button[@name='opt-in']"));
        IWebElement skipBTN => Driver.Browser.FindElement(By.XPath("//span[normalize-space()='Skip']"));
        #endregion
        public void Accpet()
        {
            Driver.BrowserWait.WaitForPageLoad();
            keepMeInfromedBTN.ScrollTo().WaitForElementToBeClickable().Click();
            Thread.Sleep(2000);
        }
        public void skip()
        {
            Driver.BrowserWait.WaitForPageLoad();
            skipBTN.ScrollTo().WaitForElementToBeClickable().Click();
            Thread.Sleep(2000);
        }
    }
}