using Core.Drivers;
using Multisite.PageObjects;
using Multisite.PageObjects.B2CLogin;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using Reqnroll;
namespace Multisite.Steps
{
    [Binding]
    public class BasicSteps
    {
        MultipleaddressPage multipleaddressPage;
        public BasicSteps()
        {
            multipleaddressPage = new MultipleaddressPage();
        }
        [Then(@"Main page is opened")]
        public void ThenMainPageIsOpened()
        {
           Assert.IsTrue(Driver.Browser.Title != null && Driver.Browser.Title.CaseInsensitiveEquals("Products"));
        }
        [When(@"I press login button")]
        public void WhenIPressLoginButton()
        {
            Driver.Browser.FindElement(By.XPath("//a[@title='Login']")).WaitForElementToBeClickable().Click();
        }
        [When(@"I enter email")]
        public void WhenIEnterEmail()
        {
            var b2c = new LoginPage();
            b2c.Email.WaitForElementToBeClickable().SendKeys(ConfigurationManager.AppSettings.Get("login"));
        }
        [When(@"I enter password")]
        public void WhenIEnterPassword()
        {
            var b2c = new LoginPage();
            b2c.Password.WaitForElementToBeClickable().SendKeys(ConfigurationManager.AppSettings.Get("password"));
        }
        [When(@"I press log in button")]
        public void WhenIPressLogInButton()
        {
            var b2c = new LoginPage();
            b2c.LoginBtn.Click();
        }
        [Then(@"I successfully logged in")]
        public void ThenISuccessfullyLoggedIn()
        {
            Driver.BrowserWait.Until(drv => drv.Url.CaseInsensitiveContains(ConfigurationManager.AppSettings.Get("url")));
            Driver.BrowserWait.WaitForPageLoad();
            Assert.IsTrue(Driver.Browser.Title != null &&
                Driver.Browser.Title.CaseInsensitiveEquals("My Account") ||
                Driver.Browser.Title.CaseInsensitiveContains("Products"));
        }
        [Then(@"the user Update primary address details")]
        public void ThenTheUserUpdatePrimaryAddressDetails()
        {
            multipleaddressPage.selectDeliveryInfoPage();
            multipleaddressPage.updatePrimaryAddress();
            Console.WriteLine("Primary address is update");
        }
        [Then(@"the user Add alternative address details")]
        public void ThenTheUserAddAlternativeAddressDetails()
        {
          multipleaddressPage.addAlternativeAddress();
        }
        [Then(@"the user Update alternative address")]
        public void ThenTheUserUpdateAlternativeAddress()
        {
            multipleaddressPage.updateAlternativeAddress();
        }
        [Then(@"the user Add Last alternative address details")]
        public void ThenTheUserAddLastAlternativeAddressDetails()
        {
            multipleaddressPage.lastAlternativeAddress();
        }
        [Then(@"the user Delete alternative address")]
        public void ThenTheUserDeleteAlternativeAddress()
        {
            multipleaddressPage.delete1stadditinalAddress();
        }
        [Then(@"the changes are saved and page deliveryinfo page refresh")]
        public void ThenTheChangesAreSavedAndPageDeliveryinfoPageRefresh()
        {
            multipleaddressPage.deleteLastadditinalAddress();
        }
    }
}
