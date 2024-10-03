using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
namespace Core.Pages
{
    public class PaymentPage
    {
        #region
        /*WebElement on Payment page*/
        IWebElement paymentEditBtn => Driver.Browser.FindElement(By.XPath("//a[@class='ds-button ds-button--link ds-button--md ds-button--padding-none']//span[@class='ds-text-label-md ds-text--medium'][normalize-space()='Edit']"));
        IWebElement OwnFunding => Driver.Browser.FindElement(By.XPath("//label[@for='0-fundingType']"));
        IWebElement saveChangesBtn => Driver.Browser.FindElement(By.XPath("//button[@data-testid='continue']"));
        IWebElement NDISRadiobtn => Driver.Browser.FindElement(By.XPath("//label[@for='1-fundingType']//span[@class='circle']"));
        IWebElement saveAndContinue => Driver.Browser.FindElement(By.XPath("//button[@class='continue-btn visible ds-button ds-button--primary ds-button--md']"));
        IWebElement headingNDIS => Driver.Browser.FindElement(By.XPath("//h2[normalize-space()='Payment method']"));
        IWebElement headingParticipant => Driver.Browser.FindElement(By.XPath("//h2[normalize-space()='NDIS participant']"));
        IWebElement NDIAManaged => Driver.Browser.FindElement(By.XPath("//label[@for='2-fundingOption']//span[@class='circle']"));
        IWebElement participantNameInputField => Driver.Browser.FindElement(By.XPath("//input[@name='ParticipantName']"));
        IWebElement participantNumber => Driver.Browser.FindElement(By.XPath("//input[@name='ParticipantNumber'][@type='text']"));
        IWebElement day => Driver.Browser.FindElement(By.Id("day"));
        IWebElement month => Driver.Browser.FindElement(By.Id("month"));
        IWebElement year => Driver.Browser.FindElement(By.Id("year"));
        IWebElement ndisNDIAmanaged => Driver.Browser.FindElement(By.XPath("//dd[contains(text(),'NDIS')]"));
        IWebElement removeBtn => Driver.Browser.FindElement(By.XPath("//button[@class='c-global-basket__remove-btn ds-icon-button ds-icon-button--ghost-neutral ds-icon-button--sm']/span"));
        IWebElement continueFundedBTN => Driver.Browser.FindElement(By.XPath("//button[@class='checkout-summary-continue-button ds-button ds-button--primary ds-button--md']"));
        /*Card Webelemnts*/
        IWebElement card => Driver.Browser.FindElement(By.XPath("//label[@for='new-card']"));
        IWebElement payCTA => Driver.Browser.FindElement(By.XPath("//button[@type='submit']"));
        IWebElement cardError => Driver.Browser.FindElement(By.XPath("//body/main[@id='app-mount']/div/div/div[@class='c-global-checkout__wrapper c-global-checkout__wrapper-narrow']/form[@class='c-global-checkout__card-layout']/div[@id='card-payment']/div[@class='c-payment-option__form']/div[1]/div[2]"));
        IWebElement cardNumber => Driver.Browser.FindElement(By.XPath("//span[@class='InputContainer']/input[@name='cardnumber']"));
        IWebElement cardNumberempty => Driver.Browser.FindElement(By.XPath("//span[@class='InputContainer']/input[@name='cardnumber']"));
        IWebElement cardExpiry => Driver.Browser.FindElement(By.XPath("//span[@class='InputContainer']/input[@name='exp-date']"));
        IWebElement cardCVC => Driver.Browser.FindElement(By.XPath("//span[@class='InputContainer']/input[@name='cvc']"));
        IWebElement payButton => Driver.Browser.FindElement(By.XPath("//button[@type='submit'][@class='e-button e-button--filled']"));
        /*SEPA Webelemnts*/
        IWebElement selectSEPARadioBTN => Driver.Browser.FindElement(By.XPath("//div[@class='c-payment-option']/label[@for='sepa']"));
        IWebElement accountName => Driver.Browser.FindElement(By.XPath("//div[@id='scrolltarget-firstName']/input[@name='DeliveryInformation.BillingAddress.FirstName']"));
        IWebElement ibantextfield => Driver.Browser.FindElement(By.XPath("//span[@class='InputContainer']/input[@name='iban']"));
        IWebElement payBtnFIN => Driver.Browser.FindElement(By.XPath("//button[@id='cardPaymentButton']"));


