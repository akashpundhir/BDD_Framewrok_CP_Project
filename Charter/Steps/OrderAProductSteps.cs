using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Reqnroll;
using SeleniumExtras.WaitHelpers;

namespace Multisite.Steps
{
    [Binding]
    public class OrderAProductSteps
    {
        [Given(@"I am on a {string} product page")]
        [When(@"I am on a {string} product page")]
        [Then(@"Page of {string} I searched is open")]
        public void GivenIAmOnAProductPage(string product)
        {
            Driver.BrowserWait.WaitForPageLoad();

            try
            {
                Driver.Browser.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"), 20).
                    WaitForElementToBeClickable().Click();

                Driver.BrowserWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.
                    Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll")));

            }
            catch
            {
            }

            var productURL = "";
            if (product.Equals("Brava"))
            {
                productURL = ConfigurationManager.AppSettings.Get("url") + "coloplast/ostomy-care/brava/brava-protective-sheet/";
            }
            else if (product.Equals("Adhesive"))
            {
                productURL = ConfigurationManager.AppSettings.Get("url") + "coloplast/ostomy-care/brava/brava-adhesive-remover/brava-adhesive-remover-spray/";
            }
            else if (product.Equals("SenSura"))
            {
                productURL = ConfigurationManager.AppSettings.Get("url") + "coloplast/ostomy-care/sensura-mio-hospital-assortment/sensura-mio-high-output/";
            }
            Driver.Navigate(productURL);
            Thread.Sleep(1000);
            Assert.IsTrue(Driver.Browser.Title.CaseInsensitiveContains("Brava® Adhesive Remover Spray") || Driver.Browser.Title.CaseInsensitiveContains("SenSura® Mio High Outpu") || Driver.Browser.Title.CaseInsensitiveContains("Brava® Protective Sheet"));
        }

        [Given(@"I am on My Account page")]
        public void GivenIAmOnMyAccountPage()
        {
            var url = ConfigurationManager.AppSettings.Get("url") + "my-account/";
            Driver.Navigate(url);
            Assert.IsTrue(Driver.Browser.Title != null && Driver.Browser.Title.CaseInsensitiveContains("My account"));
        }

        [Given(@"I have Order Template set up in SF")]
        public void GivenIHaveOrderTemplateSetUpInSF()
        {
            Assert.IsTrue(Driver.Browser.FindElement(By
                .XPath("//div[@data-testid='product-details']"), 60).Displayed);
        }

        [Given(@"I selected standard {string} pack")]
        [When(@"I selected standard {string} pack")]
        public void GivenISelectedStandardPack(string product)
        {
            Driver.Browser.FindElement(By.XPath("//span[contains(., 'Standard pack') or contains(., 'standard pack') " +
                "or contains(., 'I want to buy') or contains(., 'i want to buy') " +
                "or contains(., 'I want to order') or contains(., 'i want to order')]"), 60);
                        
            try
            {
                Driver.Browser.FindElement(By.XPath("//label[@for='selectVariant']")).ScrollTo()
                    .WaitForElementToBeClickable().CustomClick();

                Thread.Sleep(1000);    

                if (product.Equals("Brava"))
                {
                    Driver.Browser.FindElement(By.XPath
                        ("//label[contains(@for, ('variant_032105'))" +
                        "and not(contains(@class,'c-select__option--unspecified'))]"))
                        .WaitForElementToBeClickable().CustomClick();
                }
                else if (product.Equals("SenSura"))
                {
                    Driver.Browser.FindElement(By.XPath
                        ("//label[contains(@for, ('variant_186600'))" +
                        "and not(contains(@class,'c-select__option--unspecified'))]"))
                        .ScrollTo().WaitForElementToBeClickable().CustomClick();
                }
            }
            catch
            {
            }

            Driver.Browser.FindElement(By.XPath("//span[contains(., 'Standard pack') or contains(., 'standard pack') " +
                "or contains(., 'I want to buy') or contains(., 'i want to buy') " +
                "or contains(., 'I want to order') or contains(., 'i want to order')]")).
                WaitForElementToBeClickable().CustomClick();
        }

