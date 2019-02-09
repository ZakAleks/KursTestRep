using KursUnitTest.pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KursUnitTest.app
{
    public class Application
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        private MarketProdPage marketProdPage;
        private MarketMainPage marketMainPage;
        private MarketCartPage marketCartPage;

        public Application()
        {
            ChromeOptions options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            marketProdPage = new MarketProdPage(driver);
            marketMainPage = new MarketMainPage(driver);
            marketCartPage = new MarketCartPage(driver);
        }

        public void Quit()
        {
            driver.Quit();
        }

        public void Add3ProdInCart()
        {
            marketMainPage.Open();

            for (int i = 0; i < 3; i++)
            {
                marketMainPage.ClickFirstProdInList();
                marketProdPage.SelectSmallSiza();
                marketProdPage.ClickAddToCart();
                while (true)
                {
                    int qI = marketProdPage.GetQuantityItemInCart();
                    if (qI >= i + 1)
                        break;
                    Thread.Sleep(250);
                }
                marketProdPage.ClickLogo();
            }
        }

        public void OpenCart()
        {
            marketMainPage.OpenCart();
        }

        public void DelAllItemInCart()
        {
            while (true)
            {
                var itemList = marketCartPage.GetListItemInCart();
                if (itemList.Count == 0)
                {
                    break;
                }
                var artItem = marketCartPage.GetArtItemInList();
                marketCartPage.ClickDellItemInListAndWaitStalenessOf(artItem);
            }
        }
    }
}
