using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
namespace Core.Pages
{
    public class OrderSummary
    {
        #region
        IWebElement addressDetails => Driver.Browser.FindElement(By.XPath("//div[@class='c-global-checkout__summary-columns']//div[1]"));
        IWebElement contactDetails => Driver.Browser.FindElement(By.XPath("//div[@class='c-global-checkout__summary-columns']//div[2]"));
        IWebElement continueSample => Driver.Browser.FindElement(By.XPath("//div[@class='checkout-summary-container--desktop']//div//div//button[contains(., 'Continue sampling') or contains(.,'continue')]"));
        IWebElement continueSampleDesktpop=> Driver.Browser.FindElement(By.XPath("//div[@class='checkout-summary-container--desktop']//div//div//button[@type='button']"));
        IWebElement contniueBTN => Driver.Browser.FindElement(By.XPath("//button[contains(., 'Continue sampling') or contains(.,'Continue')]"));
        //div[@class='checkout-summary-container--desktop']//div//div//button[@type='button']
        IWebElement continueCTA => Driver.Browser.FindElement(By.XPath("//div[@class='c-global-checkout__buttons c-global-checkout__buttons--align-right desktop-buttons']//a[@class='c-global-checkout__continue-button e-button e-button--filled']"));
        /*WebElement for south africa*/
        IWebElement zacontinueBTN => Driver.Browser.FindElement(By.XPath("//div[@class='checkout-summary-container--desktop']//div//div//button[@type='button']"));
        IWebElement continueOrderFI => Driver.Browser.FindElement(By.XPath("//div[@class='checkout-summary-container--desktop']//div//div//button[contains(., 'Jatka maksamaan') or contains(.,'continue')]"));
        IWebElement continueOrderSpanFI => Driver.Browser.FindElement(By.XPath("//div[@class='checkout-summary-container--desktop']//div//div//button[contains(., 'Jatka maksamaan') or contains(.,'continue')]"));
        /*WebElement for SPAIN*/
        IWebElement contniueBTNSpain => Driver.Browser.FindElement(By.XPath("//div[@class='checkout-summary-container--desktop']//div//div//button[contains(., 'Continuar con el pago') or contains(.,'Continuar ')]"));
        IWebElement freetaxdiv => Driver.Browser.FindElement(By.XPath("//div[@class='c-global-checkout__left-block']//dd[contains(., '0,00 €')]"));
        IWebElement taxdiv => Driver.Browser.FindElement(By.XPath("//div[@class='c-global-checkout__left-block']//dd[contains(., '3,97 €')]"));
        //div[@class='c-global-checkout__left-block']//dd[contains(., '0,00 €')]
        #endregion
        public void verifyOrderDetails()
        {
            Console.WriteLine(addressDetails.Text);
            Console.WriteLine(contactDetails.Text);
            continueCTA.Click();
        }
        public void zaContniueCheckout()
        {
            Thread.Sleep(3000);
            zacontinueBTN.ScrollTo().WaitForElementToBeClickable().Click();
        }
        public void continueSampling()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(2000);
            if (continueSample.Displayed)
            {
                continueSample.ScrollTo().WaitForElementToBeClickable().Click();
            }
            else if(contniueBTN.Displayed)
            {
                contniueBTN.ScrollTo().WaitForElementToBeClickable().Click();
            }    
            else
            {
                continueSampleDesktpop.ScrollTo().WaitForElementToBeClickable().Click();
            }
            Thread.Sleep(2000);
            Driver.BrowserWait.WaitForPageLoad();
        }
        public void continueOrderFIN()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(5000);
            if (continueOrderFI.Displayed)
            {
                continueOrderFI.ScrollTo().WaitForElementToBeClickable().Click();
            }
            else
            {
                continueOrderSpanFI.ScrollTo().WaitForElementToBeClickable().Click();
            }
            Driver.BrowserWait.WaitForPageLoad();
        }
        public void Taxisnotfree()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(10000);
            string spiantax = "3,97 €";
            
            Assert.AreEqual(spiantax, taxdiv.Text);
            Thread.Sleep(2000);
            Console.WriteLine("Test case pass and value of tax from website is  " + taxdiv.Text);
            /* if (taxdiv.GetAttribute("text").Contains("3,97 €"))
             {
                 Console.WriteLine("Test case pass and value of tax from website is  " + taxdiv.Text);
             }
             else
             {
                 Console.WriteLine("Test case Fail and value of tax from website is " + taxdiv.Text);
             }
             */
            contniueBTNSpain.ScrollTo().WaitForElementToBeClickable().Click();
        }
        public void Taxisfree()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(10000);
            string Zerotax = "0,00 €";
            Assert.AreEqual(Zerotax, freetaxdiv.Text);
            Thread.Sleep(2000);
            Console.WriteLine("Test case pass and value of tax from website is  " + freetaxdiv.Text);
            /* if (freetaxdiv.GetAttribute("text").Contains("0,00"))
             {
                 Console.WriteLine("Test case pass and value of tax from website is  " + freetaxdiv.Text);
             }
             else
             {
                 Console.WriteLine("Test case Fail and value of tax from website is " + freetaxdiv.Text);
             }*/
            contniueBTNSpain.ScrollTo().WaitForElementToBeClickable().Click();
        }
    }
}