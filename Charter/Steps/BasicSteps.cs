using Core.Drivers;
using Multisite.PageObjects;
using Multisite.PageObjects.B2CLogin;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using Reqnroll;
using System.Threading;
using Charter.Steps;
using System.Linq;

namespace Multisite.Steps
{
    [Binding]
    public class BasicSteps
    {
        private OrderAProductSteps _orderProductSteps = new OrderAProductSteps();


        [Given(@"I login and go through checkout flow to order summary page")]
        public void GivenILoginAndGoThroughCheckoutFlow()
        {
            _orderProductSteps.GivenILoggedIn("without");
            _orderProductSteps.GivenBasketIsEmpty();
            _orderProductSteps.GivenIAmOnMyAccountPage();
            _orderProductSteps.GivenIHaveOrderTemplateSetUpInSF();
            _orderProductSteps.WhenIClickOnAddSelectedToBasket();
            Thread.Sleep(3000);
            _orderProductSteps.WhenIGoToCheckout();
        }

        [Then(@"I go through checkout flow to order summary page")]
        public void GivenIGoThroughCheckoutFlow()
        {
            Driver.Browser.FindElement(By.XPath("//button[contains(.,'Close')]"),15).WaitForElementToBeClickable().Click();

            Thread.Sleep(2000);
            _orderProductSteps.GivenBasketIsEmpty();
            _orderProductSteps.GivenIAmOnMyAccountPage();
            _orderProductSteps.GivenIHaveOrderTemplateSetUpInSF();
            _orderProductSteps.WhenIClickOnAddSelectedToBasket();
            _orderProductSteps.WhenIGoToCheckout();
        }


        [When(@"I click edit prescription information")]
        public void WhenIClickEditPrescriptionInformation()
        {
            Driver.Browser.FindElement(By.XPath("//a[@href='/checkout/reimbursement-page/']"), 10).Click();
        }

        [When(@"I change GP practice")]
        public void WhenIChangeGPPractice()
        {
            var gpInfo = Driver.Browser.FindElement(By.XPath("//input[@name='gpInformation']"), 15);
            gpInfo.ScrollTo().Click();
            Thread.Sleep(1000);
            gpInfo.SendKeys("m");
            Thread.Sleep(1000);
            gpInfo.SendKeys("e");
            Thread.Sleep(1000);
            gpInfo.SendKeys("d");
            Thread.Sleep(1000);
            gpInfo.SendKeys("i");
            Thread.Sleep(2000);

            Driver.Browser.FindElement(By.XPath("//address[contains(.,'Medi Centre')]"), 15).ScrollTo().Click();
        }

        [When(@"I change exempt status")]
        public void WhenIChangeExemptStatus()
        {
            Driver.Browser.FindElement(By.XPath("//select[@data-testid='select-exemptStatus']"), 15).WaitForElementToBeClickable().Click();
            Driver.Browser.FindElement(By.XPath("//option[@value='Tax Credit Exemption Certificate']"), 15).ScrollTo().Click();
        }

        [When(@"I change GP practice back")]
        public void WhenIChangeGPPracticeBack()
        {
            var gpInfo = Driver.Browser.FindElement(By.XPath("//input[@name='gpInformation']"), 15);
            gpInfo.ScrollTo().Click();
            Thread.Sleep(1000);
            gpInfo.SendKeys("b");
            Thread.Sleep(1000);
            gpInfo.SendKeys("u");
            Thread.Sleep(1000);
            gpInfo.SendKeys("x");
            Thread.Sleep(1000);
            gpInfo.SendKeys("t");
            Thread.Sleep(1000);
            gpInfo.SendKeys("e");
            Thread.Sleep(1000);
            gpInfo.SendKeys("d");
            Thread.Sleep(2000);

            Driver.Browser.FindElement(By.XPath("//address[contains(.,'Buxted')]"), 15).ScrollTo().Click();
        }

        [When(@"Click on Prescription View")]
        public void WhenIClickOnPrescriptionView()
        {
            Driver.Browser.FindElement(By.XPath("//a[@href='/my-account/profile/reimboursement-page/']"), 20).ScrollTo().Click();
        }

        [When(@"I change exempt status back")]
        public void WhenIChangeExemptStatusBack()
        {
            Thread.Sleep(1000);
            Driver.Browser.FindElement(By.XPath("//select[@data-testid='select-exemptStatus']"), 15).WaitForElementToBeClickable().Click();
            Driver.Browser.FindElement(By.XPath("//option[@value='Prescription Exemption Certificate Issued By Ministry Of Defence']"), 15).ScrollTo().Click();
        }

        [Then(@"GP practice is updated")]
        public void ThenGPPracticeIsUpdated()
        {
            Thread.Sleep(1000);
            var gpPractice = Driver.Browser.FindElement(By.XPath("//dd[contains(.,'Bridge St Medi Centre (Londonderry)')]"), 15);
            Assert.IsTrue(gpPractice.Displayed);
        }

        [Then(@"Exempt status details are updated")]
        public void ThenExemptStatusDetailsAreUpdated()
        {
            _orderProductSteps.GivenIAmOnMyAccountPage();
            var signUpSteps = new SignUpSteps();
            signUpSteps.WhenIGoToProfilePage();
            WhenIClickOnPrescriptionView();

            var exemptStatus = Driver.Browser.FindElement(By.XPath("//span[contains(.,'Prescription Exemption Certificate Issued By Ministry Of Defence')]"), 30);
            Assert.IsTrue(exemptStatus.Displayed);
        }