        [Given(@"I selected sample")]
        public void GivenISelectedSample()
        {
            //Driver.Browser.FindElement(By.XPath("//span[contains(., 'I want to sample')]"), 60);
            
            Driver.Browser.FindElement(By.XPath("//label[@for='selectVariant']"), 10).WaitForElementToBeClickable().CustomClick();
            Driver.Browser.FindElement(By.XPath("//label[normalize-space()='12012 - Brava Adhesive Remover Spray XL 75ml']"), 10).WaitForElementToBeClickable().CustomClick();
            /*try
            {
                Driver.Browser.FindElement(By.XPath("//label[@for='selectVariant']")).
                    WaitForElementToBeClickable().CustomClick();

                Driver.Browser.FindElement(By.XPath("//label[contains(@for, 'variant_032105') and " +
                    "not(contains(@class,'c-select__option--unspecified'))]")).
                    WaitForElementToBeClickable().CustomClick();
            }
            catch
            {
            }*/

            Driver.Browser.FindElement(By.XPath("//span[contains(., 'I want to sample')]")).
                WaitForElementToBeClickable().CustomClick();
        }

        [Given(@"I selected quantity")]
        public void GivenISelectedQuantity()
        {
            Driver.Browser.FindElement(By.XPath("//button[@class='ds-quantity-selector__button ds-quantity-selector__button--increase']"),60)
                .ScrollTo().WaitForElementToBeClickable().Click();
        }

        [Given(@"I pressed Add to basket")]
        [When(@"I pressed Add to basket")]
        public void GivenIPressedAddToBasket()
        {
            Driver.Browser.FindElement(By.XPath("//button[contains(., 'Add to basket') or contains(., 'Add sample to basket')]"), 60).ScrollTo().
                WaitForElementToBeClickable().Click();
        }

        [Given(@"I added {string} products to basket")]
        public void GivenIAddedMyProductsToBasket(string input)
        {
            string arg;
            if (string.Equals(input, "Brava"))
            {
                arg = "Brava";
            }
            else
            {
                arg = "SenSura";
            }
            GivenILoggedIn("without");
            GivenBasketIsEmpty();
            GivenIAmOnAProductPage(arg);
            GivenISelectedStandardPack(arg);
            GivenISelectedQuantity();
            GivenIPressedAddToBasket();
            WhenIGoToCheckout();
        }

        [Given(@"I added {string} products and complimentary item to basket")]
        public void GivenIAddedMyProductsAndComplimentaryItemToBasket(string input)
        {
            GivenILoggedIn("without");
            GivenBasketIsEmpty();
            
            GivenISelectedQuantity();
            GivenIPressedAddToBasket();
            WhenIGoToCheckout();
        }

        [Given(@"Basket is empty")]
        public void GivenBasketIsEmpty()
        {
            Driver.BrowserWait.WaitForPageLoad();
            var basketIcon = Driver.Browser.FindElement(By.XPath("//nav[contains(@class, 'c-nav-basket c-nav-basket--desktop')]"), 10);
            var elementsInBasket = Driver.Browser.IsElementExists(By.XPath("//span[contains(@class, 'c-nav-basket__count')]"));

            if (elementsInBasket)
            {
                try
                {
                    basketIcon.FindElement(By.XPath("//span[contains(@class, 'c-nav-basket__count')]"), 10).CustomClick();
                    Thread.Sleep(2000);
                    var items = Driver.Browser.FindElements(By.XPath("//span[@data-icon-name='delete']//*[name()='svg']"), 10);

                    //while (Driver.Browser.FindElement(By.XPath("//span[@data-icon-name='delete']//*[name()='svg']"), 10).Displayed)
                    foreach (var item in items)
                    {
                        try
                        {
                            Driver.Browser.FindElement(By.XPath("//span[@data-icon-name='delete']//*[name()='svg']"), 10)
                            .WaitForElementToBeClickable().Click();
                            Thread.Sleep(1000);
                        }
                        catch (Exception)
                        {
                            throw new Exception("Basket is empty");
                        }
                    }
                }
                catch(Exception) 
                { 
                    throw new Exception("Something went wrong"); 
                }
                finally
                {
                    Driver.Browser.FindElement(By.XPath("//button[@data-testid='flyoutCloseButton']"), 10).WaitForElementToBeClickable().Click();
                    Thread.Sleep(1000);
                }
            }
        }

