using ColoplastProfessional.PageObject;
using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using System.Configuration;
namespace ColoplastProfessional.Steps
{
    [Binding]
    public class MenuSteps
    {
        [Given(@"User is clicked {string} - {string} - {string}")]
        public void GivenUserIsClicked(string p0, string p1, string p2)
        {
            Driver.Browser.FindElement(By.XPath($"//button[@title='{p0}']"), 5).Click();
            Driver.Browser.FindElement(By.XPath($"//li/button[@title='{p0}']/..//ul[not(contains(@class,'tertiary'))]/li/button[@title='{p1}']"), 5).Click();
            Driver.Browser.FindElement(By.XPath($"//li/button[@title='{p0}']/..//ul[not(contains(@class,'tertiary'))]/li/button[@title='{p2}']"), 5).Click();
        }
        [Given(@"User is clicked {string} - {string}")]
        public void GivenUserIsClicked_(string p0, string p1)
        {
            Driver.Browser.FindElement(By.XPath($"//button[@title='{p0}']"), 5).Click();
            Driver.Browser.FindElement(By.XPath($"//li/button[@title='{p0}']/..//ul[not(contains(@class,'tertiary'))]/li/button[@title='{p1}']"), 5).Click();
        }
        [When(@"User is clicked {string}")]
        public void WhenUserIsClicked(string p0)
        {
            Driver.Browser.FindElement(By.LinkText(p0), 5).CustomClick();
        }
        [Then(@"Course card is shown")]
        public void ThenCourseCardIsShown()
        {
            try
            {
                Assert.IsTrue(Driver.Browser.FindElement(By.Id("content-info-card"), 10).Displayed);
            }
            catch
            {
                Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//div[@data-pagetype='article']"), 10).Text.Length > 0);
            }
        }
    }
}
