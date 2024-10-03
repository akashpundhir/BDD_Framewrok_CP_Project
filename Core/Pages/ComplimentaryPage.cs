using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
namespace Core.Pages
{
    public class ComplimentaryPage
    {
        /*Web elements on the page list*/
        #region
        IWebElement H2onpage => Driver.Browser.FindElement(By.XPath("//h2[normalize-space()='Complimentary Items']"));
        IWebElement h4DisposalBag => Driver.Browser.FindElement(By.XPath("//h4[normalize-space()='COMPLIMENTARY DISPOSAL BAG']"));
        IWebElement h4DCompWipesLarge => Driver.Browser.FindElement(By.XPath("//h4[normalize-space()='COMPLIMENTARY WIPES (LARGE)']"));
        IWebElement h4DDryWipesSmall => Driver.Browser.FindElement(By.XPath("//h4[normalize-space()='CHARTER DRY WIPES SMALL']"));
        /*Item container block and items*/
        IWebElement productContainer => Driver.Browser.FindElement(By.XPath("//div[@class='product-container']"));
        IWebElement CH0001 => Driver.Browser.FindElement(By.XPath("//label[@for='380NCH0001']"));
        IWebElement CH0002 => Driver.Browser.FindElement(By.XPath("//label[@for='380NCH0002']"));
        IWebElement CH0006 => Driver.Browser.FindElement(By.XPath("//label[@for='380NCH0006']"));
        /*Checkboxs*/
        IWebElement shadowHost1 => Driver.Browser.FindElement(By.CssSelector("label[for='380NCH0001']"));
        IWebElement cssSelectorForHost2 => Driver.Browser.FindElement(By.CssSelector("label[for='380NCH0002']"));
        IWebElement cssSelectorForHost6 => Driver.Browser.FindElement(By.CssSelector("label[for='380NCH0006']"));
        IWebElement shadowDomHostElementBefore => Driver.Browser.FindElement(By.CssSelector("::before"));
        IWebElement shadowDomHostElementAfter => Driver.Browser.FindElement(By.CssSelector("::after"));
        /*buttons*/
        IWebElement quantityBox => Driver.Browser.FindElement(By.XPath("(//span[@class='complimentary-quantity-selector c-global-basket__quantity-selector'])[2]"));
        IWebElement qunaityNumber => Driver.Browser.FindElement(By.XPath("//input[@type='number'])[1]"));
        IWebElement decreaseBTN => Driver.Browser.FindElement(By.XPath("(//button[@class='c-quantity-selector__decrease-btn'][normalize-space()='-'])[1]"));
        IWebElement increaseBTN => Driver.Browser.FindElement(By.XPath("(//button[@class='c-quantity-selector__increase-btn'][normalize-space()='+'])[1]"));
        IWebElement proccedBTN => Driver.Browser.FindElement(By.XPath("//button[@class='ds-button ds-button--primary ds-button--lg']"));
        IWebElement doNotAddBTN => Driver.Browser.FindElement(By.XPath("//button[@class='ds-button ds-button--ghost ds-button--lg']"));
        #endregion
        public void verifyPageContent()
        {
            Assert.Equals(H2onpage.Text, "Complimentary Items");
            Console.WriteLine("Page H2 verified successfully");
            Assert.Equals(h4DisposalBag.Text, "COMPLIMENTARY DISPOSAL BAG");
            Console.WriteLine("Disposal bag displayed");
            Assert.Equals(h4DCompWipesLarge.Text, "COMPLIMENTARY WIPES (LARGE)");
            Console.WriteLine("Wipes-Large displayed");
            Assert.Equals(h4DDryWipesSmall.Text, "CHARTER DRY WIPES SMALL");
            Console.WriteLine("Dry wipes displayed");
        }
        public void selectCheckboxBefore()
        {
            var shadowHost = shadowHost1;
            var shadowRoot = shadowHost.GetShadowRoot();
            var shadowContent = shadowRoot.FindElement(By.CssSelector("::before"));
            shadowContent.CustomClick();
        }
        public void toUnChecktheCheckBox()
        {
            var shadowHost = shadowHost1;
            var shadowRoot = shadowHost.GetShadowRoot();
            var shadowContent = shadowRoot.FindElement(By.CssSelector("::after"));
            shadowContent.CustomClick();
        }
        /*Comp-Disposl-bags*/
        #region
        public void addComDispsolBag()
        {
            Assert.Equals(productContainer.Displayed, true);
            CH0001.Click();
            Assert.ReferenceEquals(quantityBox.Text, "1");
            Console.WriteLine(quantityBox.Text);
        }
        public void increaseComDispsolBag()
        {
            increaseBTN.Click();
            Assert.ReferenceEquals(quantityBox.Text, "2");
            Console.WriteLine(quantityBox.Text);
        }
        public void decreaseComDispsolBag()
        {
            decreaseBTN.Click();
            Assert.ReferenceEquals(quantityBox.Text, "1");
            Console.WriteLine(quantityBox.Text);
        }
        #endregion
        /*Comp-Large-Wipes*/
        #region
        public void addCompLargeWipes()
        {
            Assert.Equals(productContainer.Displayed, true);
            CH0002.Click();
            Assert.ReferenceEquals(quantityBox.Text, "1");
            Console.WriteLine(quantityBox.Text);
        }
        public void increaseCompLargeWipes()
        {
            increaseBTN.Click();
            Assert.ReferenceEquals(quantityBox.Text, "2");
            Console.WriteLine(quantityBox.Text);
        }
        public void decreaseCompLargeWipes()
        {
            decreaseBTN.Click();
            Assert.ReferenceEquals(quantityBox.Text, "1");
            Console.WriteLine(quantityBox.Text);
        }
        #endregion
        /*Comp-Dry-Wipes*/
        #region
        public void addCompDryWipes()
        {
            Assert.Equals(productContainer.Displayed, true);
            CH0002.Click();
            Assert.ReferenceEquals(quantityBox.Text, "1");
            Console.WriteLine(quantityBox.Text);
        }
        public void increaseCompDryWipes()
        {
            increaseBTN.Click();
            Assert.ReferenceEquals(quantityBox.Text, "2");
            Console.WriteLine(quantityBox.Text);
        }
        public void decreaseCompDryWipes()
        {
            decreaseBTN.Click();
            Assert.ReferenceEquals(quantityBox.Text, "1");
            Console.WriteLine(quantityBox.Text);
        }
        #endregion
        public void addSelected()
        {
            proccedBTN.Click();
        }
        public void doNotAdd()
        {
            doNotAddBTN.Click();
        }
    }
}