        [When(@"I go to checkout")]
        public void WhenIGoToCheckout()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Driver.Browser.FindElement(By.XPath("//button[contains(., 'Go to checkout')]"), 60).ScrollTo().WaitForElementToBeClickable().Click();
        }

        [When(@"I remove product from basket")]
        public void WhenIRemoveProductFromBasket()
        {
            var basketIcon = Driver.Browser.FindElement(By.XPath("//nav[contains(@class, 'c-nav-basket c-nav-basket--desktop')]"), 10);
            var elementsInBasket = Driver.Browser.IsElementExists(By.XPath("//span[contains(@class, 'c-nav-basket__count')]"));

            if (elementsInBasket)
            {
                try
                {
                    basketIcon.FindElement(By.XPath("//span[contains(@class, 'c-nav-basket__count')]"), 10).CustomClick();
                    Thread.Sleep(2000);
                }
                catch (Exception ex)
                {

                }

                var productInBasket = Driver.Browser.FindElement(By.XPath("//li[contains(.,'Mio High Output')]"), 10);
                productInBasket.FindElement(By.XPath("//button[@title='remove']"), 15).Click();
            }
        }

        [When(@"I {string} complimentary item")]
        public void WhenIAddOrSkipComplimentaryItem(string complimentaryItem)
        {
            Driver.Browser.FindElement(By.XPath("//span[contains(., 'Do not add')]"), 60).ScrollTo().WaitForElementToBeClickable();
            Thread.Sleep(1000);
            if (string.Equals(complimentaryItem,"add")) 
            {
                if (!Driver.Browser.FindElement(By.XPath("//label[contains(@for,'380NCH0001')]"), 60).Selected)
                {
                    try
                    {
                        Driver.Browser.FindElement(By.XPath("//label[contains(@for,'380NCH0001')]"), 60).Click();
                        Driver.Browser.FindElement(By.XPath("//button[contains(@class,'c-quantity-selector__increase-btn')]"), 30).Click();
                    }
                    catch
                    {

                    }
                }

                Driver.Browser.FindElement(By.XPath("//button[contains(., 'Add selected') or contains(., 'Proceed')]"),60)
                    .ScrollTo().WaitForElementToBeClickable().Click();
                Thread.Sleep(1000);
            }
            else if(string.Equals(complimentaryItem, "do not add"))
            {
                Driver.Browser.FindElement(By.XPath("//button[contains(., 'Do not add')]"), 60)
                    .ScrollTo().WaitForElementToBeClickable().Click();
                Thread.Sleep(1000);
            }
        }

        [When(@"I submit order request")]
        public void WhenISubmitOrderRequest()
        {
            Thread.Sleep(1000);
            var desktopCheckout = Driver.Browser.FindElement(By.XPath("//div[contains(@class, 'checkout-summary-container--desktop')]"), 60);

            desktopCheckout.FindElement(By.XPath("//button[contains(., 'Place order') or contains(., 'Place sample order')]"), 10).ScrollTo().WaitForElementToBeClickable().Click();

        }

        [When(@"I tick a reason for change")]
        public void WhenITickAReasonForChange()
        {
            Thread.Sleep(1000);
            Driver.Browser.FindElement(By.XPath("//label[@for='This Order only']"), 60)
                .WaitForElementToBeClickable().Click();
        }

        [When(@"I click Save and continue")]
        public void WhenIClickSaveAndContinue()
        {
            Driver.Browser.FindElement(By.XPath("//button[contains(., 'Save and continue')]"), 60).ScrollTo()
                .WaitForElementToBeClickable().Click();
        }

        [When(@"I add my product to basket")]
        public void WhenIClickOnAddSelectedToBasket()
        {
            Driver.Browser.FindElement(By.XPath("//button[contains(.,'Add selected to basket')]"), 60)
                .ScrollTo().WaitForElementToBeClickable().Click();
        }

        [When(@"I add my products and complimentary to basket")]
        public void WhenIAddMyProductsAndComplimentaryItemToBasket()
        {
            Driver.Browser.FindElement(By.XPath("//div[@data-index='1']/div/div/input[@type='checkbox']"), 10).Click();

            Driver.Browser.FindElement(By.XPath("//button[contains(.,'Add selected to basket')]"), 60)
                .ScrollTo().WaitForElementToBeClickable().Click();
        }

