using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WestpacTest
{
     class GlobalDefinitions
    {
        //Initialise the browser
        public static IWebDriver driver { get; set; }

        //Custom methods
        public static void HoverAndClick(IWebDriver driver,IWebElement elementToHover,IWebElement elementToClick)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(elementToHover).Click(elementToClick).Build().Perform();
            Thread.Sleep(1000);

        }

        public static void Click( IWebDriver driver, IWebElement element)
        {
            Actions actions = new Actions(driver);

            actions.MoveToElement(element).Click(element).Build().Perform();
        }
    }
}
