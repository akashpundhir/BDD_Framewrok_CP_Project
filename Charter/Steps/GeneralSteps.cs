using Core.Drivers;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Configuration;
using Reqnroll;

namespace Charter.Steps
{
    [Binding]
    public class GeneralSteps
    {
        private ScenarioContext _context;

        public GeneralSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"Charter site is opened")]
        [Then(@"Charter site is opened")]
        public void GivenMultisiteSiteIsOpened()
        {
            Driver.Navigate(ConfigurationManager.AppSettings.Get("url"));

            try
            {
                Driver.Browser.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"), 10).
                    WaitForElementToBeClickable().Click();

                Driver.BrowserWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.
                    Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll")));

            }
            catch
            {
            }

            Cookie cname = new Cookie("TrackingTest", $"{_context.ScenarioInfo.Title}");
            Driver.Browser.Manage().Cookies.AddCookie(cname);
        }
    }
}