        [When(@"I confirm quantity")]
        public void WhenIConfirmQuantity()
        {
            try
            {
                Driver.Browser.FindElement(By.XPath("//span[contains(.,'Got it']"), 60)
                .WaitForElementToBeClickable().Click();
            }
            catch (Exception ex)
            {

            }
        }

        [Then(@"Login to your account modal is shown")]
        public void ThenLoginToYourAccountModalIsShown()
        {   
            Thread.Sleep(1000);
            Assert.IsTrue(Driver.Browser.FindElement(By.Id("modal-title-2"), 60).Displayed);
        }

        [Given(@"I logged in {string} cutting template")]
        public void GivenILoggedIn(string arg)
        {
            var basicSteps = new BasicSteps();

            basicSteps.WhenIPressLoginButton();
            basicSteps.WhenIEnterEmail(arg);
            basicSteps.WhenIEnterPassword();
            basicSteps.WhenIPressLogInButton();
            basicSteps.ThenISuccessfullyLoggedIn();
        }

        [Given(@"I opened main page")]
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

        [When(@"I select self pay")]
        public void WhenISelectSelfPay()
        {
            Driver.Browser.FindElement(By.XPath("//label[@for='0-funding']"), 60).CustomClick();
            Driver.Browser.FindElement(By.XPath("//button[@type='submit']")).WaitForElementToBeClickable().CustomClick();
        }

        [When(@"I proceed to payment")]
        public void WhenIProceedToPayment()
        {
            try
            {
                Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.FirstName']"), 10).ScrollTo().ClearExt().SendKeys("TEST");
                Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.LastName']")).ClearExt().SendKeys("TESTER");
                if (Helper.MultisiteEmail !="" || Helper.MultisiteEmail != null)
                    Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.PhoneNumber']")).
                        ClearExt().SendKeys(Helper.GetPhoneNumberFromGeneratedEmail(Helper.MultisiteEmail));
                else
                    Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.PhoneNumber']")).ClearExt().SendKeys("412137105");
                
                Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.AddressLine1']")).ClearExt().SendKeys("7 Shea St");
                Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.PostalCode']")).ClearExt().SendKeys("2606");
                Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.City']")).ClearExt().SendKeys("Phillip");
                
                try
                {
                    Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.PersonalId']")).ScrollTo().SendKeys("34123");
                    
                }
                catch
                {
                }
                Driver.Browser.FindElement(By.Id("dropdown-button")).ScrollTo().Click();
                Driver.Browser.FindElement(By.Id("Victoria")).ScrollTo().Click();


                try
                {
                    if (!Driver.Browser.FindElement(By.Id("saveToProfile")).Selected)
                        Driver.Browser.FindElement(By.XPath("//label[@for='saveToProfile']")).CustomClick();
                }
                catch
                {
                }

                try
                {
                    if (!Driver.Browser.FindElement(By.Id("deliveryTermsAndConditions")).Selected)
                        Driver.Browser.FindElement(By.XPath("//label[@for='deliveryTermsAndConditions']")).CustomClick();
                }
                catch
                {
                }

                Driver.Browser.FindElement(By.XPath("//button[@type='submit']")).CustomClick();
            }
            catch
            {
            }
        }

        [When(@"I accept consent")]
        public void WhenIAcceptConsent()
        {
            Driver.Browser.FindElement(By.XPath("//button[@data-order-consent-event='accept']"), 120).Wait(1).ScrollTo().Click();


            Driver.Browser.FindElement(By.XPath("//button[@data-consent-event='accept']"), 30);

            try
            {
                Driver.Browser.FindElement(By.XPath("//label[@for='Email']")).Click();
            }
            catch
            {
            }
            Driver.Browser.FindElement(By.XPath("//button[@data-consent-event='accept']"), 30).Wait(1).ScrollTo().Click();

            try
            {
                Driver.Browser.FindElement(By.XPath("//button[@class='c-checkout-prescription__skipbutton']"), 30).Click();
            }
            catch
            {
            }
        }


