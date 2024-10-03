using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using System.Numerics;
using System.Threading;
namespace Core.Pages
{
    public class DeliveryInfoPage
    {
        OrderSummary orderSummary;
        private int optionIndex;
        public DeliveryInfoPage()
        {
            orderSummary = new OrderSummary();
        }
        /*Page elements and error list*/
        #region
        IWebElement firstName => Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.FirstName']"));
        IWebElement firstNameError => Driver.Browser.FindElement(By.XPath("//span[normalize-space()='Dein Vorname ist ein Pflichtfeld']"));
        IWebElement lastName => Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.LastName']"));
        IWebElement lastNameError => Driver.Browser.FindElement(By.XPath("//span[normalize-space()='Bitte gib deinen Nachnamen ein']"));
        IWebElement email => Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.Email']"));
        IWebElement emailError => Driver.Browser.FindElement(By.XPath("//span[normalize-space()='Bitte gib deine E-Mail Adresse ein']"));
        IWebElement phone => Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.PhoneNumber']"));
        IWebElement phoneError => Driver.Browser.FindElement(By.XPath("//span[normalize-space()='Bitte gib deine Telefonnummer ein']"));
        IWebElement addressLine1 => Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.AddressLine1']"));
        IWebElement addressLine1Error => Driver.Browser.FindElement(By.XPath("//div[@id='error_75e74fc6-b607-4e76-9ba0-13598de4fa86']"));
        IWebElement addressLine2 => Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.AddressLine2']"));
        IWebElement postalCode => Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.PostalCode']"));
        IWebElement postalCodeError => Driver.Browser.FindElement(By.XPath("//div[@id='error_8b5c0c4d-db6f-4885-8098-bc01c9e6bb76']"));
        IWebElement city => Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.City']"));
        IWebElement cityError => Driver.Browser.FindElement(By.XPath("//div[@id='error_0468055e-5345-494e-b848-5c47e769de42']"));
        IWebElement deliveryTC => Driver.Browser.FindElement(By.XPath("//span[normalize-space()='Ich stimme den']"));
        IWebElement deliveryTCLabel => Driver.Browser.FindElement(By.XPath("//label[@for='termsAndCondition']"));
        IWebElement deliveryScroll => Driver.Browser.FindElement(By.XPath("//div[@id='scrolltarget-termsAndCondition']"));
        IWebElement continueCTA => Driver.Browser.FindElement(By.XPath("//button[@class='e-button e-button--filled']"));
        IWebElement deContinueBTN => Driver.Browser.FindElement(By.XPath("//button[@type='submit'][@class='ds-button ds-button--primary ds-button--lg']"));
        IWebElement Bayernoption => Driver.Browser.FindElement(By.XPath("//li[normalize-space()='Bayern']"));
        IWebElement dropdownAU => Driver.Browser.FindElement(By.Id("dropdown-button"));
        IWebElement victoria => Driver.Browser.FindElement(By.XPath("//li[@id='Victoria']"));
        IWebElement simpleConsentChoice => Driver.Browser.FindElement(By.XPath("//label[@for='simpleConsentChoice']"));
        /*Finland WebElemnts*/
        IWebElement consentChoiceFI => Driver.Browser.FindElement(By.XPath("//label[@for='consentChoice']"));
        IWebElement continueBTNFI => Driver.Browser.FindElement(By.XPath("//button[contains(., 'Tallenna ja jatka') or contains(.,'continue')]"));
        IWebElement continueBTNAU => Driver.Browser.FindElement(By.XPath("//button[contains(., 'Save and continue') or contains(.,'continue')]"));
        /*South Africa WebElemnts*/
        IWebElement idnumberSF => Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.PersonalId']"));
        IWebElement dropDown => Driver.Browser.FindElement(By.XPath("//button[@class='c-global-checkout__form-section  field-state dropdown__toggle errorState c-global-checkout__form-section  field-state'][@type='button']"));
        /*Spain WebElemnts*/
        IWebElement Almeria => Driver.Browser.FindElement(By.XPath("//li[@id='Almería']"));
        IWebElement LasPalmas => Driver.Browser.FindElement(By.XPath("//li[@id='Las Palmas']"));
        IWebElement continueBTNSpain => Driver.Browser.FindElement(By.XPath("//button[contains(., 'Guardar y continuar') or contains(.,'continuar')]"));
        IWebElement statedropdown => Driver.Browser.FindElement(By.XPath("//select[@class='formkit-input'][@data-field-name='state']"));
        //button[@id='dropdown-button']
        #endregion
        /*Methods to validated Mandatory fields on websites*/
        #region
        /*Validated Mandatory fields on Contend*/
        public void verifyMandatoryFieldsContend()
        {
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].scrollIntoView({block: 'center', behavior: 'smooth'});", addressLine2);
            Thread.Sleep(1000);
            continueCTA.Click();
            Assert.Equals(firstNameError.Displayed, true);
            Assert.Equals(lastNameError.Displayed, true);
            Assert.Equals(emailError.Displayed, true);
            Assert.Equals(phoneError.Displayed, true);
        }
        /*Validated Mandatory fields on Multisite*/
        public void verifyMandatoryFieldsMultiste()
        {
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].scrollIntoView({block: 'center', behavior: 'smooth'});", addressLine2);
            Thread.Sleep(1000);
            continueCTA.Click();
            Assert.Equals(firstNameError.Displayed, true);
            Assert.Equals(lastNameError.Displayed, true);
            Assert.Equals(emailError.Displayed, true);
            Assert.Equals(phoneError.Displayed, true);
        }
        /*Validated Mandatory fields on Charter*/
        public void verifyMandatoryFieldsCharter()
        {
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].scrollIntoView({block: 'center', behavior: 'smooth'});", addressLine2);
            Thread.Sleep(1000);
            continueCTA.Click();
            Assert.Equals(firstNameError.Displayed, true);
            Assert.Equals(lastNameError.Displayed, true);
            Assert.Equals(emailError.Displayed, true);
            Assert.Equals(phoneError.Displayed, true);
        }
        /*Methods to Fill Delivery infromation form fields on websites*/
        /*This method is for Contend*/
        public void fillDetailsOnPageContend()
        {
            firstName.SendKeys("Regression");
            lastName.SendKeys("Automation");
            email.SendKeys("test@coloplast.com");
            phone.SendKeys("98569856");
            addressLine1.SendKeys("Address line 101");
            addressLine2.SendKeys("Address line 202");
            postalCode.SendKeys("20008");
            city.SendKeys("testCity");
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].scrollIntoView({block: 'center', behavior: 'smooth'});", deliveryTC);
            Thread.Sleep(1000);
            deliveryTC.Click();
            continueCTA.Click();
        }
        /*This method is for Charter*/
        public void fillDetailsOnPageCharter()
        {
            firstName.SendKeys("Regression");
            lastName.SendKeys("Automation");
            email.SendKeys("test@coloplast.com");
            phone.SendKeys("98569856");
            addressLine1.SendKeys("Address line 101");
            addressLine2.SendKeys("Address line 202");
            postalCode.SendKeys("20008");
            city.SendKeys("testCity");
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].scrollIntoView({block: 'center', behavior: 'smooth'});", deliveryTC);
            Thread.Sleep(1000);
            deliveryTC.Click();
            continueCTA.Click();
        }
        /*This method is for Multisite*/
        public void dropdown(IWebElement element, string value)
        {
            SelectElement dropDown = new SelectElement(element);
            dropDown.SelectByValue(value);
        }
        public void fillDetailsOnPageMultisite()
        {
            Thread.Sleep(2000);
            filltheField(firstName, "Regression");
            filltheField(lastName, "Automation");
            filltheField(email, "test@coloplast.com");
            filltheField(phone, "0455533541");
            filltheField(addressLine1, "Address line 101");
            filltheField(addressLine2, "Address line 202");
            filltheField(postalCode, "2222");
            filltheField(city, "testCity");
            dropdown(statedropdown, "Victoria");
            Actions actions = new Actions(Driver.Browser);
            for (int i = 0; i <= optionIndex; i++)
            {
                actions.SendKeys(Keys.Down);
            }
            actions.SendKeys(Keys.Enter);
            actions.Build();
            actions.Perform();
            Thread.Sleep(1000);
            try
            {
                simpleConsentChoice.ScrollTo().WaitForElementToBeClickable().Click();
            }
            catch
            {
            }
            Thread.Sleep(2000);
            continueBTNAU.Click();
            Thread.Sleep(8000);
        }
        /*Methods to Fill Delivery infromation form fields on South Afreica websites*/
        public void fillDetailsOnSouthAfrica()
        {
            filltheField(firstName, ConfigurationManager.AppSettings.Get("dephone"));
            filltheField(lastName, ConfigurationManager.AppSettings.Get("dephone"));
            filltheField(idnumberSF, ConfigurationManager.AppSettings.Get("dephone"));
            phone.SendKeys("0119780004");
            addressLine1.SendKeys("Address Autoline 101");
            addressLine2.SendKeys("Address Autoline 202");
            postalCode.SendKeys("20008");
            city.SendKeys("testCity");
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].scrollIntoView({block: 'center', behavior: 'smooth'});", deliveryTC);
            Thread.Sleep(1000);
            try
            {
                AcceptTermCondition();
                continueCTA.Click();
            }
            catch
            {
            }
        }
        /*Methods to Fill Delivery infromation form fields on German websites*/
        public void fillDetailsOnGerman()
        {
            Thread.Sleep(2000);
            filltheField(firstName, "Regression");
            filltheField(lastName, "Automation");
            //filltheField(idnumberSF, ConfigurationManager.AppSettings.Get("dephone"));
            filltheField(phone, ConfigurationManager.AppSettings.Get("dephone"));
            /*Thread.Sleep(2000);
            filltheField(addressLine1, ConfigurationManager.AppSettings.Get("deaddress"));
            Thread.Sleep(2000);
            filltheField(postalCode, ConfigurationManager.AppSettings.Get("depostal"));
            filltheField(city, ConfigurationManager.AppSettings.Get("decity"));
            Thread.Sleep(2000);
            dropDown.ScrollTo().WaitForElementToBeClickable().Click();
            Thread.Sleep(3000);
            Bayernoption.ScrollTo().WaitForElementToBeClickable().Click();*/
            Thread.Sleep(1000);
            try
            {
                AcceptTermCondition();
            }
            catch
            {
            }
            deContinueBTN.ScrollTo().WaitForElementToBeClickable().Click();
            Thread.Sleep(8000);
        }
        public void fillDetailsOnFinland()
        {
            Thread.Sleep(2000);
            filltheField(firstName, "Regression");
            filltheField(lastName, "Automation");
            filltheField(email, "test@coloplast.com");
            filltheField(phone, "501230001");
            filltheField(addressLine1, "Address line 101");
            filltheField(addressLine2, "Address line 202");
            filltheField(postalCode, "11222");
            filltheField(city, "testCity");
            try
            {
                dropdownAU.ScrollTo().WaitForElementToBeClickable().Click();
                victoria.Click();
                Thread.Sleep(1000);
            }
            catch
            {
            }
            consentChoiceFI.ScrollTo().WaitForElementToBeClickable().Click();
            continueBTNFI.Click();
        }
        public void AcceptTermCondition()
        {
            if (deliveryTC.Displayed)
            {
                deliveryTC.ScrollTo().WaitForElementToBeClickable().Click();
            }
            else if (deliveryTCLabel.Displayed)
            {
                deliveryTCLabel.ScrollTo().WaitForElementToBeClickable().Click();
            }
            else
            {
                deliveryScroll.ScrollTo().WaitForElementToBeClickable().Click();
            }
        }
        public void filltheField(IWebElement element, string value)
        {
            element.ScrollTo().WaitForElementToBeClickable().Click();
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Backspace);
            Thread.Sleep(1000);
            element.Click();
            element.ScrollTo().WaitForElementToBeClickable().SendKeys(value);
        }
        public void fillDetailsOnSPAIN()
        {
            Thread.Sleep(2000);
            Driver.BrowserWait.WaitForPageLoad();
            postalCode.ScrollTo().WaitForElementToBeClickable().Click();
            if (postalCode.GetAttribute("value").Contains("35000"))
            {
                filltheField(postalCode, ConfigurationManager.AppSettings.Get("SpainPostalTaxCode"));
                filltheField(city, ConfigurationManager.AppSettings.Get("SpainTaxCity"));
                try
                {
                    dropdownAU.ScrollTo().WaitForElementToBeClickable().Click();
                    Almeria.Click();
                    Thread.Sleep(1000);
                }
                catch
                {
                }
                continueBTNSpain.ScrollTo().WaitForElementToBeClickable().Click();
                Driver.BrowserWait.WaitForPageLoad();
                Thread.Sleep(5000);
                orderSummary.Taxisnotfree();
            }
            else if (postalCode.GetAttribute("value").Contains("04001"))
            {
                filltheField(postalCode, ConfigurationManager.AppSettings.Get("SpainPostalCode"));
                filltheField(city, ConfigurationManager.AppSettings.Get("SpainCity"));
                try
                {
                    dropdownAU.ScrollTo().WaitForElementToBeClickable().Click();
                    LasPalmas.Click();
                    Thread.Sleep(1000);
                }
                catch
                {
                }
                continueBTNSpain.ScrollTo().WaitForElementToBeClickable().Click();
                Thread.Sleep(5000);
                orderSummary.Taxisfree();
            }
            else
            {
            }
        }
        public void fillDetailAUNewReg()
        {
            Thread.Sleep(2000);
            filltheField(firstName, "Regression");
            filltheField(lastName, "Automation");
            filltheField(phone, "0455533541");
            filltheField(addressLine1, "Address line 101");
            filltheField(addressLine2, "Address line 202");
            filltheField(postalCode, "2222");
            filltheField(city, "testCity");
            dropdown(statedropdown, "Victoria");
            Actions actions = new Actions(Driver.Browser);
            for (int i = 0; i <= optionIndex; i++)
            {
                actions.SendKeys(Keys.Down);
            }
            actions.SendKeys(Keys.Enter);
            actions.Build();
            actions.Perform();
            Thread.Sleep(1000);
            try
            {
                simpleConsentChoice.ScrollTo().WaitForElementToBeClickable().Click();
            }
            catch
            {
            }
            Thread.Sleep(2000);
            continueBTNAU.Click();
            Thread.Sleep(10000);
        }
        #endregion
    }
}
