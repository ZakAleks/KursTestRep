﻿using KursUnitTest.app;
using KursUnitTest.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KursUnitTest
{
    [TestFixture]
    class Zadanie15 : BaseTest
    {
        [Test]
        public void Test1()
        {
            app.Add3ProdInCart();
            app.OpenCart();
            app.DelAllItemInCart();
        }
    }
}