        [When(@"I pay with selected card")]
        public void WhenIPayWithSelectedCard()
        {
            try
            {
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

        [Then(@"I see Change reason page")]
        public void ThenISeeChangeReasonPage()
        {
            Thread.Sleep(3000);
            Assert.IsTrue(Driver.Browser.Title != null && 
                Driver.Browser.Title.CaseInsensitiveEquals("Reason for change"));
        }

        [Then(@"I see Complimentary item page")]
        public void ThenISeeComplimentaryItemPage()
        {
            Thread.Sleep(3000);
            Assert.IsTrue(Driver.Browser.Title != null && 
                Driver.Browser.Title.CaseInsensitiveEquals("Complimentary product step page"));
        }

        [Then(@"I see Reimbursement page")]
        public void ThenISeeReimbursmentPage()
        {
            Thread.Sleep(3000);
            Assert.IsTrue(Driver.Browser.Title != null &&
                Driver.Browser.Title.CaseInsensitiveEquals("Reimbursement page"));
        }

        [Then(@"Success screen is shown")]
        public void ThenSuccessScreenIsShown()
        {
            if (Driver.Browser.Title == "Order Confrimation")
            {
                Assert.IsTrue(Driver.Browser.
                    FindElement(By.CssSelector(".ds - text - heading - 3xl.ds - text--default"), 90).Displayed);
                Assert.IsTrue(Driver.Browser.
                FindElement(By.CssSelector(".c-global-checkout__icon.c-global-checkout__icon--success"), 90).Displayed);
                Console.WriteLine("Confrimation page displayed");

            }
            else
            {
                Assert.IsTrue(Driver.Browser.
                    FindElement(By.XPath("//h3[contains(.,'Your order request has been submitted') or contains(.,'Thank you for your sample request')]"), 90).Displayed);
                Assert.IsTrue(Driver.Browser.
                    FindElement(By.CssSelector(".c-global-checkout__icon.c-global-checkout__icon--success"), 90).Displayed);

            }
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

            start = text_profile.IndexOf("\r\n") + "\r\n".Length;
            end = text_profile.IndexOf("\r\nIn Progress");

            var orderNo_profile = text_profile.Substring(start, end - start);

            Assert.AreEqual(orderNo_order, orderNo_profile);
        }

        [Given(@"I selected a product")]
        public void GivenISelectedAProduct()
        {
            GivenISelectedProductCategory();

            Driver.Browser.FindElement(By.XPath("//a[contains(@href, '/coloplast/ostomy-care/brava/brava-powder/')]"), 30)
                .ScrollTo().Click();
        }

        [Given(@"I selected product category")]
        public void GivenISelectedProductCategory()
        {
            Driver.Browser.FindElement(By.XPath("//button[contains(.,'All products')]"), 60)
                .WaitForElementToBeClickable().Click();

            Driver.Browser.FindElement(By.XPath("//a[contains(@href, '/products/stoma/') and @class='']"), 30)
                .WaitForElementToBeClickable().Click();

            Driver.Browser.FindElement(By.XPath("//div[contains(., 'Daily care products') and @data-testid='product__primary-category-item-name']"), 60)
                .ScrollTo().WaitForElementToBeClickable().Click();

            Thread.Sleep(1000);

            Driver.Browser.FindElement(By.XPath("//img[@alt='Coloplast']"), 60).
                WaitForElementToBeClickable().Click();

        }

        [Then(@"Info about product is shown on product card")]
        public void ThenInfoAboutProductIsShownOnProductCard()
        {
            Thread.Sleep(1000);
            var cards = Driver.Browser.FindElements(By.XPath("//article[contains(@class, 'product product__card')]"),60);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(cards.Count > 0);
                Assert.IsTrue(cards[4].FindElement(By.XPath("//img[contains(@alt, 'Brava Skin Barrier Spray')]"), 30).Displayed);
                Assert.IsTrue(cards[4].FindElement(By.XPath("//a[contains(@href, '/coloplast/ostomy-care/brava/brava-barrier/brava-skin-barrier-spray/')]"), 30).Displayed);
            });
            
            
        }

