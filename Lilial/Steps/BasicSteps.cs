using Core.Drivers;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Configuration;
using Reqnroll;
using Lilial.PageObjects.B2CLogin;

namespace Lilial.Steps
{
    [Binding]
    public class BasicSteps
    {
        [Given(@"Lilial site is opened")]
        [Then(@"Lilial site is opened")]

        public void GivenLilialSiteIsOpened()
        {
            //Driver.Navigate("https://test-lilial.coloplast.com/");
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
        }

        [When(@"I press login button")]
        public void WhenIPressLoginButton()
        {
            Driver.Browser.FindElement(By.XPath("//a[@data-flow-name = 'SignIn' and @title= 'Connectez-vous']"), 60).WaitForElementToBeClickable().Click();
        }

        [When(@"I enter email for account {string} cutting template")]
        public void WhenIEnterEmail(string arg)
        {
            var b2c = new LoginPage();
            if (arg.Equals("without"))
            {
                b2c.Email.WaitForElementToBeClickable().SendKeys("lilialuser1@yopmail.com");
                //b2c.Email.WaitForElementToBeClickable().SendKeys(ConfigurationManager.AppSettings.Get("login"));
            }
            else if (arg.Equals("with"))
            {
                b2c.Email.WaitForElementToBeClickable().SendKeys("lilialuserwithTemplate@yopmail.com");
                //b2c.Email.WaitForElementToBeClickable().SendKeys(ConfigurationManager.AppSettings.Get("loginCS"));

            }
        }

        [When(@"I press log in button")]
        public void WhenIPressLogInButton()
        {
            var b2c = new LoginPage();
            b2c.LoginBtn.Click();
        }

        [When(@"I enter password")]
        public void WhenIEnterPassword()
        {
            var b2c = new LoginPage();
            b2c.Password.WaitForElementToBeClickable().SendKeys("Welcome@01");
            //b2c.Password.WaitForElementToBeClickable().SendKeys(ConfigurationManager.AppSettings.Get("password"));
        }

        [Then(@"I successfully logged in")]
        public void ThenISuccessfullyLoggedIn()
        {
            //Driver.BrowserWait.Until(drv => drv.Url.CaseInsensitiveContains(ConfigurationManager.AppSettings.Get("url")));
            Driver.BrowserWait.Until(drv => drv.Url.CaseInsensitiveContains("https://test-lilial.coloplast.com/my-account/"));

           Driver.BrowserWait.WaitForPageLoad();

            Assert.IsTrue(Driver.Browser.Title != null &&
                Driver.Browser.Title.CaseInsensitiveEquals("My Account") ||
                Driver.Browser.Title.CaseInsensitiveEquals("Charter") ||
                Driver.Browser.Title.CaseInsensitiveContains("Multisite") ||
                Driver.Browser.Title.CaseInsensitiveContains("Lilial"));
        }

        [Then(@"Main page is opened")]
        public void ThenMainPageIsOpened()
        {
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//a[@href='/' and (@class='c-nav-logo__link')]"), 60).Displayed);
            Assert.IsTrue(Driver.Browser.Title != null && Driver.Browser.Title.CaseInsensitiveEquals("Lilial"));
        }
    }
}
