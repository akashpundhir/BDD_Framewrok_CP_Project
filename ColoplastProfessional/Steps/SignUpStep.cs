using Core.Drivers;
using EmailWrapper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using Reqnroll;
using ColoplastProfessional.PageObject;
using System.Diagnostics.Tracing;
namespace ColoplastProfessional.Steps
{
    [Binding]
    public class SignUpStep
    {
        private readonly OnesecmailApi _1secApi;
        private readonly string _userEmail;
        public SignUpStep()
        {
            _1secApi = new OnesecmailApi();
            _userEmail = _1secApi.GetRandomEmail().Result;
    }
        [Given(@"Professional site is opened")]
        [Then(@"Professional site is opened")]
        public void GivenProfessionalSiteIsOpened()
        {
            Driver.Navigate(ConfigurationManager.AppSettings.Get("url"));
        }
        [Given(@"User accepted the cookies")]
        public void GivenUserAcceptedTheCookies()
        {
            try
            {
                Driver.Browser.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"), 10).
                    WaitForElementToBeClickable().Click();
                //Driver.BrowserWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.
                //    Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll")));
            }
            catch
            {
            }
        }
        [Given(@"User clicks Sign Up now")]
        public void GivenUserClicksSignUpNow()
        {
            #if !SANDBOXHCP
                Driver.Browser.FindElement(By.Id("signUpNow"), 60).WaitForElementToBeClickable().Click();
            #endif
        }
        [Given(@"User opens {string} form")]
        public void GivenUserOpensForm(string p0)
        {
            Driver.Navigate($"{ConfigurationManager.AppSettings.Get("url")}{p0}");
        }
        [When(@"I got verification code from email")]
        public void WhenIGotVerificationCodeFromEmail()
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
        }
        [When(@"User creates new B2C Account")]
        [Given(@"User creates new B2C Account")]
        public async Task GivenUserCreatesNewB2CAccount()
        {
            Thread.Sleep(2000);
            var email = Driver.Browser.FindElement(By.Id("email"), 15);
            email.Clear();
            email.SendKeys(_userEmail);
            Driver.Browser.FindElement(By.Id("emailVerificationControl_but_send_code"), 60).WaitForElementToBeClickable().Click();
            Thread.Sleep(8000);
            var code = GetVerificationCode().Result;
            Thread.Sleep(5000);
            IWebElement codeVerElement = null;
            try
            {
                codeVerElement = Driver.Browser.FindElement(By.CssSelector("#emailVerificationCode"), 60).ScrollTo();
            }
            catch { }
            codeVerElement.SendKeys(code);
            Driver.Browser.FindElement(By.Id("emailVerificationControl_but_verify_code"), 60).WaitForElementToBeClickable().Click();
            Driver.Browser.FindElement(By.Id("newPassword"), 60).WaitForElementToBeClickable().SendKeys("Qwerty123");
            Driver.Browser.FindElement(By.Id("reenterPassword"), 60).WaitForElementToBeClickable().SendKeys("Qwerty123");
            Driver.Browser.FindElement(By.Id("continue"), 60).WaitForElementToBeClickable().Click();
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
        [Then(@"I successfully logged in")]
        public void ThenISuccessfullyLoggedIn()
        {
            Driver.BrowserWait.Until(drv => drv.Url.CaseInsensitiveContains(ConfigurationManager.AppSettings.Get("url")));
            Driver.BrowserWait.WaitForPageLoad();
            Assert.IsTrue(Driver.Browser.Title != null &&
                Driver.Browser.Title.CaseInsensitiveEquals("My Account") ||
                Driver.Browser.Title.CaseInsensitiveContains("Multisite"));
        }
        [Then(@"Account is created")]
        public void ThenAccountIsCreated()
        {
            Driver.BrowserWait.Until(drv => !drv.Url.Contains("b2clogin"));
            Assert.IsTrue(Driver.Browser.Url.CaseInsensitiveContains("profile"));
        }
        [Then(@"I want browser to be restarted")]
        public void ThenIWantBrowserToBeRestarted()
        {
            Driver.Browser.Quit();
            Thread.Sleep(2000);
            Driver.StartBrowser(Helper.BrowserTypes.Edge, 120);
            Driver.Browser.Manage().Cookies.DeleteAllCookies();
        }
        [When(@"User fills Complete profile")]
        public void WhenUserFillsCompleteProfile()
        {
            #if SANDBOXHCP
                Driver.Browser.FindElement(By.Id("City"), 60).WaitForElementToBeClickable().SendKeys("Aberdeen");
                Driver.Browser.FindElement(By.Id("PostalCode")).SendKeys("01234");
                Driver.Browser.FindElement(By.XPath("//div[@class='c-profile__submit']/button")).ScrollTo().Click();
            #endif
            //Helper.HCPEmail = email;
        }
        [Then(@"Account is created - {string} page is shown")]
        public void ThenAccountIsCreated_PageIsShown(string p0)
        {
            Driver.BrowserWait.Until(drv => drv.Url.CaseInsensitiveContains($"{p0}"));
            Assert.IsTrue(Driver.Browser.Url.CaseInsensitiveContains($"{p0}"));
        }
        [Given(@"User clicks Login")]
        [When(@"User clicks Login")]
        public void GivenUserClicksLogin()
        {
            #if !SANDBOXHCP
                Driver.Browser.FindElement(By.XPath("//div[@class='c-nav-call-to-action']//a[contains(@href,'b2clogin')]"), 60).Click();
            #else
                Driver.Navigate($"{ConfigurationManager.AppSettings.Get("url")}hcp-registration");
            #endif
        }
        [When(@"I click forgot password")]
        public void WhenIClickForgotPassword()
        {
            Driver.Browser.FindElement(By.Id("forgotPassword"), 15).WaitForElementToBeClickable().Click();
        }
        [Then(@"I see reset password flow is started")]
        public void ThenISeeResetPasswordFlowIsStarted()
        {
            Thread.Sleep(3000);
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//p[contains(.,'Reset password')]"), 60).Displayed);
            Assert.IsTrue(Driver.Browser.Title != null && Driver.Browser.Title.CaseInsensitiveEquals("Coloplast Forgot Password"));
        }
        [When(@"User fills info")]
        public void WhenUserFillsInfo()
        {
            Driver.Browser.FindElement(By.Id("FirstName"), 60).ScrollTo().SendKeys("TEST");
            Driver.Browser.FindElement(By.Id("LastName"), 60).ScrollTo().SendKeys("TESTER");
            try
            {
                var title = new SelectElement(Driver.Browser.FindElement(By.Id("Title")).ScrollTo());
                title.SelectByValue("Mr");
            }
            catch
            {
            }
            Driver.Browser.FindElement(By.Id("Email"), 60).ScrollTo().SendKeys(_userEmail + Keys.Enter);
            try
            {
                Driver.Browser.FindElement(By.XPath("//button[contains(., 'Next')]")).ScrollTo().Click();
            }
            catch
            {
            }
            var job = new SelectElement(Driver.Browser.FindElement(By.Id("JobTitle"), 60).ScrollTo());
            job.SelectByValue("nurse");
            Driver.Browser.FindElement(By.XPath("//span[contains(., 'Choose one or more')]"), 60).ScrollTo().Click();
            Driver.Browser.FindElement(By.XPath("//label[@for='ostomy']"), 60).ScrollTo().Click();
            Driver.Browser.FindElement(By.XPath("//span[contains(., 'Ostomy')]"), 60).ScrollTo().Click();
            try
            {
                Driver.Browser.FindElement(By.Id("HospitalFacility")).ScrollTo().SendKeys("TEST FACILITY");
            }
            catch
            {
            }
            try
            {
                Driver.Browser.FindElement(By.XPath("//label[@for='ConsentAgreement']")).ScrollTo().Click();
            }
            catch
            {
            }
            Driver.Browser.FindElement(By.XPath("//button[contains(., 'Create account') or contains(., 'Next')]")).ScrollTo().Click();
            try
            {
                Driver.Browser.FindElement(By.XPath("//button[@type='submit']"), 10).ScrollTo().Click();
            }
            catch 
            {
            }
        }
        [Then(@"I logged in successfuly")]
        public void ThenILoggedInSuccessfuly()
        {
            Login();
        }
        public void Login(string email = null, string password = null)
        {
            var emailInput = Driver.Browser.FindElement(By.Id("email"), 60);
            var passwordInput = Driver.Browser.FindElement(By.Id("password"), 60);
            if (String.IsNullOrEmpty(email))
                emailInput.WaitForElementToBeClickable().SendKeys(ConfigurationManager.AppSettings.Get("email"));
            else
                emailInput.WaitForElementToBeClickable().SendKeys(email);
            if (String.IsNullOrEmpty(password))
                passwordInput.WaitForElementToBeClickable().SendKeys(ConfigurationManager.AppSettings.Get("password"));
            else
                passwordInput.WaitForElementToBeClickable().SendKeys(password);
            Driver.Browser.FindElement(By.Id("next"), 60).WaitForElementToBeClickable().Click();
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
