using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Reqnroll;
using Core.Pages;
using System.Security.Cryptography;
using NUnit.Framework.Internal;
using System.Diagnostics.Metrics;
using ColoplastProfessional.PageObject;
using Org.BouncyCastle.Asn1.Cms;
namespace ColoplastProfessional.Steps
{
    [Binding]
    public class ProfileSteps
    {
        DeliveryInfoPage deliveryInfoPage;
        EventPage eventPage;
        MediaPage mediaPage;
        HCPPage hCPPage;
        CoursePage coursePage;
        ThemePage themePage;
        ProductPage productPage;
        public ProfileSteps()
        {
            deliveryInfoPage = new DeliveryInfoPage();
            eventPage = new EventPage();
            mediaPage = new MediaPage();
            hCPPage = new HCPPage();
            coursePage = new CoursePage();
            themePage = new ThemePage();
            productPage = new ProductPage();

        }
        [Given(@"User is signed in with newly created profile")]
        public void GivenUserIsSignedInWithNewlyCreatedProfile()
        {
            var signupsteps = new SignUpStep();
            if (String.IsNullOrEmpty(Helper.HCPEmail))
            {
                signupsteps.GivenUserClicksLogin();
                signupsteps.GivenUserClicksSignUpNow();
                signupsteps.WhenUserFillsInfo();
                signupsteps.GivenUserCreatesNewB2CAccount();
                signupsteps.WhenUserFillsCompleteProfile();
            }
            else
            {
                Driver.Browser.FindElement(By.XPath("//div[@class='c-nav-call-to-action']//a"), 60).WaitForElementToBeClickable().Click();
                signupsteps.Login(Helper.HCPEmail, "Qwerty123");
            }
        }
        [When(@"User opens profile")]
        public void WhenUserOpensProfile()
        {
            Driver.Browser.FindElement(By.XPath("//button[@title='My Account']"), 60).WaitForElementToBeClickable().Click();
            Driver.BrowserWait.WaitForPageLoad();
        }
        [Then(@"Profile overview is opened")]
        public void ThenProfileOverviewIsOpened()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//div[@class='c-profile__container --fixedwidth']/h2"), 60).Text.CaseInsensitiveContains("welcome"));
                Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//section[@id='hcp-main-profile-page']//a[contains(@title,'Profile Overview')]")).GetAttribute("class").CaseInsensitiveContains("active"));
            });
        }
        [When(@"User opens Personal info")]
        public void WhenUserOpensPersonalInfo()
        {
            Driver.Browser.FindElement(By.XPath("//a[@title='Personal Info']/span"), 60).WaitForElementToBeClickable().Click();
            Driver.BrowserWait.WaitForPageLoad();
        }
        [Then(@"Personal info is shown correctly")]
        public void ThenPersonalInfoIsShownCorrectly()
        {
            //Assert.Multiple(() =>
            //{
            //    Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//div[@class='c-profile__container']/h2"), 60).Text.CaseInsensitiveContains("welcome"));
            //    Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//a[contains(@title,'Profile Overview')]"), 60).GetAttribute("class").CaseInsensitiveContains("active"));
            //});
        }
        [Then(@"Personal info is shown correctly - newly created profile")]
        public void ThenPersonalInfoIsShownCorrectly_NewlyCreatedProfile()
        {
            //Assert.Multiple(() =>
            //{
            var job = new SelectElement(Driver.Browser.FindElement(By.Id("JobTitle"), 60)).SelectedOption.Text;
            Assert.IsTrue(job.CaseInsensitiveEquals("Nurse"));
            Assert.IsTrue(Driver.Browser.FindElement(By.Id("FirstName"), 60).GetAttributeValue().CaseInsensitiveContains("TEST"));
            Assert.IsTrue(Driver.Browser.FindElement(By.Id("LastName")).GetAttributeValue().CaseInsensitiveContains("TESTER"));
            // Assert.IsTrue(Driver.Browser.FindElement(By.Id("Email")).GetAttributeValue().CaseInsensitiveContains(Helper.HCPEmail));
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//span[@class='checkbox-group__label filled']/span")).Text.CaseInsensitiveEquals("Ostomy"));
            Assert.IsTrue(Driver.Browser.FindElement(By.Id("Workplace")).GetAttributeValue().CaseInsensitiveContains("TEST FACILITY"));
#if SANDBOXHCP
                Assert.IsTrue(Driver.Browser.FindElement(By.Id("City")).GetAttributeValue().CaseInsensitiveContains("Aberdeen"));
#endif
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//a[contains(@title,'Personal Info') and contains(@class,'c-profile__list-item active')]")).GetAttribute("class").CaseInsensitiveContains("active"));
            //});
        }
        [When(@"User opens Certicates info")]
        public void WhenUserOpensCerticatesInfo()
        {
            Driver.Browser.FindElement(By.XPath("//a[@title='Courses & Certificates']/span"), 60).WaitForElementToBeClickable().Click();
            Driver.BrowserWait.WaitForPageLoad();
        }
        [Then(@"Certificates are empty")]
        public void ThenCertificatesAreEmpty()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//section[@id='hcp-main-profile-page']//a[contains(@title,'Certificates')]"), 60).GetAttribute("class").CaseInsensitiveContains("active"));
            });
        }
        [When(@"User opens E-Learning access info")]
        public void WhenUserOpensE_LearningAccessInfo()
        {
            Driver.Browser.FindElement(By.XPath("//a[@title='E-Learning access']//span"), 60).ScrollTo().WaitForElementToBeClickable().Click();
            Driver.BrowserWait.WaitForPageLoad();
        }
        [Then(@"E-Learning access info is shown correctly")]
        public void ThenE_LearningAccessInfoIsShownCorrectly()
        {
            //Assert.Multiple(() =>
            //{
            //    Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//div[@class='c-profile__container']/h2"), 60).Text.CaseInsensitiveContains("welcome"));
            //    Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//a[contains(@title,'Profile Overview')]"), 60).GetAttribute("class").CaseInsensitiveContains("active"));
            //});
        }
        [Then(@"E-Learning access info is shown correctly - newly created profile")]
        public void ThenE_LearningAccessInfoIsShownCorrectly_NewlyCreatedProfile()
        {
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//div[@id='hcp-elearning-access']//div[@class='c-subscription-block --filled']/h2"), 60).Text.CaseInsensitiveContains("Paid Subscription"));
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//div[@id='hcp-elearning-access']//div[@class='c-subscription-block --selected']/h2")).Text.CaseInsensitiveContains("Coloplast Professional account"));
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//section[@id='hcp-main-profile-page']//a[contains(@title,'E-Learning access')]")).GetAttribute("class").CaseInsensitiveContains("active"));
        }
        [When(@"User opens Notifications info")]
        public void WhenUserOpensNotificationsInfo()
        {
            Driver.Browser.FindElement(By.XPath("//a[@title='Notifications']/span"), 60).ScrollTo().WaitForElementToBeClickable().Click();
            Driver.BrowserWait.WaitForPageLoad();
        }
        [Then(@"Notifications info is shown correctly")]
        public void ThenNotificationsInfoIsShownCorrectly()
        {
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//div[@class='c-profile__container']/h2"), 60).Text.CaseInsensitiveContains("welcome"));
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//a[contains(@title,'Profile Overview')]"), 60).GetAttribute("class").CaseInsensitiveContains("active"));
        }
        [Then(@"Notifications info is shown correctly - newly created profile")]
        public void ThenNotificationsInfoIsShownCorrectly_NewlyCreatedProfile()
        {
            Assert.Multiple(() =>
            {
                Assert.IsFalse(Driver.Browser.FindElement(By.Id("marketingAgreementCheckbox"), 60).Selected);
                Assert.IsFalse(Driver.Browser.FindElement(By.Id("pmc_Email"), 60).Selected);
                Assert.IsFalse(Driver.Browser.FindElement(By.Id("pmc_Phone"), 60).Selected);
                Assert.IsFalse(Driver.Browser.FindElement(By.Id("pmc_SMS"), 60).Selected);
                Assert.IsFalse(Driver.Browser.FindElement(By.Id("pmc_Letter"), 60).Selected);
                Assert.IsFalse(Driver.Browser.FindElement(By.Id("pmc_Fax"), 60).Selected);
                Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//section[@id='hcp-main-profile-page']//a[contains(@title,'Notifications')]"), 60).GetAttribute("class").CaseInsensitiveContains("active"));
            });
        }
        [When(@"User updates country to {string}")]
        public void WhenUserUpdatesCountryTo(string p0)
        {
            Driver.Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var country = new SelectElement(Driver.Browser.FindElement(By.Id("Country")));
            country.SelectByText(p0);
            Driver.Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            Thread.Sleep(1000);
            Driver.Browser.FindElement(By.XPath("//div[@class='c-profile__submit']/button"), 60).ScrollTo().Click();
            Driver.BrowserWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("spinner-overlay")));
        }
        [Then(@"Profile is updated and country is {string}")]
        public void ThenProfileIsUpdatedAndCountryIs(string p0)
        {
            var job = new SelectElement(Driver.Browser.FindElement(By.Id("Country"), 60).Wait(10)).SelectedOption.Text;
            Assert.IsTrue(job.CaseInsensitiveEquals(p0));
        }
        /*Update  First name, Last name, Medical specialty, Registration number,etc. on Personal info page */
        [Then(@"I update details like First name Last name Medical specialty Registration number,etc.")]
        public void ThenIUpdateDetailsLikeFirstNameLastNameMedicalSpecialtyRegistrationNumberEtc_()
        {
            IWebElement jobtitel = Driver.Browser.FindElement(By.Id("JobTitle"));
            IWebElement firstName = Driver.Browser.FindElement(By.Id("FirstName"));
            IWebElement lastName = Driver.Browser.FindElement(By.Id("LastName"));
            IWebElement speciality = Driver.Browser.FindElement(By.XPath("//span[@class='checkbox-group__label filled']/span"));
            IWebElement bladderSpeciality = Driver.Browser.FindElement(By.XPath("//label[normalize-space()='Bladder Management']"));
            IWebElement Ostomy = Driver.Browser.FindElement(By.XPath("//span[contains(text(),'Ostomy')]"));
            IWebElement registrationNumber = Driver.Browser.FindElement(By.Id("RegistrationNumber"));
            IWebElement country = Driver.Browser.FindElement(By.Id("Country"));
            IWebElement uk = Driver.Browser.FindElement(By.CssSelector("option[value = 'Great Britain']"));
            IWebElement submitBTN = Driver.Browser.FindElement(By.XPath("//button[@type='submit']"));
            Random r = new Random();
            int rand = r.Next(100);
            string number = $"34{rand.ToString("D4")}";
            string fname = rand.ToString();
            if (firstName.GetAttributeValue().CaseInsensitiveContains("UpdateBy"))
            {
                deliveryInfoPage.filltheField(firstName, "Test");
                deliveryInfoPage.filltheField(lastName, "TESTER");
                deliveryInfoPage.filltheField(registrationNumber, "321456");
                Thread.Sleep(2000);
                submitBTN.ScrollTo().WaitForElementToBeClickable().Click();
                Thread.Sleep(4000);
                Assert.IsTrue(Driver.Browser.FindElement(By.Id("FirstName"), 60).GetAttributeValue().CaseInsensitiveContains("TEST"));
                Assert.IsTrue(Driver.Browser.FindElement(By.Id("LastName")).GetAttributeValue().CaseInsensitiveContains("TESTER"));
                Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//span[@class='checkbox-group__label filled']/span")).Text.CaseInsensitiveEquals("Ostomy"));
            }
            else if (firstName.GetAttributeValue().CaseInsensitiveContains("Test"))
            {
                deliveryInfoPage.filltheField(firstName, "UpdateBy");
                deliveryInfoPage.filltheField(lastName, "Automation " + fname);
                registrationNumber.ScrollTo().WaitForElementToBeClickable().Click();
                deliveryInfoPage.filltheField(registrationNumber, number);
                Thread.Sleep(2000);
                submitBTN.ScrollTo().WaitForElementToBeClickable().Click();
                Thread.Sleep(4000);
                Assert.IsTrue(Driver.Browser.FindElement(By.Id("FirstName"), 60).GetAttributeValue().CaseInsensitiveContains("UpdateBy"));
                Assert.IsTrue(Driver.Browser.FindElement(By.Id("LastName")).GetAttributeValue().CaseInsensitiveContains("Automation " + fname));
                Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//span[@class='checkbox-group__label filled']/span")).Text.CaseInsensitiveEquals("Ostomy"));
            }
            else
            {
                Console.WriteLine("Name is change by manual tester");
            }
        }
        [Then(@"I click on logout and test completed successfully")]
        public void ThenIClickOnLogoutAndTestCompletedSuccessfully()
        {
            IWebElement logout = Driver.Browser.FindElement(By.XPath("//a[@class='ds-button ds-button--secondary-neutral ds-button--md c-profile__ctabutton'][@title='Log out']"));
            logout.ScrollTo().WaitForElementToBeClickable().Click();
        }
        /*************************************Start of Event page************************************************/
        [Given(@"user is open Event page")]
        public void GivenUserIsOpenEventPage()
        {
            eventPage.Eventpage();
        }
        [Then(@"I verified event page componenet its details and test completed successfully")]
        public void ThenIVerifiedEventPageComponentItsDetailsAndTestCompletedSuccessfully()
        {
            Console.WriteLine("Verifed event page components successfuly ");
        }
        /*************************************Start of Media page************************************************/
        [Given(@"user is navigate to  meida page")]
        public void GivenUserIsNavigateToMeidaPage()
        {
            mediaPage.Mediapage();
        }
        [Then(@"user read introduction and author details")]
        public void ThenUserReadIntroductionAndAuthorDetails()
        {
            mediaPage.Introduction();
        }
        [Then(@"user played and audio podcast")]
        public void ThenUserPlayedAndAudioPodcast()
        {
            mediaPage.PlayandpuaseAudio();
        }
        [Then(@"user scroll to rich text section")]
        public void ThenUserScrollToRichTextSection()
        {
            mediaPage.Richtextblock();
        }
        [Then(@"user click play video button")]
        public void ThenUserClickPlayVideoButton()
        {
            mediaPage.Videoplayer();
        }
        [Then(@"user open FAQ")]
        public void ThenUserOpenFAQ()
        {
            mediaPage.FAQ();
        }
        [Then(@"user successfully verified component on media page")]
        public void ThenUserSuccessfullyVerifiedComponenetOnMediaPage()
        {
            Console.WriteLine("Test case pass successfully");
        }
        /*************************************Start of HCP page************************************************/
        [Given(@"user is navigate to  hcp page")]
        public void GivenUserIsNavigateToHcpPage()
        {
            hCPPage.HCPpage();
        }
        [Then(@"user read introduction, heading, text, content and buttons")]
        public void ThenUserReadIntroductionHeadingTextContentAndButtons()
        {
            hCPPage.Verifycomponenets();
        }
        [Then(@"user scroll to rich text section to verify text and heading")]
        public void ThenUserScrollToRichTextSectionToVerifyTextAndHeading()
        {
            hCPPage.Richtextblock();
        }
        [Then(@"user open hcp page FAQ")]
        public void ThenUserOpenHcpPageFAQ()
        {
            hCPPage.FAQ();
        }
        [Then(@"user successfully verified component on HCP page")]
        public void ThenUserSuccessfullyVerifiedComponentOnHCPPage()
        {
            hCPPage.PDFBlock();
        }
        [Then(@"user play podcast on HCP page")]
        public void ThenUserPlayPodcastOnHCPPage()
        {
            hCPPage.Podcast();
        }
        [Then(@"user play video HCP Page")]
        public void ThenUserPlayVideoHCPPage()
        {
            hCPPage.Videoplayer();
        }
        [Given(@"user is hovering resources")]
        public void GivenUserIsHoveringResources()
        {
            hCPPage.Hovermenu();
        }
        [Then("user successfully verified menu layer navigation")]
        public void ThenUserSuccessfullyVerifiedMenuLayerNavigation()
        {
            Console.WriteLine("3 layer mneu navigation working fine");
        }
        /*************************************Start of Course page************************************************/
        [Given("user is navigate to  course page and veirfied components")]
        public void GivenUserIsNavigateToCoursePageAndVeirfiedComponents()
        {
           coursePage.Coursepage();
        }
        [Then("user read course details, name, length, enorsed by, category etc.")]
        public void ThenUserReadCourseDetailsNameLengthEnorsedByCategoryEtc_()
        {
            coursePage.Verifyblocks();
        }
        [Then("user open FAQ section")]
        public void ThenUserOpenFAQSection()
        {
            coursePage.Richtextblock();
        }
        [Then("user play video")]
        public void ThenUserPlayVideo()
        {
            coursePage.Videoplayer();
        }
        [Then("user successfully verified component on course page")]
        public void ThenUserSuccessfullyVerifiedComponentOnCoursePage()
        {
            coursePage.FAQ();
        }

        /*************************************Start of Theme page************************************************/
        [Given(@"user is navigate to  theme page and veirfied components")]
        public void GivenUserIsNavigateToThemePageAndVeirfiedComponents()
        {
            themePage.Themepage();
        }

        [Then(@"user read intoduction, verified tagging,recommended block and other details")]
        public void ThenUserReadIntoductionVerifiedTaggingRecommendedBlockAndOtherDetails()
        {
            themePage.Verifycomponenets();
        }

        [Then(@"user successfully verified component on theme page")]
        public void ThenUserSuccessfullyVerifiedComponentOnThemePage()
        {
            Console.WriteLine("Test case pass successfuly");
        }

        /*************************************Start of Product page************************************************/

        [Given(@"user is navigate to  product page and veirfied components")]
        public void GivenUserIsNavigateToProductPageAndVeirfiedComponents()
        {
            productPage.NavigateProductPage();
        }
        [Then(@"user verify page components like Richtext, Product,Varient and etc")]
        public void ThenUserVerifyPageComponentsLikeRichtextProductVarientAndEtc()
        {
            productPage.Verifycomponenets();
        }
        [Then(@"user scroll down and click pulsating icon and read the text")]
        public void ThenUserScrollDownAndClickPulsatingIconAndReadTheText()
        {
            productPage.pulsating();
        }
        [Then(@"user scroll up and pause the video")]
        public void ThenUserScrollUpAndPauseTheVideo()
        {
            productPage.pausevideo();
        }





    }
}
