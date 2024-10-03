using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Drivers;
using EmailWrapper;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Lilial.Steps
{
    [Binding]
    internal class SignUpSteps
    {
        private readonly OnesecmailApi _1secApi;
        private readonly string _userEmail;

        public SignUpSteps()
        {
            _1secApi = new OnesecmailApi();
            _userEmail = _1secApi.GetRandomEmail().Result;
        }

        [Given(@"SignUp flow is started")]
        [Then(@"SignUp flow is started")]

        public void GivenSignUpFlowIsStarted()
        {
            WhenIClickRegister();
        }

        [When(@"I click register")]
        public void WhenIClickRegister()
        {
            Thread.Sleep(2000);

            try
            {
                Driver.Browser.FindElement(By.XPath("//nav[@class='c-nav-service c-nav-service--desktop']//a[@data-flow-name='SignUp']"), 20).WaitForElementToBeClickable().Click();
            }
            catch
            {
                Driver.Browser.FindElement(By.XPath("//span[contains(., 'Login')]"), 60).WaitForElementToBeClickable().Click();
                Driver.Browser.FindElement(By.Id("signUpNow"), 60).WaitForElementToBeClickable().Click();
            }

            Driver.Browser.FindElement(By.Id("hcp-consent"), 60).WaitForElementToBeClickable().Click();
            Driver.Browser.FindElement(By.XPath("//button[@data-testid='submitButton']"), 20).WaitForElementToBeClickable().Click();

        }
        [Then(@"start SignUp flow")]
        public void ThenStartSignUpFlow()
        {
            Thread.Sleep(3000);
            Driver.BrowserWait.WaitForPageLoad();
            Driver.Browser.FindElement(By.Id("hcp-consent"), 60).WaitForElementToBeClickable().Click();
            Driver.Browser.FindElement(By.XPath("//button[@data-testid='submitButton'] "), 20).WaitForElementToBeClickable().Click();
        }


        [When(@"I enter new email")]
        [When(@"I write email address")]
        public void WhenIEnterNewEmail()
        {
            Thread.Sleep(6000);
            Driver.Browser.FindElement(By.Id("email"), 60).SendKeys(_userEmail);
        }

        [When(@"Click Send code button")]
        public void WhenClickSendCodeButton()
        {
            Driver.Browser.FindElement(By.Id("emailVerificationControl_but_send_code"), 60).WaitForElementToBeClickable().Click();
            Thread.Sleep(5000);
        }

        [When(@"I got verification code from email")]
        public Task WhenIGotVerificationCodeFromEmail()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(5000);
            var code = GetVerificationCode().Result;

            Driver.Browser.FindElement(By.XPath("//input[@id='emailVerificationCode']"), 600).SendKeys(code);
            try
            {
                Driver.Browser.FindElement(By.Id("emailVerificationControl_but_verify_code"), 10).WaitForElementToBeClickable().Click();
                Driver.BrowserWait.WaitForPageLoad();
                Driver.Browser.FindElement(By.Id("continue"), 10).WaitForElementToBeClickable().Click();
            }
            catch { }

            return Task.CompletedTask;
        }

        [When(@"Create a new password")]
        public void WhenCreateANewPassword()
        {
            Driver.Browser.FindElement(By.Id("newPassword"), 60).WaitForElementToBeClickable().SendKeys("Qwerty123");
            Driver.Browser.FindElement(By.Id("reenterPassword"), 60).WaitForElementToBeClickable().SendKeys("Qwerty123");
        }

        [Then(@"B2C page is opened")]
        public void ThenBCPageIsOpened()
        {
            Driver.BrowserWait.WaitForPageLoad();

            Assert.IsTrue(Driver.Browser.Url.CaseInsensitiveContains("b2clogin.com"));
            //Assert.IsTrue(Driver.Browser.Url.CaseInsensitiveContains("sharedtsweaadlilialb2c.b2clogin.com"));
        }

        [Then(@"New account is created")]
        public void ThenNewAccountIsCreated()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Thread.Sleep(5000);
            var completeProfileBtn = Driver.Browser.FindElement(By.XPath("//div[contains(@class, 'modal')]//h2[contains(.,'Compte client créé')]"), 60);

            Assert.IsTrue(completeProfileBtn.Displayed);
        }

        [When(@"I click Create account button")]
        public void WhenIClickCreateAccountButton()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Driver.Browser.FindElement(By.Id("continue"), 60).WaitForElementToBeClickable().Click();
        }

        [Given(@"B2C account is created")]
        public void GivenBCAccountIsCreated()
        {
            GivenSignUpFlowIsStarted();
            WhenIEnterNewEmail();
            WhenClickSendCodeButton();
            WhenIGotVerificationCodeFromEmail();
            WhenCreateANewPassword();
            WhenIClickCreateAccountButton();

            System.Threading.Thread.Sleep(1000);
        }

        [Given(@"I clicked Complete Contact details")]
        public void GivenIClickedCompleteContactDetails()
        {
            Driver.Browser.FindElement(By.XPath("//div[@id='Contact' or @id='Delivery']//a[@class='c-profile__link']"), 60).CustomClick();
        }

        [Given(@"I clicked Complete My Profile")]
        [Then(@"I clicked Complete My Profile")]
        public void GivenIClickedCompleteMyProfile()
        {
            Driver.Browser.FindElement(By.XPath("//div[contains(@class, 'modal')]//a[@href='/my-account/' and contains(@class,'button')]"), 60).WaitForElementToBeClickable().Click();
        }

        [Given(@"I clicked Contact Details")]
        [Then(@"I clicked Contact Details")]
        public void GivenIClickedContactDetails()
        {
            Driver.Browser.FindElement(By.XPath("//a[@title='Profile']"), 60).WaitForElementToBeClickable().Click();
        }


        [When(@"I fill Profile data")]
        public void WhenIFillProfileData()
        {
            Driver.Browser.FindElement(By.XPath("//input[@data-field-name='firstName']"), 60).SendKeys("TEST");
            Driver.Browser.FindElement(By.XPath("//input[@data-field-name='lastName']"), 5).SendKeys("TESTER");
            Driver.Browser.FindElement(By.XPath("//input[@data-field-name='phoneNumber']"), 5).Click();
            Driver.Browser.FindElement(By.XPath("//input[@data-field-name='phoneNumber']"), 5).SendKeys(PhoneNoGeneratorAu());
            Driver.Browser.FindElement(By.XPath("//input[@data-field-name='addressLine1']"), 5).SendKeys("7 Shea St");
            Driver.Browser.FindElement(By.XPath("//input[@data-field-name='addressLine2']"), 5).SendKeys("");
            Driver.Browser.FindElement(By.XPath("//input[@data-field-name='postalCode']"), 5).ScrollTo();
            Driver.Browser.FindElement(By.XPath("//input[@data-field-name='postalCode']"), 5).SendKeys("2606");
            Driver.Browser.FindElement(By.XPath("//input[@data-field-name='city']"), 5).SendKeys("Phillip");
            Driver.Browser.FindElement(By.XPath("//*[@data-field-name='state']"), 5).WaitForElementToBeClickable().Click();
            Driver.Browser.FindElement(By.XPath("//li[@id='Victoria']"), 5).WaitForElementToBeClickable().Click();

            try
            {
                Driver.Browser.FindElement(By.XPath("//input[@data-field-name='personalId']"), 5).SendKeys("34123");
            }
            catch
            {
            }

            System.Threading.Thread.Sleep(1000);
        }

        [When(@"I save changes")]
        public void WhenISaveChanges()
        {
            Driver.Browser.FindElement(By.XPath("//button[@type='submit']"), 60).WaitForElementToBeClickable().Click();
            Thread.Sleep(10000);
        }

        [When(@"I click continue")]
        public void WhenIClickContinue()
        {
            Driver.Browser.FindElement(By.Id("continue"), 10).WaitForElementToBeClickable().Click();
        }

        [When(@"I click forgot password")]
        public void WhenIClickForgotPassword()
        {
            Driver.Browser.FindElement(By.Id("forgotPassword"), 15).WaitForElementToBeClickable().Click();
        }

        [When(@"I fullfil personal details")]
        public void WhenIFullfilPersonalDetails()
        {
            Driver.Browser.FindElement(By.Name("DeliveryInformation.BillingAddress.FirstName"), 60)
                .WaitForElementToBeClickable().SendKeys("John Doe");

            Driver.Browser.FindElement(By.Name("DeliveryInformation.BillingAddress.LastName"), 60)
                .WaitForElementToBeClickable().SendKeys("AutomatedTest" + DateTime.Now.ToString());

            //Driver.Browser.FindElement(By.Name("DeliveryInformation.BillingAddress.PhoneNumber"), 60)
            //    .WaitForElementToBeClickable().SendKeys(PhoneNoGenerator());

            /* Driver.Browser.FindElement(By.CssSelector("button[type='submit']"), 60)
                 .WaitForElementToBeClickable().Click();*/

            /* Driver.Browser.FindElement(By.XPath("//button[contains(., 'Create Account')]"), 60)
                 .WaitForElementToBeClickable().Click();*/

            Driver.Browser.FindElement(By.XPath("//span[@class='c-create-account__buttons']/button"), 60)
                 .WaitForElementToBeClickable().CustomClick();


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
            WhenIEnterNewEmail();
            WhenClickSendCodeButton();
            WhenIGotVerificationCodeFromEmail();
            WhenCreateANewPassword();
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//button[contains(.,'Continuer')]"), 60).Displayed);
            Driver.Browser.FindElement(By.XPath("//button[contains(.,'Continuer')]")).Click();
        }

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

        private async Task<string> GetVerificationCode()
        {
            OneSecMailResponse readEmailContent = null;
            Thread.Sleep(6000);
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