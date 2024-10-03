using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
namespace Core.Pages
{
    public class OrderConfirmationPage
    {
        #region
        IWebElement confmsg => Driver.Browser.FindElement(By.XPath("//div[@class='c-global-checkout__wrapper-box-confirmation']"));
        IWebElement confmsgIN => Driver.Browser.FindElement(By.XPath("//h3[normalize-space()='Kiitos tilauksestasi']"));
        IWebElement confirmBTN => Driver.Browser.FindElement(By.XPath("//button[@class='e-button e-button--filled primary']"));

        IWebElement confmsgSpain=> Driver.Browser.FindElement(By.XPath("//h3[normalize-space()='Gracias por tu pedido']"));
        IWebElement closeBtn => Driver.Browser.FindElement(By.XPath("//button[@class='ds-button ds-button--secondary ds-button--lg']"));
       

        #endregion
        /* From Line 24-40 are specfic to Conatned*/
        public void OrderNumber()
        {
            /*Assert.AreEqual("expected", confmsg);*/
            Thread.Sleep(2000);
            Console.WriteLine(confmsg.Text);
            confirmBTN.Click();
        }
        public void confirmationFIN()
        {
            Thread.Sleep(2000);
            Assert.AreEqual(confmsgIN.Text, "Kiitos tilauksestasi");
            Console.WriteLine("Out of pocket order placed on FINLAND as a Guest user");
        }

        public void confirmationSpain()
        {
            Thread.Sleep(2000);
            Assert.AreEqual(confmsgSpain.Text, "Gracias por tu pedido");
            closeBtn.ScrollTo().WaitForElementToBeClickable().Click();
        }
    }
}