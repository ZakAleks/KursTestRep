using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest.pages
{
    internal class MarketProdPage : Page
    {
        public MarketProdPage(IWebDriver driver) : base(driver) { }

        internal MarketProdPage SelectSmallSiza()
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                var size = driver.FindElement(By.Name("options[Size]"));
                var selectElement = new SelectElement(size);
                selectElement.SelectByValue("Small");
            }
            catch
            { }
            finally
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            return this;
        }

        internal MarketProdPage ClickAddToCart()
        {
            var buttonAddCatr = driver.FindElement(By.CssSelector("button[name='add_cart_product']"));
            buttonAddCatr.Click();
            return this;
        }

        internal int GetQuantityItemInCart()
        {
            var quantityItemInCart = driver.FindElement(By.CssSelector("span[class='quantity']"));
            int qI = Int32.Parse(quantityItemInCart.Text);
            return qI;
        }

        internal void ClickLogo()
        {
            driver.FindElement(By.CssSelector("div[id = 'logotype-wrapper']")).Click();
        }
    }
}
