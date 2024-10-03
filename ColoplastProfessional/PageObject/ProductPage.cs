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
    public class ProductPage
    {
        /*WebElement on Product page */
        #region
        IWebElement richtextbanner => Driver.Browser.FindElement(By.XPath("//div[@id='rich-text-cta-banner']"));
        IWebElement videopausebtn => Driver.Browser.FindElement(By.XPath("//div[@class='c-video-item --loop']//button[@type='button']/span[@data-icon-name='pause']"));
        IWebElement contentLibrary => Driver.Browser.FindElement(By.XPath("//div[@class='c-content-library-carousel']"));
        IWebElement factbox => Driver.Browser.FindElement(By.XPath("//div[@class='c-fact-box__container']"));
        IWebElement variantblock => Driver.Browser.FindElement(By.XPath("//div[@id='variant-portfolio-block']"));
        IWebElement productcontainerview => Driver.Browser.FindElement(By.XPath("//div[@class='c-product-highlights__background']"));
        IWebElement pulsatingIcon=> Driver.Browser.FindElement(By.XPath("//button[@aria-label='Open info box: Headline']"));
        IWebElement pulsatingText => Driver.Browser.FindElement(By.XPath("//div[@class='c-product-hotspot c-product-hotspot--active']//p[@class='ds-text-label-sm ds-text--default c-product-hotspot__description']"));
        #endregion
      /*  Methodes for Prdouct page  */
        #region
        public void NavigateProductPage()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Driver.Navigate(ConfigurationManager.AppSettings.Get("productpage"));
            Driver.BrowserWait.WaitForPageLoad();
            Driver.Browser.Title.CaseInsensitiveEquals("Product Deep dive page_Fact box_variant potfolio_benefit  challenge block_chartblock_automation");
        }
        public void Verifycomponenets()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Assert.IsTrue(richtextbanner.Displayed);
            Assert.IsTrue(videopausebtn.Displayed);
            Assert.IsTrue(contentLibrary.Displayed);
            Assert.IsTrue(factbox.Displayed);
            Assert.IsTrue(variantblock.Displayed);
            Assert.IsTrue(productcontainerview.Displayed);
        }
        public void pulsating()
        {
            Driver.BrowserWait.WaitForPageLoad();
            pulsatingIcon.ScrollTo().WaitForElementToBeClickable().Click();
            Console.WriteLine(pulsatingText.Text);
        }
        public void pausevideo()
        {
            Driver.BrowserWait.WaitForPageLoad();
            videopausebtn.ScrollTo().WaitForElementToBeClickable().Click();
        }
        #endregion
    }
}
