using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace WestpacTest.Global
{
    class Base
    {

        [SetUp]
        public void Initialize()
        {
            GlobalDefinitions.driver = new ChromeDriver();
            GlobalDefinitions.driver.Navigate().GoToUrl("https://www.westpac.co.nz/kiwisaver/calculators/kiwisaver-calculator");
            GlobalDefinitions.driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void TearDown()
        {
            GlobalDefinitions.driver.Close();
        }
    }
}
