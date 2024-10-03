using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace Core.Drivers
{
    /// <summary>
    /// Driver manager
    /// </summary>
    public class Driver
    {
        private static WebDriverWait _browserWait;

        private static readonly ThreadLocal<IWebDriver> _driver;

        /// <summary>
        /// Multi-threading, thread-safe instance consrtuctor
        /// </summary>
        static Driver()
        {
            _driver = new ThreadLocal<IWebDriver>();
        }

        public Driver(IWebDriver browser)
        {
            Browser1 = browser;
        }

        /// <summary>
        /// Browser instance
        /// </summary>
        public static IWebDriver Browser
        {
            get
            {
                if (_driver == null)
                {
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method Start.");
                }
                return _driver.Value;
            }

            set
            {
                _driver.Value = value;
            }
        }

        /// <summary>
        /// Wait instance
        /// </summary>
        public static WebDriverWait BrowserWait
        {
            get
            {
                if (_browserWait == null || _driver == null)
                {
                    throw new NullReferenceException("The WebDriver browser wait instance was not initialized. You should first call the method Start.");
                }
                return _browserWait;
            }
            private set
            {
                _browserWait = value;
            }
        }

        public IWebDriver Browser1 { get; }

        /// <summary>
        /// Creating Browser instance with defined type (Safari, Edge, etc.). Session is created in its own thread.
        /// </summary>
        /// <param name="browserType"></param>
        /// <param name="defaultTimeOut"></param>
        public static void StartBrowser(Helper.BrowserTypes browserType, int defaultTimeOut = 60)
        {
            var assemblyConfigurationAttribute = typeof(Driver).Assembly.GetCustomAttribute<AssemblyConfigurationAttribute>();
            var buildConfigurationName = assemblyConfigurationAttribute?.Configuration;

            var path = Helper.TryGetSolutionDirectoryInfo().FullName + $"/Core/bin/{buildConfigurationName}/net8.0/";

            switch (browserType)
            {
                case Helper.BrowserTypes.Chrome:
                    var chromeOptions = new ChromeOptions();

                    List<string> chrome_arguments = new List<string>();

                    if (Environment.UserName == "CPAZDEVDCPBUILDAGENT")
                    {
                        chrome_arguments.Add("window-size=1920,1080");
                        chrome_arguments.Add("no-sandbox");
                        chrome_arguments.Add("disable-gpu");
                        chrome_arguments.Add("-inprivate");
                        chrome_arguments.Add("headless");
                    }
                    else
                    {
                        chromeOptions.AddArgument(@$"load-extension={path}BrowserExtensions/GA_Debugger/");
                    }

                    string[] chrome_args = chrome_arguments.ToArray();

                    chromeOptions.AddArguments(chrome_args);
                    chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
                    chromeOptions.UseSpecCompliantProtocol = true;

                    var chromedriver = new ChromeDriver(path, chromeOptions);
                    chromedriver.Manage().Window.Maximize();

                    Browser = chromedriver;

                    break;

                case Helper.BrowserTypes.Edge:
                    var edgeOptions = new EdgeOptions();

                    List<string> edge_arguments = new List<string>();

                    if(Environment.UserName == "CPAZDEVDCPBUILDAGENT")
                    {
                        edge_arguments.Add("window-size=1920,1080");
                        edge_arguments.Add("no-sandbox");
                        edge_arguments.Add("disable-gpu");
                        edge_arguments.Add("-inprivate");
                        edge_arguments.Add("headless");
                    }
                    else
                    {
                        edgeOptions.AddArgument(@$"load-extension={path}BrowserExtensions/GA_Debugger/");
                    }

                    string[] edge_args = edge_arguments.ToArray();

                    edgeOptions.AddArguments(edge_args);
                    edgeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
                    edgeOptions.UseSpecCompliantProtocol = true;
                    
                    var edgedriver = new EdgeDriver(path, edgeOptions);

                    if(Environment.UserName != "CPAZDEVDCPBUILDAGENT")
                        edgedriver.Manage().Window.Maximize();

                    Browser = edgedriver;

                    break;

                default:
                    break;
            }
            BrowserWait = new WebDriverWait(Browser, TimeSpan.FromSeconds(defaultTimeOut));
        }

        /// <summary>
        /// Safe closing Driver instance
        /// </summary>
        public static void StopBrowser()
        {
            Browser.Quit();
            Browser.Dispose();
            if (Browser != null)
                Browser = null;
        }

        /// <summary>
        /// Warapper over the standard Selenium Navigate function 
        /// </summary>
        /// <param name="url"></param>
        public static void Navigate(string url)
        {
            Browser.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Waoit for the AJAX call to be completed in acceptable time
        /// </summary>
        /// <param name="maxSeconds"></param>
        public static void WaitForAjaxComplete(int maxSeconds = 30)
        {
            var isAjaxCallComplete = false;
            for (var i = 1; i <= maxSeconds; i++)
            {
                isAjaxCallComplete = (bool)((IJavaScriptExecutor)Browser).
                ExecuteScript("return window.jQuery != undefined && jQuery.active == 0");

                if (isAjaxCallComplete)
                {
                    return;
                }
                Thread.Sleep(1000);
            }

            throw new WebDriverTimeoutException(string.Format("Timed out after {0} seconds", maxSeconds));
        }

        /// <summary>
        /// Get currently running browser capabilities (browser name, version, platform, etc.)
        /// </summary>
        /// <returns></returns>
        public static ICapabilities GetBrowserCapabilities()
        {
            ICapabilities capabilities = null;

            try
            {
                capabilities = ((RemoteWebDriver)Browser).Capabilities;
            }
            catch (InvalidCastException)
            {
                capabilities = ((WebDriver)Browser).Capabilities;
            }
            return capabilities;
        }
    }
}
