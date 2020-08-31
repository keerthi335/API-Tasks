using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarsFrameworkSpecFlow.PagesFeatures.Helpers
{
    class Initialization
    {
        public static void Initialize()
        {
            //Defining the browser
            GlobalDefinitions.driver = new ChromeDriver();

            //Maximise the window
            GlobalDefinitions.driver.Manage().Window.Maximize();
        }

        public static void NavigateUrl()
        {
            GlobalDefinitions.driver.Navigate().GoToUrl("http://192.168.99.100:5000/");
        }

        public static void LoginSteps(string username, string pwd)
        {
            //Click on Sign In Tab
            IWebElement SignIntab = GlobalDefinitions.driver.FindElement(By.XPath("//a[contains(text(),'Sign')]"));
            SignIntab.Click();

            //Giving value for Email field
            IWebElement Email = GlobalDefinitions.driver.FindElement(By.Name("email"));
            Email.SendKeys(username);

            //Giving value for Password field
            IWebElement Password = GlobalDefinitions.driver.FindElement(By.Name("password"));
            Password.SendKeys(pwd);

            //Clicking on Login Button
            IWebElement LoginBtn = GlobalDefinitions.driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));
            LoginBtn.Click();
        }
        //Close the browser
        public static void Close()
        {
            GlobalDefinitions.driver.Quit();
        }
    }
}
