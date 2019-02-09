using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest.pages
{
    internal class MarketCartPage : Page
    {
        public MarketCartPage(IWebDriver driver) : base(driver) { }

        internal IReadOnlyCollection<IWebElement> GetListItemInCart()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            var itemList = driver.FindElements(By.CssSelector("tr td[class='item']"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return itemList;
        }

        internal string GetArtItemInList()
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                driver.FindElement(By.CssSelector("ul[class='shortcuts'] li[class='shortcut']")).Click();
            }
            catch
            { }
            finally
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }

            var art = driver.FindElement(By.CssSelector("form[name='cart_form'] span"));
            var artText = art.Text;
            artText = artText.Replace("[SKU: ", "");
            artText = artText.Replace("]", "");
            return artText;
        }

        internal MarketCartPage ClickDellItemInListAndWaitStalenessOf(string art)
        { 
            var elArt = driver.FindElement(By.XPath("//table[@class='dataTable rounded-corners']//td[contains(.,'" + art + "')]"));
            driver.FindElement(By.CssSelector("button[name='remove_cart_item']")).Click();
            wait.Until(ExpectedConditions.StalenessOf(elArt));
            return this;
        }
    }
}
