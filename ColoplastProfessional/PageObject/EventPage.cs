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
    public class EventPage
    {
        #region
        IWebElement sharebutton => Driver.Browser.FindElement(By.XPath("//label[@class='c-share-print__sharebutton'][@data-testid='share']"));
        IWebElement backToEvents => Driver.Browser.FindElement(By.XPath("//span[normalize-space()='Back to events']"));
        IWebElement cta => Driver.Browser.FindElement(By.XPath("//button[contains(., 'CTA') or contains(@data-testid,'CTA')]"));
        IWebElement alternativeDates => Driver.Browser.FindElement(By.XPath("//div[@class='c-alternative-date__navigation-wrapper']"));
        IWebElement dateBoxText => Driver.Browser.FindElement(By.XPath("//div[@class='c-alternative-date__item']/a/span"));
        IWebElement H3date => Driver.Browser.FindElement(By.XPath("//h3[@class='ds-text-heading-3xl ds-text--default c-content-info-card__heading']"));
        IWebElement infoBox => Driver.Browser.FindElement(By.XPath("//ul[@class='c-content-info-card__item-wrapper']"));
        #endregion

        public void Eventpage()
        {
            Driver.BrowserWait.WaitForPageLoad();
            Driver.Navigate(ConfigurationManager.AppSettings.Get("evenetpage"));
            Driver.Browser.Title.CaseInsensitiveEquals("Patient im Fokus: Edukation in der Wundversorgung");
            Assert.IsTrue(H3date.Text.CaseInsensitiveContains("Dec 25, 2024"));
            Assert.IsTrue(sharebutton.Displayed);
            Assert.IsTrue(backToEvents.Displayed);
            Assert.IsTrue(cta.Displayed);
            Assert.IsTrue(alternativeDates.Displayed);               
            alternativeDates.ScrollTo().WaitForElementToBeClickable().Click();
            Assert.IsTrue(dateBoxText.Text.CaseInsensitiveContains("Sep 19"));
        }
    }
}
