using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace KursUnitTest
{

    //[TestFixture]
    public class BaseTest
    {
        public IWebDriver driver;
        public WebDriverWait wait;

        /// <summary>
        /// функция выполняется перед каждым тестом
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--headless");//hide browser
            driver = new ChromeDriver(options);
            //driver = new EdgeDriver();
            //EdgeOptions option = new EdgeOptions();
            //FirefoxOptions optionsf = new FirefoxOptions();
            //options.AddArgument("--headless");
            //driver = new FirefoxDriver(optionsf);
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
