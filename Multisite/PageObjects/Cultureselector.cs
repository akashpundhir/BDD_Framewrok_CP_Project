using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace Multisite.PageObjects
{
    public class Cultureselector
    {
        #region
        string headingtext = "Based on your browser settings we have detected that you might be in United States. Please confirm or choose another country below.";
        IWebElement cultureModal = Driver.Browser.FindElement(By.CssSelector(".c-culture__wrapper.c-culture__country.c-culture__wrapper--active"));
        IWebElement heading = Driver.Browser.FindElement(By.XPath("//p[contains(text(),'Based on your browser settings we have detected th')]"));
        IWebElement closeBtn = Driver.Browser.FindElement(By.XPath("//div[@class='c-culture__wrapper c-culture__country c-culture__wrapper--active']//button[@class='c-culture__close']"));
        IWebElement lunguageDorpdown = Driver.Browser.FindElement(By.XPath("//select[@class='c-culture__select']"));
        IWebElement contniueBtn = Driver.Browser.FindElement(By.XPath("//button[normalize-space()='Continue']"));
        #endregion
        public void SelectLunguage()
        {
            try
            {
                Assert.AreEqual(heading, headingtext);
                closeBtn.WaitForElementToBeClickable().CustomClick();
                lunguageDorpdown.Click();
                SelectElement dropDown = new SelectElement(lunguageDorpdown);
                dropDown.SelectByValue("Australia EN");
            }
            catch
            {
                contniueBtn.WaitForElementToBeClickable().Click();
            }
/*commnet to delete*/
        }

    }
}
