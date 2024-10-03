using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Reqnroll;

namespace ColoplastProfessional.Steps
{
    [Binding]
    public class ContentSteps
    {
        [Given(@"User searches {string}")]
        public void GivenUserSearches(string p0)
        {
            Driver.Browser.FindElement(By.XPath("//main//input[@data-testid='global-search-field']"), 60).WaitForElementToBeClickable(10).SendKeys(p0);
            Driver.Browser.FindElement(By.XPath("//div[@class='c-global-search-autosuggestions__box']"), 60);
            Driver.Browser.FindElement(By.XPath("//main//input[@data-testid='global-search-field']"), 60).WaitForElementToBeClickable(10).SendKeys(Keys.Enter);

            Driver.Browser.FindElement(By.Id("spinner-overlay"), 10);
            Driver.BrowserWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("spinner-overlay")));
        }

        [When(@"User is clicked search result {string}")]
        public void WhenUserIsClickedSearchResult(string p0)
        {
            bool found = false;
            int count = 0;

            while (count < 5)
            {
                try
                {
                    found = Driver.Browser.FindElement(By.XPath($"//article[contains(.,'{p0}')]"), 10).Displayed;

                    Driver.Browser.FindElement(By.XPath($"//article[contains(.,'{p0}')]"), 10).Click();
                    
                    break;
                }
                catch (WebDriverTimeoutException)
                {
                    Helper.ScrollDown();
                }

                count++;

                if (count == 5)
                    throw new NoSuchElementException($"Page '{p0}' was not found");
            }
        }

        [Then(@"Article page is opened and content is shown correct")]
        public void ThenArticlePageIsOpenedAndContentIsShownCorrect()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//main//h1"), 60).Text.Contains("Leg Ulcers: Identification, Assessment and Management -HCP Article"));
                Assert.AreEqual("HCP Article page", Driver.Browser.FindElement(By.XPath("//p[contains(@class,'sup-headline')]")).Text);
                var tags = Driver.Browser.FindElements(By.XPath("//div[contains(@class,'keywords')]//span")).ToList();
                Assert.IsTrue(tags.Count>=1);
                Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//div[@class='-row --hcparticle']")).Text.Contains("Residual urine or incomplete bladder emptying is an important " +
                    "UTI risk factor for catheter users9, so it is beneficial for them to " +
                    "know that a flow stop does not necessarily indicate that the bladder " +
                    "is empty. Residual urine after first flow stop may contain pathogenic" +
                    " bacteria, which, if allowed to remain in the bladder, multiply and may" +
                    " cause a UTI. This makes complete bladder emptying* key in alleviating" +
                    " the risk of UTI in catheter users. *Complete bladder emptying is defined" +
                    " as <10 mL residual urine 3,4"));
                var factBoxes = Driver.Browser.FindElements(By.XPath("//div[@class='c-fact-box']")).ToList();
                Assert.AreEqual(2, factBoxes.Count);
                Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//div[@class='video-poster']")).ScrollTo().Displayed);
                Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//div[@class='c-podcast-player__container --top']")).ScrollTo().Displayed);
            });
        }

        [Given(@"User is clicked first search result")]
        public void GivenUserIsClickedFirstSearchResult()
        {
            var results = Driver.Browser.FindElements(By.XPath("//div[@id='global-search-page']//article"), 60).ToList();
            results.First().Click();
        }

        [When(@"User is clicking Start Course")]
        public void WhenUserIsClickingStartCourse()
        {
            Driver.Browser.FindElement(By.XPath("//a//span[.='Start Course']"), 60).Click();
        }

        [Then(@"Showpad is opened")]
        public void ThenShowpadIsOpened()
        {
            Driver.Browser.SwitchTo().Window(Driver.Browser.WindowHandles[1]);
            Driver.Browser.FindElement(By.XPath("//input[@type='checkbox']"), 60).SendKeys(Keys.Space);
            Driver.Browser.FindElement(By.Id("continue_with_consent")).Click();

            var cards = Driver.Browser.FindElements(By.XPath("//sp-course-card"), 60).ToList();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(Driver.Browser.Url.Contains("showpad"));
                Assert.AreEqual(2, cards.Count);
            });
        }

        [Given(@"User click on Logo to redirect on main page")]
        public void GivenUserClickOnLogoToRedirectOnMainPage()
        {
            Driver.Browser.FindElement(By.XPath("//a[@data-param='/api/navigation/clearcache']"), 60).Click();        
        }

        [Then(@"Theme page is opened and content is shown correct")]
        public void ThenThemePageIsOpenedAndContentIsShownCorrect()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//main//h1"), 60).Text.Contains("Leg Ulcers: Identification, Assessment and Management -HCP Theme"));
                Assert.AreEqual("Theme Page", Driver.Browser.FindElement(By.XPath("//p[contains(@class,'sup-headline')]")).Text);
                var tags = Driver.Browser.FindElements(By.XPath("//div[contains(@class,'keywords')]//span")).ToList();
                Assert.AreEqual(5, tags.Count);
                Assert.IsTrue(Driver.Browser.FindElement(By.XPath("//div[@class='-row --hcptheme']"))
                    .Text.Contains("In this section, you’ll find short, informative articles " +
                    "on understanding the impact of leakage on patients’ mental health. " +
                    "These newsletters are based on, or inspired by the global best" +
                    " practice guidelines on stoma care."));
                var recommended = Driver.Browser.FindElements(By.XPath("//div[contains(@class,'c-content-recommended__wrapper--static')]//a")).ToList();
                Assert.AreEqual(5, recommended.Count);
            });
        }
    }
}
