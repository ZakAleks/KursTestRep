using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace KursUnitTest
{

    [TestFixture]

    public class FirstKursTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        /// <summary>
        /// функция выполняется перед каждым тестом
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        /// <summary>
        /// функция выполняется перед каждым тестом
        /// </summary>
        [OneTimeSetUp]
        public void OnOneTimeSetUp()
        {
        }

        [Test]
        public void FirstTest()
        {
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            driver.FindElement(By.CssSelector("a[title='Logout']")).Click();
        }

        /// <summary>
        /// функция выполняется после каждого теста
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver = null;
        }

        /// <summary>
        /// функция выполняется после каждого теста
        /// </summary>
        [OneTimeTearDown]
        public void OnOneTimeTearDown()
        {

        }
    }
}
