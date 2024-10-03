using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
namespace ColoplastProfessional.PageObject
{
    public class MediaPage
    {
        /* Webelements on media page*/
        #region
        IWebElement sharebutton => Driver.Browser.FindElement(By.XPath("//label[@class='c-share-print__sharebutton'][@data-testid='share']"));
        IWebElement bookmark => Driver.Browser.FindElement(By.XPath("//button[@class='with-icon ds-icon-button ds-icon-button--ghost-neutral ds-icon-button--md'][@data-testid='bookmark']"));
        IWebElement intoductionHeading => Driver.Browser.FindElement(By.XPath("//h5[normalize-space()='Introduction']"));
        IWebElement intoductionText => Driver.Browser.FindElement(By.XPath("//p[contains(text(),'When looking at the available research on the psyc')]"));
        IWebElement pdfheading => Driver.Browser.FindElement(By.XPath("//h3[normalize-space()='SAMPLE REQUEST_16_products.pdf']"));
        IWebElement sampleDownload => Driver.Browser.FindElement(By.XPath("//a[@class='ds-button ds-button--primary ds-button--md'][@download='SAMPLE REQUEST_16_products.pdf']"));
        IWebElement productDownload => Driver.Browser.FindElement(By.XPath("//a[@class='ds-button ds-button--primary ds-button--md'][@download='Versorgungsbereiche_Edge.pdf']"));
        IWebElement podcastPlayer => Driver.Browser.FindElement(By.XPath("//div[@class='c-podcast-player__controls']"));
        IWebElement playBTN => Driver.Browser.FindElement(By.XPath("//button[@class='c-podcast-player__buttons']"));
        IWebElement puaseBTNbyID => Driver.Browser.FindElement(By.Id("pause-button"));
        IWebElement puaseBTNbyXpath => Driver.Browser.FindElement(By.XPath("//button[@data-testid='playPauseButton']"));
        IWebElement richtextblock => Driver.Browser.FindElement(By.XPath("//div[@class='richtextblock spot']"));
        IWebElement richtextblockP => Driver.Browser.FindElement(By.XPath("//div[@class='richtextblock spot']/p"));
        IWebElement richtextblockH2 => Driver.Browser.FindElement(By.XPath("//div[@class='richtextblock spot']/h2"));
        IWebElement videoContainer => Driver.Browser.FindElement(By.XPath("//div[@class='c-video-block__container']"));
        IWebElement palyVideo => Driver.Browser.FindElement(By.XPath("//button[@aria-label='Play video']"));
        IWebElement closeVideo => Driver.Browser.FindElement(By.XPath("//button[@class='c-content-library-card__close-btn']"));
        IWebElement faq => Driver.Browser.FindElement(By.ClassName("c-faq"));
        IWebElement q1 => Driver.Browser.FindElement(By.XPath("//span[contains(text(),'Question 1')]"));
        IWebElement q2 => Driver.Browser.FindElement(By.XPath("//span[contains(text(),'Question 2')]"));
        IWebElement q3 => Driver.Browser.FindElement(By.XPath("//span[contains(text(),'Question 3')]"));
        #endregion
        /* Methodas fpr the page*/
        public void Mediapage()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Driver.Navigate(ConfigurationManager.AppSettings.Get("mediapage"));
        }
        public void Introduction()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Assert.IsTrue(sharebutton.Displayed);
            Assert.IsTrue(bookmark.Displayed);
            Assert.IsTrue(intoductionHeading.Displayed);
            Assert.IsTrue(intoductionText.Displayed);
            Assert.IsTrue(pdfheading.Displayed);
            Assert.IsTrue(sampleDownload.Displayed);
            Assert.IsTrue(productDownload.Displayed);
            Assert.IsTrue(podcastPlayer.Displayed);
            Assert.IsTrue(playBTN.Displayed);
            Assert.IsTrue(videoContainer.Displayed);
        }
        public void PlayandpuaseAudio()
        {
            Driver.BrowserWait.WaitForPageLoad();
            playBTN.ScrollTo().WaitForElementToBeClickable().CustomClick();
            Thread.Sleep(1000);
            // puaseBTNbyID.Click();
        }
        public void Richtextblock()
        {
            Driver.BrowserWait.WaitForPageLoad();
            var intro = "Uncovering paediatric psychosocial issues";
            var paragraph = "Optional Paragraph: Learn how to recognise the anatomy and circulatory physiology that can lead to leg ulcers and how to assess leg ulcers. You will learn about the Global impact and cost of Leg Ulcers, the internaltional guidelines for management of leg. Learn how to recognise the anatomy and circulatory physiology that can lead to leg ulcers and how to assess leg ulcers. You will learn about the Global impact and cost of Leg Ulcers, the internaltional guidelines for management of leg.";
            if (richtextblock.Displayed)
            {
                richtextblock.ScrollTo().WaitForElementToBeClickable();
                var getinto = richtextblockH2.Text;
                Assert.AreEqual(intro, getinto);
                var para = richtextblockP.Text;
                Assert.AreEqual(paragraph, para);
            }
            else
            {
                Console.Error.WriteLine("rich text block not displayed");
            }
        }
        public void Videoplayer()
        {
            Driver.BrowserWait.WaitForPageLoad();
            if (videoContainer.Displayed)
            {
                videoContainer.ScrollTo().WaitForElementToBeClickable();
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
            if (faq.Displayed)
            {
                faq.ScrollTo().WaitForElementToBeClickable();
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
    }
}
