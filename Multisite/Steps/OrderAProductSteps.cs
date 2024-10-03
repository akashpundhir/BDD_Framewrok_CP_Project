using Core.Drivers;
using Multisite.PageObjects;
using Multisite.PageObjects.B2CLogin;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Threading;
using Reqnroll;
using System.Text.RegularExpressions;
using System.Text;
using EmailWrapper;
using Core.Pages;
namespace Multisite.Steps
{
    [Binding]
    public class OrderAProductSteps
    {
        Reordering reordering;
        OrderSummary orderSummary;
        LoginPage loginPage;
        FlyOutBasket flyOutBasket;
        PaymentPage paymentPage;
        ConsumerHCPmodal consumerHCPmodal;
        DeliveryInfoPage deliveryInfoPage;
        MultipleaddressPage multipleaddressPage;
        MarketingPage marketingPage;
        OrderConsentPage orderConsentPage;
        OrderConfirmationPage orderConfirmationPage;
        private OnesecmailApi _1secApi;
        private string _userEmail;
        public OrderAProductSteps()
        {
            reordering = new Reordering();
            flyOutBasket = new FlyOutBasket();
            orderSummary = new OrderSummary();
            consumerHCPmodal = new ConsumerHCPmodal();
            deliveryInfoPage = new DeliveryInfoPage();
            loginPage = new LoginPage();
            paymentPage = new PaymentPage();
            marketingPage = new MarketingPage();
            orderConsentPage = new OrderConsentPage();
            orderConfirmationPage = new OrderConfirmationPage();
            multipleaddressPage = new MultipleaddressPage();
        }
        [Given(@"I selected a product")]
        [When(@"I selected a product")]
        public void GivenISelectedAProduct()
        {
            GivenISelectedProductCategory();
            bool found = false;
            int count = 0;
            while (!found)
            {
                try
                {
                    found = Driver.Browser.FindElement(By.XPath("//a[contains(., 'SpeediCath Compact Set, Female, Straight tip')]"), 20).Displayed;
                    Driver.Browser.FindElement(By.XPath("//a[contains(., 'SpeediCath Compact Set, Female, Straight tip')]")).ScrollTo().
                        WaitForElementToBeClickable().CustomClick();
                }
                catch (WebDriverTimeoutException)
                {
                    Helper.ScrollDown();
                }
                count++;
                if (count == 5)
                    throw new System.Exception("Product was not found");
            }
        }
        [Given(@"I selected Standard pack")]
        public void GivenISelectedStandardPack()
        {
            Driver.Browser.FindElement(By.XPath("//span[contains(., 'Standard pack') or contains(., 'standard pack') " +
                "or contains(., 'I want to buy') or contains(., 'i want to buy') " +
                "or contains(., 'I want to order') or contains(., 'i want to order')]"), 60);
            try
            {
                Driver.Browser.FindElement(By.XPath("//label[@for='selectVariant']")).
                    WaitForElementToBeClickable().CustomClick();
                Driver.Browser.FindElement(By.XPath("//label[contains(@for, 'variant') and " +
                    "not(contains(@class,'c-select__option--unspecified'))]")).
                    WaitForElementToBeClickable().CustomClick();
            }
            catch
            {
            }
            Driver.Browser.FindElement(By.XPath("//span[contains(., 'Standard pack') or contains(., 'standard pack') " +
                "or contains(., 'I want to buy') or contains(., 'i want to buy') " +
                "or contains(., 'I want to order') or contains(., 'i want to order')]")).
                WaitForElementToBeClickable().CustomClick();
        }
        [Given(@"I selected a sample")]
        public void GivenISelectedASample()
        {

            Driver.Navigate(ConfigurationManager.AppSettings.Get("brawa3210"));
        }

