using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Core.Pages
{
    public class ConsumerHCPmodal
    {
        /*Page elements and error list*/
        #region
        string text = "Make sure to sample from the right website";
        IWebElement modal => Driver.Browser.FindElement(By.XPath("//div[@class='c-modal__wrapper c-modal__wrapper--form-signup']"));
        IWebElement textOnModal => Driver.Browser.FindElement(By.XPath("//h2[normalize-space()='Make sure to sample from the right website']"));
        IWebElement consumerRadioBtn => Driver.Browser.FindElement(By.XPath("//label[@for='consumer']"));
        IWebElement hcpRadioBtn => Driver.Browser.FindElement(By.XPath("//label[@for='hcp']"));
        IWebElement hiddenConsumerRadioBtn => Driver.Browser.FindElement(By.XPath("//ul[@class='c-modal__sample-options']/li[@class='box']/input[@id='consumer']"));
        IWebElement hiddenHcpRadioBtn => Driver.Browser.FindElement(By.XPath("//ul[@class='c-modal__sample-options']/li[@class='box']/input[@id='hcp']"));
        IWebElement addToBasket => Driver.Browser.FindElement(By.XPath("//span[normalize-space()='Add sample to basket']"));
        IWebElement checkoutBTN => Driver.Browser.FindElement(By.XPath("//button[contains(., 'Checkout') or contains(.,'Checkout')]"));
        IWebElement checkoutBTNspan => Driver.Browser.FindElement(By.XPath("//span[normalize-space()='Checkout']"));
        IWebElement checkoutBTNclass => Driver.Browser.FindElement(By.XPath("//button[@class='disableGoToCheckout ds-button ds-button--primary ds-button--lg']"));


        //a[normalize-space()='Jatka ilman rekisteröitymistä']

        /*Login Modal elements*/
        IWebElement proccedLink => Driver.Browser.FindElement(By.XPath("//button[normalize-space()='Continue as guest']"));
        IWebElement proccedSpan => Driver.Browser.FindElement(By.XPath("//span[normalize-space()='Continue as guest']"));
        //a[normalize-space()='Proceed without registering']
        IWebElement loginModalText => Driver.Browser.FindElement(By.XPath("//h2[contains(., 'Login') or contains(., 'Log in')]"));


        /* WebElement on Finland*/
        IWebElement loginModalTextFI => Driver.Browser.FindElement(By.XPath("//h2[normalize-space()='Nopeuta asiointia']"));
        //h2[normalize-space()='Kirjaudu Coloplast Tilillesi']
        
        IWebElement proccedLinkFI => Driver.Browser.FindElement(By.XPath("//button[normalize-space()='Jatka kirjautumatta']"));
        //a[normalize-space()='Jatka ilman rekisteröitymistä']
        #endregion
        public void SelectConsumer()
        {
            textOnModal.ScrollTo().WaitForElementToBeClickable();
            Console.WriteLine(textOnModal.Text);
            Assert.AreEqual(text, textOnModal.Text);
            if (consumerRadioBtn.Displayed)
            {
                consumerRadioBtn.ScrollTo().WaitForElementToBeClickable().Click();
                addToBasket.ScrollTo().WaitForElementToBeClickable().Click();
            }
            else if (hiddenConsumerRadioBtn.Displayed)
            {
                hiddenConsumerRadioBtn.ScrollTo().WaitForElementToBeClickable().Click();
                addToBasket.ScrollTo().WaitForElementToBeClickable().Click();
            }
            else
            {

                Console.Error.WriteLine("Modal not displayed");
            }
            checkout();
            Driver.BrowserWait.WaitForPageLoad();

        }


        public void checkout()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(3000);
            if (checkoutBTN.Displayed)
            {
                checkoutBTN.ScrollTo().WaitForElementToBeClickable().Click();
            }
            else if (checkoutBTNspan.Displayed)
            {
                checkoutBTNspan.ScrollTo().WaitForElementToBeClickable().Click();
            }
            else
            {
                Console.Error.WriteLine("Modal not displayed");

            }
            Driver.BrowserWait.WaitForPageLoad();


        }
        public void SelectHCP()
        {
            modal.ScrollTo().WaitForElementToBeClickable().Click();
            var textdisplayed = textOnModal.Text;
            Console.WriteLine(text, textdisplayed);
            Assert.AreSame(text, textdisplayed);
            if (hcpRadioBtn.Displayed)
            {
                consumerRadioBtn.ScrollTo().WaitForElementToBeClickable().Click();
                addToBasket.ScrollTo().WaitForElementToBeClickable().Click();
            }
            else if (hiddenHcpRadioBtn.Displayed)
            {
                hiddenHcpRadioBtn.ScrollTo().WaitForElementToBeClickable().Click();
                addToBasket.ScrollTo().WaitForElementToBeClickable().Click();
            }
            else
            {
                Console.Error.WriteLine("Modal not displayed");
            }
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(2000);
            checkout();
            Thread.Sleep(4000);
        }

        public void loginModalProceedWithoutReg()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(4000);
            //Assert.IsTrue(loginModalText.Displayed);
            proccedLink.ScrollTo().WaitForElementToBeClickable().Click();
            Thread.Sleep(4000);
            
        }

        public void loginModalProceedWithoutRegFI()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(2000);
            //Assert.IsTrue(loginModalTextFI.Displayed);
            proccedLinkFI.ScrollTo().WaitForElementToBeClickable().Click();
            Thread.Sleep(2000);
            
        }
    }
}