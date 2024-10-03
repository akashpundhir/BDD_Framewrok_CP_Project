using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Drivers;
using EmailWrapper;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Charter.Steps
{
    [Binding]
    public class SignUpSteps
    {
        private readonly OnesecmailApi _1secApi;
        private readonly string _userEmail;

        public SignUpSteps()
        {
            _1secApi = new OnesecmailApi();
            _userEmail = _1secApi.GetRandomEmail().Result;
        }

        [Given(@"SignUp flow is started")]
        public void GivenSignUpFlowIsStarted()
        {
            WhenIClickRegister();
        }
        
        [When(@"I click register")]
        public void WhenIClickRegister()
        {
            try
            {
                Driver.Browser.FindElement(By.XPath("//button[contains(., 'Register') or contains(.,'Create an account')]"), 20).WaitForElementToBeClickable().Click();
            }
            catch
            {
                Driver.Browser.FindElement(By.XPath("//span[contains(., 'Login')]"), 60).WaitForElementToBeClickable().Click();
                Driver.Browser.FindElement(By.Id("signUpNow"), 60).WaitForElementToBeClickable().Click();
            }
            try
            {
                Driver.Browser.FindElement(By.Id("hcp-consent"), 60).WaitForElementToBeClickable().Click();
                Driver.Browser.FindElement(By.XPath("//button[contains(., 'I agree')]"), 20).WaitForElementToBeClickable().Click();
            }
            catch { }
        }

        [When(@"I enter new email")]
        [When(@"I write email address")]
        public void WhenIEnterNewEmail()
        {
            Driver.Browser.FindElement(By.Id("email"), 60).SendKeys(_userEmail);
        }

        [When(@"Click Send code button")]
        public void WhenClickSendCodeButton()
        {
            Driver.Browser.FindElement(By.Id("emailVerificationControl_but_send_code"), 60).WaitForElementToBeClickable().Click();
            Thread.Sleep(2000);
        }

        [When(@"I got verification code from email")]
        public void WhenIGotVerificationCodeFromEmail()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(6000);
            var code = GetVerificationCode().Result;
            
            Driver.Browser.FindElement(By.XPath("//input[@id='emailVerificationCode']"), 600).SendKeys(code);
            try
            {
                Driver.Browser.FindElement(By.Id("emailVerificationControl_but_verify_code"), 10).WaitForElementToBeClickable().Click();
                Driver.BrowserWait.WaitForPageLoad();
                Driver.Browser.FindElement(By.Id("continue"), 10).WaitForElementToBeClickable().Click();
            }
            catch { }
        }

        [When(@"Create a new password")]
        public void WhenCreateANewPassword()
        {
            Driver.Browser.FindElement(By.Id("newPassword"), 60).WaitForElementToBeClickable().SendKeys("Qwerty123");
            Driver.Browser.FindElement(By.Id("reenterPassword"), 60).WaitForElementToBeClickable().SendKeys("Qwerty123");
            Thread.Sleep(5000);
        }

        [When(@"I click continue")]
        public void WhenIClickContinue()
        {
            Driver.Browser.FindElement(By.Id("continue"), 10).WaitForElementToBeClickable().Click();
        }

        [When(@"I fullfil personal details")]
        public void WhenIFullfilPersonalDetails()
        {
            Driver.Browser.FindElement(By.Name("DeliveryInformation.BillingAddress.FirstName"), 60)
                .WaitForElementToBeClickable().SendKeys("John Doe");

            Driver.Browser.FindElement(By.Name("DeliveryInformation.BillingAddress.LastName"), 60)
                .WaitForElementToBeClickable().SendKeys("AutomatedTest" + DateTime.Now.ToString());

            Driver.Browser.FindElement(By.Name("DeliveryInformation.BillingAddress.PhoneNumber"), 60)
                .WaitForElementToBeClickable().SendKeys(PhoneNoGenerator());

            /* Driver.Browser.FindElement(By.CssSelector("button[type='submit']"), 60)
                 .WaitForElementToBeClickable().Click();*/

            /* Driver.Browser.FindElement(By.XPath("//button[contains(., 'Create Account')]"), 60)
                 .WaitForElementToBeClickable().Click();*/

            Driver.Browser.FindElement(By.XPath("//span[@class='c-create-account__buttons']/button"), 60)
                 .WaitForElementToBeClickable().CustomClick();
            

        }

        [Then(@"B2C page is opened")]
        public void ThenBCPageIsOpened()
        {
            Driver.BrowserWait.WaitForPageLoad();

            Assert.IsTrue(Driver.Browser.Url.CaseInsensitiveContains("b2clogin.com"));
        }

        [Then(@"New account is created")]
        public void ThenNewAccountIsCreated()
        {
            var xpath = "//a[@data-testid='linkButton']";
            Thread.Sleep(15000);
            var completeProfileBtn = Driver.Browser.FindElement(By.XPath(xpath), 60);
            Assert.IsTrue(completeProfileBtn.Displayed);
        }

        [Then(@"I am able to add or edit delivery details")]
        public void ThenIAmAbleToAddOrEditDeliveryDetails()
        {
            Assert.IsTrue(Driver.Browser.Title != null && Driver.Browser.Title.Equals("Consumer Details"));
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//h1[contains(.,'Add or edit delivery details')]"), 60).Displayed);
        }

        [When(@"I click Create account button")]
        public void WhenIClickCreateAccountButton()
        {
            Driver.Browser.FindElement(By.Id("continue"), 05).WaitForElementToBeClickable().Click();
        }

        //[Given(@"B2C account is created")]
        //public async void GivenBCAccountIsCreated()
        //{
        //    GivenSignUpFlowIsStarted();
        //    await WhenIEnterNewEmail();
        //    WhenClickSendCodeButton();
        //    await WhenIGotVerificationCodeFromEmail();
        //    WhenCreateANewPassword();
        //    WhenIClickCreateAccountButton();
        //    WhenIFullfilPersonalDetails();
        //    ThenNewAccountIsCreated();
        //    Thread.Sleep(1000);
        //}

        [Given(@"I clicked Go to My Profile")]
        [Then(@"I clicked Go to My Profile")]

        public void GivenIClickedGoToMyProfile()
        {
            var xpath = "//a[@href='/my-account/' and contains(.,'Go to My Account')]";
            Driver.Browser.FindElement(By.XPath(xpath), 05).CustomClick();
        }

        public void GivenIClickedCompleteMyProfile()
        {
            var xpath = "//a[@href='/my-account/' and contains(@class,'ds-button--primary ds-button--lg')]";
            Driver.Browser.FindElement(By.XPath(xpath), 60).WaitForElementToBeClickable().Click();
        }

        [Given(@"I clicked delivery Details")]
        public void GivenIClickedContactDetails()
        {
            Driver.Browser.FindElement(By.XPath("//a[@href='/my-account/consumer-contact-details/' and contains(@class'ds-button ds-button--link ds-button--md)]"), 60).WaitForElementToBeClickable().Click();
        }

        [When(@"I go to Profile page")]
        public void WhenIGoToProfilePage()
        {
            Driver.Browser.FindElement(By.XPath("//span[@class='ds-text-heading-lg ds-text--medium' and contains(.,'Profile')]"), 60).ScrollTo().WaitForElementToBeClickable().Click();
        }

        [When(@"I click on Order Hostry")]
        public void WhenIClickOnOrderHistory()
        {
            Driver.Browser.FindElement(By.XPath("//a[@title='Order History']"), 15).ScrollTo().Click();
        }

        [When(@"Click on Delivery Info View")]
        public void WhenIClickOnDeliveryInfoView()
        {
            Driver.Browser.FindElement(By.XPath("//a[@href='/my-account/profile/consumer-contact-details-page/' and contains(.,'View')]"), 60).WaitForElementToBeClickable().CustomClick();
        }

        [When(@"I click edit on address card")]
        public void WhenIClickEditOnAddressCard()
        {
            Driver.Browser.FindElement(By.XPath("//span[contains(.,'Edit')]"), 60).WaitForElementToBeClickable().Click();
        }

        [When(@"I type a valid postcode")]
        [When(@"I fill delivery details")]
        public void WhenITypeAValidPostcode()
        {
            var postcode = Driver.Browser.FindElement(By.XPath("//input[@name='DeliveryInformation.BillingAddress.PostalCode']"),30).ScrollTo();
            postcode.Click();
            Thread.Sleep(1000);
            postcode.SendKeys("pa3");
            Thread.Sleep(1000);
            postcode.SendKeys("2");
            Thread.Sleep(1000);
            postcode.SendKeys("d");
            Thread.Sleep(1000);
            postcode.SendKeys("g");
            Thread.Sleep(1000);
            Driver.Browser.FindElement(By.XPath("//div[@class='ds-text-heading-lg ds-text--bold' and contains(., '4 Mclean Place, Paisley, PA3 2DG')]"), 20).WaitForElementToBeClickable().Click();
            Thread.Sleep(1000);
        }

        [When(@"I Save delivery details")]
        public void WhenISaveDeliveryDetails()
        {
            Driver.Browser.FindElement(By.XPath("//button[contains(., 'Save changes')]"), 30).ScrollTo().Click();
            Thread.Sleep(15000);
        }

        [When(@"I save changes")]
        public void WhenISaveChanges()
        {
            Driver.Browser.FindElement(By.XPath("//button[@type='submit']"), 60).WaitForElementToBeClickable().Click();
        }

        [When(@"I click forgot password")]
        public void WhenIClickForgotPassword()
        {
            Driver.Browser.FindElement(By.Id("forgotPassword"),15).WaitForElementToBeClickable().Click();
        }

        [Then(@"Delivery details are updated")]
        public void ThenDeliveryDetailsAreUpdated()
        {
            WhenIGoToProfilePage();
            Thread.Sleep(1000);
            WhenIClickOnDeliveryInfoView();
            Thread.Sleep(2000);
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//label[@for='shippingAddress']"), 60).Displayed);
        }

        [Then(@"I want browser to be restarted")]
        public void ThenIWantBrowserToBeRestarted()
        {
            Driver.Browser.Quit();
            Thread.Sleep(2000);
            Driver.StartBrowser(Helper.BrowserTypes.Edge, 120);
            Driver.Browser.Manage().Cookies.DeleteAllCookies();
        }

        [Then(@"I see reset password flow is started")]
        public void ThenISeeResetPasswordFlowIsStarted()
        {
            Thread.Sleep(3000);
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//p[contains(.,'Reset password')]"), 60).Displayed);
            Assert.IsTrue(Driver.Browser.Title != null && Driver.Browser.Title.CaseInsensitiveEquals("Coloplast Forgot Password"));
        }

        private string PhoneNoGenerator()
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();
            sb.Append("75");
            for(int i=0; i<8; i++)
            {
                var digit = rnd.Next(0, 9);
                sb.Append(digit);
            }
            return sb.ToString();
        }
        private async Task<string> GetVerificationCode()
        {
            OneSecMailResponse readEmailContent = null;
            Thread.Sleep(7000);
            const int RetryTimes = 120;
            const int WaitTime = 1000;

            for (int i = 0; i < RetryTimes; i++)
            {
                try
                {
                    var latestEmail = await _1secApi.GetLatestMail(_userEmail);

                    if (latestEmail is null)
                    {
                        throw new Exception("Email not recieved... retrying");
                    }

                    readEmailContent = await _1secApi.GetEmailContent(_userEmail, latestEmail.Id);

                    break;
                }
                catch (Exception Ex)
                {
                    Console.WriteLine($"Retry {i + 1}: {Ex.Message}");
                    await Task.Delay(WaitTime);
                }
            }
            var code = OnesecmailApi.GetCodeFromEmail(readEmailContent.HtmlBody);

            return code;
        }
    }
}
