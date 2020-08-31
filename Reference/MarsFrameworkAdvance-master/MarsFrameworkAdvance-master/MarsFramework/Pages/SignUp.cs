using MarsFramework.Global;
using OpenQA.Selenium;
using NUnit.Framework;
using System;
using System.Threading;
using RelevantCodes.ExtentReports;

namespace MarsFramework.Pages
{
    public class SignUp
    {
        #region  Initialize Web Elements 
        //Finding the Join 
        private IWebElement Join => GlobalDefinitions.driver.FindElement(By.XPath("//button[@class='ui green basic button'][text()='Join']"));
        //Identify FirstName Textbox
        private IWebElement FirstName => GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='firstName']"));
        //Identify LastName Textbox
        private IWebElement LastName => GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='lastName']"));
        //Identify Email Textbox
        private IWebElement Email => GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='email']"));
        //Identify Password Textbox 
        private IWebElement Password => GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='password']"));
        //Identify Confirm Password Textbox
        private IWebElement ConfirmPassword => GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='confirmPassword']"));
        //Identify Term and Conditions Checkbox terms
        private IWebElement Checkbox => GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='terms']"));
        //Identify join button
        private IWebElement JoinBtn => GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='submit-btn']"));
        #endregion
    
        internal void register(string regFirstname, string regLastname, string regEmail, string regPasswd, string regConfirmPswd)
            //public static void register()
        {
            //Populate the excel data
            //GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignUp");
            //Click on Join button
            Join.Click();

            //Enter FirstName
            FirstName.SendKeys(regFirstname);
            //Enter LastName
            LastName.SendKeys(regLastname);
            //Enter Email
             Email.SendKeys(regEmail);
            //Enter Password
            Password.SendKeys(regPasswd);
            //Enter Password again to confirm
             ConfirmPassword.SendKeys(regConfirmPswd);
            //Click on Checkbox
            Checkbox.Click();
            //Click on join button to Sign Up
            JoinBtn.Click();
            Thread.Sleep(5000);
            //validateRegister();
        }
        internal void validateRegister()
        {
            // Assert to verify that the join button is visible
            try
            {
                String actualErrorEmail = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='field error ']")).Text;
                String expectedErrorEmail = "This email has already been used to register an account.";
                //Type 1
                Assert.AreEqual(actualErrorEmail, expectedErrorEmail);
                //Type 2
                Assert.True(actualErrorEmail.Contains("This email has already been used to register an account."));

                Base.test.Log(LogStatus.Info, "Signup completed");

                //IWebElement Join = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='fluid ui teal button'][text()='Join']"));                
                //Assert.IsTrue(Join.Text.Equals("Join"));
            }
            catch (Exception)
            {
                //JoinBtn.Click(); do nothing                
                GlobalDefinitions.driver.Navigate().GoToUrl("http://192.168.99.100:5000/");
            }
        }
    }
}
