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
        private static readonly Random random = new Random();
        public static string GetRandomDigit(int x)
        {
            string code = "";
            while (code.Length < x)
            {
                Char c = (char)random.Next(33, 125);
                if (Char.IsDigit(c))
                    code += c;
            }
            return code;
        }

        public class Product
        {
            public Product()
            {
                Name = "testitem_" + Zadanie12.GetRandomDigit(2);
                Quantity = "10";
                Code = "rd" + Zadanie12.GetRandomDigit(4);
                ImgPath = System.IO.Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
                ImgPath = Directory.GetParent(ImgPath).Parent.FullName;
                ImgPath = System.IO.Path.Combine(ImgPath, "images\\test_duck.png");
                Keywords = "Test Keywords";
                ShortDescription = "Test Short Description";
                Description = "Test Description";
                HeadTitle = "Test Head Title";

                MetaDescription = "Test Meta Description";
                PurchasePrice = "1";
                PricesUSD = "1";
                PricesEUR = "1";
            }

            public string Name { get; set; }
            public string Quantity { get; set; }
            public string Code { get; set; }
            public string ImgPath { get; set; }
            public string Keywords { get; set; }
            public string ShortDescription { get; set; }
            public string Description { get; set; }
            public string HeadTitle { get; set; }

            public string MetaDescription { get; set; }
            public string PurchasePrice { get; set; }
            public string PricesUSD { get; set; }
            public string PricesEUR { get; set; }

        }


        [Test]
        public void Test1()
        {

            var product = new Product();
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

            driver.FindElement(By.CssSelector("input[name='name[en]']")).SendKeys(product.Name);

            driver.FindElement(By.CssSelector("input[name='code']")).SendKeys(product.Code);
                       
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
            Qua.SendKeys(product.Quantity);

            driver.FindElement(By.CssSelector("input[name='new_images[]']")).SendKeys(product.ImgPath);

            var DataFrom = driver.FindElement(By.CssSelector("input[name='date_valid_from']"));
            DataFrom.SendKeys("27012019");

            var DataTo = driver.FindElement(By.CssSelector("input[name='date_valid_to']"));
            DataFrom.SendKeys("27012020");

            driver.FindElement(By.CssSelector("a[href$='#tab-information']")).Click();

            var Manufacture = driver.FindElement(By.Name("manufacturer_id"));
            var SelectElement = new SelectElement(Manufacture);
            SelectElement.SelectByValue("1");

            driver.FindElement(By.CssSelector("input[name='keywords']")).SendKeys(product.Keywords);
            driver.FindElement(By.CssSelector("input[name='short_description[en]']")).SendKeys(product.ShortDescription);
            driver.FindElement(By.CssSelector("div[class='trumbowyg-editor']")).SendKeys(product.Description);
            driver.FindElement(By.CssSelector("input[name='head_title[en]']")).SendKeys(product.HeadTitle);
            driver.FindElement(By.CssSelector("input[name='meta_description[en]']")).SendKeys(product.MetaDescription);
            driver.FindElement(By.CssSelector("a[href$='#tab-prices']")).Click();
            var PuPr = driver.FindElement(By.CssSelector("input[name='purchase_price']"));
            PuPr.Clear();
            PuPr.SendKeys(product.PurchasePrice);

            var PurchaseCurrency = driver.FindElement(By.Name("purchase_price_currency_code"));
            var se3 = new SelectElement(PurchaseCurrency);
            se3.SelectByValue("USD");

            driver.FindElement(By.CssSelector("input[name='prices[USD]']")).SendKeys(product.PricesUSD);

            driver.FindElement(By.CssSelector("input[name='prices[EUR]']")).SendKeys(product.PricesEUR);

            driver.FindElement(By.CssSelector("button[name='save']")).Click();

            try
            {
                driver.FindElement(By.XPath("//table[@class='dataTable']//a[contains(.,'" + product.Name + "')]"));
              
            }
            catch
            {
                //Если товар не найден то что-то делаем
            }
        }
    }
}
