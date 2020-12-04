using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Threading;
using System.Linq;

namespace WestpacTest.Global
{
    class KiwisaverCalculators: GlobalDefinitions
    {

        public KiwisaverCalculators()
        {

        }
        #region  Initialize Web Elements
        
        // IWebElement CLickHereBtn => GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='content-ps']/div[2]/div/section/p[4]/a"));
        
        //Information Icons
        IWebElement IICurrrentAge => GlobalDefinitions.driver.FindElement(By.CssSelector("div.wpnib-field-current-age .icon"));
        IWebElement IIEmploymentStatus => GlobalDefinitions.driver.FindElement(By.CssSelector("div.wpnib-field-employment-status .icon"));
        IWebElement IISalary => GlobalDefinitions.driver.FindElement(By.CssSelector("div.wpnib-field-annual-income .icon"));
        IWebElement IIKiwiSaverMemberContribution => GlobalDefinitions.driver.FindElement(By.CssSelector("div.wpnib-field-kiwisaver-member-contribution .icon"));
        IWebElement IIKiwiSaverBalance => GlobalDefinitions.driver.FindElement(By.CssSelector("div.wpnib-field-kiwi-saver-balance .icon"));
        IWebElement IIVoluntaryContribution => GlobalDefinitions.driver.FindElement(By.CssSelector("div.wpnib-field-voluntary-contributions .icon"));
        IWebElement IIRiskProfile => GlobalDefinitions.driver.FindElement(By.CssSelector("div.wpnib-field-risk-profile .icon"));
        IWebElement IISavingGoalRetirement=> GlobalDefinitions.driver.FindElement(By.CssSelector("div.wpnib-field-savings-goal .icon"));

        IWebElement CurrentAgeMessage => GlobalDefinitions.driver.FindElement(By.CssSelector(".wpnib-field-current-age .field-message"));
        //Current Age Field
        IWebElement CurrentAge => GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='widget']/div/div[1]/div/div[1]/div/div[1]/div/div/div/div[2]/div[1]/div[1]/div/div[1]/div/div[1]/div/div/input"));

        //EMployment Status
        IWebElement EmpDropDown => GlobalDefinitions.driver.FindElement(By.CssSelector("div.wpnib-field-employment-status .well-value"));
        IList<IWebElement> EmpOptions => GlobalDefinitions.driver.FindElements(By.XPath("//*[@class='option-list']/li"));
        //IWebElement EmploymentStatus => GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='widget']/div/div[1]/div/div[1]/div/div[2]/div/div/div/div[2]/div[1]/div[1]/div/div/div/div[2]/ul/li[1]"));
        IWebElement AnnualIncome => GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='widget']/div/div[1]/div/div[1]/div/div[3]/div/div/div/div[2]/div[1]/div[1]/div/div/div[1]/div/div/input"));
        IWebElement MemberContribution => GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='widget']/div/div[1]/div/div[1]/div/div[4]/div/div/div/div[2]/div[1]/div[1]/div/div/div/div/div[2]"));
        IWebElement CurrentKiwiSaverBalance => GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='wpnib-field-kiwi-saver-balance field-group ng-isolate-scope']//input[@type='text']"));
        IWebElement VolutaryContributions => GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='widget']/div/div[1]/div/div[1]/div/div[4]/div/div/div/div[2]/div[1]/div[1]/div/div/div[1]/div[1]/div/input"));
        IWebElement FrequencyDrpDwn => GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='widget']/div/div[1]/div/div[1]/div/div[4]/div/div/div/div[2]/div[1]/div[1]/div/div/div[1]/div[2]/div/div[1]/div"));
        IWebElement DefensiveRiskProfile => GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='widget']/div/div[1]/div/div[1]/div/div[7]/div/div/div/div[2]/div[1]/div[1]/div/div/div/div/div[1]/div/label/span[2]/span"));
        IWebElement ConservativeRiskProfile => GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='radio-option-016']"));
        IWebElement BalancedRiskProfile => GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='radio-option-019']"));
        IWebElement SavingsGoals => GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='widget']/div/div[1]/div/div[1]/div/div[6]/div/div/div/div[2]/div[1]/div[1]/div/div/div[1]/div/div/input"));
        IWebElement SubmitBtn => GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='widget']/div/div[1]/div/div[2]/button/span[2]"));
        IWebElement KiwiSaverProjectionMsg => GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='widget']/div/div[1]/div/div[3]/div/div[1]/div[1]/div[1]/span[1]"));
        #endregion  Initialize WebElements
         
        public void CheckInformationIcons()
        {
                    
            GlobalDefinitions.driver.SwitchTo().Frame(0);
            Assert.IsTrue(IICurrrentAge.Displayed);
            Assert.IsTrue(IIEmploymentStatus.Displayed);
            Assert.IsTrue(IIKiwiSaverBalance.Displayed);
            Assert.IsTrue(IIVoluntaryContribution.Displayed);
            Assert.IsTrue(IIRiskProfile.Displayed);
            Assert.IsTrue(IISavingGoalRetirement.Displayed);

            //Clicking Information Icon next to Current Age and verifying display message
            IICurrrentAge.Click();
            String ActValue = CurrentAgeMessage.Text;
            String ExpValue = "This calculator has an age limit of 64 years old as you need to be under the age of 65 to join KiwiSaver.";
            Assert.AreSame(ActValue, ExpValue);
          
          
        }

        public void RetirementCalculationsEmployed()
        {
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            GlobalDefinitions.driver.SwitchTo().Frame(0);
            CurrentAge.SendKeys("30");
            EmpDropDown.Click();
                      
            EmpOptions.ElementAt(1).Click();
            AnnualIncome.SendKeys("82000");
            MemberContribution.Click();
            DefensiveRiskProfile.Click();
            SubmitBtn.Click();

            Assert.IsTrue(KiwiSaverProjectionMsg.Displayed);
        }
          
       
        public void RetirementCalculationsSelfemployed()
        {
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            GlobalDefinitions.driver.SwitchTo().Frame(0);
            CurrentAge.SendKeys("45");
            EmpDropDown.Click();
            EmpOptions.ElementAt(2).Click();
            CurrentKiwiSaverBalance.SendKeys("100000");
            VolutaryContributions.SendKeys("90");
            FrequencyDrpDwn.Click();
            EmpOptions.ElementAt(6).Click();
            ConservativeRiskProfile.Click();
            SavingsGoals.SendKeys("290000");

            SubmitBtn.Click();
            Assert.IsTrue(KiwiSaverProjectionMsg.Displayed);

        }

        public void RetirementCalculationsNotemployed()
        {
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            GlobalDefinitions.driver.SwitchTo().Frame(0);
            CurrentAge.SendKeys("55");
            EmpDropDown.Click();
            EmpOptions.ElementAt(3).Click();
            CurrentKiwiSaverBalance.SendKeys("140000");
            VolutaryContributions.SendKeys("10");
            FrequencyDrpDwn.Click();
            EmpOptions.ElementAt(7).Click();
            BalancedRiskProfile.Click();
            SavingsGoals.SendKeys("200000");

            SubmitBtn.Click();
            Assert.IsTrue(KiwiSaverProjectionMsg.Displayed);
        }
    }
}
