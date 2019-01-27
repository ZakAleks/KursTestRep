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
        private static readonly Random random = new Random();
        public static string GetRandomText(int x)
        {
            string pass = "";
            while (pass.Length < x)
            {
                Char c = (char)random.Next(33, 125);
                if (Char.IsLetterOrDigit(c))
                    pass += c;
            }
            return pass;
        }

        public class User
        {
            public User()
            {
                Email = "testmail_" + Zadanie11.GetRandomText(6) + "@gmail.com";
                Pass = "admin123456";
                Phone = "+79111111111";
                Lname = "TestLname";
                Fname = "TestFname";
                Adress = "TestAdress 1 1";
                PostCode = "12345";
                City = "TestCity";
            }

            public string Email { get; set; }
            public string Pass { get; set; }
            public string Phone { get; set; }
            public string Lname { get; set; }
            public string Fname { get; set; }
            public string Adress { get; set; }
            public string PostCode { get; set; }
            public string City { get; set; }
        }

        [Test]
        public void Test1()
        {
            var user = new User();
            //переходим на сайт
            driver.Url = "http://localhost/litecart/en/";
            driver.FindElement(By.CssSelector("a[href$='/create_account']")).Click();

            driver.FindElement(By.CssSelector("span[dir='ltr']")).Click();
            driver.FindElement(By.CssSelector("li[id^='select2'][id$='-US']")).Click();
            driver.FindElement(By.CssSelector("input[name='firstname']")).SendKeys(user.Fname);
            driver.FindElement(By.CssSelector("input[name='lastname']")).SendKeys(user.Lname);
            driver.FindElement(By.CssSelector("input[name='address1']")).SendKeys(user.Adress);
            driver.FindElement(By.CssSelector("input[name='postcode']")).SendKeys(user.PostCode);
            driver.FindElement(By.CssSelector("input[name='city']")).SendKeys(user.City);
            driver.FindElement(By.CssSelector("input[name='email']")).SendKeys(user.Email);
            var InputPhone = driver.FindElement(By.CssSelector("input[name='phone']"));
            InputPhone.Clear();
            InputPhone.SendKeys(user.Phone);
            driver.FindElement(By.CssSelector("input[name='password']")).SendKeys(user.Pass);
            driver.FindElement(By.CssSelector("input[name='confirmed_password']")).SendKeys(user.Pass);
            driver.FindElement(By.CssSelector("button[name='create_account']")).Click();
            driver.FindElement(By.CssSelector("a[href$='/logout']")).Click();
            var LoginForm = driver.FindElement(By.CssSelector("form[name='login_form']"));
            LoginForm.FindElement(By.CssSelector("input[name = 'email']")).SendKeys(user.Email);
            LoginForm.FindElement(By.CssSelector("input[name = 'password']")).SendKeys(user.Pass);
            LoginForm.FindElement(By.CssSelector("button[name = 'login']")).Click(); ;
        }
    }
}
