using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsFramework.Global.GlobalDefinitions;
using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;


namespace MarsFramework.Test
{
    class BaseTest:Base
    {
        #region setup and tear down
        [SetUp]
        public virtual void Inititalize()
        {
            switch (Browser)
            {

                case 1:
                    driver = new FirefoxDriver();
                    break;
                case 2:
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    driver.Navigate().GoToUrl(Url);
                    break;
            }

            #region Initialise Reports

            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(ReportXMLPath);
            test = extent.StartTest(TestContext.CurrentContext.Test.Name);

            #endregion


            if (IsLogin == "true")
            {
                SignIn Signinobj = new SignIn();
                //Populate the excel data
                ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");
                Signinobj.LoginSteps(ExcelLib.ReadData(2, "Username"), ExcelLib.ReadData(2, "Password"));
            }
            else
            {
                SignUp Signupobj = new SignUp();
                Signupobj.register(ExcelLib.ReadData(2, "FirstName"), ExcelLib.ReadData(2, "LastName"), ExcelLib.ReadData(2, "Email"), ExcelLib.ReadData(2, "Password"), ExcelLib.ReadData(2, "ConfirmPswd"));
            }

            //Set Implicit Wait
            GlobalDefinitions.wait(5);
                
        }
        [TearDown]
        public void TearDown()
        {
            //Get test restult
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            // Screenshot
            String screenShotPath = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, TestContext.CurrentContext.Test.Name);
            // Write log to report
            LogStatus logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = LogStatus.Fail;
                    test.Log(logstatus, "Test ended with " + logstatus + "–" + stacktrace + errorMessage);
                    test.Log(LogStatus.Info, "Snapshot below:" + test.AddScreenCapture(screenShotPath));
                    break;
                case TestStatus.Passed:
                    logstatus = LogStatus.Pass;
                    test.Log(logstatus, "Test ended with " + logstatus);
                    test.Log(LogStatus.Info, "Snapshot below:" + test.AddScreenCapture(screenShotPath));
                    break;
            }
            // end test. (Reports)
            extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();
            // Close the driver :)            
            GlobalDefinitions.driver.Close();
            GlobalDefinitions.driver.Quit();
        }
        #endregion
    }
    }