        [Then(@"Info about product is shown on product page")]
        public void ThenInfoAboutProductIsShownOnProductPage()
        {
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//span[contains(., 'Choose size')]"),60).Displayed);
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//span[contains(., 'I want to sample')]"), 60).Displayed);
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//span[contains(., 'I want to order')]"), 60).Displayed);
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//span[contains(., 'Add to basket')]"), 60).Displayed);
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//button[@data-testid='button-add-to-basket']"), 60).Displayed);
            Assert.IsFalse(Driver.Browser.FindElement(By.XPath("//button[@data-testid='button-add-to-basket']"), 60).Enabled);
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

        [When(@"I select NDIS")]
        public void WhenISelectNDIS()
        {
            Driver.Browser.FindElement(By.XPath("//label[@for='1-funding']/span[@class='headline']"), 60).ScrollTo().CustomClick();
        }

        [When(@"I select NDIA-managed")]
        public void WhenISelectNDIA_Managed()
        {
            Driver.Browser.FindElement(By.XPath("//label/span[@class='headline' and contains(., 'NDIA')]"), 60).Click();
        }

        [When(@"I fill NDIS participant number")]
        public void WhenIFillNDISParticipantNumber()
        {
            Random r = new Random();
            int rand = r.Next(10000000);
            Helper.ndis = $"43{rand.ToString("D7")}";

            Driver.Browser.FindElement(By.XPath("//input[@name='ParticipantNumber']")).ClearExt().SendKeys(Helper.ndis);
        }

        [When(@"I select plan-managed")]
        public void WhenISelectPlan_Managed()
        {
            Driver.Browser.FindElement(By.XPath("//label/span[@class='headline' and contains(., 'Plan-managed')]"), 20).Click();
        }

        [When(@"I select self-managed")]
        public void WhenISelectSelf_Managed()
        {
            Driver.Browser.FindElement(By.XPath("//label/span[@class='headline' and contains(., 'Self-managed ')]"), 20).Click();
        }

        [When(@"I fill plan company data")]
        public void WhenIFillPlanCompanyData()
        {
            Driver.Browser.FindElement(By.XPath("//input[@name='PlanManagementCompany']"), 20).SendKeys("AAA");
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
            XPath("//div[contains(@class, 'checkout-summary-container--desktop')]//a[contains(@class, 'checkout-summary-continue-button')]"), 120).
            ScrollTo().WaitForElementToBeClickable().Click();
        }

        [Then(@"I can see complimentary items are added")]
        public void ThenICanSeeComplimentaryItemsAreAdded()
        {
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//h2[contains(.,'Complimentary items')]"), 60).Displayed);
        }

        [Then(@"Error popup is displayed")]
        public void ThenErrorPopupIsDisplayed()
        {
            Assert.IsTrue(Driver.Browser.FindElement(By
                .XPath("//div[@aria-errormessage='Something went wrong when updating your order.']"), 60).Displayed);
        }

        [Then(@"I can see product and complimentary item added to the basket")]
        public void ThenICanSeeItemsInBasket()
        {
            var elementsInBasket = Driver.Browser.FindElement(By.ClassName("c-global-basket__line-items"), 30);
            var numberOfItemsInBasket = elementsInBasket.FindElements(By.XPath("//li[@data-testid='basketLineItem']"), 10).Count;
            Assert.IsNotNull(numberOfItemsInBasket);
            Assert.IsTrue(numberOfItemsInBasket == 2);
        }

        [Then(@"All items are removed from basket")]
        public void ThenBasketIsEmpty()
        {
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//span[contains(.,'Your shopping basket is empty')]"), 10).Displayed);
        }

        private async Task DeleteBasketAsync()
        {

            var test = "https://sandbox05-coloplastcharter.coloplast.com/api/global-basket/basket?language=en-GB";
            //using HttpResponseMessage response = await httpClient.GetAsync(test);

            //using HttpResponseMessage response = await httpClient.DeleteAsync(ConfigurationManager.AppSettings.Get(clearBasketUrl));
            //response.EnsureSuccessStatusCode();

            //var jsonResponse = await response.Content.ReadAsStringAsync();

            //var a = jsonResponse.ToString();
            // Expected output
            //   DELETE https://jsonplaceholder.typicode.com/todos/1 HTTP/1.1
            //   {}
        }

    }
}
