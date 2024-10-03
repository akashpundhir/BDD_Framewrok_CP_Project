using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.ObjectModel;

namespace Core.Drivers
{
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Extension method for Finding element with timeout
        /// </summary>
        /// <param name="driver">Driver Instance</param>
        /// <param name="by">By locator</param>
        /// <param name="timeoutInSeconds">Timeout in seconds</param>
        /// <returns>Returns an instance of IWebElement</returns>
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

                    return wait.Until(drv => drv.FindElement(by));
                }

                return driver.FindElement(by);

            }
            catch (Exception)
            {
                if (timeoutInSeconds !=0)
                    throw new WebDriverTimeoutException($"no such element: Unable to locate element: \"method\":\"{by.Mechanism}\", \"selector\":\"{by.Criteria}\" within {timeoutInSeconds} seconds");
                else throw new WebDriverTimeoutException($"no such element: Unable to locate element:\"method\":\"{by.Mechanism}\", \"selector\":\"{by.Criteria}\"");
            }
        }

        /// <summary>
        /// Extension method for Finding elements with timeout
        /// </summary>
        /// <param name="driver">Driver Instance</param>
        /// <param name="by">By locator</param>
        /// <param name="timeoutInSeconds">Timeout in seconds</param>
        /// <returns>Returns an ReadOnly Collection of IWebElements</returns>
        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

                    return wait.Until(drv => (drv.FindElements(by).Count > 0) ? drv.FindElements(by) : null);
                }

                return driver.FindElements(by);

            }
            catch (Exception)
            {
                if (timeoutInSeconds != 0)
                    throw new WebDriverTimeoutException($"no such elements: Unable to locate element: \"method\":\"{by.Mechanism}\", \"selector\":\"{by.Criteria}\" within {timeoutInSeconds} seconds");
                else throw new WebDriverTimeoutException($"no such elements: Unable to locate element:\"method\":\"{by.Mechanism}\", \"selector\":\"{by.Criteria}\"");
            }
        }

        /// <summary>
        /// Extension method for string. 
        /// </summary>
        /// <param name="text">string instances</param>
        /// <param name="value">value to find</param>
        /// <param name="stringComparison"></param>
        /// <returns>Returns true or false</returns>
        public static bool CaseInsensitiveContains(this string text, string value,
        StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return text.IndexOf(value, stringComparison) >= 0;
        }

        /// <summary>
        /// Extension method for string. 
        /// </summary>
        /// <param name="text">string instances</param>
        /// <param name="value">value to find</param>
        /// <param name="stringComparison"></param>
        /// <returns>Returns true or false</returns>
        public static bool CaseInsensitiveEquals(this string text, string value,
        StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return text.Equals(value, stringComparison);
        }

        /// <summary>
        /// Extension method for finding IWebElement from IWebElement
        /// </summary>
        /// <param name="element">IWebElement instance</param>
        /// <param name="by">By locator</param>
        /// <param name="timeoutInSeconds">Timeout in seconds</param></param>
        /// <returns></returns>
        public static IWebElement FindElement(this IWebElement element, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

                return wait.Until(element => element.FindElement(by));
            }

            return element.FindElement(by);
        }

        /// <summary>
        /// Extension method for finding collection of IWebElements from IWebElement
        /// </summary>
        /// <param name="element">IWebElement instance</param>
        /// <param name="by">By locator</param>
        /// <param name="timeoutInSeconds">Timeout in seconds</param></param>
        /// <returns></returns>
        public static ReadOnlyCollection<IWebElement> FindElements(this IWebElement element, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(timeoutInSeconds));

                return wait.Until(element => (element.FindElements(by).Count > 0) ? element.FindElements(by) : null);
            }

            return element.FindElements(by);
        }

        /// <summary>
        /// Method for click if reular selenium doesn't work
        /// </summary>
        /// <param name="element"></param>
        public static void CustomClick(this IWebElement element)
        {
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].click();", element);
        }

        /// <summary>
        /// Scroll to the element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static IWebElement ScrollTo(this IWebElement element)
        {
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].scrollIntoView({block: 'center', behavior: 'smooth'});", element);

            System.Threading.Thread.Sleep(1000);

            return element;
        }

        /// <summary>
        /// Get parent of the element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static IWebElement GetParentElement(this IWebElement element)
        {
            IWebElement parent = element.FindElement(By.XPath("../.."));

            return parent;
        }

        /// <summary>
        /// Check if the element exists
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <returns></returns>
        public static bool IsElementExists(this IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Perfrom double click on element
        /// </summary>
        /// <param name="element"></param>
        public static void DoubleClick(this IWebElement element)
        {
            var action = new Actions(Driver.Browser);

            action.DoubleClick(element).Build().Perform();
        }

        /// <summary>
        /// Get value of the element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetAttributeValue(this IWebElement element)
        {
            return element.GetAttribute("value");
        }

        /// <summary>
        /// Wait for the element visibility for 30 seconds
        /// </summary>
        /// <param name="wait"></param>
        /// <param name="by"></param>
        public static IWebElement WaitForVisibility(this WebDriverWait wait, By by)
        {
            wait.PollingInterval = TimeSpan.FromSeconds(1);
            wait.Until(ExpectedConditions.ElementIsVisible(by));

            return Driver.Browser.FindElement(by);
        }

        /// <summary>
        /// Wait for the element to be clickable for 30 seconds
        /// </summary>
        /// <param name="wait"></param>
        /// <param name="by"></param>
        public static IWebElement WaitForElementToBeClickable(this WebDriverWait wait, By by)
        {
            wait.PollingInterval = TimeSpan.FromSeconds(1);
            wait.Until(ExpectedConditions.ElementToBeClickable(by));

            return Driver.Browser.FindElement(by);
        }

        /// <summary>
        /// Wait for the element to be clickable for default 60 seconds
        /// </summary>
        /// <param name="wait"></param>
        /// <param name="by"></param>
        public static IWebElement WaitForElementToBeClickable(this IWebElement element)
        {
            Driver.BrowserWait.PollingInterval = TimeSpan.FromSeconds(1);
            Driver.BrowserWait.Until(ExpectedConditions.ElementToBeClickable(element));

            return element;
        }

        public static IWebElement WaitForElementToBeClickable(this IWebElement element, int timeout)
        {
            var wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(timeout));
            wait.PollingInterval = TimeSpan.FromSeconds(1);
            wait.Until(ExpectedConditions.ElementToBeClickable(element));

            return element;
        }

        public static void WaitForPageLoad(this WebDriverWait wait)
        {
            wait.Until(drv => ((IJavaScriptExecutor)drv).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static IWebElement ClearExt(this IWebElement element)
        {
            element.Clear();

            return element;
        }

        public static IWebElement Wait(this IWebElement element, int timeout)
        {
            System.Threading.Thread.Sleep(timeout*1000);

            return element;
        }
    }
}
