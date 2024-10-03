using Core.Drivers;
using OpenQA.Selenium;
using System.Threading;
namespace Core.Pages
{
    public class OrderConsentPage
    {
        /*Webelement on Page*/
        #region

        /*Conetend weblements*/
        IWebElement faqQestion1 => Driver.Browser.FindElement(By.XPath("//section[@class='c-faq c-faq__has-icons']//details[1]//summary[1]"));
        IWebElement faqQestion2 => Driver.Browser.FindElement(By.XPath("//section[@class='c-faq c-faq__has-icons']//details[2]//summary[1]"));
        IWebElement answer => Driver.Browser.FindElement(By.XPath("//div[contains(@dir,'auto')][normalize-space()='Wir bearbeiten Ihr Anliegen bzw. die von Ihnen gewünschte Leistung und führen die damit verbundenen administrativen bzw. organisatorischen Tätigkeiten durch und halten Sie darüber auf dem Laufenden.']"));
        IWebElement acceptCTA => Driver.Browser.FindElement(By.CssSelector(".button_accept.e-button.e-button--filled"));

        IWebElement accpetContinueAU => Driver.Browser.FindElement(By.XPath("//button[contains(., 'Accept and continue')]"));
        IWebElement rejectCTA => Driver.Browser.FindElement(By.CssSelector(".button__remove.e-button"));
        string text = "Wir bearbeiten Ihr Anliegen bzw. die von Ihnen gewünschte Leistung und führen die damit verbundenen administrativen bzw. organisatorischen Tätigkeiten durch und halten Sie darüber auf dem Laufenden";

        /*Finland weblements*/
        IWebElement acceptConsnetFI => Driver.Browser.FindElement(By.XPath("//button[@data-order-consent-event='accept']"));
        #endregion
        /*To Verify text displaye on Consnet page*/
        public void verifyOrderConsent()
        {
            Thread.Sleep(1000);
            faqQestion1.Click();
            Thread.Sleep(1000);
            faqQestion2.Click();
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].scrollIntoView({block: 'center', behavior: 'smooth'});", acceptCTA);
            Thread.Sleep(1000);
            acceptCTA.Click();
        }


        public void acceptOrderConsentFI()
        {
            Thread.Sleep(1000);
            acceptConsnetFI.ScrollTo().WaitForElementToBeClickable().Click();

        }
        public void sampleConsentAU()
        {
            Thread.Sleep(1000);
            accpetContinueAU.ScrollTo().WaitForElementToBeClickable().Click();

        }




    }
}