        [Given(@"I selected sample")]
        [When(@"I selected sample")]
        public void GivenSelectedSample()
        {
            GivenISelectedASample();
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(4000);

            Driver.Browser.FindElement(By.XPath("//label[@for='add-to-basket-action-sample']"), 10).ScrollTo().WaitForElementToBeClickable().Click();
        }
        [Given(@"I pressed Add to basket")]
        [When(@"I pressed Add to basket")]
        public void GivenIPressedAddToBasket()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(3000);
            Driver.Browser.FindElement(By.XPath("//button[contains(., 'Add to basket') or contains(.,'Order free sample')]"), 60).
                WaitForElementToBeClickable().CustomClick();
        }
        [When(@"I press register button")]
        public void WhenIPressRegisterButton()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(3000);
            Driver.Browser.FindElement(By.XPath("//span[contains(.,'Create account')]"), 10).Click();
        }
        [Given(@"I choose I am a customer")]
        public void GivenIChooseIAmACustomer()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(3000);
            Driver.Browser.FindElement(By.XPath("//label[@for='consumer']"), 10).Click();
            Thread.Sleep(1000);
            Driver.Browser.FindElement(By.XPath("//button[@data-testid='consents-modal__add-to-basket-test']"), 10).Click();
        }
        [When(@"I click continue adding products")]
        public void WhenIClickContinueAddingProducts()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Driver.Browser.FindElement(By.XPath("//span[contains(.,'Continue adding products')]"), 15).Click();
        }
        [When(@"I go to checkout")]
        public void WhenIGoToCheckout()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Driver.Browser.FindElement(By.XPath("//button[contains(., 'Checkout')]"), 60).ScrollTo().WaitForElementToBeClickable().Click();
        }
        [Then(@"Login to your account modal is shown")]
        public void ThenLoginToYourAccountModalIsShown()
        {
            Thread.Sleep(5000);
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//h2[contains(., 'Login') or contains(., 'Log in')]"), 60).Displayed);
        }
        [Given(@"I logged in")]
        public void GivenILoggedIn()
        {
            var basicSteps = new BasicSteps();
            basicSteps.WhenIPressLoginButton();
            basicSteps.WhenIEnterEmail();
            basicSteps.WhenIEnterPassword();
            basicSteps.WhenIPressLogInButton();
            basicSteps.ThenISuccessfullyLoggedIn();
        }
        [Given(@"I'm on the minishop page")]
        public void GivenImOnTheMinishopPage()
        {
            Driver.Navigate(ConfigurationManager.AppSettings.Get("minishop"));
        }
        [When(@"I click on a product")]
        public void WhenIClickOnAProduct()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(3000);
            Driver.Browser.FindElement(By.XPath("//article[@class='c-product-category-carousel__card']//a[@class='product__link'][normalize-space()='SpeediCath® Flex']"), 10).ScrollTo().WaitForElementToBeClickable().Click();
        }
        [Then(@"I'm on the product page")]
        public void ThenImOnTheProductPage()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(3000);
            Assert.IsTrue(Driver.Browser.Title != null && Driver.Browser.Title == "SpeediCath® Flex");
            var description = Driver.Browser.FindElement(By.XPath("//h3[contains(.,'Key benefits')]"), 10).ScrollTo();
            Assert.IsTrue(description.Displayed);
            Assert.IsNotEmpty(description.Text);
        }
        [Given(@"I opened main page")]
        [When(@"I opened main page")]
        public void GivenIOpenedMainPage()
        {
            Driver.Navigate(ConfigurationManager.AppSettings.Get("url"));
        }
        [When(@"I fill delivery info")]
        public void WhenIFillDeliveryInfo()
        {
            Driver.Browser.FindElement(By.XPath("//input[@data-field-name='addressLine1']"), 60).ClearExt().SendKeys("abc");
            Driver.Browser.FindElement(By.XPath("//input[@data-field-name='postalCode']")).ClearExt().SendKeys("1234");
            Driver.Browser.FindElement(By.XPath("//input[@data-field-name='city']")).ClearExt().SendKeys("qwer");
            Driver.Browser.FindElement(By.XPath("//button[@data-field-name='state']")).CustomClick();
            Driver.Browser.FindElement(By.Id("Austrialian Capital Territory"), 10).CustomClick();
        }
        [When(@"I fill delivery info page")]
        public void WhenIFillDeliveryInfoPage()
        {
            Driver.Browser.FindElement(By.XPath("//input[@data-field-name='firstName']"), 60).ClearExt().SendKeys("Auto");
            Driver.Browser.FindElement(By.XPath("//input[@data-field-name='lastName']")).ClearExt().SendKeys("Tester");
            Driver.Browser.FindElement(By.XPath("//input[@data-field-name='phoneNumber']"), 5).Click();
            Driver.Browser.FindElement(By.XPath("//input[@data-field-name='phoneNumber']"), 5).SendKeys(PhoneNoGeneratorAu());
            Driver.Browser.FindElement(By.XPath("//input[@data-field-name='addressLine1']"), 5).SendKeys("7 Shea St");
            Driver.Browser.FindElement(By.XPath("//input[@data-field-name='addressLine2']"), 5).SendKeys("");
            Driver.Browser.FindElement(By.XPath("//input[@data-field-name='postalCode']"), 5).ScrollTo();
            Driver.Browser.FindElement(By.XPath("//input[@data-field-name='postalCode']"), 5).SendKeys("2606");
            Driver.Browser.FindElement(By.XPath("//input[@data-field-name='city']"), 5).SendKeys("Phillip");
            Driver.Browser.FindElement(By.XPath("//*[@data-field-name='state']"), 5).WaitForElementToBeClickable().Click();
            Driver.Browser.FindElement(By.XPath("//li[@id='Victoria']"), 5).WaitForElementToBeClickable().Click();
            Thread.Sleep(3000);
        }
        [Given(@"Basket is empty")]
        public void GivenBasketIsEmpty()
        {
            var basketIcon = Driver.Browser.FindElement(By.XPath("//nav[contains(@class, 'c-nav-basket c-nav-basket--desktop')]"), 10);
            var elementsInBasket = Driver.Browser.IsElementExists(By.XPath("//span[contains(@class, 'c-nav-basket__count')]"));
            if (elementsInBasket)
            {
                basketIcon.FindElement(By.XPath("//span[contains(@class, 'c-nav-basket__count')]"), 10).CustomClick();
                Thread.Sleep(2000);
                var productsInBasket = Driver.Browser.FindElements(By.XPath("//button[contains(@title, 'remove')]"), 10);
                foreach (var product in productsInBasket)
                {
                    product.WaitForElementToBeClickable().CustomClick();
                    Thread.Sleep(1000);
                }
            }
        }
        [When(@"I select self pay")]
        public void WhenISelectSelfPay()
        {
            Driver.Browser.FindElement(By.XPath("//label[@for='0-funding']"), 60).CustomClick();
            Driver.Browser.FindElement(By.XPath("//button[@type='submit']")).WaitForElementToBeClickable().CustomClick();
        }
        [When(@"I proceed to payment")]
        [Then(@"I proceed to payment")]
        public void WhenIProceedToPayment()
        {
            Thread.Sleep(1000);
            var desktopCheckout = Driver.Browser.FindElement(By.XPath("//div[contains(@class, 'checkout-summary-container--desktop')]"), 60).ScrollTo();
            desktopCheckout.FindElement(By.XPath("//button[contains(., 'Continue to payment')or contains(.,'Continue funded')]"), 10).ScrollTo().Click();
        }

        [When(@"I click edit payment method")]
        public void WhenIEditPaymentMethod()
        {
            Thread.Sleep(1000);
            Driver.Browser.FindElement(By.XPath("//a[@href='/checkout/funding-options/']"), 10).WaitForElementToBeClickable().Click();
        }
        [When(@"I accept consent")]
        public void WhenIAcceptConsent()
        {
            try
            {
                Driver.Browser.FindElement(By.XPath("//button[@data-order-consent-event='accept']"), 120).Wait(1).ScrollTo().Click();
                Driver.Browser.FindElement(By.XPath("//button[@data-consent-event='accept']"), 30);
                try
                {
                    Driver.Browser.FindElement(By.XPath("//label[@for='Email']")).Click();
                    Driver.Browser.FindElement(By.XPath("//button[@data-consent-event='accept']")).Click();
                }
                catch
                {
                }
                try
                {
                    Driver.Browser.FindElement(By.XPath("//button[@class='c-checkout-prescription__skipbutton']"), 30).Click();
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        [When(@"I pay with selected card")]
        [Then(@"I pay with selected card")]
        public void WhenIPayWithSelectedCard()
        {
            try
            {
                Thread.Sleep(3000);
                Driver.Browser.FindElement(By.XPath("//span[contains(., '4242')]"), 10).WaitForElementToBeClickable().Click();
                Driver.Browser.FindElement(By.XPath("//div/button[@type='submit']")).WaitForElementToBeClickable().Click();
            }
            catch
            {
                var frames = Driver.Browser.FindElements(By.XPath("//iframe[contains(@name,'privateStripeFrame')]"));
                Driver.Browser.SwitchTo().Frame(frames[0]);
                Driver.Browser.FindElement(By.XPath("//span[@class='InputContainer']/input[@name='cardnumber']")).SendKeys("4242424242424242");
                Driver.Browser.SwitchTo().DefaultContent();
                Driver.Browser.SwitchTo().Frame(frames[1]);
                Driver.Browser.FindElement(By.XPath("//span[@class='InputContainer']/input[@name='exp-date']")).SendKeys("0536");
                Driver.Browser.SwitchTo().DefaultContent();
                Driver.Browser.SwitchTo().Frame(frames[2]);
                Driver.Browser.FindElement(By.XPath("//span[@class='InputContainer']/input[@name='cvc']")).SendKeys("123");
                Driver.Browser.SwitchTo().DefaultContent();
                if (!Driver.Browser.FindElement(By.Id("save-card")).Selected)
                    Driver.Browser.FindElement(By.XPath("//label[@for='save-card']")).CustomClick();
                Driver.Browser.FindElement(By.XPath("//button[@type='submit']")).CustomClick();
            }
        }
        [When(@"Click place order")]
        public void WhenClickPlaceOrder()
        {
        }
        [When(@"I accept consent and save")]
        public void WhenIAcceptConsentAndSave()
        {
            Thread.Sleep(12000);
            Driver.BrowserWait.WaitForPageLoad();
            orderConsentPage.sampleConsentAU();
            
        }
        [When(@"Order sample")]
        public void WhenOrderSample()
        {
            Thread.Sleep(12000);
            Driver.Browser.FindElement(By.XPath("//button[contains(.,'Continue sampling')]"), 10).ScrollTo().WaitForElementToBeClickable().Click();
        }
        [When(@"I {string} complimentary item")]
        public void WhenIAddOrSkipComplimentaryItem(string complimentaryItem)
        {
            Driver.Browser.FindElement(By.XPath("//span[contains(., 'No thanks, do not add')]"), 60).ScrollTo().WaitForElementToBeClickable();
            Thread.Sleep(1000);
            if (string.Equals(complimentaryItem, "add"))
            {
                if (!Driver.Browser.FindElement(By.XPath("//label[contains(@for,'380NCH0001')]"), 60).Selected)
                {
                    Driver.Browser.FindElement(By.XPath("//label[contains(@for,'380NCH0001')]"), 60).Click();
                    Driver.Browser.FindElement(By.XPath("//button[contains(@class,'c-quantity-selector__increase-btn')]"), 30).Click();
                }
                Driver.Browser.FindElement(By.XPath("//span[contains(., 'Add selected') or contains(., 'Proceed')]"), 60)
                    .ScrollTo().WaitForElementToBeClickable().Click();
                Thread.Sleep(1000);
            }
            else if (string.Equals(complimentaryItem, "do not add"))
            {
                Driver.Browser.FindElement(By.XPath("//button[@data-testid='skip-complementary-btn']"), 60)
                    .ScrollTo().Click();
                Thread.Sleep(1000);
            }
        }
        [Then(@"Success screen is shown")]
        public void ThenSuccessScreenIsShown()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Assert.IsTrue(Driver.Browser.
                FindElement(By.XPath("//div/h3[contains(., 'Thank you for')]"), 60).Displayed);
        }
        [Then(@"Order number equals to order number on Profile page")]
        public void ThenOrderNumberEqualsToOrderNumberOnProfilePage()
        {
            var text_order = Driver.Browser.FindElement(By.XPath("//div/p[contains(., 'order ID')]"), 60).Text;
            int start = text_order.IndexOf("#") + "#".Length;
            int end = text_order.IndexOf(".");
            var orderNo_order = text_order.Substring(start, end - start);
            ThenIClickAccount();
            var orderlist = Driver.Browser.FindElements(By.XPath("//div[@data-testid='order-status-number']"), 60);
            var text_profile = orderlist[0].Text;
            string pattern = "[A-Z]{3}[0-9]{4,}";
            var orderNo_profile = Regex.Match(text_profile, pattern);
            //Order number\r\nWAU81602
            Assert.AreEqual(orderNo_order, orderNo_profile.Value);
        }
        [Given(@"I selected product category")]
        public void GivenISelectedProductCategory()
        {
            Driver.Browser.FindElement(By.XPath("//a[contains(@href, 'continence-care') and @class='c-ob__link']"), 60).
                WaitForElementToBeClickable().CustomClick();
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(2000);
            try
            {
                Driver.Browser.FindElement(By.XPath("//div[contains(., 'Intermittent') and @data-testid='product__primary-category-item-name']"), 20).
                    WaitForElementToBeClickable().CustomClick();
            }
            catch
            {
            }
            //try
            //{
            //    Driver.Browser.FindElement(By.XPath("//div/figure/img[@alt='Coloplast']"), 20).
            //    WaitForElementToBeClickable().Click();
            //}
            //catch
            //{
            //}
        }
        [Then(@"Info about product is shown on product card")]
        public void ThenInfoAboutProductIsShownOnProductCard()
        {
            bool found = false;
            int count = 0;
            IWebElement card = null;
            while (!found)
            {
                try
                {
                    found = Driver.Browser.FindElement(By.XPath("//a[contains(., 'SpeediCath Compact Set, Female, Straight tip')]"), 20).Displayed;
                    card = Driver.Browser.FindElement(By.XPath("//a[contains(., 'SpeediCath Compact Set, Female, Straight tip')]/..")).ScrollTo();
                }
                catch (WebDriverTimeoutException)
                {
                    Helper.ScrollDown();
                }
                count++;
                if (count == 5)
                    throw new System.Exception("Product was not found");
            }
            Assert.Multiple(() =>
            {
                try
                {
                    Assert.IsTrue(card.FindElement(By.XPath(".//section/div[@class='product__label']")).Text.
                    CaseInsensitiveContains("SpeediCath"));
                }
                catch
                {
                }
                Assert.IsTrue(card.FindElement(By.XPath(".//h2[contains(@class, 'product__header') or contains(@class,'product__card-header')]")).
                    Text.CaseInsensitiveContains("SpeediCath® Compact Set Female"));
            });
        }
        [Then(@"Info about product is shown on product page")]
        public void ThenInfoAboutProductIsShownOnProductPage()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//article//h1"), 60).Text.
                        CaseInsensitiveContains("SpeediCath® Compact Set Female"));
                Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//article//div[@class='product__detail__block ds-text--regular ds-text-body-lg']")).
                    Text.Replace(". ", ".").Replace(" - ", "-").CaseInsensitiveContains("SpeediCath® Compact Set Female is an ideal choice for those who " +
                    "want a simple and convenient all-in-one catheter and bag solution.It is instantly " +
                    "ready-to-use due to its pre-lubricated coating."));
                try
                {
                    Driver.Browser.FindElement(By.XPath("//button[.='Show more ']"), 10).ScrollTo().CustomClick();
                }
                catch
                {
                }
                Assert.AreEqual("Hydrophilic Coated", Driver.Browser.FindElement(By.XPath("//article//div[.='Catheter coating:']/following-sibling::div"), 10).
                    Text);
                Assert.AreEqual("Compact", Driver.Browser.FindElement(By.XPath("//article//div[.='Catheter design:']/following-sibling::div"), 10).
                    Text);
                Assert.AreEqual("Set", Driver.Browser.FindElement(By.XPath("//article//div[.='Catheter type:']/following-sibling::div"), 10).
                    Text);
            });
        }
        [Then(@"I can see consent modal")]
        public void ThenICanSeeConsentModal()
        {
            Thread.Sleep(1000);
            var modal = Driver.Browser.FindElement(By.XPath("//div[@data-testid='consents-modal']"), 10);
            Assert.IsTrue(modal.Displayed);
            var modalTitle = modal.FindElement(By.XPath("//h2[@data-testid='consents-modal__headline']"), 10).Text;
            Assert.IsTrue(modalTitle == "Make sure to sample from the right website");
        }
        [When(@"I choose healthcare proffessional option")]
        public void WhenIChooseHealthcareProffessionalOption()
        {
            Driver.Browser.FindElement(By.XPath("//label[@for='hcp']")).Click();
            Thread.Sleep(1000);
            Driver.Browser.FindElement(By.XPath("//button[@data-testid='consents-modal__redirect-test']"), 10).WaitForElementToBeClickable().Click();
        }
        [Then(@"I'm redirected to the old basket page")]
        public void ThenImRedirectedToTheOldBasketPage()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(Driver.Browser.Title != null && Driver.Browser.Title == "Basket");
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//h2[contains(.,'Your basket')]"), 10).Displayed);
        }
        [When(@"I fulfill hcp delivery info and submit")]
        public void WhenIFulfillHcpDeliveryInfo()
        {
            Thread.Sleep(1000);
            _1secApi = new OnesecmailApi();
            _userEmail = _1secApi.GetRandomEmail().Result;
            var phoneNo = PhoneNoGeneratorAu();
            Driver.Browser.FindElement(By.Id("SampleOrderDetails_FirstName"), 10).ScrollTo().SendKeys("Test");
            Driver.Browser.FindElement(By.Id("SampleOrderDetails_LastName"), 10).SendKeys("Atomation");
            Driver.Browser.FindElement(By.Id("SampleOrderDetails_HcpClinicName"), 10).SendKeys("test clinic");
            Driver.Browser.FindElement(By.Id("SampleOrderDetails_HcpJobTitle"), 5).WaitForElementToBeClickable().Click();
            Driver.Browser.FindElement(By.XPath("//option[@value='Nurse']"), 5).WaitForElementToBeClickable().Click();
            IWebElement phone = null;
            try
            {
                phone = Driver.Browser.FindElement(By.ClassName("phone-mask-input"), 10);
                phone.Click();
                phone.SendKeys(phoneNo);
            }
            catch { }
            Driver.Browser.FindElement(By.Id("SampleOrderDetails_Email"), 10).SendKeys(_userEmail);
            Driver.Browser.FindElement(By.Id("SampleOrderDetails_Address1"), 10).ScrollTo().SendKeys("test address");
            Driver.Browser.FindElement(By.Id("SampleOrderDetails_PostalCode"), 10).SendKeys("2606");
            Driver.Browser.FindElement(By.Id("SampleOrderDetails_City"), 10).SendKeys("Phillip");
            Driver.Browser.FindElement(By.Id("SampleOrderDetails_RegionCode"), 5).WaitForElementToBeClickable().Click();
            Driver.Browser.FindElement(By.XPath("//option[@value='Victoria']"), 5).WaitForElementToBeClickable().Click();
            Driver.Browser.FindElement(By.XPath("//label[@for='SampleOrderDetails_AcceptTerms']"), 10).ScrollTo().Click();
            Driver.Browser.FindElement(By.XPath("//button[@value='next']"), 10).Click();
        }
        [Then(@"I see old success screen")]
        public void ThenISeeOldSuccessScreen()
        {
            Thread.Sleep(3000);
            var thankYou = Driver.Browser.FindElement(By.XPath("//h2[contains(.,'Thank you for requesting your Coloplast sample.')]"), 10);
            Assert.IsTrue(thankYou.Displayed);
        }
        [Then(@"I click Account")]
        public void ThenIClickAccount()
        {
            Driver.Browser.FindElement(By.XPath("//button[contains(., 'Account')]")).WaitForElementToBeClickable().CustomClick();
        }
        [Then(@"I see saved credit card")]
        public void ThenISeeSavedCreditCard()
        {
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//span[contains(., '4242')]"), 30).Displayed);
        }
        [Then(@"I see Marketing permission page")]
        public void ThenISeeMarketingPermissionPage()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(5000);
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//h3[contains(.,'Select how to receive information')]"), 30).Displayed);
            Assert.IsTrue(Driver.Browser.Title.CaseInsensitiveEquals("Marketing Permission"));
        }
        [When(@"I click Skip")]
        public void WhenIClickSkip()
        {
            Driver.Browser.FindElement(By.Name("opt-out"), 10).ScrollTo().Click();
            Thread.Sleep(2000);
        }
        [Then(@"I see Complimentary item page")]
        public void ThenISeeComplimentaryItemPage()
        {
            Thread.Sleep(3000);
            Assert.IsTrue(Driver.Browser.Title != null &&
            Driver.Browser.Title.CaseInsensitiveEquals("Complimentary Items"));
        }
        [Then(@"I am on the Delivery Information page")]
        public void ThenIAmOnTheDeliveryInformationPage()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(Driver.Browser.Title != null
                && Driver.Browser.Title == "Delivery Information");
        }
        [Then("I am on the funding options page")]
        public void ThenIAmOnTheFundingOptionsPage()
        {
            var subtitleElement = Driver.Browser.FindElement(By.XPath("//h2[contains(.,' Payment method ')]"), 20).Displayed;
            Driver.BrowserWait.Until((d) => subtitleElement);
            Assert.IsTrue(Driver.Browser.Title != null &&
            Driver.Browser.Title.CaseInsensitiveEquals("Funding options"));
        }
        [When(@"I select NDIS")]
        public void WhenISelectNDIS()
        {
            Driver.Browser.FindElement(By.XPath("//label[@for='1-fundingType']"), 60).ScrollTo().CustomClick();
        }
        [When(@"I select NDIA-managed")]
        public void WhenISelectNDIA_Managed()
        {
            Driver.Browser.FindElement(By.XPath("//label[@for='ndis-funding-ndia']"), 120).Click();
        }
        [When(@"I fill NDIS participant number")]
        public void WhenIFillNDISParticipantNumber()
        {
            Random r = new Random();
            int rand = r.Next(10000000);
            Helper.ndis = $"43{rand.ToString("D7")}";
            Driver.Browser.FindElement(By.XPath("//input[@name='ParticipantNumber']")).ClearExt().SendKeys(Helper.ndis);
            try
            {
                Driver.Browser.FindElement(By.Id("day")).SendKeys("15");
                Driver.Browser.FindElement(By.Id("month")).SendKeys("03");
                Driver.Browser.FindElement(By.Id("year")).SendKeys("1970");
            }
            catch
            {
            }
        }
        [When(@"I select plan-managed")]
        public void WhenISelectPlan_Managed()
        {
            Driver.Browser.FindElement(By.XPath("//label[@for='ndis-funding-plan']"), 120).Click();
        }
        [When(@"I select self-managed")]
        public void WhenISelectSelf_Managed()
        {
            Driver.Browser.FindElement(By.XPath("//label[@for='ndis-funding-self']"), 120).Click();
        }
        [When(@"I fill plan company data")]
        public void WhenIFillPlanCompanyData()
        {
            Driver.Browser.FindElement(By.XPath("//input[@name='planManagementCompany']"), 20).SendKeys("AAA");
            Driver.Browser.FindElement(By.XPath("//input[@name='ContactPerson']"), 20).SendKeys("Andrii");
            Driver.Browser.FindElement(By.XPath("//input[@name='Email']"), 20).SendKeys("coloplast.test.signup@outllok.com");
            Driver.Browser.FindElement(By.XPath("//input[@name='Phone']"), 20).SendKeys("412123456");
        }
        [When(@"I press continue to summary")]
        public void WhenIPressContinueToSummary()
        {
            Driver.Browser.FindElement(By.XPath("//div[contains(@class, 'c-checkout-ndis')]//button")).CustomClick();
        }
        [When(@"I press continue to payment")]
        public void WhenIPressContinueToPayment()
        {
            try
            {
                Driver.Browser.FindElement(By.XPath("//button[@class='c-checkout-prescription__skipbutton']"), 10).Click();
            }
            catch
            {
            }
            Driver.Browser.FindElement(By.
            XPath("//div[contains(@class, 'checkout-summary-container--desktop')]//button[contains(@class, 'checkout-summary-continue-button')]"), 120).
            ScrollTo().WaitForElementToBeClickable().Click();
        }
        [Given(@"I ordered a product with NDIA-managed funding")]
        public void GivenIOrderedAProductWithNDIA_ManagedFunding()
        {
            GivenIOpenedMainPage();
            GivenISelectedAProduct();
            GivenISelectedStandardPack();
            GivenIPressedAddToBasket();
            WhenIGoToCheckout();
            WhenISelectNDIS();
            WhenIProceedToPayment();
            WhenISelectNDIA_Managed();
            WhenIFillNDISParticipantNumber();
            WhenIPressContinueToSummary();
            WhenIAcceptConsent();
            WhenIPressContinueToPayment();
            ThenSuccessScreenIsShown();
        }
        [Then(@"I navigate to My account page")]
        public void ThenINavigateToMyAccountPage()
        {
            reordering.navigateToMyAccountPage();
        }
        [Then(@"I click on product")]
        public void ThenIClickOnProduct()
        {
            Driver.Browser.FindElement(By.XPath("//div[@data-testid='product-details']"), 10).WaitForElementToBeClickable().Click();
        }
        [Then(@"I am on the product page")]
        public void ThenIAmOnTheProductPage()
        {
            Thread.Sleep(3000);
            Assert.IsTrue(Driver.Browser.Title != null && Driver.Browser.Title == "SpeediCath® Compact Set Female");
        }
        [Then(@"I change payment method to {string}")]
        public void ThenIChangePaymentMethodTo(string method)
        {
            if (method == "NDIS")
            {
                WhenISelectNDIS();
                Driver.Browser.FindElement(By.XPath("//button[@data-testid='continue']"), 10).ScrollTo().Click();
                Thread.Sleep(1000);
                Driver.Browser.FindElement(By.XPath("//label[@for='2-fundingOption'"), 10).ScrollTo().Click();
            }
            else if (method == "self pay")
            {
            }
            else
            {
                throw new Exception("No such payment method!");
            }
        }
        [Then(@"I pressed Add to basket")]
        public void ThenIPressedAddToBasket()
        {
            reordering.AddToBasket();
        }
        /*************************Start Scenario: Delivery is not free while reordering / South Africa**************************/
        [Given(@"South Africa Multisite site is opened")]
        public void GivenSouthAfricaMultisiteSiteIsOpened()
        {
            Driver.Navigate(ConfigurationManager.AppSettings.Get("zaurl"));
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//a[@href='/' and (@class='c-nav-logo__link')]"), 30).Displayed);
            Assert.IsTrue(Driver.Browser.Title != null && Driver.Browser.Title.CaseInsensitiveEquals("Coloplast South Africa"));
        }
        [Given(@"I logged to SF site")]
        public void GivenILoggedToSFSite()
        {
            Driver.Browser.FindElement(By.XPath("//a[@title='Login']")).WaitForElementToBeClickable().Click();
            loginPage.Email.Click();
            loginPage.Email.SendKeys(ConfigurationManager.AppSettings.Get("zalogin"));
            loginPage.Password.Click();
            loginPage.Password.SendKeys(ConfigurationManager.AppSettings.Get("zapassword"));
            loginPage.LoginBtn.Click();
            Thread.Sleep(4000);
        }
        [Then("I navigate to My account page and add items to basket")]
        public void ThenINavigateToMyAccountPageAndAddItemsToBasket()
        {
            reordering.SFnavigateToMyAccountPage();
        }
        [Then("Flyoutbasket displayed with Delivery charges")]
        public void ThenFlyoutbasketDisplayedWithDeliveryCharges()
        {
            IWebElement heading = Driver.Browser.FindElement(By.XPath("//h1[normalize-space()='Shopping basket']"));
            Assert.AreEqual(heading.Text, "Shopping basket");
        }
        [Then("Delivery charges displayed on flyoutbasket")]
        public void ThenDeliveryChargesDisplayedOnFlyoutbasket()
        {
            Thread.Sleep(4000);
            IWebElement arrowBtn = Driver.Browser.FindElement(By.XPath("//span[@data-icon-name='chevron-up']//*[name()='svg']"));
            arrowBtn.ScrollTo().WaitForElementToBeClickable().Click();
        }
        [Then(@"Delivery charges successfuly verified on flyoutbasket")]
        public void ThenDeliveryChargesSuccessfulyVerifiedOnFlyoutbasket()
        {
            string deliveryPrice = "Gratis";
            IWebElement deliveryNotFree = Driver.Browser.FindElement(By.XPath("//dd[normalize-space()='R95,00']"));
            Assert.AreNotEqual(deliveryNotFree.Text, deliveryPrice);
        }
        [Then(@"I emptied the basket and test case successfuly completed")]
        public void ThenIEmptiedTheBasketAndTestCaseSuccessfulyCompleted()
        {
            GivenBasketIsEmpty();
        }
        /*************************End Scenario: Delivery is not free while reordering/ South Africa**************************/
        /*************************Start- Update delivery details from Order Summary page***********************************/
        [Then(@"I edit my first name and last name in delivery address")]
        public void ThenIEditMyFirstNameAndLastNameInDeliveryAddress()
        {
            multipleaddressPage.updateAddressOnSummarypage();
            Console.WriteLine("First Name updated to  : " + ConfigurationManager.AppSettings.Get("fname"));
        }
        [Then(@"address update successfuly")]
        public void ThenAddressUpdateSuccessfuly()
        {
            GivenBasketIsEmpty();
            Console.WriteLine("First Name updated to  : " + ConfigurationManager.AppSettings.Get("fname"));
            Console.WriteLine("Last Name updated to  : " + ConfigurationManager.AppSettings.Get("lname"));
        }
        /*************************End- Update delivery details from Order Summary page***********************************/
        /*************************Start- Update Payment details from Order Summary page***********************************/
        [Then(@"I edit the payment details and fill NDIS payment details")]
        public void ThenIEditThePaymentDetailsAndFillNDISPaymentDetails()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(1000);
            bool funding = false;
            try
            {
                funding = Driver.Browser.FindElement(By.XPath("//div[contains(.,'OwnFunding') and (@class='content')]"), 10).Displayed;
            }
            catch
            {
                Console.WriteLine("No such element!");
            }
            if (funding)
            {
                reordering.NavigateToPaymentPage();
                reordering.SelctNDISPayment();
                reordering.NdisParticipant();
            }
        }
        [Then(@"payment details update successfully")]
        public void ThenPaymentDetailsUpdateSuccessfully()
        {
            reordering.validateFundingChange();
        }
        [Then(@"I continue with order")]
        public void ThenIContinueWithOrder()
        {
            Thread.Sleep(3000);
            Driver.Browser.FindElement(By.XPath("//button[contains(.,'Continue funded')]"), 20).ScrollTo().WaitForElementToBeClickable().Click();
        }

        [Then(@"user update payment type from NDIS to own funding")]
        public void ThenUserUpdatePaymentTypeFromNDISToOwnFunding()
        {
           
        }

        [Then(@"Funding update from NDIS to own funding")]
        public void ThenFundingUpdateFromNDISToOwnFunding()
        {
            Thread.Sleep(1000);
            bool funding = false;
            try
            {
                funding = Driver.Browser.FindElement(By.XPath("//span[contains(., 'Funding') or contains(.,'Own funding')]"), 10).Displayed;
            }
            catch
            {
                Console.WriteLine("No such elements!");
            }
            if (!funding)
            {
                reordering.NavigateToPaymentPage();
                reordering.SelectOwnFunding();
            }
        }
        /*************************End- Update Payment details from Order Summary page***********************************/
        private string PhoneNoGeneratorAu()
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();
            sb.Append("412");
            for (int i = 0; i < 6; i++)
            {
                var digit = rnd.Next(0, 9);
                sb.Append(digit);
            }
            return sb.ToString();
        }
        #region
        /*************************Start-  Pay by SEPA while reordering on DE version***********************************/
        [Given(@"South German Multisite site is opened")]
        public void GivenSouthGermanMultisiteSiteIsOpened()
        {
            Driver.Navigate(ConfigurationManager.AppSettings.Get("deUrl"));
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//a[@href='/' and (@class='c-nav-logo__link')]"), 30).Displayed);
        }
        [Then(@"I logged to DE site")]
        public void ThenILoggedToDESite()
        {
            Driver.Browser.FindElement(By.XPath("//nav[@class='c-nav-service c-nav-service--desktop']//span[@class='c-nav-service__text'][normalize-space()='Einloggen']")).WaitForElementToBeClickable().Click();
            loginPage.Email.Click();
            loginPage.Email.SendKeys(ConfigurationManager.AppSettings.Get("delogin"));
            loginPage.Password.Click();
            loginPage.Password.SendKeys(ConfigurationManager.AppSettings.Get("depassword"));
            loginPage.LoginBtn.Click();
            Thread.Sleep(4000);
            Assert.IsTrue(Driver.Browser.Title != null && Driver.Browser.Title.CaseInsensitiveEquals("Coloplast Homecare - Broschüre für freiverkäufliche Produkte"));
            //GivenBasketIsEmpty();
        }
        [Then(@"Continue checkout")]
        public void ThenContinueCheckout()
        {
            reordering.DEnavigateToMyAccountPage();
        }
        [When(@"I select SEPA pay on Payment page")]
        public void WhenISelectSEPAPayOnPaymentPage()
        {
            paymentPage.SepaPaymentForDE();
        }
        [Then(@"I order successfully")]
        public void ThenIOrderSuccessfully()
        {
            Console.WriteLine("OrderAProductSteps with SEPA payment successful");
        }
        /*************************END-  Pay by SEPA while reordering on DE version*************************************/
        /*************************Start-  Checkout as guest with Sample in basket - AU version*************************/
        [Then(@"I navigate to speedicath-flex smaple product page")]
        public void ThenINavigateToSpeedicath_FlexSmapleProductPage()
        {
            Driver.Navigate(ConfigurationManager.AppSettings.Get("brawa3210"));
        }
        [Then(@"I added a smaple to the basket and hit order free sample button")]
        public void ThenIAddedASmapleToTheBasketAndHitOrderFreeSampleButton()
        {
            GivenSelectedSample();
            GivenIPressedAddToBasket();
        }
        [Then(@"Pop modal displayed")]
        public void ThenPopModalDisplayed()
        {
            consumerHCPmodal.SelectConsumer();
        }
        [Then(@"I selected Procced without registration on Login modal")]
        public void ThenISelectedProccedWithoutRegistrationOnLoginModal()
        {
            consumerHCPmodal.loginModalProceedWithoutReg();
        }
        [Then(@"filled the dteails on dleivery infomartion page")]
        public void ThenFilledTheDteailsOnDleiveryInfomartionPage()
        {
            deliveryInfoPage.fillDetailsOnPageMultisite();
        }
        [Then(@"completed sampling consnet permisision")]
        public void ThenCompletedSamplingConsnetPermisision()
        {
            orderConsentPage.sampleConsentAU();
        }

        [Then(@"comleted Marketing permisision")]
        public void ThenComletedMarketingPermisision()
        {
            
            marketingPage.Accpet();
        }
        [Then(@"order summary page veryfied delivery details and click on continure button")]
        public void ThenOrderSummaryPageVeryfiedDeliveryDetailsAndClickOnContinureButton()
        {
            orderSummary.continueSampling();
        }
        [Then(@"Sample order placed successfuly and I am navigated to order confrimation page")]
        public void ThenSampleOrderPlacedSuccessfulyAndIAmNavigatedToOrderConfrimationPage()
        {

            ThenSuccessScreenIsShown();
        }
        /*************************End-  Checkout as guest with Sample in basket - AU version*******************************/
        /*************************Start-  Checkout as guest with OOP in basket - FI version*************************/
        [Then(@"I navigate to speedicath flex set  product page")]
        public void ThenINavigateToSpeedicathFlexSetProductPage()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Driver.Navigate(ConfigurationManager.AppSettings.Get("speedicath"));
            //label[@for='add-to-basket-action-buy']
        }
        [Then(@"I added a item to the basket and hit continue")]
        public void ThenIAddedAItemToTheBasketAndHitContinue()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(3000);
            IWebElement buyBtn = Driver.Browser.FindElement(By.XPath(" //label[@for='add-to-basket-action-buy']"));
            buyBtn.ScrollTo().WaitForElementToBeClickable().Click();
        }
        [Then("Click Checkout CTA on flyout basket")]
        public void ThenClickCheckoutCTAOnFlyoutBasket()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(3000);
            Driver.Browser.FindElement(By.XPath("//button[contains(., 'Lisää tilaukseen') or contains(.,'button-add-to-basket')]"), 60).
                WaitForElementToBeClickable().CustomClick();
            Thread.Sleep(3000);
            Driver.Browser.FindElement(By.XPath("//button[contains(., 'Siirry tilaamaan') or contains(.,'Add to basket')]"), 60).
                WaitForElementToBeClickable().CustomClick();
        }
        [Then("Click Proceed without registration link")]
        public void ThenClickProceedWithoutRegistrationLink()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(5000);
            consumerHCPmodal.loginModalProceedWithoutRegFI();
        }
        [Then(@"Entered all delivery information")]
        public void ThenEnteredAllDeliveryInformation()
        {
            Driver.BrowserWait.WaitForPageLoad();
            deliveryInfoPage.fillDetailsOnFinland();
        }
        [Then(@"Accpeted Order Consent and  marketing permission")]
        public void ThenAccpetedOrderConsentAndMarketingPermission()
        {
            Driver.BrowserWait.WaitForPageLoad();
            orderConsentPage.acceptOrderConsentFI();
            marketingPage.Accpet();
        }
        [Then("Click Proceed to payment CTA on summary page")]
        public void ThenClickProceedToPaymentCTAOnSummaryPage()
        {
            Driver.BrowserWait.WaitForPageLoad();
            orderSummary.continueOrderFIN();
        }
        [When(@"I entered the card details and click payment")]
        public void WhenIEnteredTheCardDetailsAndClickPayment()
        {
            Driver.BrowserWait.WaitForPageLoad();
            paymentPage.finalndCard();
        }
        [Then(@"OOP order successfully placed without user registration")]
        public void ThenOOPOrderSuccessfullyPlacedWithoutUserRegistration()
        {
            Driver.BrowserWait.WaitForPageLoad();
            orderConfirmationPage.confirmationFIN();
        }
        /*************************End-  Checkout as guest with OOP in basket - FI version*************************/
        /*************************Start-  Tax is free delivery address according Spain islands- Spain version*************************/
        [Then(@"I logged in on Spain website")]
        public void ThenILoggedInOnSpainWebsite()
        {
            Driver.Browser.FindElement(By.XPath("//a[@title='Login']")).WaitForElementToBeClickable().Click();
            Driver.BrowserWait.WaitForPageLoad();
            loginPage.Email.Click();
            loginPage.Email.SendKeys(ConfigurationManager.AppSettings.Get("SpainLogin"));
            Thread.Sleep(4000);
            loginPage.Password.Click();
            loginPage.Password.SendKeys(ConfigurationManager.AppSettings.Get("SpainPassword"));
            loginPage.LoginBtn.Click();
            Thread.Sleep(4000);
        }
        [Then(@"I navigate to My Account page on Spain")]
        public void ThenINavigateToMyAccountPageOnSpain()
        {
            reordering.NavigateToMyAccountPageSPAIN();
        }
        [Then(@"Flyoutbasket displayed with TAX charges")]
        public void ThenFlyoutbasketDisplayedWithTAXCharges()
        {
            reordering.TaxisnotfreeSpain();
        }
        [Then("I continued to deliveryinfo page and entered address details")]
        public void ThenIContinuedToDeliveryinfoPageAndEnteredAddressDetails()
        {
            deliveryInfoPage.fillDetailsOnSPAIN();
        }
        [Then("I navigate to order summary page and verified Tax amount for the order")]
        public void ThenINavigateToOrderSummaryPageAndVerifiedTaxAmountForTheOrder()
        {
            paymentPage.spanCard();
        }
        [Then("Completed tax is free  Order of Valleseco city in Las Palmas Province")]
        public void ThenCompletedTaxIsFreeOrderOfVallesecoCityInLasPalmasProvince()
        {
            orderConfirmationPage.confirmationSpain();
            Console.WriteLine("tax fee is successfuly validate to Spain postalc codes");
        }

        [When(@"I fill delivery info deatils")]
        public void WhenIFillDeliveryInfoDeatils()
        {
           deliveryInfoPage.fillDetailAUNewReg();
        }

        [When(@"I accept marketing permission")]
        public void WhenIAcceptMarketingPermission()
        {
            marketingPage.Accpet();
        }
        #endregion
    }
}
