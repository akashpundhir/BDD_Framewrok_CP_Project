using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ColoplastProfessional.PageObject
{
    public class ThemePage
    {
        #region
        /*Webelements on the page */
        IWebElement subheadline => Driver.Browser.FindElement(By.XPath("//p[@class='ds-text-body-sm ds-text--medium c-keyword-cta-hero-banner__sup-headline']"));
        IWebElement headline => Driver.Browser.FindElement(By.XPath("//h1[contains(text(),'Leg Ulcers: Identification, Assessment and Managem')]"));
        IWebElement taggingExudate => Driver.Browser.FindElement(By.XPath("//div[@id='keyword-cta-hero-banner']//span[normalize-space()='Exudate pooling']"));
        IWebElement taggingAcute => Driver.Browser.FindElement(By.XPath("//div[@id='keyword-cta-hero-banner']//span[normalize-space()='Acute wounds']"));
        IWebElement taggingBladder => Driver.Browser.FindElement(By.XPath("//div[@id='keyword-cta-hero-banner']//span[normalize-space()='Bladder']"));
        IWebElement taggingBowel => Driver.Browser.FindElement(By.XPath("//div[@id='keyword-cta-hero-banner']//span[normalize-space()='Bowel']"));
        IWebElement heroImage => Driver.Browser.FindElement(By.XPath("//img[@class='c-keyword-cta-hero-banner__image']"));
        IWebElement printBtn => Driver.Browser.FindElement(By.XPath("//span[contains(@data-icon-name,'print')]"));
        IWebElement shareBtn => Driver.Browser.FindElement(By.XPath("//label[@class='c-share-print__sharebutton'][@data-testid='share']"));
        IWebElement bookmark => Driver.Browser.FindElement(By.XPath("//button[@class='with-icon ds-icon-button ds-icon-button--ghost-neutral ds-icon-button--md'][@data-testid='bookmark']"));
        IWebElement richtextblock => Driver.Browser.FindElement(By.XPath("//div[@class='richtextblock spot']/h2[normalize-space()='Rich text block']"));
        IWebElement recommendedContentBlock=> Driver.Browser.FindElement(By.XPath("//div[@class='c-content-recommended__container c-product-features__block']"));
        IWebElement recommendedContentHeading => Driver.Browser.FindElement(By.XPath("//h2[contains(text(),'Solutions Coloplast indiquées (pansements primaire')]"));
        #endregion
        public void Themepage()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Driver.Navigate(ConfigurationManager.AppSettings.Get("themepage"));
            Driver.BrowserWait.WaitForPageLoad();
            Driver.Browser.Title.CaseInsensitiveEquals("Leg Ulcers: Identification, Assessment and Management");
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
            Assert.IsTrue(heroImage.Displayed);
            Assert.IsTrue(taggingAcute.Displayed);
            Assert.IsTrue(taggingExudate.Displayed);
            Assert.IsTrue(taggingBladder.Displayed);
            Assert.IsTrue(taggingBowel.Displayed);
            Assert.IsTrue(recommendedContentBlock.Displayed);
            Assert.IsTrue(recommendedContentHeading.Displayed);
        }
    }
}
