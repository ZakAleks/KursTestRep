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
    class Zadanie9 : BaseTest
    {
        class RowCountry
        {
            public string Country { get; set; }
            public string Link { get; set; }
            public int ZoneCount { get; set; }
        }

        private List<RowCountry> GetCountries()
        {
            var trElements = driver.FindElements(By.CssSelector("table[class='dataTable'] tr[class='row']"));
            List<RowCountry> rows = new List<RowCountry>();
            foreach (var tr in trElements)
            {
                RowCountry row = new RowCountry();
                var tdElements = tr.FindElements(By.CssSelector("td"));
                row.Country = tdElements[2].Text;
                row.Link = tdElements[2].FindElement(By.CssSelector("a")).GetAttribute("href");
                row.ZoneCount = Int32.Parse(tdElements[3].Text);
                rows.Add(row);
            }
            return rows;
        }


        [Test]
        public void Test1()
        {
            //переходим на сайт
            driver.Url = "http://localhost/litecart/admin/login.php";
            var el = driver.FindElement(By.Name("username"));
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();

            driver.FindElement(By.CssSelector("a[href$='doc=geo_zones']")).Click();


            var rows = GetCountries();

            RowCountry previous = null;
            foreach (var row in rows)
            {
                if (previous != null)
                {
                    Assert.IsTrue(string.Compare(row.Country, previous.Country) >= 0, "неправильный алфавитный порядок стран");
                }
                previous = row;
            }

            foreach (var row in rows)
            {
                if (row.ZoneCount > 0)
                {
                    driver.Url = row.Link;

                    var trZoneElements = driver.FindElements(By.CssSelector("table[id='table-zones'] tr"));

                    List<string> zones = new List<string>();
                    bool skipHeader = true;
                    foreach (var trz in trZoneElements)
                    {
                        if (skipHeader)
                        {
                            skipHeader = false;
                            continue;
                        }


                        var tdZoneElements = trz.FindElements(By.CssSelector("td"));

                        string zone = tdZoneElements[2].FindElement(By.CssSelector("table[id='table-zones'] option[selected='selected']")).Text;

                        zones.Add(zone);
                    }

                    string prv = null;
                    foreach (var zone in zones)
                    {
                        if (prv != null)
                        {
                            Assert.IsTrue(string.Compare(zone, prv) >= 0, "неправильный алфавитный порядок зон");
                        }
                        prv = zone;
                    }

                    driver.FindElement(By.CssSelector("a[href$='doc=geo_zones']")).Click();

                }
            }

        }

        [Test]
        public void Test2()
        {
            //переходим на сайт
            driver.Url = "http://localhost/litecart/admin/login.php";
            var el = driver.FindElement(By.Name("username"));
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();

            var rows = GetCountries();

            foreach (var row in rows)
            {

                driver.Url = row.Link;

                var trZoneElements = driver.FindElements(By.CssSelector("table[id='table-zones'] tr"));

                List<string> zones = new List<string>();
                bool skipHeader = true;
                foreach (var trz in trZoneElements)
                {
                    if (skipHeader)
                    {
                        skipHeader = false;
                        continue;
                    }


                    var tdZoneElements = trz.FindElements(By.CssSelector("td"));

                    string zone = tdZoneElements[2].FindElement(By.CssSelector("table[id='table-zones'] option[selected='selected']")).Text;

                    zones.Add(zone);
                }

                string prv = null;
                foreach (var zone in zones)
                {
                    if (prv != null)
                    {
                        Assert.IsTrue(string.Compare(zone, prv) >= 0, "неправильный алфавитный порядок зон");
                    }
                    prv = zone;
                }

                driver.FindElement(By.CssSelector("a[href$='doc=geo_zones']")).Click();

            }

        }
    }
}
