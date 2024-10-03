using Core.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
namespace Core.Pages
{
    internal class Minibasket
    {
        /*Basket icon & Basket elements*/
        #region
        IWebElement basketImage => Driver.Browser.FindElement(By.XPath("//img[@alt='Warenkorb']"));
        IWebElement basketIconCount => Driver.Browser.FindElement(By.XPath("//span[@class='c-nav-basket__count']"));
        /*Basket elements*/
        IWebElement miniBasketQuantity => Driver.Browser.FindElement(By.XPath("//div[@class='c-global-basket__quantity-number']"));
        IWebElement totalPrice => Driver.Browser.FindElement(By.XPath("//span[@class='c-global-basket__product-total']"));
        IWebElement subTotal => Driver.Browser.FindElement(By.XPath("//span[@class='c-global-basket__summary-value'][contains(text(),'59,70 €')]"));
        #endregion
        /*Verify Basket count and Icon count*/
        public void verifyBasketCount()
        {
            if (basketIconCount.Text == "3")
            {
                Assert.Equals("3", basketIconCount.Text);
                Console.WriteLine("Qauntity of product in basket icon is  " + basketIconCount.Text + ", Count match!");
                Assert.Equals("3", miniBasketQuantity.Text);
                Console.WriteLine("Qauntity in  mini basket is " + miniBasketQuantity.Text + ", Quantity match!");
                Assert.Equals("59,70 €", totalPrice.Text);
                Console.WriteLine("Price of product is  " + totalPrice.Text + ", Price match!");
                /* Assert.AreEqual("59,70 €", subTotal.Text);
                 Console.WriteLine("Qauntity of product in basket is  " + subTotal.Text + " Subtotl match!");*/
            }
            else
            {
                Console.WriteLine("price mismatch! Test case fail");
            }
        }
    }
}
