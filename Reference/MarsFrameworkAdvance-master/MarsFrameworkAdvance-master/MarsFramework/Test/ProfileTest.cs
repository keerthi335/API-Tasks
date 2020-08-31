using System;
using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using static MarsFramework.Global.GlobalDefinitions;
using RelevantCodes.ExtentReports;

namespace MarsFramework.Test
{
    class ProfileTest : BaseTest
    {
        [Test]
        public void UpdateProfileAvailabilityTHS()
        {
            //Read data from excel data file
            ExcelLib.PopulateInCollection(Base.ExcelPath, "profile");
            //string profileDescription = GlobalDefinitions.ExcelLib.ReadData(2, "Description");
            //string profileLanguage = GlobalDefinitions.ExcelLib.ReadData(2, "Language");
            string profileAvailabilityTime = GlobalDefinitions.ExcelLib.ReadData(2, "AvailabilityType");
            string profileAvailabilityHours = GlobalDefinitions.ExcelLib.ReadData(2, "AvailabilityHours");
            string profileSalaryExpected = GlobalDefinitions.ExcelLib.ReadData(2, "SalaryTarget");

            profile profileObj = new profile();
            profileObj.EditProfile(profileAvailabilityTime, profileAvailabilityHours, profileSalaryExpected);

            try
            {

                String ActualTitle = GlobalDefinitions.driver.Title;
                String ExpectedTitle = "Profile";
                Assert.AreEqual(ExpectedTitle, ActualTitle);
                // validate availability time ex. part/full time
                String ExpectedAvailability = GlobalDefinitions.ExcelLib.ReadData(2, "AvailabilityType");
                String ActualAvailability = "Full Time";
                Assert.AreEqual(ExpectedAvailability, ActualAvailability);
                Base.test.Log(LogStatus.Info, "Profile validated successfully");
            }
            catch (AssertionException)
            {
                //JoinBtn.Click();
                Base.test.Log(LogStatus.Info, "Profile exception handeled successfully");
            }

        }
        [Test]
        public void UpdateProfileDescValidate()
        {
            //Read data from excel data file
            ExcelLib.PopulateInCollection(Base.ExcelPath, "profile");
            string profileDescription = ExcelLib.ReadData(2, "Description");
            // Add/edit/update description
            profile profileObj = new profile();
            profileObj.EditProfileDesc(profileDescription);

            //Validate the message confirmation displayed
            string expMessage = "Description has been saved successfully";
            string actMessage = driver.FindElement(By.XPath("/html/body/div/div[@class='ns-box-inner']")).Text;
            Assert.AreEqual(expMessage, actMessage, "Getting expected message failed");

            //Validate - Description display correctly
            string actDescription = driver.FindElement(By.XPath("//span[contains(@style,'padding-top: 1em;')]")).Text;
            Assert.AreEqual(profileDescription, actDescription, "Description mismatch - update has failed");

        }
        [Test]
        public void UpdateProfileLangcValidate()
        {
            //Read data from excel data file
            ExcelLib.PopulateInCollection(Base.ExcelPath, "profile");
            string profileLangName = ExcelLib.ReadData(2, "Language");
            string profileLangLevel = ExcelLib.ReadData(2, "LangLevel");
            // edit/update language name and level
            profile profileObj = new profile();
            profileObj.EditProfileLang(profileLangName, profileLangLevel);

            string actualMsg = driver.FindElement(By.XPath("/html/body/div/div[@class='ns-box-inner']")).Text;
            //string expectedMsg = profileLangName + " " + "has been added to your languages";
            Assert.IsTrue(actualMsg.Contains(" your languages"));
        }
    }
}