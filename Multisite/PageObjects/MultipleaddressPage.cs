using Core.Drivers;
using Core.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Configuration;
using System.Threading;
using System.Xml.Linq;
namespace Multisite.PageObjects
{
    internal class MultipleaddressPage
    {
        FlyOutBasket flyOutBasket;
        public MultipleaddressPage()
        {
            flyOutBasket = new FlyOutBasket();
        }
        string h1text = "Add alternative address";
        string myAccount = "My Account";
        string deliveryTxt = "Delivery info";
        private int optionIndex;

        /*List of Web elements on the page */
        #region
        IWebElement myaccountMenu => Driver.Browser.FindElement(By.XPath("//a[@class='ds-button ds-button--primary ds-button--md ']"));
        IWebElement myAccountHeading => Driver.Browser.FindElement(By.XPath("//div[@class='c-profile__menu']//div[text()='My Account']"));
        IWebElement deliveryInfo => Driver.Browser.FindElement(By.XPath("//a[@title='Delivery info']"));
        IWebElement deliveryInfoPageHeading => Driver.Browser.FindElement(By.XPath("//h1[normalize-space()='Edit or change delivery details']"));
        IWebElement editPrimaryAddress => Driver.Browser.FindElement(By.XPath("//span[@class='ds-text-label-lg ds-text--medium'][contains(.,'Edit primary address')]"));
        IWebElement addAnotherAddress => Driver.Browser.FindElement(By.XPath("//button[contains(.,'Add another address')]"));
        //button[normalize-space()='Add another address'] //button[@class='box new-address-button']//span[@data-icon-name='add']
        IWebElement eidt1AlternativeAddress => Driver.Browser.FindElement(By.XPath("//button[@class='address-edit-button ds-button ds-button--link ds-button--lg ds-button--padding-none'][@data-testid='edit-mailingAddress']"));
        IWebElement deleteLastAddress => Driver.Browser.FindElement(By.XPath("//button[@class='address-edit-button ds-button ds-button--link ds-button--lg ds-button--padding-none'][@data-testid='edit-otherAddress']"));
        IWebElement verifyH1Text => Driver.Browser.FindElement(By.XPath("//h1[normalize-space()='Add alternative address']"));
        IWebElement firstName => Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.FirstName']"));
        IWebElement lastName => Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.LastName']"));
        IWebElement countryCode => Driver.Browser.FindElement(By.XPath("//div[@class='c-global-checkout__form-section']//input[@name='DeliveryInformation.BillingAddress.InternationalCallingCode']"));
        IWebElement phoneNumber => Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.PhoneNumber']"));
        IWebElement addressLine1 => Driver.Browser.FindElement(By.XPath("//div[@id='scrolltarget-addressLine1']//input[contains(@name,'DeliveryInformation.BillingAddress.AddressLine1')]"));
        IWebElement addressLine2 => Driver.Browser.FindElement(By.XPath("//div[@id='scrolltarget-addressLine2']//input[contains(@name,'DeliveryInformation.BillingAddress.AddressLine2')]"));
        IWebElement postalCode => Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.PostalCode']"));
        IWebElement city => Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.City']"));
        IWebElement statedropdown => Driver.Browser.FindElement(By.XPath("//select[@class='formkit-input'][@data-field-name='state']"));
        //button[@id='dropdown-button']
        IWebElement submitBtn => Driver.Browser.FindElement(By.XPath("//button[@type='submit']")); //c-btn__disable-on-loading ds-button ds-button--primary ds-button--lg
        IWebElement closeBtn => Driver.Browser.FindElement(By.XPath("//div[@class='save-button']//button[contains(.,'Close')]"));
        IWebElement deletebtn => Driver.Browser.FindElement(By.XPath("//button[@class='ds-button ds-button--ghost ds-button--md']"));
        IWebElement backBtn => Driver.Browser.FindElement(By.XPath("//button[@aria-label='back button']"));
        IWebElement state => Driver.Browser.FindElement(By.XPath("//option[contains(.,'Victoria')]"));
        IWebElement country => Driver.Browser.FindElement(By.XPath("//label[normalize-space()='Country']"));
        IWebElement adressbox => Driver.Browser.FindElement(By.XPath("//main[@id='app-mount']//address[1]"));
        /*Order Sumamry page Edit button*/
        IWebElement editBtn => Driver.Browser.FindElement(By.XPath("//button[@class='edit-button ds-button ds-button--link ds-button--md ds-button--padding-none']//span[@class='ds-text-label-md ds-text--medium'][normalize-space()='Edit']"));
        IWebElement continuePaymentBTN => Driver.Browser.FindElement(By.XPath("//div[@class='checkout-summary-container--desktop']//div//div//button[@type='button']"));
        #endregion
        #region
        /*Clear the text filed value*/
        public void clearTextField(IWebElement webElement)
        {
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].scrollIntoView();", webElement);
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].value = '';", webElement);
            /* var inputText = webElement.GetAttributeValue();
             if (inputText != null)
             {
                 for (int i = 0; i < inputText.Length; i++)
                 {
                     webElement.SendKeys(Keys.Backspace);
                 }*//*
             }*/
        }
        #endregion
        public void scrol(IWebElement elementName)
        {
            Actions actions = new Actions(Driver.Browser);
            actions.MoveToElement(elementName);
            actions.Perform();
        }

        public void dropdown(IWebElement element, string value)
        {
            SelectElement dropDown = new SelectElement(element);
            dropDown.SelectByValue(value);

        }
        public void selectDeliveryInfoPage()
        {
            Driver.BrowserWait.WaitForPageLoad();
            myaccountMenu.ScrollTo().WaitForElementToBeClickable().CustomClick();
            Assert.AreEqual(myAccount, myAccountHeading.Text);
            Console.WriteLine("Nvaigate to  " + myAccountHeading.Text + " page");
            Assert.AreEqual(deliveryTxt, deliveryInfo.Text);
            Thread.Sleep(2000);
            deliveryInfo.Click();
        }
        /* Edit-update primary address details*/
        public void updatePrimaryAddress()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Console.WriteLine("Now Updating primary address details");
            Thread.Sleep(6000);
            editPrimaryAddress.Click();
            clearTextField(phoneNumber);
            phoneNumber.SendKeys(ConfigurationManager.AppSettings.Get("uk-phone"));
            clearTextField(addressLine1);
            addressLine1.SendKeys("Update by Automation line 1 ");
            clearTextField(addressLine2);
            addressLine2.SendKeys("Update by Automation line 1 2");
            Thread.Sleep(2000);
            submitBtn.ScrollTo().WaitForElementToBeClickable().CustomClick();
            Console.WriteLine("waiting for page load");
            Thread.Sleep(5000);
        }
        /* Add Another address details*/
        public void addAlternativeAddress()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(9000);
            addAnotherAddress.ScrollTo().WaitForElementToBeClickable().Click();
            Console.WriteLine("add another address displayed");
            Assert.AreEqual(h1text, verifyH1Text.Text);
            clearTextField(phoneNumber);
            phoneNumber.SendKeys(ConfigurationManager.AppSettings.Get("aus-phone"));
            clearTextField(addressLine1);
            addressLine1.SendKeys("Address2 by Automation line 1 ");
            clearTextField(postalCode);
            postalCode.SendKeys("22222");
            clearTextField(city);
            city.SendKeys("Sydny");
            Thread.Sleep(2000);
            dropdown(statedropdown, "Victoria");
            Actions actions = new Actions(Driver.Browser);
            for (int i = 0; i <= optionIndex; i++)
            {
                actions.SendKeys(Keys.Down);
            }
            actions.SendKeys(Keys.Enter);
            actions.Build();
            actions.Perform();

            /*Actions action = new Actions(Driver.Browser);
            action.MoveToElement(submitBtn).Click().Perform();
           submitBtn.ScrollTo().WaitForElementToBeClickable().Click();*/
            Thread.Sleep(4000);

            try
            {
                submitBtn.ScrollTo().WaitForElementToBeClickable().Click();
            }
            catch
            {

            }
            Thread.Sleep(8000);
        }
        /* Update Another address details*/
        public void updateAlternativeAddress()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(6000);
            scrol(eidt1AlternativeAddress);
            eidt1AlternativeAddress.ScrollTo().WaitForElementToBeClickable().CustomClick();
            Thread.Sleep(4000);
            clearTextField(addressLine1);
            addressLine1.SendKeys("Edit alternate tound 2 ");
            clearTextField(postalCode);
            postalCode.SendKeys("22222");
            clearTextField(city);
            city.SendKeys("Aarhus");
            submitBtn.ScrollTo().WaitForElementToBeClickable().CustomClick();
            Thread.Sleep(8000);
        }
        /* Add last alternative address details*/
        public void lastAlternativeAddress()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(9000);
            addAnotherAddress.ScrollTo().WaitForElementToBeClickable().Click();
            clearTextField(phoneNumber);
            phoneNumber.SendKeys(ConfigurationManager.AppSettings.Get("aus-phone"));
            clearTextField(addressLine1);
            addressLine1.SendKeys("last address by Automation ");
            clearTextField(postalCode);
            postalCode.SendKeys("33333");
            clearTextField(city);
            city.SendKeys("COLOPLAST");
            dropdown(statedropdown, "Victoria");
            Actions actions = new Actions(Driver.Browser);
            for (int i = 0; i <= optionIndex; i++)
            {
                actions.SendKeys(Keys.Down);
            }
            actions.SendKeys(Keys.Enter);
            actions.Build();
            actions.Perform();
            Thread.Sleep(4000);

            try
            {
                submitBtn.ScrollTo().WaitForElementToBeClickable().Click();
            }
            catch
            {

            }
            Thread.Sleep(8000);
        }
        /* Delete 1st last alternative address details*/
        public void delete1stadditinalAddress()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(4000);
            eidt1AlternativeAddress.ScrollTo().WaitForElementToBeClickable().Click();
            deletebtn.ScrollTo().WaitForElementToBeClickable().Click();
            Thread.Sleep(8000);
        }
        /* Delete  last alternative address details*/
        public void deleteLastadditinalAddress()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(4000);
            deleteLastAddress.ScrollTo().WaitForElementToBeClickable().Click();
            Thread.Sleep(4000);
            deletebtn.ScrollTo().WaitForElementToBeClickable().Click();
            Thread.Sleep(5000);
            Driver.BrowserWait.WaitForPageLoad();
            closeBtn.ScrollTo().WaitForElementToBeClickable().Click();
            Thread.Sleep(6000);
        }
        public void updateAddressOnSummarypage()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Assert.AreEqual(Driver.Browser.Title, ConfigurationManager.AppSettings.Get("OStitle"));
            Thread.Sleep(5000);
            editBtn.ScrollTo().WaitForElementToBeClickable().CustomClick();
            Console.WriteLine("Now Updating primary address details");
            Thread.Sleep(5000);
            editPrimaryAddress.Click();
            clearTextField(firstName);
            firstName.SendKeys(ConfigurationManager.AppSettings.Get("fname"));
            clearTextField(lastName);
            lastName.SendKeys(ConfigurationManager.AppSettings.Get("lname"));
            clearTextField(addressLine2);
            addressLine2.SendKeys("Update by summary page flow");
            Thread.Sleep(2000);
            submitBtn.ScrollTo().WaitForElementToBeClickable().CustomClick();
            Console.WriteLine("waiting for page load to complete");
            Thread.Sleep(5000);
            //desktopCheckout.FindElement(By.XPath("//button[contains(., 'Continue to payment')]"), 10).ScrollTo().Click();
        }
    }
}
