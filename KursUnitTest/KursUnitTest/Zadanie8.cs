using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest
{
    [TestFixture]
    class Zadanie8 : BaseTest
    {
        
        [Test]
        public void Test4()
        {
            //переходим на сайт
            driver.Url = "http://localhost/litecart/en/";
            //получаем список товаров на странице
            var prods =driver.FindElements(By.CssSelector("li[class*='product']"));
            //для каждого товара получаем стикеры
            foreach (var prod in prods)
            {
                var stikers = prod.FindElements(By.CssSelector("div[class^='sticker']"));
                //проверяем один ли стикер у товара
                Assert.True(stikers.Count == 1,"Не верное количество стикеров");
            }
        }
    }
}
