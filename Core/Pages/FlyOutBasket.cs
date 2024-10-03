using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using Core.Pages;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Configuration;
using System.Xml.Linq;
namespace Core.Pages
{
    public class FlyOutBasket
    {
        string deliveryPrice = "Gratis";
        string qantityValueCheck = "";
        /*Page WebElemnets list*/
        #region
        IWebElement basketIcon => Driver.Browser.FindElement(By.XPath("//nav[@class='c-nav-basket c-nav-basket--desktop']//img[@class='c-nav-basket__custom-icon']"));
        IWebElement baskettext => Driver.Browser.FindElement(By.XPath("//h1[normalize-space()='Shopping basket']"));
        IWebElement nameOfProduct => Driver.Browser.FindElement(By.CssSelector(".c-global-basket__product-link"));
        IWebElement qantityCheck => Driver.Browser.FindElement(By.XPath("//span[@class='c-global-basket__items']"));
        IWebElement sizeCheck => Driver.Browser.FindElement(By.XPath("//div[@class='c-global-basket__product-description']"));
        IWebElement textforBox => Driver.Browser.FindElement(By.XPath(""));
        IWebElement qunatityDiv => Driver.Browser.FindElement(By.CssSelector(".c-global-basket__quantity-selector"));
        IWebElement addQuantity => Driver.Browser.FindElement(By.XPath("//button[normalize-space()='+']"));
        IWebElement minusQuantity => Driver.Browser.FindElement(By.XPath("//button[normalize-space()='-']"));
        IWebElement priceChange => Driver.Browser.FindElement(By.CssSelector(".c-global-basket__product-total"));
        IWebElement subtotal => Driver.Browser.FindElement(By.XPath("//span[@class='c-global-basket__sub-total-value'][contains(text(),'59,70 €')]"));
        IWebElement gst => Driver.Browser.FindElement(By.XPath("//span[@class='c-global-basket__sub-total-value'][contains(text(),'0,00 €')]"));
        IWebElement deliveryFee => Driver.Browser.FindElement(By.XPath("//span[@class='c-global-basket__sub-total-value'][contains(text(),'Gratis')]"));
        IWebElement TotalVatIncul => Driver.Browser.FindElement(By.XPath("//span[@class='c-global-basket__total-value'])[contains(text(),'59,70 €']"));
        IWebElement textTotalVatIncul => Driver.Browser.FindElement(By.CssSelector(".c-cta-buttons__total-value"));
        IWebElement continueCTA => Driver.Browser.FindElement(By.CssSelector("button.e-button.e-button--filled.c-global-basket__checkout-btn"));
        IWebElement arrowBtn => Driver.Browser.FindElement(By.XPath("//span[@data-icon-name='chevron-up']//*[name()='svg']"));
        IWebElement deliveryNotFree => Driver.Browser.FindElement(By.XPath("//dd[normalize-space()='R95,00']"));
        IWebElement removeBtn => Driver.Browser.FindElement(By.XPath("//button[@class='c-global-basket__remove-btn ds-icon-button ds-icon-button--ghost-neutral ds-icon-button--sm']/span"));
        IWebElement removeBtnbySpan => Driver.Browser.FindElement(By.XPath("//span[@data-icon-name='delete']//*[name()='svg']"));
       /* WebElements for South africa version*/
        IWebElement zaContinueBTN => Driver.Browser.FindElement(By.XPath("//span[normalize-space()='Go to checkout']"));
        #endregion
        /*FlyOutBasket method to verify qunaitiy, price and text*/
        public void validateflyoutbasketDe()
        {
            Thread.Sleep(5000);
            Assert.Equals("1 Produkt", qantityCheck.Text);
            Console.WriteLine("Qauntity of product displayed is  " + qantityCheck.Text);
            Assert.Equals("Contend™", nameOfProduct.Text);
            Console.WriteLine("Name of product displayed is  " + nameOfProduct.Text);
            Assert.Equals("Normale Passform", sizeCheck.Text);
            Console.WriteLine("Size of product is  " + sizeCheck.Text);
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("arguments[0].scrollIntoView();", qunatityDiv);
            if (priceChange.Text == "39,80 €")
            {
                addQuantity.Click();
                /*Verify Price of 3 product*/
                Thread.Sleep(2000);
                Assert.Equals(priceChange.Text, "59,70 €");
                Console.WriteLine("Price of 3 is " + priceChange.Text + "Price match!");
                /*Subtotal*/
                Assert.Equals(subtotal.Text, "59,70 €");
                Console.WriteLine("Sub total of 3 boxes is " + priceChange.Text + " ,Sub total match!");
                /*GST*/
                Assert.Equals(gst.Text, "0,00 €");
                Console.WriteLine(gst.Text + " on 3 boxes " + " ,GST match!");
                /*DeliveryFee charges*/
                Assert.Equals(deliveryFee.Text, "Gratis");
                Console.WriteLine("Delivery of 3 boxes are " + deliveryFee.Text + ", Delivery match!");
                /*TotalVatIncul Inculding VAT*//*
                Assert.AreEqual(TotalVatIncul.Text, "59,70 €");
                Console.WriteLine("Total amount for 3 boxes are " + TotalVatIncul.Text + ", Total amount match!")*/
                Assert.Equals(textTotalVatIncul.Text, "59,70 €");
                Console.WriteLine("Amount displayed next to to  Continue CTA for 3 boxes " + textTotalVatIncul.Text + ", Amount match!");
            }
            else
            {
                Console.WriteLine("Test case fail, Price of 1 product is " + priceChange.Text);
            }
        }
        /*Click Continue checkout on FlyOutBasket*/
        public void clickContniueCTA()
        {
            continueCTA.Click();
        }     
        public void deleteAllItemFromBasket()
        {
            basketIcon.ScrollTo().WaitForElementToBeClickable().Click();
            if (removeBtn.Displayed)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver.Browser;
                executor.ExecuteScript("arguments[0].scrollIntoView(true).click();", removeBtn);
            }
            else if(removeBtnbySpan.Displayed)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver.Browser;
                executor.ExecuteScript("arguments[0].scrollIntoView(true).click();", removeBtnbySpan);
            }
            else
            {
                removeBtn.ScrollTo().Click();
            }
        }
        public void updateQauntity()
        {
            Assert.AreEqual(qantityCheck.Text, qantityCheck.Text);
            addQuantity.ScrollTo().WaitForElementToBeClickable().Click();
        }
        public void zacheckoutContniue()
        {
            zaContinueBTN.ScrollTo().WaitForElementToBeClickable().Click();
        }
    }
}
