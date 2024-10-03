using Core.Drivers;
using EmailWrapper;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using Reqnroll;

namespace Charter.Steps
{
    [Binding]
    public class NPRSteps
    {
        [When(@"I fill prescription information")]
        public void WhenIFillPrescriptionInformation()
        {
            Thread.Sleep(1000);
            var month = Driver.Browser.FindElement(By.Id("month"), 10);
            month.Click();
            month.SendKeys("01");

            var day = Driver.Browser.FindElement(By.Id("day"), 10);
            day.SendKeys("01");

            var year = Driver.Browser.FindElement(By.Id("year"), 10);
            year.SendKeys("1970");


            //old design of DOB field
            //Thread.Sleep(1000);
            //var dob = Driver.Browser.FindElement(By.Id("dateOfBirth"), 30);
            //dob.Click();
            //dob.SendKeys("01011970");

            Thread.Sleep(1000);
            var exempt = Driver.Browser.FindElement(By.XPath("//select[@data-testid='select-exemptStatus']"), 10);
            exempt.Click();
            //exempt.FindElement(By.XPath("//option[@value = 'Prescription Prepayment Certificate']"), 10).WaitForElementToBeClickable().Click();
            exempt.SendKeys(Keys.Down);
            exempt.SendKeys(Keys.Enter);

            Thread.Sleep(1000);
            var nhsNumber = Driver.Browser.FindElement(By.Name("ReimbursementInformation.NhsNumber."),10);
            nhsNumber.SendKeys(NhsNoGenerator());

            Thread.Sleep(1000);
            var gpPractice = Driver.Browser.FindElement(By.XPath("//input[@data-testid='autoSuggestInput']"), 10);
            gpPractice.Click();
            gpPractice.SendKeys("I c");
            Thread.Sleep(1000);
            gpPractice.SendKeys("an");
            Thread.Sleep(1000);
            gpPractice.SendKeys("not");
            Thread.Sleep(1000);
            
            Driver.Browser.FindElement(By.XPath("//address[contains(.,'I cannot find')]"), 50).CustomClick(); 
        }

        [When(@"I click accept and continue")]
        public void WhenIClickAcceptAndContinue()
        {
            Driver.Browser.FindElement(By.XPath("//span[contains(.,'Accept and continue')]"), 30).CustomClick();
            Thread.Sleep(2000);
        }

        [When(@"I click Skip")]
        public void WhenIClickSkip()
        {
            Driver.Browser.FindElement(By.Name("opt-out"), 10).CustomClick();
            Thread.Sleep(2000);
        }

        [When(@"I click cancel")]
        public void WhenIClickCancel()
        {
            Driver.Browser.FindElement(By.XPath("//span[contains(.,'Cancel request')]"), 30).CustomClick();
        }

        [Then(@"I see Order Consent Page")]
        public void ThenISeeOrderConsentPage()
        {
            Thread.Sleep(5000);
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//span[contains(.,'Accept and continue')]"), 30).Displayed);
            Assert.IsTrue(Driver.Browser.Title.Equals("Order Consent Page"));
        }

        [Then(@"I see Reimbursment page")]
        public void ThenISeeReimburmentPage()
        {
            Thread.Sleep(12000);
            var baskeItems = Driver.Browser.FindElement(By.XPath("//li[@data-testid='basketLineItem']"), 30);
            Assert.IsTrue(baskeItems.Displayed);
            Assert.IsTrue(Driver.Browser.Title.Equals("Reimbursement page"));
        }

        [Then(@"I see Delivery detail page")]
        public void ThenISeeDeliveryDetailPage()
        {
            Thread.Sleep(1000);
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//li[@data-testid='basketLineItem']"), 30).Displayed);
            Assert.IsTrue(Driver.Browser.Title.Equals("Delivery page"));
        }

        [Then(@"I see Marketing permission page")]
        public void ThenISeeMarketingPermissionPage()
        {
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//strong[contains(.,'Would you like to stay informed?')]"), 30).Displayed);
            Assert.IsTrue(Driver.Browser.Title.Equals("Marketing permission"));
        }

        [Then(@"Sample of {string} is added to the basket")]
        public void ThenSampleIsAddedToTheBasket(string product)
        {
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//span[contains(.,'1 sample pack')]"), 30).Displayed);
        }

        [Then(@"I can see modal 'Account created'")]
        public void ThenICanSeeModalAccountCreated()
        {
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//h2[contains(.,'Account created')]"), 30).Displayed);
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//button[contains(.,'Go to basket')]"), 30).Displayed);

            Driver.Browser.FindElement(By.XPath("//button[contains(.,'Go to basket')]"), 30).Click();
        }

        private string NhsNoGenerator()
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < 10; i++)
            {
                var digit = rnd.Next(0, 9);
                sb.Append(digit);
            }
            return sb.ToString();
        }
    }
}
