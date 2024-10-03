using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Reqnroll;

namespace Core.Hooks
{
    [Binding]
    public class GeneralHooks
    {
        //private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        private ScenarioContext _context;
        private FeatureContext _featureContext;

        public GeneralHooks(/*ISpecFlowOutputHelper specFlowOutputHelper, */ScenarioContext context, FeatureContext featureContext)
        {
            //_specFlowOutputHelper = specFlowOutputHelper;
            _context = context;
            _featureContext = featureContext;
        }

        [BeforeTestRun] 
        public static void BeforeRun()
        {
            if (Environment.UserName == "CPAZDEVDCPBUILDAGENT")
            {
                Helper.DeleteOldFiles();
            }

            string[] files = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "*.png", SearchOption.TopDirectoryOnly);
            foreach (string file in files)
                try
                {
                    File.Delete(file);
                }
                catch { }
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var cookies = Driver.Browser.Manage().Cookies.AllCookies.Where(x => x.Name.StartsWith("TrackingTest"));

            //foreach (var c in cookies)
            //{
            //    _specFlowOutputHelper.WriteLine(c.ToString());
            //}
            //var tags = _context.ScenarioInfo.Tags.ToList();

            //if (tags.Contains("newaccount"))
            //    _specFlowOutputHelper.WriteLine($"Email used in this test: {Helper.MultisiteEmail}");

            Driver.Browser.Manage().Cookies.DeleteAllCookies();
            Driver.StopBrowser();
        }

        [AfterStep]
        public void AfterStep()
        {
            string stepInfo = _context.StepContext.StepInfo.Text.Replace(" ", "_");

            if (!stepInfo.CaseInsensitiveContains("browser_is_started"))
            {
                var token = Environment.GetEnvironmentVariable("FILESHARE_SASTOKEN");
                var name = String.Format("{0}-{1}-{2}-{3}-{4}-{5}.png", 
                    Helper.GetBrowserName(), 
                    Helper.GetProjectName(), 
                    _featureContext.FeatureInfo.Title.Replace(" ", "_"), 
                    _context.ScenarioInfo.Title.Replace(" ", "_"), 
                    stepInfo.Replace("\"","_"),
                    DateTime.UtcNow.Ticks);

                var filename = String.Format("{0}\\{1}", 
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    name);

                Screenshot image = ((ITakesScreenshot)Driver.Browser).GetScreenshot();

                image.SaveAsFile(filename, ScreenshotImageFormat.Png);

                if (Environment.UserName == "CPAZDEVDCPBUILDAGENT")
                {
                    Helper.SaveScreenshotOnAzureShare(name);
                    
                    //_specFlowOutputHelper.AddAttachment($"https://muldvwest.file.core.windows.net/multisitescreenshots/{name}{token}");
                }
            }

            if (_context.ScenarioExecutionStatus != ScenarioExecutionStatus.OK)
            {
                Assert.Fail(_context.TestError.Message + "\n" + _context.TestError.StackTrace);
                //_specFlowOutputHelper.WriteLine(_context.TestError.Message + "\n" + _context.TestError.StackTrace);
            }
        }
    }
}