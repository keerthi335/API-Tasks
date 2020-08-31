using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using MarsFramework.Global;
using System;
using NUnit.Framework;
using System.Threading;
using RelevantCodes.ExtentReports;

namespace MarsFramework.Pages
{    
    public class SignIn
    {        
        #region  Initialize Web Elements 
        //Finding the Sign Link
        private IWebElement SignIntab => GlobalDefinitions.driver.FindElement(By.XPath("//a[contains(text(),'Sign')]"));
        // Finding the Email Field
        private IWebElement Email => GlobalDefinitions.driver.FindElement(By.XPath("(//INPUT[@type='text'])[2]"));
        //Finding the Password Field
        private IWebElement Password => GlobalDefinitions.driver.FindElement(By.XPath("//INPUT[@type='password']"));
        //Finding the Login Button
        private IWebElement SignInBtn => GlobalDefinitions.driver.FindElement(By.XPath("//BUTTON[@class='fluid ui teal button'][text()='Login']"));
        #endregion

        //Finding Join button
        private IWebElement JoinBtn => GlobalDefinitions.driver.FindElement(By.XPath("//a[@class='pointerCursor'][text()=' Join']"));
        //internal void LoginSteps()
        
        public void LoginSteps(string username, string password)
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");
            GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

            //Click on Signin button            
            SignIntab.Click();
            //Enter Email
            Email.SendKeys(username);
            //Enter Password
            Password.SendKeys(password);
            //click SignIn Button
            SignInBtn.Click();
        }
    }
}