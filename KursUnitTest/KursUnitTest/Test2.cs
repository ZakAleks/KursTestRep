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
    class Test2
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        /// <summary>
        /// функция выполняется перед каждым тестом
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            driver = new ChromeDriver(options);
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
            driver.Url = "http://pskovline.ru";
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