        [Then(@"Exempt status is updated")]
        public void ThenExemptStatusIsUpdated()
        {
            Thread.Sleep(1000);
            var exemptStatus = Driver.Browser.FindElement(By.XPath("//dd[contains(.,'Tax Credit Exemption Certificate')]"), 15);
            Assert.IsTrue(exemptStatus.Displayed);
        }

        [Then(@"Main page is opened")]
        [Then(@"I am redirected to Home Page")]

        public void ThenMainPageIsOpened()
        {
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//a[@href='/' and (@class='c-nav-logo__link')]"), 60).Displayed);
            Assert.IsTrue(Driver.Browser.Title != null && Driver.Browser.Title.CaseInsensitiveEquals("Charter"));
        }

        [When(@"I press login button")]
        public void WhenIPressLoginButton()
        {
            Driver.Browser.FindElement(By.XPath("//span[contains(., 'Login')]"), 60).WaitForElementToBeClickable().Click();
        }

        [When(@"I enter email for account {string} cutting template")]
        public void WhenIEnterEmail(string arg)
        {
            var b2c = new LoginPage();
            if (arg.Equals("without"))
            {
                b2c.Email.WaitForElementToBeClickable().SendKeys(ConfigurationManager.AppSettings.Get("login"));
            }
            else if (arg.Equals("with"))
            {
                b2c.Email.WaitForElementToBeClickable().SendKeys(ConfigurationManager.AppSettings.Get("loginCS"));

            }
        }

        [When(@"I enter password")]
        public void WhenIEnterPassword()
        {
            var b2c = new LoginPage();
            b2c.Password.WaitForElementToBeClickable().SendKeys(ConfigurationManager.AppSettings.Get("password"));
        }


        [When(@"I press log in button")]
        public void WhenIPressLogInButton()
        {
            var b2c = new LoginPage();
            b2c.LoginBtn.Click();
        }

        [When(@"I search for a product")]
        public void WhenISearchForAProduct()
        {
            Driver.Browser.FindElement(By.XPath("//button[@data-testid='global-search-icon']"), 30).Click();
            var searchBar = Driver.Browser.FindElement(By.Id("searchField"),30);
            searchBar.Click();
            searchBar.SendKeys("1");
            Thread.Sleep(500);
            searchBar.SendKeys("8");
            Thread.Sleep(500);
            searchBar.SendKeys("6");
            Thread.Sleep(500);
            searchBar.SendKeys("6");
            Thread.Sleep(500);

            Driver.Browser.FindElement(By.XPath("//a[@data-testid='product-link']"), 30).WaitForElementToBeClickable().Click();
        }

        [When(@"I search for an article")]
        public void WhenISearchForAnArticle()
        {
            Driver.Browser.FindElement(By.XPath("//button[@data-testid='global-search-icon']"), 30).Click();
            var searchBar = Driver.Browser.FindElement(By.Id("searchField"), 30);
            searchBar.Click();
            searchBar.SendKeys("stoma ");
            Thread.Sleep(500);
            searchBar.SendKeys("surgery");
            searchBar.SendKeys(Keys.Return);
            Thread.Sleep(1000);
        }

        [Then(@"I can see articles in search results")]
        public void ThenICanSeeArticlesInSearchResults()
        {
            var resultsContainer = Driver.Browser.FindElement(By.XPath("//section[@aria-label='Articles found']"), 30);
            Assert.IsNotNull(resultsContainer);
            Assert.IsTrue(resultsContainer.Displayed);
            var articles = resultsContainer.FindElements(By.XPath("//article[@class='c-list-view-card']"), 30);
            Assert.IsTrue(articles.Count > 0);
        }

        [Then(@"I can open article by clicing on it")]
        public void ThenICanOpenArticleByClickingOnIt()
        {
            var article = Driver.Browser.FindElements(By.XPath("//article[@class='c-list-view-card']"), 30).FirstOrDefault();
            article.Click();
            Thread.Sleep(3000);
        }

        [Then(@"I see article page open")]
        public void ThenISeeArticlePageOpen()
        {
            var expectedTitle = "What you can do about a bulging stoma | Coloplast Charter";
            var title = Driver.Browser.Title;
            Assert.IsTrue(title == expectedTitle);
        }

        [Then(@"I successfully logged in")]
        public void ThenISuccessfullyLoggedIn()
        {
            Driver.BrowserWait.Until(drv => drv.Url.CaseInsensitiveContains(ConfigurationManager.AppSettings.Get("url")));

            Driver.BrowserWait.WaitForPageLoad();

            Assert.IsTrue(Driver.Browser.Title != null && 
                Driver.Browser.Title.CaseInsensitiveEquals("My Account") ||
                Driver.Browser.Title.CaseInsensitiveEquals("Charter") ||
                Driver.Browser.Title.CaseInsensitiveContains("Multisite"));
        }

        [Then(@"I can see previous orders")]
        public void ThenICanSeePreviousOrders()
        {
            Thread.Sleep(1000);
            var ordersContainer = Driver.Browser.FindElement(By.ClassName("c-order-history__orders-list"), 30);

            var orderLists = ordersContainer.FindElements(By.XPath("//div[@data-testid='order-card']"), 10);

            Assert.IsTrue(ordersContainer.Displayed);
            Assert.IsNotNull(orderLists);
        }
    }
}
