using Core.Drivers;
using Reqnroll;

namespace Core.Steps
{
    [Binding]
    public class GeneralSteps
    {
        [Given(@"Chrome browser is started")]
        public void GivenChromeBrowserIsStarted()
        {
            Driver.StartBrowser(Helper.BrowserTypes.Chrome, 120);
            Driver.Browser.Manage().Cookies.DeleteAllCookies();
        }

        [Given(@"Edge browser is started")]
        public void GivenEdgeBrowserIsStarted()
        {
            Driver.StartBrowser(Helper.BrowserTypes.Edge, 120);
            Driver.Browser.Manage().Cookies.DeleteAllCookies();
        }
    }
}
