using Core.Drivers;
using EmailWrapper;
using OpenQA.Selenium;
using System.Configuration;
using Reqnroll;

namespace CareConnect.Steps
{
    [Binding]
    public class GeneralSteps
    {
        private FeatureContext _featureContext;

        public GeneralSteps(FeatureContext featureContext)
        {
            _featureContext = featureContext;
        }


        [Given(@"Careconnect site is opened")]
        public void GivenCareconnectSiteIsOpened()
        {
            Driver.Navigate(ConfigurationManager.AppSettings.Get("url"));

            if(_featureContext.FeatureInfo.Title.CaseInsensitiveContains("ICEnrollment"))
            {
                var wrapper = new MessageWrapper();
                wrapper.DeleteMailsBySubject("Coloplast Care Enrollment form");
                wrapper.DeleteMailsBySubject("Completed: Coloplast Care Enrollment form");
            }
        }

        [Given(@"User is signed in")]
        public void GivenUserIsSignedIn()
        {
            Driver.Navigate(ConfigurationManager.AppSettings.Get("loginUrl"));
            Driver.Browser
                .FindElement(By.XPath("//div[@class='c-nav-call-to-action']//a[contains(@href, 'b2clogin')]"), 30)
                .ScrollTo()
                .Click();
            Driver.Browser
                .FindElement(By.Id("email"), 30)
                .WaitForElementToBeClickable()
                .SendKeys(ConfigurationManager.AppSettings.Get("login"));
            Driver.Browser
                .FindElement(By.Id("password"), 30)
                .SendKeys(ConfigurationManager.AppSettings.Get("password"));
            Driver.Browser
                .FindElement(By.Id("next"), 30)
                .Click();

/*
            //try
            //{
            //    Driver.Browser
            //        .FindElement(By.Id("email_option"), 10)
            //        .WaitForElementToBeClickable()
            //        .Click();
            //    Driver.Browser
            //        .FindElement(By.Id("continue"), 10)
            //        .Click();
            //    Driver.Browser
            //        .FindElement(By.Id("readOnlyEmail_ver_but_send"), 10)
            //        .WaitForElementToBeClickable()
            //        .Click();
            //    var wrapper = new MessageWrapper();
            //    wrapper.DeleteMails("coloplast.test.signup@outlook.com");

            //    var messages = wrapper.GetB2CEmails("coloplast.test.signup@outlook.com", "account email verification code");
            //    var code = wrapper.GetCodeFromEmail(messages);

            //    Driver.Browser
            //        .FindElement(By.Id("readOnlyEmail_ver_input"), 10)
            //        .WaitForElementToBeClickable()
            //        .SendKeys(code);
            //    Driver.Browser
            //        .FindElement(By.Id("readOnlyEmail_ver_but_verify"), 10)
            //        .Click();
            //    Thread.Sleep(5000);
            //    Driver.Browser
            //        .FindElement(By.Id("continue"), 10)
            //        .Click();
            //}
            //catch
            //{
            //}


            //try
            //{
            //    Driver.Browser
            //        .FindElement(By.Id("spinner-overlay"), 10);
            //}
            //catch
            //{
            //}
            Driver.BrowserWait.WaitForPageLoad();

            Driver.Browser.FindElement(By.XPath("//button[contains(.,'Complete profile')]"),30).Click();

            Thread.Sleep(3000);

            Driver.Navigate(ConfigurationManager.AppSettings.Get("url"));
*/
        }
    }
}