       /* Spain saved card webelements*/

        IWebElement selectCard => Driver.Browser.FindElement(By.XPath("//div[contains(@class, 'c-payment-option c-payment-option--saved')]"), 60).ScrollTo();

        #endregion
        /*Fill card details*/
        /*Method for French Contend website*/
        public void fillCarddetails()
        {
            card.Click();
            /*Specfic to french*/
            Driver.BrowserWait.WaitForPageLoad();
            Assert.Equals(payCTA.Text, "Ja, Ich bestätige meine Zahlung 59,70 €");
            var frames = Driver.Browser.FindElements(By.XPath("//iframe[contains(@name,'privateStripeFrame')]"));
            Driver.Browser.SwitchTo().Frame(frames[0]);
            cardNumber.SendKeys("4242424242424242");
            Driver.Browser.SwitchTo().DefaultContent();
            Driver.Browser.SwitchTo().Frame(frames[1]);
            cardExpiry.SendKeys("0536");
            Driver.Browser.SwitchTo().DefaultContent();
            Driver.Browser.SwitchTo().Frame(frames[2]);
            cardCVC.SendKeys("356");
            Thread.Sleep(2000);
            Driver.Browser.SwitchTo().DefaultContent();
            Console.WriteLine("Click pay button");
            payButton.Click();
            Console.WriteLine("Clicked pay button");
            Console.WriteLine("Fetch order number");
        }
        public void finalndCard()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(4000);
            var frames = Driver.Browser.FindElements(By.XPath("//iframe[contains(@name,'privateStripeFrame')]"));
            Driver.Browser.SwitchTo().Frame(frames[0]);
            cardNumber.SendKeys("4242424242424242");
            Driver.Browser.SwitchTo().DefaultContent();
            Driver.Browser.SwitchTo().Frame(frames[1]);
            cardExpiry.SendKeys("0536");
            Driver.Browser.SwitchTo().DefaultContent();
            Driver.Browser.SwitchTo().Frame(frames[2]);
            cardCVC.SendKeys("356");
            Thread.Sleep(2000);
            Driver.Browser.SwitchTo().DefaultContent();
            Console.WriteLine("Click pay button");
            payBtnFIN.ScrollTo().WaitForElementToBeClickable().Click();
            Thread.Sleep(2000);
        }
        public void SepaPaymentForDE()
        {
            Driver.BrowserWait.WaitForPageLoad();
            //iframe[@title='Sicherer Eingaberahmen für IBAN']
            selectSEPARadioBTN.ScrollTo().WaitForElementToBeClickable().Click();
            accountName.ScrollTo().WaitForElementToBeClickable().Click();
            accountName.SendKeys(ConfigurationManager.AppSettings.Get("sepaAccountName"));
            var frames = Driver.Browser.FindElements(By.XPath("//iframe[contains(@name,'privateStripeFrame')]"));
            Console.WriteLine("Total number of iframes are " + frames.Count);
            if (frames.Count > 0)
                Driver.Browser.SwitchTo().Frame(frames[3]);
            ibantextfield.SendKeys(ConfigurationManager.AppSettings.Get("IBEN"));
            Driver.Browser.SwitchTo().DefaultContent();
            Thread.Sleep(4000);
            payCTA.ScrollTo().WaitForElementToBeClickable().Click();
            Thread.Sleep(6000);
        }
        public void spanCard()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(5000);
            selectCard.ScrollTo().WaitForElementToBeClickable().Click();
            payBtnFIN.ScrollTo().WaitForElementToBeClickable().Click();
            Thread.Sleep(3000);
        }
    }
}
