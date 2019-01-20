using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest
{
    [TestFixture]
    class Zadanie10 : BaseTest
    {
        class ProductInfo
        {
            public string ProductName { get; set; }
            public string Price { get; set; }
            public string PriceFontWeight { get; set; }
            public string PriceFontSize { get; set; }
            public string PriceFontColor { get; set; }
            public string PriceTextDecoration { get; set; }

            public string PromoPrice { get; set; }
            public string PromoPriceFontWeight { get; set; }
            public string PromoPriceFontSize { get; set; }
            public string PromoPriceFontColor { get; set; }
            public string PromoPriceTextDecoration { get; set; }

        }

        Color GetColor(string strColor)
        {

            if (strColor.StartsWith("rgba("))
            {
                int i1 = strColor.LastIndexOf("rgba(");
                int i2 = strColor.LastIndexOf(")");

                strColor = strColor.Substring(i1 + 5);

                strColor = strColor.Replace(")", "");

            }
            else if (strColor.StartsWith("rgb("))
            {
                int i1 = strColor.LastIndexOf("rgb(");
                int i2 = strColor.LastIndexOf(")");

                strColor = strColor.Substring(i1 + 4);

                strColor = strColor.Replace(")", "");

            }
            var RGB = strColor.Split(',');

            int R = Int32.Parse(RGB[0]);

            int G = Int32.Parse(RGB[1]);

            int B = Int32.Parse(RGB[2]);
            return Color.FromArgb(R, G, B);

        }


        void AssertStyle(ProductInfo product)
        {
            Assert.True(product.PriceTextDecoration.Contains("line-through"), "Цена не перечеркнута");

            var color = GetColor(product.PriceFontColor);
            Assert.True(color.R == color.G && color.G == color.B, "Цыет старой цены не серый");

            Assert.True(Int32.Parse(product.PromoPriceFontWeight) >= 700, "Акционная цена не жирная ");

            var color2 = GetColor(product.PromoPriceFontColor);
            Assert.True(color2.G == 0 && color2.B == 0, "Цвет цены по акции не  красный");

            var price = Double.Parse(product.Price);
            var promoprice = Double.Parse(product.PromoPrice);
            Assert.True(promoprice < price,"Цена по скидке не меньше простой цены");

            int i1 = product.PriceFontSize.IndexOf("px");
            int i2 = product.PromoPriceFontSize.IndexOf("px");

            var fontsizw = product.PriceFontSize.Substring(0, i1).Replace(".",",");
            var promofontsizw = product.PromoPriceFontSize.Substring(0, i2).Replace(".", ",");

            var fs = Double.Parse(fontsizw);
            var promofs = Double.Parse(promofontsizw);

            Assert.True(fs < promofs, "Акционная цена не крупнее, чем обычная");

        }

        ProductInfo GetFromStartPage(IWebElement el)
        {

            var ProdPrice = el.FindElement(By.CssSelector("[class='regular-price']"));
            var ProdPromoPrice = el.FindElement(By.CssSelector("[class='campaign-price']"));
            ProductInfo prop = new ProductInfo();
            prop.ProductName = el.FindElement(By.CssSelector("div[class='name']")).Text;

            var pr = ProdPrice.Text;
            int i1 = pr.IndexOf("$");
            prop.Price = pr.Substring(i1 + 1);
            prop.PriceFontWeight = ProdPrice.GetCssValue("font-weight");
            prop.PriceFontSize = ProdPrice.GetCssValue("font-size");

            prop.PriceFontColor = ProdPrice.GetCssValue("color");
            prop.PriceTextDecoration = ProdPrice.GetCssValue("text-decoration");

            var prprom = ProdPromoPrice.Text;
            int i2 = prprom.IndexOf("$");
            prop.PromoPrice = prprom.Substring(i1 + 1);
            prop.PromoPriceFontWeight = ProdPromoPrice.GetCssValue("font-weight");
            prop.PromoPriceFontSize = ProdPromoPrice.GetCssValue("font-size");
            prop.PromoPriceFontColor = ProdPromoPrice.GetCssValue("color");
            prop.PromoPriceTextDecoration = ProdPromoPrice.GetCssValue("text-decoration");

            return prop;
        }

        ProductInfo GetFromProductPage(IWebElement el)
        {

            var ProdPrice = el.FindElement(By.CssSelector("[class='regular-price']"));
            var ProdPromoPrice = el.FindElement(By.CssSelector("[class='campaign-price']"));
            ProductInfo prop = new ProductInfo();
            prop.ProductName = el.FindElement(By.CssSelector("h1[class='title']")).Text;
            //prop.Price = Int32.Parse(ProdPrice.Text);
            var pr = ProdPrice.Text;
            int i1 = pr.IndexOf("$");
            prop.Price = pr.Substring(i1 + 1);
            prop.PriceFontWeight = ProdPrice.GetCssValue("font-weight");
            prop.PriceFontSize = ProdPrice.GetCssValue("font-size");

            prop.PriceFontColor = ProdPrice.GetCssValue("color");
            prop.PriceTextDecoration = ProdPrice.GetCssValue("text-decoration");

            //prop.PromoPrice = Int32.Parse(ProdPrice.Text);
            var prprom = ProdPromoPrice.Text;
            int i2 = prprom.IndexOf("$");
            prop.PromoPrice = prprom.Substring(i1 + 1);
            prop.PromoPriceFontWeight = ProdPromoPrice.GetCssValue("font-weight");
            prop.PromoPriceFontSize = ProdPromoPrice.GetCssValue("font-size");
            prop.PromoPriceFontColor = ProdPromoPrice.GetCssValue("color");
            prop.PromoPriceTextDecoration = ProdPromoPrice.GetCssValue("text-decoration");

            return prop;
        }

        [Test]
        public void Test1()
        {
            //переходим на сайт
            driver.Url = "http://localhost/litecart/en/";

            var firstCampaignsProd = driver.FindElement(By.CssSelector("div[id='box-campaigns'] li"));

            var prod1 = GetFromStartPage(firstCampaignsProd);
            AssertStyle(prod1);

            firstCampaignsProd.Click();



            var FullProdInfo = driver.FindElement(By.CssSelector("div[id='box-product']"));

            var prod2 = GetFromProductPage(FullProdInfo);

            AssertStyle(prod2);

            Assert.True(prod1.ProductName == prod2.ProductName, "Название продукта на главной странице и странице продукта не совпадает");
            Assert.True(prod1.Price == prod2.Price, "Цена продукта на главной странице и странице продукта не совпадает");
            Assert.True(prod1.PromoPrice == prod2.PromoPrice, "Акционная цена продукта на главной странице и странице продукта не совпадает");


        }

    }
}
