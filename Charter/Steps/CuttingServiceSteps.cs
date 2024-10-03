using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Reqnroll;

namespace Charter.Steps
{
    [Binding]
    public class CuttingServiceSteps
    {
        [Given(@"I ticked I want cutting service")]
        public void GivenITickedIWantCuttingService()
        {
            Driver.Browser.FindElement(By.XPath("//label[contains(@for,'add-to-basket-option-cutting-service')]"), 30).Click();
        }

        [Then(@"I see cutting service checkbox ticked and cutting service banner displayed {string}")]
        public void ThenISeeCuttingTemplateCheckboxTickedAndCuttingServiceBannerDisplayed(string arg)
        {
            Thread.Sleep(2000);
            if(arg.Equals("cutting template doesn't exist"))
            {
                Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//div[contains(@data-testid,'info-box-new')]"), 30).Displayed);
            }
            else if(arg.Equals("cutting template added in SF"))
            {
                Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//div[contains(@data-testid,'info-box-active')]"), 30).Displayed);
            }
        }

        [Then(@"I see order summary page")]
        public void ThenISeeOrderSummaryPage()
        {
            Thread.Sleep(3000);
            Driver.BrowserWait.WaitForPageLoad();
            /*Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//div[@class='c-global-checkout__wrapper-holder']//div[@class='c-global-checkout__left-block']//section[@class='c-delivery-cart']"), 30).Displayed);
            Assert.IsTrue(Driver.Browser.FindElement(By.ClassName("c-delivery-cart__frame"),30).Displayed);*/
            Assert.IsTrue(Driver.Browser.Title.Equals("Order summary"));
        }

        [Then(@"Cutting service is added to the order")]
        [Then(@"I see cutting template is added")]
        public void ThenCuttingServiceIsAddedToTheOrder()
        {
            Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//p[contains(@data-testid,'cutting-service-summary')]"), 30).Displayed);
        }
    }
}
