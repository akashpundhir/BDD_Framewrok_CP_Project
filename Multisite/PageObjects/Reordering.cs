using Core.Drivers;
using Core.Pages;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Threading;
namespace Multisite.PageObjects
{
    internal class Reordering
    {
        DeliveryInfoPage deliveryInfoPage;
        string regText = "What do you need today?";
        string myAccount = "My Account";
        string DEmyAccount = "Mein Online-Konto";
        string heading = "Reordering";
        public Reordering()
        {
            deliveryInfoPage = new DeliveryInfoPage();
        }
        /*List of Web elements on the page */
        #region
        IWebElement productBlock => Driver.Browser.FindElement(By.XPath("//div[@id='my-products-block']"));
        IWebElement headingH2 => Driver.Browser.FindElement(By.XPath("//div[@id='My Products']/h2"));
        IWebElement myAccountHeading => Driver.Browser.FindElement(By.XPath("//div[@class='c-profile__menu']//div[text()='My Account']"));
        IWebElement viewMoreDetails => Driver.Browser.FindElement(By.XPath("//span[@class='ds-text-label-md ds-text--medium'][normalize-space()='View more details']"));
        IWebElement regulerText => Driver.Browser.FindElement(By.XPath("//div[@class='ds-text-body-md ds-text--regular']"));
        IWebElement myaccountMenu => Driver.Browser.FindElement(By.XPath("//a[@class='ds-button ds-button--primary ds-button--md ']"));
        IWebElement myAccountIconSF => Driver.Browser.FindElement(By.XPath("//img[@alt='My Account']"));
        IWebElement fundingMenu => Driver.Browser.FindElement(By.XPath("//span[normalize-space()='Funding']"));
        IWebElement checkBox => Driver.Browser.FindElement(By.XPath("//label[@data-checked='true']//span[@class='formkit-decorator']"));
        IWebElement addToBasket => Driver.Browser.FindElement(By.CssSelector("button[aria-label='add-selected-to-the-basket']"));
        IWebElement orderMyRegularProductsSF => Driver.Browser.FindElement(By.XPath("//button[@aria-label='order-my-regular-products']"));
        IWebElement addSelectedToBasket => Driver.Browser.FindElement(By.XPath("//button[@aria-label='add-selected-to-the-basket']"));
        IWebElement addToBasketCSS => Driver.Browser.FindElement(By.CssSelector(".ds-button-group.ds-button-group--md.ds-button-group--start.ds-button-group--row.ds-button-group--m-stretch.ds-button-group--m-column"));
        /* list of elements used in  Edit Payment details*/
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
        IWebElement arrowBtn => Driver.Browser.FindElement(By.XPath("//span[@data-icon-name='chevron-up']//*[name()='svg']"));
        IWebElement closeMakesure => Driver.Browser.FindElement(By.XPath("//button[@aria-label='got-it']"));
        /*German MyAccount Webelements*/
        IWebElement DeMyAccount => Driver.Browser.FindElement(By.XPath("//img[@alt='Mein Online-Konto']"));
        IWebElement DEaddToBasket => Driver.Browser.FindElement(By.CssSelector("button[aria-label='in-den-warenkorb-legen']"));
        IWebElement DeMyAccountHeading => Driver.Browser.FindElement(By.XPath("//div[@class='c-profile__menu']/div[contains(., 'Mein Online-Konto')]"));
        IWebElement DEContinueBTNFlyOUtBasket => Driver.Browser.FindElement(By.XPath("//button[@class='disableGoToCheckout ds-button ds-button--primary ds-button--lg']"));
        IWebElement DEContinueBTNOnSummaryPage => Driver.Browser.FindElement(By.XPath("//button[contains(., 'Weiter zur Zahlung')]"));
        /*Spain MyAccount Webelements*/
        IWebElement myAccountIconSpain => Driver.Browser.FindElement(By.XPath("//img[@class='c-nav-icon__icon e-icon--nav']"));
        IWebElement myAccountHeadingSpain => Driver.Browser.FindElement(By.XPath("//div[@class='c-profile__menu']/div[contains(., 'Mi cuenta')]"));
        IWebElement finalizer => Driver.Browser.FindElement(By.XPath("//button[contains(., 'Finalizar')]"));
        IWebElement addToBasketSpain => Driver.Browser.FindElement(By.XPath("//button[@aria-label='pedir-mis-productos' or @data-testid='reorder-products-button']"));
        IWebElement qunatitybox => Driver.Browser.FindElement(By.XPath("//div[@id='dialog-review-quantity']"));
        IWebElement qunatityboxClose => Driver.Browser.FindElement(By.XPath("//button[@aria-label='Close']"));
        IWebElement qunatityboxGotIt => Driver.Browser.FindElement(By.XPath("//button[@aria-label='got-it']"));
        


