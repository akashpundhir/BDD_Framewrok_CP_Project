using Core.Drivers;
using EmailWrapper;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Reqnroll;

namespace CareConnect.Steps
{
    [Binding]
    public class EnrollmentSteps
    {
        private string originalwindow;
        private ScenarioContext _scenarioContext;

        public EnrollmentSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"User selects new continence enrollment from menu")]
        public void WhenUserSelectsNewContinenceEnrollmentFromMenu()
        {
            Driver.Browser
                .FindElement(By.XPath("//button[.='Create New Enrollment']"), 30)
                .ScrollTo()
                .Click();
            Driver.Browser
                .FindElement(By.XPath("//a[@href='/new-enrollments/new-ic-enrollment/?popup=']"), 30)
                .Click();
        }

        [When(@"User selects new ostomy enrollment from menu")]
        public void WhenUserSelectsNewOstomyEnrollmentFromMenu()
        {
            Driver.Browser.FindElement(By.XPath("//a[contains(.,'My Dashboard')]"), 15).WaitForElementToBeClickable().Click();
            Thread.Sleep(5000);
            Driver.Browser
                .FindElement(By.XPath("//a[contains(.,'New enrollment')]"), 30)
                .ScrollTo()
                .WaitForElementToBeClickable()
                .Click();
            Driver.Browser
                .FindElement(By.XPath("//label[contains(@for,'oc-enrollment/')]"), 30)
                .Click();
            Driver.BrowserWait
                .Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("spinner-overlay")));
        }

        [Given(@"Guest enrollment is opened")]
        public void GivenGuestEnrollmentIsOpened()
        {
            Driver.Browser
                .FindElement(By.XPath("//button[contains(., 'Enroll patient')]"), 30)
                .ScrollTo()
                .Click();
        }

        [When(@"User selects new continence enrollment")]
        public void WhenUserSelectsNewContinenceEnrollment()
        {
            Driver.Browser
                .FindElement(By.Id("/new-enrollments/guest-ic-enrollment/?popup="), 30)
                .Click();
            Driver.Browser
                .FindElement(By.XPath("//a[contains(., 'Start enrollment')]"))
                .Click();
        }

        [When(@"User selects new ostomy enrollment")]
        public void WhenUserSelectsNewOstomyEnrollment()
        {
            Driver.Browser
                .FindElement(By.XPath("//input[@id='/new-enrollments/guest-oc-enrollment/?popup=' and @name='enrollmentType']"), 30)
                .Click();
            Driver.Browser
                .FindElement(By.XPath("//span[contains(.,'Start enrollment')]"),10)
                .ScrollTo()
                .WaitForElementToBeClickable()
                .Click();
        }

        [When(@"User selects Quick form")]
        public void WhenUserSelectsQuickForm()
        {
            Driver.Browser
                .FindElement(By.XPath("//label[contains(@for, '/?type=CareAdvisor')]"), 30)
                .Click();
            Driver.Browser
                .FindElement(By.XPath("//a[contains(., 'Continue')]"))
                .Click();
        }

        [When(@"Guest selects Care Advisor form")]
        public void WhenGuestSelectsCareAdvisorForm()
        {
            Thread.Sleep(1000);
            Driver.Browser
                .FindElement(By.XPath("//label[contains(@for, '/?type=CareAdvisor')]"), 30)
                .Click();
            Thread.Sleep(1000);
            Driver.Browser
                .FindElement(By.XPath("//a[contains(., 'Continue')]"))
                .WaitForElementToBeClickable()
                .Click();
        }

        [When(@"Guest selects OC Product catalog")]
        public void WhenGuestSelectsOCProductCatalog()
        {
            Driver.Browser
                .FindElement(By.XPath("//label[contains(@for, '/?type=FromCatalog')]"), 30)
                .ScrollTo()
                .WaitForElementToBeClickable()
                .Click();
            Thread.Sleep(1000);
            Driver.Browser
                .FindElement(By.XPath("//a[contains(., 'Continue')]"))
                .ScrollTo()
                .WaitForElementToBeClickable()
                .Click();
            Driver.BrowserWait
                .Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("spinner-overlay")));
        }

        [When(@"Guest selects Educational")]
        public void WhenGuestSelectsEducational()
        {
            Driver.Browser
                .FindElement(By.XPath("//label[contains(@for, '/?type=EducationalPreSurgical')]"), 30)
                .ScrollTo()
                .WaitForElementToBeClickable()
                .Click();
            Thread.Sleep(1000);
            Driver.Browser
                .FindElement(By.XPath("//a[contains(., 'Continue')]"),30)
                .ScrollTo()
                .WaitForElementToBeClickable()
                .Click();
        }

        [When(@"User selects Product catalog")]
        public void WhenUserSelectsProductCatalog()
        {
            Driver.Browser
                .FindElement(By.XPath("//label[contains(@for, '/?type=FromCatalog')]"), 30)
                .Click();
            Driver.Browser
                .FindElement(By.XPath("//a[contains(., 'Continue')]"))
                .Click();
        }

        [When(@"User selects Care Advisor form")]
        public void WhenUserSelectsCareAdvisorForm()
        {
            {
                Thread.Sleep(1000);
                Driver.Browser
                    .FindElement(By.Id("CareAdvisor"), 30)
                    .ScrollTo()
                    .WaitForElementToBeClickable()
                    .Click();
                Thread.Sleep(1000);
                Driver.Browser
                    .FindElement(By.XPath("//button[contains(., 'Start enrollment')]"))
                    .ScrollTo()
                    .WaitForElementToBeClickable()
                    .Click();
            }
        }

        [When(@"User selects OC Product catalog")]
        public void WhenUserSelectsOCProductCatalog()
        {
            Thread.Sleep(1000);
            Driver.Browser
                .FindElement(By.XPath("//input[@id='FromCatalog' and @name='ocEnrollmentFormType']"), 30) //("FromCatalog"), 30)
                .ScrollTo()
                .WaitForElementToBeClickable()
                .Click();
            Thread.Sleep(1000);
            Driver.Browser
                .FindElement(By.XPath("//span[contains(., 'Start enrollment')]"))
                .ScrollTo()
                .WaitForElementToBeClickable()
                .Click();
            Driver.BrowserWait
                .Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("spinner-overlay")));
        }

        [When(@"User selects Educational")]
        public void WhenUserSelectsEducational()
        {
            Thread.Sleep(1000);
            Driver.Browser
                .FindElement(By.Id("EducationalPreSurgical"), 30)
                .ScrollTo()
                .WaitForElementToBeClickable()
                .Click();
            Thread.Sleep(1000);
            Driver.Browser
                .FindElement(By.XPath("//span[contains(., 'Start enrollment')]"))
                .ScrollTo()
                .WaitForElementToBeClickable()
                .Click();
        }

        [When(@"User fills Patient info - First Name is {string}")]
        public void WhenUserFillsPatientInfo_FirstNameIs(string p0)
        {
            FillGeneralPatientInfo(p0);
        }

        [When(@"User fills Patient info - Hospital delivery - First Name is {string}")]
        public void WhenUserFillsPatientInfo_HospitalDelivery_FirstNameIs(string p0)
        {
            Driver.Browser
                .FindElement(By.XPath("//input[@value='Hospital']/ancestor::label"), 30)
                .ScrollTo()
                .Click();
            Driver.Browser
                .FindElement(By.Id("hospitalName"), 10)
                .SendKeys("TEST HOSPITAL");
            Driver.Browser
                .FindElement(By.Id("hospitalAddress"), 10)
                .SendKeys("1725 Pine St");
            Driver.Browser
                .FindElement(By.Id("hospitalPostCode"), 10)
                .SendKeys("36106");
            Driver.Browser
                .FindElement(By.Id("hospitalCity"), 10)
                .SendKeys("Montgomery");
            Driver.Browser
                .FindElement(By.Id("hospitalState"))
                .SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);

            FillGeneralPatientInfo(p0);
        }

        [When(@"User fills Care advisor info")]
        public void WhenUserFillsCareAdvisorInfo()
        {
            Driver.Browser
                .FindElement(By.XPath("//input[contains(@value, 'Straight')]/ancestor::label"), 30)
                .ScrollTo()
                .Click();
            Driver.Browser
                .FindElement(By.Id("intermittentSizeDropdown1"))
                .SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            Driver.Browser
                .FindElement(By.XPath("//input[contains(@value, 'Hydrophilic')]/ancestor::label"))
                .ScrollTo()
                .Click();
            GoNext(2);
        }

        [When(@"User selects Product {string}")]
        public void WhenUserSelectsProduct(string p0)
        {
            Driver.Browser
                .FindElement(By.XPath("//input[@role='search']"))
                .ScrollTo()
                .SendKeys(p0);
            Driver.BrowserWait.Until(x => x.FindElement(By.XPath("//span[@class='c-search__product-name']")).Text.Contains(p0));
            Driver.Browser
                .FindElement(By.XPath("//span[@class='c-search__product-name']"), 30)
                .Click();
            Driver.Browser
                .FindElement(By.XPath("//button[@data-testid='select-product-variant-button']"), 30)
                .Click();
            Driver.Browser
                 .FindElement(By.XPath("//button[@data-testid='product-variant-add']"), 30)
                 .Click();
            try
            {
                GoNext(2);
            }
            catch
            {
                GoNext(3);
            }
        }

        [When(@"User fills Patient Condition info")]
        public void WhenUserFillsPatientConditionInfo()
        {
            Driver.Browser
                .FindElement(By.XPath("//input[@value='Colostomy']/ancestor::label"), 30)
                .ScrollTo()
                .Click();
            Driver.Browser
                .FindElement(By.Id("surgeryDate"))
                .SendKeys("01/01/2020");
            Driver.Browser
                .FindElement(By.Id("stomaSize"))
                .SendKeys("5");
            Driver.Browser
                .FindElement(By.XPath("//input[@value='Coloplast']/ancestor::label"), 30)
                .ScrollTo()
                .Click();

            try
            {
                Driver.Browser
                    .FindElement(By.XPath("//input[@value='One piece']/ancestor::label"))
                    .ScrollTo()
                    .Click();
            }
            catch
            {
            }

            Driver.Browser
                .FindElement(By.XPath("//input[@value='Regular']/ancestor::label"), 30)
                .ScrollTo()
                .Click();
            Driver.Browser
                .FindElement(By.XPath("//input[@value='Above the skin']/ancestor::label"), 30)
                .ScrollTo()
                .Click();
            GoNext(2);
        }

        [When(@"User fills Prescription details")]
        public void WhenUserFillsPrescriptionDetails()
        {
            Driver.Browser
                .FindElement(By.XPath("//input[@id='durationOfNeed-option-12']/ancestor::label"))
                .ScrollTo()
                .Click();
            Driver.Browser
                .FindElement(By.XPath("//input[@id='numberOfRefills-option-12']/ancestor::label"))
                .ScrollTo()
                .Click(); 
            FillGeneralPrescriptionDetails();
        }

        [When(@"User fills Prescription details - other")]
        public void WhenUserFillsPrescriptionDetails_Other()
        {
            Driver.Browser
                .FindElement(By.XPath("//input[@id='durationOfNeed-option-1']/ancestor::label"))
                .ScrollTo()
                .Click();
            Driver.Browser
                .FindElement(By.XPath("//input[@id='numberOfRefills-option-1']/ancestor::label"))
                .ScrollTo()
                .Click();
            Driver.Browser
                .FindElement(By.Id("durationOfNeedOther"))
                .ScrollTo()
                .SendKeys("7");
            Driver.Browser
                .FindElement(By.Id("numberOfRefillsOther"))
                .ScrollTo()
                .SendKeys("7");

            FillGeneralPrescriptionDetails();
        }

        [When(@"User fills Supplier and documentation")]
        public void WhenUserFillsSupplierAndDocumentation()
        {
            try
            {
                GoNext(3);
            }
            catch
            {
                GoNext(4);
            }
        }

        [When(@"User fills Supplier and documentation - Preferred supplier")]
        public void WhenUserFillsSupplierAndDocumentation_PreferredSupplier()
        {
            Driver.Browser
                .FindElement(By.XPath("//input[@id='preferredSupplier']/ancestor::label"), 30)
                .ScrollTo()
                .Click();
            Driver.Browser
                .FindElement(By.Id("preferredSupplierOther"))
                .SendKeys("Coloplast");
            WhenUserFillsSupplierAndDocumentation();
        }

        [When(@"User fills Identify healthcare provider")]
        public void WhenUserFillsIdentifyHealthcareProvider()
        {
            Driver.Browser
                .FindElement(By.XPath("//form[@id='hcpInformationForm']//input[@id='firstName']"), 30)
                .SendKeys("TEST");
            Driver.Browser
                .FindElement(By.XPath("//form[@id='hcpInformationForm']//input[@id='lastName']"))
                .SendKeys("TESTER");
            Driver.Browser
                .FindElement(By.XPath("//form[@id='hcpInformationForm']//input[@id='facilityName']"))
                .SendKeys("TEST FACILITY");
            
            Driver.Browser
                .FindElement(By.XPath("//form[@id='hcpInformationForm']//input[@id='email']"))
                .SendKeys("coloplast.test.signup@outlook.com");
            
            try
            {
                Driver.Browser
                    .FindElement(By.XPath("//form[@id='hcpInformationForm']//input[@id='confirmEmail']"))
                    .SendKeys("coloplast.test.signup@outlook.com");
                Driver.Browser
                .FindElement(By.XPath("//form[@id='hcpInformationForm']//input[@id='facilityAddress']"))
                .SendKeys("28 Morrell St");
            }
            catch
            {
            }

            try
            {
                Driver.Browser
                    .FindElement(By.XPath("//form[@id='hcpInformationForm']//input[@id='facilityPhone']"))
                    .SendKeys("14121234567");
            }
            catch
            {
            }

            try
            {
                GoNext(4);
            }
            catch
            {
                GoNext(5);
            }
        }

        [When(@"User fills Sign and Submit prescription")]
        public void WhenUserFillsSignAndSubmitPrescription()
        {
            Driver.Browser
                .FindElement(By.XPath("//span[contains(.,'Send to provider')]"), 15)
                .ScrollTo()
                .Click();

            Driver.Browser
                .FindElement(By.XPath("//form[@id='signAndSubmit']//input[@id='providerName' and not(contains(@placeholder, 'Prescribing'))]"), 30)
                .ScrollTo()
                .SendKeys("TEST PROVIDER");

            Driver.Browser
                .FindElement(By.XPath("//form[@id='signAndSubmit']//input[@id='providerEmail']"))
                .ScrollTo()
                .SendKeys("coloplast.test.signup@outlook.com");

            try
            {
                GoNext(5);
            }
            catch
            {
                GoNext(6);
            }
        }

        [When(@"User fills Sign and Submit prescription - Send to Provider")]
        public void WhenUserFillsSignAndSubmitPrescription_SendToProvider()
        {
            Driver.Browser
                .FindElement(By.XPath("//input[@id='whoShouldSign-option-send-to-provider']/ancestor::label"), 30)
                .ScrollTo()
                .Click();
            WhenUserFillsSignAndSubmitPrescription();
        }

        [When(@"User fills Sign and Submit prescription - Sign now")]
        public void WhenUserFillsSignAndSubmitPrescription_SignNow()
        {
            Driver.Browser
                .FindElement(By.XPath("//input[@id='whoShouldSign-option-sign-now-as-username']/ancestor::label"), 30)
                .ScrollTo()
                .Click();
            Driver.Browser
                .FindElement(By.XPath("//input[@id='iAmAuthorizedToSubmit']/ancestor::label"))
                .ScrollTo()
                .Click();
            Driver.Browser
                .FindElement(By.Id("npiNumber"))
                .SendKeys("1234567890");
            try
            {
                GoNext(5);
            }
            catch
            {
                GoNext(6);
            }
        }

        [When(@"User signs Enrollment form via DocuSign")]
        public void WhenUserSignsEnrollmentFormViaDocuSign()
        {
            var wrapper = new MessageWrapper();
            var messages = wrapper.GetCareConnectEmails("coloplast.test.signup@outlook.com", "Coloplast Care Enrollment form");
            var url = wrapper.GetDocuSignLinkFromEmail(messages);
            originalwindow = Driver.Browser.CurrentWindowHandle;

            Driver.Browser.SwitchTo().NewWindow(WindowType.Tab);
            Driver.Navigate(url);

            SignDocuSignDoc();

            Driver.Browser.SwitchTo().Window(originalwindow);
        }

        [When(@"User signs Enrollment form via DocuSign - Self sign")]
        public void WhenUserSignsEnrollmentFormViaDocuSign_SelfSign()
        {
            SignDocuSignDoc();
        }

        [When(@"User clicks Close on draft popup")]
        public void WhenUserClicksCloseOnDraftPopup()
        {
            Driver.Browser
                .FindElement(By.XPath("//button[@data-testid='closeModel']"), 30)
                .ScrollTo()
                .Click();
        }

        [Then(@"Form is signed - self sign")]
        public void ThenFormIsSigned_SelfSign()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Driver.Browser
                .FindElement(By.XPath("//div[@class='enrollment-form-success-intro']//h1"), 60).Wait(1)
                .Displayed);
                Assert.IsTrue(Driver.Browser
                .FindElement(By.XPath("//div[@class='enrollment-form-success-intro']//h1"), 60)
                .Text
                .CaseInsensitiveContains("Your Coloplast® Care enrollment\r\nform was submitted successfully"));
            });
        }

        [Then(@"Form is signed")]
        public void ThenFormIsSigned()
        {
            //var wrapper = new MessageWrapper();
            //var messages = wrapper.GetCareConnectEmails("coloplast.test.signup@outlook.com", "Completed: Coloplast Care Enrollment form");

            //Assert.IsNotNull(messages); 
            //Assert.AreEqual("Securely manage agreements with just one more step", Driver.Browser
            //    .FindElement(By.XPath("//span[@data-qa='dialog-title']"), 60)
            //    .Text);

            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//img[@src='/globalassets/microsoftteams-image-36-1-1.png']"), 15).Displayed);
            var confirmaption = Driver.Browser.FindElement(By.XPath("//h1[contains(.,'form was submitted successfully')]"), 15).Text;
            Assert.AreEqual("Your Coloplast® Care enrollment\r\nform was submitted successfully", confirmaption);
            
        }

        [When(@"Confirm submitting as a guest")]
        public void WhenConfirmSubmittingAsAGuest()
        {
            Driver.Browser.FindElement(By.XPath("//span[contains(.,'Submit as guest')]"), 30).WaitForElementToBeClickable().Click();
        }

        [Then(@"OC Form is signed")]
        public void ThenOCFormIsSigned()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Driver.Browser
                    .FindElement(By.XPath("//h1[contains(.,'Your Coloplast® Care enrollment')]"), 120)
                    .Displayed);

                Assert.IsTrue(Driver.Browser
                    .FindElement(By.XPath("//a[contains(@href, '/DownloadSignedPdf')]"))
                    .Displayed);
            });
        }

        [Then(@"Enrollment page is opened")]
        public void ThenEnrollmentPageIsOpened()
        {
            Assert.IsTrue(Driver.Browser.Url.EndsWith("guest-ic-enrollment/?type=CareAdvisor"));
        }

        private void FillGeneralPatientInfo(string firstname)
        {
            Driver.Browser
                .FindElement(By.Id("patientInformationForm"), 30)
                .FindElement(By.Id("firstname"), 30)
                .ScrollTo()
                .SendKeys(firstname);
            Driver.Browser
                .FindElement(By.Id("patientInformationForm"))
                .FindElement(By.Id("lastname"))
                .SendKeys("TESTER");
            Driver.Browser
                .FindElement(By.Id("patientInformationForm"))
                .FindElement(By.Id("birthdate"))
                .SendKeys("01/01/1970");
            Driver.Browser
                .FindElement(By.Id("gender"))
                .SendKeys(Keys.ArrowDown + Keys.Enter);
            Driver.Browser
                .FindElement(By.Id("patientInformationForm"))
                .FindElement(By.Id("phone"))
                .SendKeys("14121234567");
            Driver.Browser
                .FindElement(By.Id("patientInformationForm"))
                .FindElement(By.Id("address1"))
                .SendKeys("27 Morrell St");
            Driver.Browser
                .FindElement(By.Id("patientInformationForm"))
                .FindElement(By.Id("city"))
                .SendKeys("Elizabeth");
            Driver.Browser
                .FindElement(By.Id("state"))
                .SendKeys(Keys.ArrowDown + Keys.Enter);
            Driver.Browser
                .FindElement(By.Id("patientInformationForm"))
                .FindElement(By.Id("zipCode"))
                .SendKeys("07201");

            try
            {
                Driver.Browser
                    .FindElement(By.Id("patientInformationForm"))
                    .FindElement(By.XPath("//input[@id='consentAccepted']/ancestor::label"))
                    .ScrollTo()
                    .Click();
            }
            catch
            {
            }

            try
            {
                Driver.Browser
                    .FindElement(By.Id("patientInformationForm"))
                    .FindElement(By.XPath("//input[@id='secondaryConsentAccepted']/ancestor::label"))
                    .ScrollTo()
                    .Click();
            }
            catch
            {
            }

            GoNext(1);
        }

        private void FillGeneralPrescriptionDetails()
        {
            //var element = Driver.Browser.FindElement(By.Id("primaryDiagnosis-option-r33-9"), 10);

            //element.FindElement(By.XPath("//span[@class='formkit-decorator-icon formkit-icon']"), 10)
            //    .ScrollTo()
            //    .Click();

            Driver.Browser
                .FindElement(By.XPath("//input[@value='Chronic/Permanent']/ancestor::label"), 30)
                .ScrollTo()
                .Click();
            Driver.Browser
                .FindElement(By.XPath("//span[contains(.,'R33.9 Retention of Urine')]"),10)
                .ScrollTo()
                .Click();
            Driver.Browser
                .FindElement(By.Id("frequencyOfUse"))
                .SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            GoNext(3);
        }

        private void SignDocuSignDoc()
        {
            try
            {
                Driver.Browser
                    .FindElement(By.XPath("//label[@for='disclosureAccepted']"), 60)
                    .Click();
                Thread.Sleep(5000);
            }
            catch
            {
            }
            
            Driver.Browser
                .FindElement(By.Id("action-bar-btn-continue"), 30)
                .Click();
            Thread.Sleep(5000);
            Driver.Browser
                .FindElement(By.XPath("//div[contains(@class, 'signature-tab-content')]"), 60)
                .Click();
            Thread.Sleep(5000);
            
            try
            {
                Driver.Browser
                    .FindElement(By.XPath("//button[@data-qa='adopt-submit' and @data-group-item='signature']"), 10)
                    .Click();
                Thread.Sleep(5000);
            }
            catch
            {
            }
            
            Driver.Browser
                .FindElement(By.XPath("//img[contains(@src, 'docusign.net/Signing/image.aspx')]"), 60);
            Thread.Sleep(5000);
            Driver.Browser
                .FindElement(By.Id("action-bar-btn-finish"), 30)
                .WaitForElementToBeClickable()
                .Click();
        }

        private void GoNext(int step)
        {
            Driver.Browser
                .FindElement(By.XPath($"//div[contains(@class, 'c-enrollment-step{step-1}')]//div[contains(@class, 'c-enrollment-form-actions')]//button[@type='submit' and not(contains(@class, 'lubricants')) or @type='button' and not(contains(., 'Edit')) and not(contains(., 'Save Draft'))]"))
                .ScrollTo()
                .Click();
            Driver.BrowserWait
                .Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("spinner-overlay")));
        }

        [Then(@"Form is submitted on dashboard for {string} with type {string} and {string} sampled products")]
        public void ThenFormIsSubmittedOnDashboardForWithTypeAndSampledProducts(string firstname, string type, string product)
        {
            if (type == "Continence")
                Thread.Sleep(30000);

            Driver.Browser
                .FindElement(By.XPath($"//a[@href='/dashboard/']"))
                .ScrollTo()
                .Click();
            Driver.BrowserWait
                .Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("spinner-overlay")));
            Thread.Sleep(1000);
            Driver.Browser
                .FindElement(By.XPath("//input[contains(@class, 'c-enrollment-dashboard-search__input')]"))
                .SendKeys($"{firstname} TESTER");
            Driver.Browser
                .FindElement(By.XPath("//button[@data-testid='search-button']"))
                .Click();
            Driver.BrowserWait
                .Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("spinner-overlay")));
            Thread.Sleep(1000);
            var table = Driver.Browser
                .FindElement(By.XPath($"//table[@aria-label='submitted enrollments']"));
            var row = table
                .FindElements(By.XPath("//tr[@data-testid='completed-row']"))
                .ToList()
                .First()
                .ScrollTo();
            Assert.Multiple(() =>
            {
                Assert.IsTrue(row.Text.CaseInsensitiveContains(type));
                Assert.IsTrue(row.Text.CaseInsensitiveContains(product));
            });
        }

        [Then(@"Patient info is shown correctly - Firs Name is '([^']*)'")]
        public void ThenPatientInfoIsShownCorrectly_FirsNameIs(string firstname)
        {
            var summaryItems = Driver.Browser
                .FindElements(By.XPath("//div[@class='c-enrollment-step0']//ul[@class='form-summary']//li"), 30)
                .ToList();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(firstname, summaryItems.Where(x => x.Text.CaseInsensitiveContains("First Name")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).ScrollTo().Text);
                Assert.AreEqual("TESTER", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Last Name")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual("Male", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Gender")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual("1970-01-01", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Date of birth")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual("+1(412)123-4567", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Phone")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual("27 Morrell St", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Address")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual("Elizabeth", summaryItems.Where(x => x.Text.CaseInsensitiveContains("City")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual("Alaska", summaryItems.Where(x => x.Text.CaseInsensitiveContains("State")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual("07201", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Zip code")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                try
                {
                    if(_scenarioContext.ScenarioInfo.Title.Contains("Hospital"))
                    {
                        Assert.AreEqual("Hospital", summaryItems.Where(x => x.Text.CaseInsensitiveContains("patients home or to the hospital")).First()
                            .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                    }
                    else
                    {
                        Assert.AreEqual("Home", summaryItems.Where(x => x.Text.CaseInsensitiveContains("patients home or to the hospital")).First()
                            .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                    }
                    Assert.AreEqual("TEST HOSPITAL", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Hospital name")).First()
                        .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                    Assert.AreEqual("1725 Pine St", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Hospital address")).First()
                        .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                    Assert.AreEqual("36106", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Hospital postal code")).First()
                        .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                    Assert.AreEqual("Montgomery", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Hospital city")).First()
                        .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                    Assert.AreEqual("Alabama", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Hospital state")).First()
                        .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);

                }
                catch
                {
                }
            });
        }

        [Then(@"Patient Condition info is shown correctly")]
        public void ThenPatientConditionInfoIsShownCorrectly()
        {
            var summaryItems = Driver.Browser
                .FindElements(By.XPath("//div[@class='c-enrollment-step1']//ul[@class='form-summary']//li"), 30)
                .ToList();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("Colostomy", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Type of Surgery")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).ScrollTo().Text);
                Assert.AreEqual("2020-01-01", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Date of surgery")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual("5", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Stoma Size")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual("Coloplast", summaryItems.Where(x => x.Text.CaseInsensitiveContains("patient currently wearing")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual("Regular", summaryItems.Where(x => x.Text.CaseInsensitiveContains("area around the stoma")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual("Above the skin", summaryItems.Where(x => x.Text.CaseInsensitiveContains("profile of the stom")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text); 
            });
        }

        [Then(@"Facility info is shown")]
        public void ThenFacilityInfoIsShown()
        {
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//*[contains(@class,'facility-info')]")).ScrollTo().Displayed);
        }

        [Then(@"Product is shown correctly '([^']*)'")]
        public void ThenProductIsShownCorrectly(string p0)
        {
            Assert.AreEqual(p0, Driver.Browser
                    .FindElement(By.XPath("//div[contains(@class,'c-enrollment-form-done')]//section[@class='product__info']//h2")).ScrollTo().Text);
        }

        [Then(@"Supplier and documentation is shown correctly")]
        public void ThenSupplierAndDocumentationIsShownCorrectly()
        {
            var summaryItems = Driver.Browser
                    .FindElements(By.XPath("//div[contains(@class,'c-enrollment-step3')]//ul[@class='form-summary']//li"), 30)
                    .ToList();

            Assert.AreEqual("Coloplast", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Preferred Supplier")).First()
                .FindElement(By.XPath(".//div[@class='form-summary__value']")).ScrollTo().Text);
        }

        [Then(@"Care advisor info is shown correctly")]
        public void ThenCareAdvisorInfoIsShownCorrectly()
        {
            var summaryItems = Driver.Browser
                .FindElements(By.XPath("//div[@class='c-enrollment-step1']//ul[@class='form-summary']//li"), 30)
                .ToList();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("Straight (A4351)", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Tip")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).ScrollTo().Text);
                Assert.AreEqual("12", summaryItems.Where(x => x.Text.CaseInsensitiveContains("French")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual("Hydrophilic preferred", summaryItems.Where(x => x.Text.CaseInsensitiveContains("preferred or")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
            });
        }

        [Then(@"Prescription details are shown correcly")]
        public void ThenPrescriptionDetailsAreShownCorrecly()
        {
            var summaryItems = Driver.Browser
                .FindElements(By.XPath("//div[@class='c-enrollment-step2']//ul[@class='form-summary']//li"), 30)
                .ToList();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("Chronic/Permanent", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Primary Diagnosis")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).ScrollTo().Text);
                Assert.AreEqual("No", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Secondary Diagnosis")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual("2 per day / 60 per month / 180 per 3 months", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Frequency of use")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual(DateTime.Now.ToString("yyyy-MM-dd"), summaryItems.Where(x => x.Text.CaseInsensitiveContains("Prescription start date")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual("12 months", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Duration of need")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual("12 months", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Number of refills")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
            });
        }

        [Then(@"Prescription details are shown correcly - other")]
        public void ThenPrescriptionDetailsAreShownCorrecly_Other()
        {
            var summaryItems = Driver.Browser
                .FindElements(By.XPath("//div[@class='c-enrollment-step2']//ul[@class='form-summary']//li"), 30)
                .ToList();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("R33.9 Retention of Urine", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Primary Diagnosis")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).ScrollTo().Text);
                //Assert.AreEqual("Chronic/Permanent", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Primary diagnosis 2")).First()
                //    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual("2 per day / 60 per month / 180 per 3 months", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Frequency of use")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual(DateTime.Now.ToString("yyyy-MM-dd"), summaryItems.Where(x => x.Text.CaseInsensitiveContains("Prescription start date")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual("7", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Duration of need")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual("7", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Number of refills")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
            });
        }

        [Then(@"Identify healthcare provider is shown correctly")]
        public void ThenIdentifyHealthcareProviderIsShownCorrectly()
        {
            var summaryItems = Driver.Browser
                .FindElements(By.XPath("//div[contains(@class,'c-enrollment-step4')]//ul[@class='form-summary']//li"), 30)
                .ToList();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("TEST", summaryItems.Where(x => x.Text.CaseInsensitiveContains("First name")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).ScrollTo().Text);
                Assert.AreEqual("TESTER", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Last name")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual("TEST FACILITY", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Facility name")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                //Assert.AreEqual("28 Morrell St", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Facility address")).First()
                //    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
                Assert.AreEqual("coloplast.test.signup@outlook.com", summaryItems.Where(x => x.Text.CaseInsensitiveContains("Work email")).First()
                    .FindElement(By.XPath(".//span[@class='form-summary__value']")).Text);
            });
        }
    }
}
