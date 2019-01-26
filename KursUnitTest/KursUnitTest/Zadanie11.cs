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
    class Zadanie11 : BaseTest
    {
        private readonly Random random = new Random();
        public string GetRandomText(int x)
        {
            string pass = "";
            var r = new Random();
            while (pass.Length < x)
            {
                Char c = (char)r.Next(33, 125);
                if (Char.IsLetterOrDigit(c))
                    pass += c;
            }
            return pass;
        }

        [Test]
        public void Test1()
        {
            //переходим на сайт
            driver.Url = "http://localhost/litecart/en/";
            driver.FindElement(By.CssSelector("a[href$='/create_account']")).Click();

            var Rtext = GetRandomText(4);
            string Email = "testmail_"+ Rtext+"@gmail.com";
            string Pass = "admin123456";
            string Phone = "+79111111111";
            string Lname = "TestLname";
            string Fname = "TestFname";
            string Adress = "TestAdress 1 1";
            string PostCode = "12345";
            string City = "TestCity";

            driver.FindElement(By.CssSelector("span[dir='ltr']")).Click();
            driver.FindElement(By.CssSelector("li[id^='select2'][id$='-US']")).Click();
            driver.FindElement(By.CssSelector("input[name='firstname']")).SendKeys(Fname);
            driver.FindElement(By.CssSelector("input[name='lastname']")).SendKeys(Lname);
            driver.FindElement(By.CssSelector("input[name='address1']")).SendKeys(Adress);
            driver.FindElement(By.CssSelector("input[name='postcode']")).SendKeys(PostCode);
            driver.FindElement(By.CssSelector("input[name='city']")).SendKeys(City);
            driver.FindElement(By.CssSelector("input[name='email']")).SendKeys(Email);
            var InputPhone = driver.FindElement(By.CssSelector("input[name='phone']"));
            InputPhone.Clear();
            InputPhone.SendKeys(Phone);
            driver.FindElement(By.CssSelector("input[name='password']")).SendKeys(Pass);
            driver.FindElement(By.CssSelector("input[name='confirmed_password']")).SendKeys(Pass);
            driver.FindElement(By.CssSelector("button[name='create_account']")).Click();

            driver.FindElement(By.CssSelector("a[href$='/logout']")).Click();
            var LoginForm = driver.FindElement(By.CssSelector("form[name='login_form']"));
            LoginForm.FindElement(By.CssSelector("input[name = 'email']")).SendKeys(Email);
            LoginForm.FindElement(By.CssSelector("input[name = 'password']")).SendKeys(Pass);
            LoginForm.FindElement(By.CssSelector("button[name = 'login']")).Click(); ;
        }
    }
}
