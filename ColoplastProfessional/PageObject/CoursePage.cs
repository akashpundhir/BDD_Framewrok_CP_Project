using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;
namespace ColoplastProfessional.PageObject
{
    public class CoursePage
    {
        /*Weblements on the page*/
        #region
        IWebElement sharebutton => Driver.Browser.FindElement(By.XPath("//label[@class='c-share-print__sharebutton'][@data-testid='share']"));
        /*heroBanner*/
        IWebElement heroBanner => Driver.Browser.FindElement(By.XPath("//section[@class='c-keyword-cta-hero-banner']"));
        IWebElement courseName => Driver.Browser.FindElement(By.XPath("//h1[contains(text(),'Start Course Leg Ulcers: Identification, Assessmen')]"));
        /*Tagging */
        IWebElement taggingAdherence => Driver.Browser.FindElement(By.XPath("//div[@id='keyword-cta-hero-banner']//span[normalize-space()='Adherence to ISC']"));
        IWebElement taggingBalloning => Driver.Browser.FindElement(By.XPath("//div[@id='keyword-cta-hero-banner']//span[normalize-space()='Balloning']"));
        IWebElement taggingDiabetes => Driver.Browser.FindElement(By.XPath("//div[@id='keyword-cta-hero-banner']//span[normalize-space()='Diabetes']"));
        IWebElement taggingLeakage => Driver.Browser.FindElement(By.XPath("//div[@id='keyword-cta-hero-banner']//span[normalize-space()='Leakage']"));
        IWebElement resturnBTN => Driver.Browser.FindElement(By.XPath("//span[normalize-space()='Return to all courses']"));
        IWebElement rickTextBlock => Driver.Browser.FindElement(By.XPath("//div[@class='richtextblock spot']"));
        IWebElement rickTextBlockHeading => Driver.Browser.FindElement(By.XPath("//div[@class='richtextblock spot']/h2[normalize-space()='Key learning objectives']"));
        IWebElement faqHeading => Driver.Browser.FindElement(By.ClassName("c-faq__heading"));
        /* content-info-card*/
        IWebElement contentInfoCard => Driver.Browser.FindElement(By.Id("content-info-card"));
        IWebElement startDate => Driver.Browser.FindElement(By.XPath("//p[@class='c-content-page__posted ds-text--medium ds-text-body-lg']"));
        //October 31, 2021
        IWebElement courselengthlabel => Driver.Browser.FindElement(By.XPath("//p[normalize-space()='Lessons 4 x 35 mins']"));
        IWebElement startBTN => Driver.Browser.FindElement(By.XPath("//div[@class='c-content-page__container']//span[normalize-space()='Start Course']"));
        IWebElement courselength => Driver.Browser.FindElement(By.XPath("//p[normalize-space()='Approx. 1 hour']"));
        IWebElement endorsedBy => Driver.Browser.FindElement(By.XPath("//span[normalize-space()='EWMA']"));
        IWebElement category => Driver.Browser.FindElement(By.XPath("//p[normalize-space()='Stoma']"));
        IWebElement type => Driver.Browser.FindElement(By.XPath("//p[normalize-space()='Bowel']"));
        IWebElement courseType => Driver.Browser.FindElement(By.XPath("//p[normalize-space()='Article']"));
        IWebElement cpdPoints => Driver.Browser.FindElement(By.XPath("//p[normalize-space()='1 CPD point']"));
        IWebElement logo => Driver.Browser.FindElement(By.XPath("//img[@alt=' EWMA']"));
        IWebElement videoBlock => Driver.Browser.FindElement(By.XPath("//div[@class='c-video-block__container']"));
        IWebElement palyVideo => Driver.Browser.FindElement(By.XPath("//div[@class='c-video-poster__play-container']/button[@aria-label='Play video']"));
        IWebElement closeVideo => Driver.Browser.FindElement(By.XPath("//button[@class='c-content-library-card__close-btn']"));
        IWebElement faqBlock => Driver.Browser.FindElement(By.ClassName("c-faq"));
        IWebElement q1 => Driver.Browser.FindElement(By.XPath("//span[contains(text(),'The impact and cost of leg ulcers')]"));
        IWebElement q3 => Driver.Browser.FindElement(By.XPath("//span[contains(text(),'Assessment of leg ulcers')]"));
        #endregion
        public void Coursepage()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Driver.Navigate(ConfigurationManager.AppSettings.Get("coursepage"));
            Driver.BrowserWait.WaitForPageLoad();
            Driver.Browser.Title.CaseInsensitiveEquals("Start Course Leg Ulcers: Identification, Assessment and Management");
        }
        public void Verifyblocks()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Assert.IsTrue(sharebutton.Displayed);
            Assert.IsTrue(heroBanner.Displayed);
            Assert.IsTrue(courseName.Displayed);
            Assert.IsTrue(taggingAdherence.Displayed);
            Assert.IsTrue(taggingBalloning.Displayed);
            Assert.IsTrue(taggingDiabetes.Displayed);
            Assert.IsTrue(taggingLeakage.Displayed);
            Assert.IsTrue(resturnBTN.Displayed);
            Assert.IsTrue(rickTextBlock.Displayed);
            Assert.IsTrue(faqHeading.Displayed);
            Assert.IsTrue(contentInfoCard.Displayed);
            Assert.IsTrue(startDate.Displayed);
            Assert.IsTrue(courselength.Displayed);
            Assert.IsTrue(endorsedBy.Displayed);
            Assert.IsTrue(category.Displayed);
            Assert.IsTrue(courselengthlabel.Displayed);
            Assert.IsTrue(type.Displayed);
            Assert.IsTrue(cpdPoints.Displayed);
            Assert.IsTrue(courseType.Displayed);
            Assert.IsTrue(startBTN.Displayed);
            Assert.IsTrue(courselength.Displayed);
            Assert.IsTrue(logo.Displayed);
        }
        public void Richtextblock()
        {
            Driver.BrowserWait.WaitForPageLoad();
            var intro = "Key learning objectives";
            if (rickTextBlock.Displayed)
            {
                rickTextBlock.ScrollTo().WaitForElementToBeClickable();
                var getinto = rickTextBlockHeading.Text;
                Assert.AreEqual(intro, getinto);
                Console.WriteLine(rickTextBlockHeading.Text);
            }
            else
            {
                Console.Error.WriteLine("rich text block not displayed");
            }
        }
        public void Videoplayer()
        {
            Driver.BrowserWait.WaitForPageLoad();
            if (videoBlock.Displayed)
            {
                videoBlock.ScrollTo().WaitForElementToBeClickable();
                palyVideo.Click();
                Thread.Sleep(5000);
                closeVideo.ScrollTo().WaitForElementToBeClickable().Click();
            }
            else
            {
                Console.Error.WriteLine("Video block not present or displayed");
            }
        }
        public void FAQ()
        {
            Driver.BrowserWait.WaitForPageLoad();
            if (faqBlock.Displayed)
            {
                faqBlock.ScrollTo().WaitForElementToBeClickable();
                q1.Click();
                Thread.Sleep(1000);
                q1.Click();
                Thread.Sleep(1000);
                q3.Click();
            }
            else
            {
                Console.Error.WriteLine("FAQ block not present or displayed om course page");
            }
        }
    }
}
