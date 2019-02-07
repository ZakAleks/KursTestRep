using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KursUnitTest
{
    [TestFixture]
    class Zadanie15 : BaseTest
    {
        [Test]
        public void Test1()
        {
            //переходим на сайт
            driver.Url = "http://localhost/litecart/admin/login.php";

            string mainHandle = driver.CurrentWindowHandle;

            var oldWindows = driver.WindowHandles;

            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            driver.FindElement(By.CssSelector("a[href$='app=catalog&doc=catalog']")).Click();
            driver.FindElement(By.CssSelector("a[href$='?app=catalog&doc=catalog&category_id=1']")).Click();
            
            var prodList = driver.FindElements(By.CssSelector("a[href*='product_id'][title='Edit']"));
            List<string> prodUrls = new List<string>();
            foreach (var prod in prodList)
            {
                var url = prod.GetAttribute("href");
                prodUrls.Add(url);
            }

            foreach (var url in prodUrls)
            {
                int before = driver.Manage().Logs.GetLog("browser").Count();
                driver.Url = url;
                int after = driver.Manage().Logs.GetLog("browser").Count();
                Assert.True(before==after,"В логе появилось новое сообщение");
                //при необходимости дальше с ними можно делать что угодно
            }
        }
    }
}
