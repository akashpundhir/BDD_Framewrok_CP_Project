using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Configuration;
namespace ColoplastProfessional.PageObject
{
    public class HCPPage
    {
        /*List of webelments */
        #region
        IWebElement subheadline => Driver.Browser.FindElement(By.XPath("//p[@class='ds-text-body-sm ds-text--medium c-keyword-cta-hero-banner__sup-headline']"));
        IWebElement headline => Driver.Browser.FindElement(By.XPath("//h1[contains(text(),'Leg Ulcers: Identification, Assessment and Managem')]"));
        IWebElement printBtn => Driver.Browser.FindElement(By.XPath("//span[contains(@data-icon-name,'print')]"));
        IWebElement shareBtn => Driver.Browser.FindElement(By.XPath("//label[@class='c-share-print__sharebutton'][@data-testid='share']"));
        IWebElement bookmark => Driver.Browser.FindElement(By.XPath("//button[@class='with-icon ds-icon-button ds-icon-button--ghost-neutral ds-icon-button--md'][@data-testid='bookmark']"));
        IWebElement richtextblock => Driver.Browser.FindElement(By.XPath("//div[@class='richtextblock spot']/h2[normalize-space()='Uncovering paediatric psychosocial issues']"));
        IWebElement richtextblock2 => Driver.Browser.FindElement(By.XPath("//div[@class='richtextblock spot']/h2[contains(text(),'The children’s perspective')]"));
        IWebElement richtextblockP => Driver.Browser.FindElement(By.XPath("//div[@class='richtextblock spot']/p"));
        IWebElement richtextblockH2 => Driver.Browser.FindElement(By.XPath("//div[@class='richtextblock spot']/h2"));
        IWebElement factBox => Driver.Browser.FindElement(By.XPath("//div[@class='c-fact-box__container']"));
        IWebElement chartBlock => Driver.Browser.FindElement(By.XPath("//div[@class='vue-apexcharts']/div[@id='apexchartsicxggbev']"));
        IWebElement chartBlock1 => Driver.Browser.FindElement(By.XPath("//div[@class='c-chart-box__introduction']/h2[normalize-space()='Average number of accessories used']"));
        IWebElement chartBlock2 => Driver.Browser.FindElement(By.XPath("//div[@class='c-chart-box__introduction']/h2[normalize-space()='When outward peristomal areas develop']"));
        IWebElement chartBlock3 => Driver.Browser.FindElement(By.XPath("//div[@class='c-chart-box__introduction']/h2[normalize-space()='% agree (low degree to very high degree)']"));
        IWebElement videoBlock => Driver.Browser.FindElement(By.XPath("//div[@class='c-video-block__container']"));
        IWebElement palyVideo => Driver.Browser.FindElement(By.XPath("//div[@class='c-video-poster__play-container']/button[@aria-label='Play video']"));
        IWebElement closeVideo => Driver.Browser.FindElement(By.XPath("//button[@class='c-content-library-card__close-btn']"));
        IWebElement podcastPlayer => Driver.Browser.FindElement(By.XPath("//div[@class='c-podcast-player__controls']"));
        IWebElement playBTN => Driver.Browser.FindElement(By.XPath("//button[@class='c-podcast-player__buttons']"));
        IWebElement PdfBlock => Driver.Browser.FindElement(By.XPath("//div[contains(@class,'c-pdf-download__container')]"));
        IWebElement downloadBTN => Driver.Browser.FindElement(By.XPath(" //span[normalize-space()='Download']"));
        IWebElement faqBlock => Driver.Browser.FindElement(By.ClassName("c-faq"));
        IWebElement q1 => Driver.Browser.FindElement(By.XPath("//span[contains(text(),'1. What is a UTI Risk factor model?')]"));
        IWebElement q3 => Driver.Browser.FindElement(By.XPath("//span[contains(text(),'3. What is a UTI Risk factor model?')]"));
        IWebElement SplitMultimediaBlock => Driver.Browser.FindElement(By.XPath("//div[@class='c-split-multimedia__container ']"));
        IWebElement returnArrow => Driver.Browser.FindElement(By.XPath("//a[contains(@class,'ds-button--padding-none')]//span[@class='ds-text-label-md ds-text--medium']"));
        IWebElement resource => Driver.Browser.FindElement(By.XPath("//button[normalize-space()='Resources']"));
        IWebElement Knowledge => Driver.Browser.FindElement(By.XPath("//button[normalize-space()='Knowledge']"));
        IWebElement stoma => Driver.Browser.FindElement(By.XPath("(//button[@title='Stoma'][normalize-space()='Stoma'])[2]"));
        #endregion
        public void Hovermenu()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Actions action = new Actions(Driver.Browser);
            action.MoveToElement(resource).Perform();
            Knowledge.ScrollTo().WaitForElementToBeClickable().Click();
            Thread.Sleep(2000);
            Assert.IsTrue(stoma.Displayed);
            stoma.ScrollTo().WaitForElementToBeClickable().Click();
            Console.WriteLine("3 layer Menu displayed");
        }
        public void HCPpage()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Driver.Navigate(ConfigurationManager.AppSettings.Get("hcppage"));
            Driver.Browser.Title.CaseInsensitiveEquals("Leg Ulcers: Identification, Assessment and Management -HCP Article page_TEST_Automation");
        }
        public void Verifycomponenets()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Assert.IsTrue(subheadline.Displayed);
            Assert.IsTrue(headline.Displayed);
            Assert.IsTrue(shareBtn.Displayed);
            Assert.IsTrue(printBtn.Displayed);
            Assert.IsTrue(bookmark.Displayed);
            Assert.IsTrue(richtextblock.Displayed);
            Assert.IsTrue(richtextblock2.Displayed);
            Assert.IsTrue(factBox.Displayed);
            Assert.IsTrue(chartBlock1.Displayed);
            Assert.IsTrue(chartBlock2.Displayed);
            Assert.IsTrue(chartBlock3.Displayed);
            Assert.IsTrue(videoBlock.Displayed);
            Assert.IsTrue(podcastPlayer.Displayed);
            Assert.IsTrue(PdfBlock.Displayed);
            Assert.IsTrue(faqBlock.Displayed);
            Assert.IsTrue(SplitMultimediaBlock.Displayed);
            Assert.IsTrue(returnArrow.Displayed);
        }
        public void Richtextblock()
        {
            Driver.BrowserWait.WaitForPageLoad();
            var intro = "Uncovering paediatric psychosocial issues";
            if (richtextblock.Displayed)
            {
                richtextblock.ScrollTo().WaitForElementToBeClickable();
                var getinto = richtextblockH2.Text;
                Assert.AreEqual(intro, getinto);
                Console.WriteLine(richtextblockP.Text);
            }
            else
            {
                Console.Error.WriteLine("rich text block not displayed");
            }
        }
        public void Podcast()
        {
            Driver.BrowserWait.WaitForPageLoad();
            playBTN.ScrollTo().WaitForElementToBeClickable().CustomClick();
            Thread.Sleep(1000);
            Console.Error.WriteLine("Page not displayed");
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
                Console.Error.WriteLine("FAQ block not present or displayed");
            }
        }
        public void PDFBlock()
        {
            Driver.BrowserWait.WaitForPageLoad();
            if (PdfBlock.Displayed)
            {
                PdfBlock.ScrollTo().WaitForElementToBeClickable();
                Thread.Sleep(200);
                downloadBTN.ScrollTo().WaitForElementToBeClickable().Click();
            }
            else
            {
                Console.Error.WriteLine("pdf block not present or displayed on hcp page");
            }
        }
    }
}
