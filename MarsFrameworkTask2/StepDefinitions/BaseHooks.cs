using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using MarsFramework.Global;
using static MarsFramework.Global.GlobalDefinitions;
using MarsFramework.Config;


namespace MarsFrameworkTask2.StepDefinitions
{
    [Binding]
    public class BaseHooks : Base
    {
        #region Before Scenario
        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://192.168.99.100:5000/");
        }
        #endregion



    }
}
