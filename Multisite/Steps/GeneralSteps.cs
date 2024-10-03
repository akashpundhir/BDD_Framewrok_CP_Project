using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Configuration;
using Reqnroll;
using System;
namespace Multisite.Steps
{
    [Binding]
    public class GeneralSteps
    {
        private ScenarioContext _context;
        public GeneralSteps(ScenarioContext context)
        {
            _context = context;
        }
        [Given(@"Multisite site is opened")]
        [Then(@"Multisite site is opened")]
        public void GivenMultisiteSiteIsOpened()
        {
            Driver.Navigate(ConfigurationManager.AppSettings.Get("url"));
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//a[@href='/' and (@class='c-nav-logo__link')]"), 30).Displayed);
            Assert.IsTrue(Driver.Browser.Title != null && Driver.Browser.Title.CaseInsensitiveEquals("Products"));
            try
            {
                Driver.Browser.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"), 10).
                    WaitForElementToBeClickable().Click();
                Driver.BrowserWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.
                    Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll")));
               /* Driver.Browser.FindElement(By.XPath("//div[@class='c-culture__wrapper c-culture__country c-culture__wrapper--active']//button[@class='c-culture__close']"), 10)
                    .WaitForElementToBeClickable().Click();*/
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
            /*Cookie cname = new Cookie("TrackingTest", $"{_context.ScenarioInfo.Title}");
            Driver.Browser.Manage().Cookies.AddCookie(cname);*/
        }
        [Given(@"Spain Multisite site is opened")]
        public void GivenSpainMultisiteSiteIsOpened()
        {
            Driver.Navigate(ConfigurationManager.AppSettings.Get("SpainURL"));
        }
    }
}