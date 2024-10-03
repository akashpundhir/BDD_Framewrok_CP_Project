using Core.Base;
using Core.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Multisite.PageObjects.B2CLogin
{
    public class LoginPage : BasePage
    {
        public LoginPage() : base()
        {
        }

        public IWebElement Email => Browser.FindElement(By.Id("email"), 30);
        public IWebElement Password => Browser.FindElement(By.Id("password"));
        public IWebElement LoginBtn => Browser.FindElement(By.Id("next"));
    }
}
