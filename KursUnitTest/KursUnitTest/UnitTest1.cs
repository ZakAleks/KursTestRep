using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace KursUnitTest
{

    [TestFixture]

    public class FirstKursTest : BaseTest
    {

        [Test]
        public void Test1()
        {
            driver.Url = "http://localhost/litecart/admin/login.php";
            var el = driver.FindElement(By.Name("username"));
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            driver.FindElement(By.CssSelector("a[title='Logout']")).Click();
        }

        [Test]
        public void Test2()
        {
            driver.Url = "http://localhost/litecart/admin/login.php";
            var el = driver.FindElement(By.Name("username"));
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();

            driver.FindElement(By.CssSelector("li[id='app-']>a[href$='template']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-logotype']")).Click();
            driver.FindElement(By.CssSelector("h1"));

            driver.FindElement(By.CssSelector("li[id='app-']>a[href$='catalog']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-product_groups']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-option_groups']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-manufacturers']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-suppliers']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-delivery_statuses']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-sold_out_statuses']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-quantity_units']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-csv']")).Click();
            driver.FindElement(By.CssSelector("h1"));

            driver.FindElement(By.CssSelector("li[id='app-']>a[href$='countries']")).Click();
            driver.FindElement(By.CssSelector("h1"));

            driver.FindElement(By.CssSelector("li[id='app-']>a[href$='currencies']")).Click();
            driver.FindElement(By.CssSelector("h1"));

            driver.FindElement(By.CssSelector("li[id='app-']>a[href$='customers']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-csv']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-newsletter']")).Click();
            driver.FindElement(By.CssSelector("h1"));

            driver.FindElement(By.CssSelector("li[id='app-']>a[href$='geo_zones']")).Click();
            driver.FindElement(By.CssSelector("h1"));

            driver.FindElement(By.CssSelector("li[id='app-']>a[href$='languages']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-storage_encoding']")).Click();
            driver.FindElement(By.CssSelector("h1"));

            driver.FindElement(By.CssSelector("li[id='app-']>a[href$='jobs']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-customer']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-shipping']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-payment']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-order_total']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-order_success']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-order_action']")).Click();
            driver.FindElement(By.CssSelector("h1"));

            driver.FindElement(By.CssSelector("li[id='app-']>a[href$='orders']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-order_statuses']")).Click();
            driver.FindElement(By.CssSelector("h1"));

            driver.FindElement(By.CssSelector("li[id='app-']>a[href$='pages']")).Click();
            driver.FindElement(By.CssSelector("h1"));

            driver.FindElement(By.CssSelector("li[id='app-']>a[href$='monthly_sales']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-most_sold_products']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-most_shopping_customers']")).Click();
            driver.FindElement(By.CssSelector("h1"));

            driver.FindElement(By.CssSelector("li[id='app-']>a[href$='store_info']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-defaults']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-general']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-listings']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-images']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-checkout']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-advanced']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-security']")).Click();
            driver.FindElement(By.CssSelector("h1"));

            driver.FindElement(By.CssSelector("li[id='app-']>a[href$='slides']")).Click();
            driver.FindElement(By.CssSelector("h1"));

            driver.FindElement(By.CssSelector("li[id='app-']>a[href$='tax_classes']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-tax_rates']")).Click();
            driver.FindElement(By.CssSelector("h1"));

            driver.FindElement(By.CssSelector("li[id='app-']>a[href$='search']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-scan']")).Click();
            driver.FindElement(By.CssSelector("h1"));
            driver.FindElement(By.CssSelector("li[id='app-'] li[id='doc-csv']")).Click();
            driver.FindElement(By.CssSelector("h1"));

            driver.FindElement(By.CssSelector("li[id='app-']>a[href$='users']")).Click();
            driver.FindElement(By.CssSelector("h1"));

            driver.FindElement(By.CssSelector("li[id='app-']>a[href$='vqmods']")).Click();
            driver.FindElement(By.CssSelector("h1"));


            driver.FindElement(By.CssSelector("a[title='Logout']")).Click();
        }

        [Test]
        public void Test3()
        {
            driver.Url = "http://localhost/litecart/admin/login.php";
            var el = driver.FindElement(By.Name("username"));
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();

            var cats = driver.FindElements(By.CssSelector("li[id='app-']>a"));
            var catNames = new List<string>();
            foreach (var cat in cats)
                catNames.Add(cat.Text);

            foreach (var catName in catNames)
            {
                driver.FindElement(By.XPath("//li[@id='app-']/a//span[contains(.,'"+catName+"')]")).Click();
                IList<IWebElement> pages = driver.FindElements(By.CssSelector("li[id='app-'] li"));
                var pageNames = new List<string>();
                foreach (var page in pages)
                    pageNames.Add(page.Text);

                foreach (var pageName in pageNames)
                {
                    driver.FindElement(By.XPath("//ul[@class='docs']//a//span[contains(.,'" + pageName + "')]")).Click();
                    driver.FindElement(By.CssSelector("h1"));
                }

            }
            driver.FindElement(By.CssSelector("a[title='Logout']")).Click();
            
        }
    }
}