        //img[@class='c-nav-icon__icon e-icon--nav']
        #endregion
        public void navigateToMyAccountPage()
        {
            Thread.Sleep(4000);
            myaccountMenu.ScrollTo().WaitForElementToBeClickable().CustomClick();
            Assert.AreEqual(myAccount, myAccountHeading.Text);
            Console.WriteLine(myAccountHeading.Text);
            Assert.AreEqual(heading, headingH2.Text);
        }
        public void AddToBasket()
        {
            addToBasket.ScrollTo().WaitForElementToBeClickable().CustomClick();
            try
            {
                closeMakesure.Click();
            }
            catch { }
        }
        public void SFnavigateToMyAccountPage()
        {
            Thread.Sleep(4000);
            myAccountIconSF.ScrollTo().WaitForElementToBeClickable().CustomClick();
            Assert.AreEqual(myAccount, myAccountHeading.Text);
            Console.WriteLine(myAccountHeading.Text);
            Thread.Sleep(4000);
            addtobasketmethod();
        }
        public void NavigateToPaymentPage()
        {
            Driver.BrowserWait.WaitForPageLoad();
            paymentEditBtn.ScrollTo().WaitForElementToBeClickable().CustomClick();
        }
        public void SelectOwnFunding()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(1000);
            //fundingMenu.ScrollTo().WaitForElementToBeClickable().CustomClick();
            OwnFunding.ScrollTo().WaitForElementToBeClickable().CustomClick();
            saveChangesBtn.ScrollTo().WaitForElementToBeClickable().CustomClick();
        }
        public void SelctNDISPayment()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(2000);
            NDISRadiobtn.ScrollTo().WaitForElementToBeClickable().CustomClick();
            saveAndContinue.ScrollTo().WaitForElementToBeClickable().CustomClick();
            Thread.Sleep(3000);
        }
        public void NdisParticipant()
        {
            Thread.Sleep(1000);
            Assert.AreEqual(ConfigurationManager.AppSettings.Get("NDISPageHeading"), headingNDIS.Text);
            Assert.AreEqual(ConfigurationManager.AppSettings.Get("participantHeading"), headingParticipant.Text);
            NDIAManaged.ScrollTo().WaitForElementToBeClickable().CustomClick();
            participantNameInputField.ScrollTo().WaitForElementToBeClickable().CustomClick();
            var username = participantNameInputField.ScrollTo().WaitForElementToBeClickable().Text;
            ConfigurationManager.AppSettings.Set("username", username);
            //participantNumber.ScrollTo().WaitForElementToBeClickable().SendKeys("1234567890");
            Random r = new Random();
            int rand = r.Next(10000000);
            Helper.ndis = $"43{rand.ToString("D7")}";
            Driver.Browser.FindElement(By.XPath("//input[@name='ParticipantNumber']")).ClearExt().SendKeys(Helper.ndis);
            try
            {
                day.SendKeys(ConfigurationManager.AppSettings.Get("day"));
                month.SendKeys(ConfigurationManager.AppSettings.Get("month"));
                year.SendKeys(ConfigurationManager.AppSettings.Get("year"));
            }
            catch
            {
                Console.WriteLine("element is not displayed");
            }
            saveAndContinue.ScrollTo().WaitForElementToBeClickable().CustomClick();
        }
        public void validateFundingChange()
        {
            Thread.Sleep(8000);
            var details = ndisNDIAmanaged.ScrollTo().WaitForElementToBeClickable().Text;
            Assert.AreEqual(ndisNDIAmanaged.Text, ConfigurationManager.AppSettings.Get("ndiatext"));
            Console.WriteLine("payment type " + details);
            Console.WriteLine("NIDA payment succeffuly filled and updated during payment step");
            continueFundedBTN.ScrollTo().WaitForElementToBeClickable().CustomClick();
            Thread.Sleep(1000);
        }
        public void addtobasketmethod()
        {
            if (addToBasketCSS.Displayed)
            {
                addToBasketCSS.ScrollTo().WaitForElementToBeClickable().Click();
            }
            else if (orderMyRegularProductsSF.Displayed)
            {
                orderMyRegularProductsSF.ScrollTo().WaitForElementToBeClickable().Click();
            }
            else
            {
                addSelectedToBasket.ScrollTo().WaitForElementToBeClickable().Click();
            }
            Thread.Sleep(4000);
            try
            {
                if (qunatitybox.Displayed)
                {
                    qunatityboxGotIt.ScrollTo().WaitForElementToBeClickable().Click();
                }
                else
                {
                    qunatityboxClose.ScrollTo().WaitForElementToBeClickable().Click();
                }
            }
            catch { }
        }
        public void deleteAllitems()
        {
            arrowBtn.ScrollTo().WaitForElementToBeClickable().Click();
            removeBtn.Click();
        }
        /*Code and method for German multiste, Reordering, Sepa, add to  my acocunt etc..*/
        public void DEnavigateToMyAccountPage()
        {
            Thread.Sleep(6000);
            DeMyAccount.ScrollTo().WaitForElementToBeClickable().Click();
            Thread.Sleep(6000);
            if (DeMyAccountHeading.Displayed)
                Assert.AreEqual(DEmyAccount, DeMyAccountHeading.Text);
            else
            {
                Console.WriteLine(DeMyAccountHeading.Text);
            }
            DEaddToBasket.ScrollTo().WaitForElementToBeClickable().Click();
            Thread.Sleep(4000);
            DEContinueBTNFlyOUtBasket.ScrollTo().WaitForElementToBeClickable().Click();
            Thread.Sleep(5000);
            if (Driver.Browser.Url == "https://test-homecare-de.coloplast.com/global-checkout/delivery-information-step/")
                deliveryInfoPage.fillDetailsOnGerman();
            else 
            {
                string url = "https://test-homecare-de.coloplast.com/global-checkout/order-summary/";
                Assert.AreEqual(Driver.Browser.Url, url);
                DEContinueBTNOnSummaryPage.ScrollTo().WaitForElementToBeClickable().Click();
            }
            Thread.Sleep(8000);
            
        }


        public void NavigateToMyAccountPageSPAIN()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(2000);
            myAccountIconSpain.ScrollTo().WaitForElementToBeClickable().CustomClick();
            Driver.BrowserWait.WaitForPageLoad();
            Assert.AreEqual("Mi cuenta", myAccountHeadingSpain.Text);
            Console.WriteLine(myAccountHeadingSpain.Text);
            Thread.Sleep(2000);
            addToBasketSpain.ScrollTo().WaitForElementToBeClickable().Click();
            

        }
        public void TaxisnotfreeSpain()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(2000);
            IWebElement arrowBtn = Driver.Browser.FindElement(By.XPath("//span[@data-icon-name='chevron-up']//*[name()='svg']"));
            arrowBtn.ScrollTo().WaitForElementToBeClickable().Click();
            /*Driver.BrowserWait.WaitForPageLoad();
            string IVA = "0,00 €";
            IWebElement tax = Driver.Browser.FindElement(By.XPath("//dd[normalize-space()='3,97 €']"));
            Assert.AreNotEqual(tax.Text, IVA);
            Console.WriteLine(tax.Text);*/
            Thread.Sleep(1000);
            finalizer.ScrollTo().WaitForElementToBeClickable().Click();
         
        }



    }
}
