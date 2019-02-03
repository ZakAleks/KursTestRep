using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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

            int qI = 0;
            for (int i = qI; i < 3; )
            {
                i++;
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
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                }


                var buttonAddCatr = driver.FindElement(By.CssSelector("button[name='add_cart_product']"));
                buttonAddCatr.Click();

                while(qI != i)
                {
                    var quantityItemInCart = driver.FindElement(By.CssSelector("span[class='quantity']"));

                    qI = Int32.Parse(quantityItemInCart.Text);
                }

                driver.FindElement(By.CssSelector("div[id = 'logotype-wrapper']")).Click();

            }
            driver.FindElement(By.CssSelector("a[href$='/checkout'][class='link']")).Click();

            var itemList = driver.FindElements(By.CssSelector("tr td[class='item']"));
            var count = itemList.Count;
            while (count != 0)
            {
                try
                {
                    try
                    {
                        driver.FindElement(By.CssSelector("ul[class='shortcuts'] li[class='shortcut']")).Click();
                    }
                    catch
                    { }
                    //TODO нужно както логику подправить а то я тупить начинаю
                    driver.FindElement(By.CssSelector("button[name='remove_cart_item']")).Click();
                    count--;
                }
                catch
                {
                    count = 0;
                }
            }
        }
    }
}
