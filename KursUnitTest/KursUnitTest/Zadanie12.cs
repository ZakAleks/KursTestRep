using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest
{
    [TestFixture]
    class Zadanie12 : BaseTest
    {
        private readonly Random random = new Random();
        public string GetRandomText(int x)
        {
            string code = "";
            var r = new Random();
            while (code.Length < x)
            {
                Char c = (char)r.Next(33, 125);
                if (Char.IsDigit(c))
                    code += c;
            }
            return code;
        }

        [Test]
        public void Test1()
        {
            var ranItNa = GetRandomText(2);
            var ranCode = GetRandomText(4);
            string Name = "testitem_" + ranItNa;
            string Quantity = "10";
            string Code = "rd"+ ranCode;

            string ImgPath = System.IO.Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
            ImgPath = Directory.GetParent(ImgPath).Parent.FullName;
            ImgPath = System.IO.Path.Combine(ImgPath, "images\\test_duck.png");




            //переходим на сайт
            driver.Url = "http://localhost/litecart/admin/login.php";
            var el = driver.FindElement(By.Name("username"));
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            driver.FindElement(By.CssSelector("a[href$='/?app=catalog&doc=catalog']")).Click();
            driver.FindElement(By.CssSelector("a[href$='&doc=edit_product']")).Click();

            var CheckBoxStatus = driver.FindElements(By.CssSelector("input[name='status']"));
            CheckBoxStatus[0].Click();

            driver.FindElement(By.CssSelector("input[name='name[en]']")).SendKeys(Name);

            driver.FindElement(By.CssSelector("input[name='code']")).SendKeys(Code);

                       
            var CheckRoot = driver.FindElement(By.CssSelector("input[name='categories[]'][data-name='Root']"));
            if (CheckRoot.GetCssValue("checked")!=null)
            {
                CheckRoot.Click();
            }

            var CheckRubberDucks = driver.FindElement(By.CssSelector("input[name='categories[]'][data-name='Rubber Ducks']"));

            if (CheckRubberDucks.GetCssValue("checked") == "")
            {
                CheckRubberDucks.Click();
            }

            var Qua = driver.FindElement(By.CssSelector("input[name='quantity']"));
            Qua.Clear();
            Qua.SendKeys(Quantity);

            driver.FindElement(By.CssSelector("input[name='new_images[]']")).SendKeys(ImgPath);

            var DataFrom = driver.FindElement(By.CssSelector("input[name='date_valid_from']"));
            DataFrom.Clear();

            var DataTo = driver.FindElement(By.CssSelector("input[name='date_valid_to']"));
            DataTo.Clear();


        }
    }
}
