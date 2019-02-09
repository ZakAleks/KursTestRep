using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest.pages
{
    internal class MarketMainPage : Page
    {
        public MarketMainPage(IWebDriver driver) : base(driver) { }

        internal MarketMainPage Open()
        {
            driver.Url = "http://localhost/litecart/en/";
            return this;
        }

        internal void ClickFirstProdInList()
        {
            var firstsProd = driver.FindElement(By.CssSelector("ul[class='listing-wrapper products'] li"));
            firstsProd.Click();
        }

        internal void OpenCart()
        {
            driver.FindElement(By.CssSelector("a[href$='/checkout'][class='link']")).Click();
        }
    }
}
