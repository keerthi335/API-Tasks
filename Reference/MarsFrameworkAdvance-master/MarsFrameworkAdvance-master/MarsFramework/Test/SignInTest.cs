using System;
using static MarsFramework.Global.GlobalDefinitions;
using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;


namespace MarsFramework.Test
{
    [TestFixture]
    class SignInTest : BaseTest
    {
        public override void Inititalize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Url);

            #region Initialise Reports
            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(ReportXMLPath);
            test = extent.StartTest(TestContext.CurrentContext.Test.Name);
            #endregion

            //Set Implicit Wait
            wait(5);
        }
        [Test]
        public void SignInValid()
        {
            SignIn Signinobj = new SignIn();
            //Populate the excel data
            ExcelLib.PopulateInCollection(ExcelPath, "SignIn");
            Signinobj.LoginSteps(ExcelLib.ReadData(2, "Username"), ExcelLib.ReadData(2, "Password"));

            try
            {
                //Verify if signout is visible
                IWebElement SignOutElement = GlobalDefinitions.driver.FindElement(By.XPath("//button[@class='ui green basic button'][text()='Sign Out']"));
                Assert.IsTrue(SignOutElement.Text.Equals("Sign Out"));
                Base.test.Log(LogStatus.Info, "Signed in successfully");

                //Verify if user is navigated to Profile Page
                string expectedTitle = "Profile";
                string actualTitle = driver.Title;
                Assert.AreEqual(expectedTitle, actualTitle, "SignIn Failed");
            }
            catch (Exception)
            {
                //JoinBtn.Click();                
                Base.test.Log(LogStatus.Info, "Signed in error");
            }
        }

        [Test]
        public void SignInInvalid()
        {
            SignIn Signinobj = new SignIn();
            //Populate the excel data
            ExcelLib.PopulateInCollection(ExcelPath, "SignIn");
            Signinobj.LoginSteps(ExcelLib.ReadData(3, "Username"), ExcelLib.ReadData(3, "Password"));
            try
            {
                //Verify "Send Verification Email" button
                IWebElement EmailVerifyBtn = driver.FindElement(By.XPath("//button[@id='submit-btn']"));
                Assert.IsTrue(EmailVerifyBtn.Enabled, "User failed to login successfully");
            }
            catch
            {
                Base.test.Log(LogStatus.Info, "Signup please and go to registration page");
            }
        }
    }
}
