using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KursUnitTest
{
    [TestFixture]
    class Zadanie13 : BaseTest
    {


        [Test]
        public void Test1()
        {
            //переходим на сайт
            driver.Url = "http://localhost/litecart/en/";

            //int qI = 0;
            for (int i = 0; i < 3; i++)
            {
                //i++;
                var firstsProd = driver.FindElement(By.CssSelector("ul[class='listing-wrapper products'] li"));
                firstsProd.Click();

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


                var buttonAddCatr = driver.FindElement(By.CssSelector("button[name='add_cart_product']"));
                buttonAddCatr.Click();

                while(true)
                {
                    var quantityItemInCart = driver.FindElement(By.CssSelector("span[class='quantity']"));
                    int qI = Int32.Parse(quantityItemInCart.Text);
                    if (qI >= i + 1)
                        break;
                    Thread.Sleep(250);
                }
                driver.FindElement(By.CssSelector("div[id = 'logotype-wrapper']")).Click();
            }
            driver.FindElement(By.CssSelector("a[href$='/checkout'][class='link']")).Click();

            while (true)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                var itemList = driver.FindElements(By.CssSelector("tr td[class='item']"));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                if (itemList.Count == 0)
                {
                    break;
                }
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
                artText = artText.Replace("]","");

                var elArt = driver.FindElement(By.XPath("//table[@class='dataTable rounded-corners']//td[contains(.,'" + artText +"')]"));
                driver.FindElement(By.CssSelector("button[name='remove_cart_item']")).Click();
                wait.Until(ExpectedConditions.StalenessOf(elArt));
            }
        }
    }
}
