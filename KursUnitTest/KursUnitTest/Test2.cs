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
    class Test2 : BaseTest
    {
        
        [Test]
        public void FirstTest()
        {
            driver.Url = "http://pskovline.ru";
        }
    }
}
