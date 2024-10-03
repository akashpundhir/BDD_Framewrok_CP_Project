using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
namespace Core.Pages
{
    internal class ReimbursmentPage
    {
        /*Web elements on the page list*/
        #region
        IWebElement h1Description => Driver.Browser.FindElement(By.XPath("//h1[normalize-space()='Prescription information']"));
        IWebElement ddDate => Driver.Browser.FindElement(By.XPath("//input[@id='day']"));
        IWebElement mmMonth => Driver.Browser.FindElement(By.XPath("//input[@id='month']"));
        IWebElement yyyyYear => Driver.Browser.FindElement(By.XPath("//input[@id='year']"));
        IWebElement nhsNumber => Driver.Browser.FindElement(By.XPath("//input[@id='94b79e9f-eafb-4212-ad73-642f2a0bc781']"));
        IWebElement exemptStatus => Driver.Browser.FindElement(By.XPath("//button[@id='dropdown-button']"));
        IWebElement h3Description => Driver.Browser.FindElement(By.XPath("//h3[normalize-space()='GP practice']"));
        IWebElement gpPractice => Driver.Browser.FindElement(By.XPath("//input[@id='gpInformation']"));
        IWebElement autoGpSerach => Driver.Browser.FindElement(By.XPath("//input[@data-testid='autoSuggestInput']"));
        IWebElement gplist => Driver.Browser.FindElement(By.XPath("//div[@class='c-search-dropdown gp-practice-list']"));
        IWebElement cliftonMedical => Driver.Browser.FindElement(By.XPath("//div[normalize-space()='Doncaster Gate, ROTHERHAM S65 1DA.']"));
        IWebElement gplistbox => Driver.Browser.FindElement(By.XPath("//ul[@id='vs1__listbox']"));
        IWebElement submitCTa => Driver.Browser.FindElement(By.XPath("//button[@type='submit']"));
        #endregion
        /*Web elements missing error */
        #region
        IWebElement ddError => Driver.Browser.FindElement(By.XPath("//span[normalize-space()='Missing day']"));
        IWebElement mmError => Driver.Browser.FindElement(By.XPath("//span[normalize-space()='Missing month']"));
        IWebElement yyyyError => Driver.Browser.FindElement(By.XPath("//span[normalize-space()='Missing year']"));
        IWebElement exemptError => Driver.Browser.FindElement(By.XPath("//span[normalize-space()='Select one please']"));
        IWebElement gpError => Driver.Browser.FindElement(By.XPath("//span[normalize-space()='Search and select one from the list']"));
        #endregion
        /*Web elements wrong format error */
        #region
        IWebElement ddWrongFromat => Driver.Browser.FindElement(By.XPath("//div[@id='error_day']//span[@class='error show-error format-error'][normalize-space()='Wrong format']"));
        IWebElement mmWrongFromat => Driver.Browser.FindElement(By.XPath("//div[@id='error_month']//span[@class='error show-error format-error'][normalize-space()='Wrong format']"));
        IWebElement yyyyWrongFromat => Driver.Browser.FindElement(By.XPath("//div[@id='error_year']//span[@class='error show-error format-error'][normalize-space()='Wrong format']"));
        IWebElement WrongDOB => Driver.Browser.FindElement(By.XPath("//span[normalize-space()='Not a valid date for a birthday']"));
        #endregion
        /*Methods to validated Mandatory fields on websites*/
        public void verifyFields()
        {
            Assert.Equals(ddDate.Displayed, true);
            Assert.Equals(mmMonth.Displayed, true);
            Assert.Equals(yyyyYear.Displayed, true);
            Assert.Equals(nhsNumber.Displayed, true);
            Assert.Equals(exemptStatus.Displayed, true);
            Assert.Equals(gpPractice.Displayed, true);
            Assert.Equals(h1Description, "Prescription information");
            Assert.Equals(h3Description, "GP practice");
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].scrollIntoView({block: 'center', behavior: 'smooth'});", submitCTa);
        }
        /*Method to validated Empty fields*/
        public void verifyMissingFieldsError()
        {
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].scrollIntoView({block: 'center', behavior: 'smooth'});", submitCTa);
            submitCTa.Click();
            Assert.Equals(ddError.Displayed, true);
            Assert.Equals(mmError.Displayed, true);
            Assert.Equals(yyyyError.Displayed, true);
            Assert.Equals(exemptError.Displayed, true);
            Assert.Equals(gpError.Displayed, true);
        }
        /*Method to validated fields formats*/
        public void verifyWrongFormat()
        {
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].scrollIntoView({block: 'center', behavior: 'smooth'});", submitCTa);
            submitCTa.Click();
            ddDate.SendKeys("43");
            Assert.Equals(ddWrongFromat.Displayed, true);
            mmMonth.SendKeys("ds");
            Assert.Equals(mmWrongFromat.Displayed, true);
            yyyyYear.SendKeys("fdf");   
            Assert.Equals(yyyyWrongFromat.Displayed, true);
            Assert.Equals(WrongDOB.Displayed, true);
        }
        /*Method to fill details for NPR USER */
        public void fillNPRdetails()
        {
            ddDate.SendKeys("01");
            mmMonth.SendKeys("01");
            yyyyYear.SendKeys("1981");
            nhsNumber.SendKeys("3212345678");
            SelectElement exempt = new SelectElement(exemptStatus);
            exempt.SelectByIndex(4);
            autoGpSerach.Click();
            autoGpSerach.SendKeys("clifton");
            if (cliftonMedical.Displayed)
            {
                cliftonMedical.WaitForElementToBeClickable();
                cliftonMedical.CustomClick();
                Console.WriteLine("User entered Clifton medical center as GP practice");
                submitCTa.Click();
            }
            else
            {
                Thread.Sleep(1000);
                autoGpSerach.Clear();
                Thread.Sleep(1000);
                autoGpSerach.Click();
                autoGpSerach.SendKeys("I c");
                Thread.Sleep(1000);
                autoGpSerach.SendKeys("an");
                Thread.Sleep(1000);
                autoGpSerach.SendKeys("not");
                Thread.Sleep(1000);
                cliftonMedical.CustomClick();
                submitCTa.Click();
            }
        }
    }
}
