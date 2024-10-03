using Core.Drivers;
using Core.Pages;
using OpenQA.Selenium;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lilial.Steps
{
    [Binding]
    internal class OrderAProductSteps
    {

        /*************************Start-  Checkout as guest with OOP in basket - *************************/
        [Given(@"I navigate to speedicath flex set  product page")]
        public void GivenINavigateToSpeedicathFlexSetProductPage()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Driver.Navigate("https://test-lilial.coloplast.com/coloplast/continence-care-coloplast/speedicath/speedicath-flex/speedicath-flex/#variant=289120");
            //Driver.Navigate(ConfigurationManager.AppSettings.Get("speedicath"));
            //label[@for='add-to-basket-action-buy']
        }
        [Then(@"I added a item to the basket and hit continue")]
        public void ThenIAddedAItemToTheBasketAndHitContinue()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(3000);
            IWebElement buyBtn = Driver.Browser.FindElement(By.XPath("//label[@for='add-to-basket-action-reimbursement']"));
            buyBtn.ScrollTo().WaitForElementToBeClickable().Click();
            //label[@for='add-to-basket-action-buy']
            
        }
        [Then("Click Checkout CTA on flyout basket")]
        public void ThenClickCheckoutCTAOnFlyoutBasket()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(3000);
            Driver.Browser.FindElement(By.XPath("//button[@data-testid='button-add-to-basket']"), 60).
                WaitForElementToBeClickable().CustomClick();
            //button[@data-testid='button-add-to-basket']
            Thread.Sleep(3000);
            Driver.Browser.FindElement(By.XPath("//button[contains(., 'Passer la commande') or contains(.,'Add to basket')]"), 60).
                WaitForElementToBeClickable().CustomClick();
           
        }
        [Then(@"I select the signup on modal")]
        public void ThenISelectTheSignupOnModal()
        {
            Driver.Browser.FindElement(By.XPath("//span[normalize-space()='Créez un compte']")).Click();
            //button[@data-testid='linkButton']//span[contains(.,'Сontinuer')]


        }
        [Then(@"account is created and Modal displayed")]
        public void ThenAccountIsCreatedAndModalDisplayed()
        {
            Driver.Browser.FindElement(By.XPath("//a[@data-testid='linkButton']")).Click();
        }




    }
}
