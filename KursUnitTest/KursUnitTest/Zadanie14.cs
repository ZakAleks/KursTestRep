using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KursUnitTest
{
    [TestFixture]
    class Zadanie14 : BaseTest
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
            driver.FindElement(By.CssSelector("a[href$='app=countries&doc=countries']")).Click();
            driver.FindElement(By.CssSelector("a[href$='app=countries&doc=edit_country']")).Click();

            var newBlankAList = driver.FindElements(By.CssSelector("form[method='post'] a[target='_blank']"));
            foreach (var blankLink in newBlankAList)
            {
                blankLink.Click();

                //Ожидаем 5 секунд и считаем что этого времени достаточно для открытия окна\всех окон после нажатия ссылки
                Thread.Sleep(5000);

                bool ffoundNewWindow = false;
                //for (int i=0; i<10; i++)
                {
                    var allOpenWindowsHandle = driver.WindowHandles;

                    foreach (var newWindow in allOpenWindowsHandle)
                    {
                        if(!oldWindows.Contains(newWindow))
                        {
                            ffoundNewWindow = true;

                            driver.SwitchTo().Window(newWindow);
                            string curentWind = driver.CurrentWindowHandle;
                            Assert.True(curentWind == newWindow, "Handle current window not valid");
                            driver.Close();
                            driver.SwitchTo().Window(mainHandle);
                        }
                    }
                    //Thread.Sleep(1000);
                }
                if (!ffoundNewWindow)
                    Assert.Fail("new window not found");
            }
        }
    }
}
