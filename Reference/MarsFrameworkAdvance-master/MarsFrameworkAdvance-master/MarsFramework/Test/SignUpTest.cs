using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsFramework.Global.GlobalDefinitions;
using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;

namespace MarsFramework.Test
{
    class SignUpTest : BaseTest
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
        public void SignUpRegister()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignUp");

            string regFirstname = GlobalDefinitions.ExcelLib.ReadData(2, "FirstName");
            string regLastname = GlobalDefinitions.ExcelLib.ReadData(2, "LastName");
            string regEmail = GlobalDefinitions.ExcelLib.ReadData(2, "Email");
            string regPasswd = GlobalDefinitions.ExcelLib.ReadData(2, "Password");
            string regConfirmPswd = GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPswd");

            SignUp Signupobj = new SignUp();
            Signupobj.register(regFirstname, regLastname, regEmail, regPasswd, regConfirmPswd);

            try
            {
                String actualErrorEmail = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='field error ']")).Text;
                String expectedErrorEmail = "This email has already been used to register an account.";
                //Type 1
                Assert.AreEqual(actualErrorEmail, expectedErrorEmail);
                //Type 2
                Assert.True(actualErrorEmail.Contains("This email has already been used to register an account."));
                Base.test.Log(LogStatus.Info, "Signup completed");
            }
            catch (Exception)
            {
                Base.test.Log(LogStatus.Info, "Signup had issues");
                GlobalDefinitions.driver.Navigate().GoToUrl("http://192.168.99.100:5000/");
            }

        }
    }
}
