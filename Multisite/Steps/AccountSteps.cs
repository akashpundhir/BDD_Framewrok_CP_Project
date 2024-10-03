using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;
using Reqnroll;

namespace Multisite.Steps
{
    [Binding]
    public class AccountSteps
    {
        [Then(@"Funding info is correctly saved")]
        public void ThenFundingInfoIsCorrectlySaved()
        {
            Driver.Browser.FindElement(By.Id("my-welcome-banner-block"), 120);

            Driver.Browser.FindElement(By.XPath("//a[@title='Funding']"), 60).WaitForElementToBeClickable().Click();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(Driver.Browser.FindElement(By.Id("1-funding"), 60).Selected);
                Assert.IsTrue(Driver.Browser.FindElement(By.Id("ndis-funding-ndia"), 60).Selected);
                Assert.IsTrue(Driver.Browser.FindElement(By.
                    XPath("//input[@name='ParticipantName']"), 60).GetAttribute("value").Contains("TEST"));
                Assert.IsTrue(Driver.Browser.FindElement(By.
                    XPath("//input[@name='ParticipantName']"), 60).GetAttribute("value").Contains("TESTER"));
                Assert.IsTrue(Driver.Browser.FindElement(By.
                    XPath("//input[@name='ParticipantNumber']"), 60).GetAttribute("value").Contains(Helper.ndis));
            });
        }

        [Then(@"I change NDIS number")]
        public void ThenIChangeNDISNumber()
        {
            Driver.Browser.FindElement(By.XPath("//a[@title='Funding']"), 60).WaitForElementToBeClickable().Click();

            var orderaproduct = new OrderAProductSteps();
            orderaproduct.WhenIFillNDISParticipantNumber();

            Driver.Browser.FindElement(By.XPath("//button[@type='submit']")).ScrollTo().Click();
            Driver.BrowserWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("spinner-overlay")));
            Driver.Browser.FindElement(By.XPath("//a[@role='back-button']")).ScrollTo().WaitForElementToBeClickable().Click();
        }

        [Then(@"Ordered product is shown on Profile page")]
        public void ThenOrderedProductIsShownOnProfilePage()
        {
            Driver.Browser.FindElement(By.XPath("//a[@title='My Products']"), 60).WaitForElementToBeClickable().Click();

            Assert.IsTrue(Driver.Browser.FindElement(By.
                XPath("//ul[@class='c-profile__orders-list']/li//a[@class='c-profile__order-item-name']"), 20).
                Text.Contains("SpeediCath® Compact Set Female"));
        }

        [Then(@"Profile is saved")]
        public void ThenProfileIsSaved()
        {
            try
            {
                Driver.Browser.FindElement(By.Id("my-welcome-banner-block"), 120);
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException("Profile was not saved within 2 minutes. Something went wrong.");
            }

            Driver.Browser.FindElement(By.XPath("//a[@title='Profile']"), 60).WaitForElementToBeClickable().Click();

            Assert.Multiple(() =>
            {
                try
                {
                    Driver.Browser.FindElement(By.XPath("//button[@data-testid='edit-shippingAddress']"), 10).Click();
                }
                catch
                {
                }

                Assert.AreEqual("TEST", Driver.Browser.FindElement(By.
                    XPath("//input[@data-field-name='firstName']"), 10).GetAttribute("value"));
                Assert.AreEqual("TESTER", Driver.Browser.FindElement(By.
                    XPath("//input[@data-field-name='lastName']"), 5).GetAttribute("value"));                
                Assert.AreEqual("7 Shea St", Driver.Browser.FindElement(By.
                    XPath("//input[@data-field-name='addressLine1']"), 5).GetAttribute("value"));
                Assert.AreEqual("2606", Driver.Browser.FindElement(By.
                    XPath("//input[@data-field-name='postalCode']"), 5).GetAttribute("value"));
                Assert.AreEqual("Phillip", Driver.Browser.FindElement(By.
                    XPath("//input[@data-field-name='city']"), 5).GetAttribute("value"));
                try
                {
                    Assert.AreEqual("34123", Driver.Browser.FindElement(By.
                    XPath("//input[@data-field-name='personalId']"), 5).GetAttribute("value"));
                }
                catch
                {
                }
            });
        }
    }
}
