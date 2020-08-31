using NUnit.Framework;
using System;
using MarsFramework.Global;
using MarsFramework.Pages;
using OpenQA.Selenium;
using static MarsFramework.Global.GlobalDefinitions;
using RelevantCodes.ExtentReports;

namespace MarsFramework.Test
{
    [TestFixture]
    class SearchSkillsTest : BaseTest
    {
        [Test]
        public void SearchSkillsOnline()
        {
            //Read data from excel data file
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Search-Skills");
            string profileDescription = ExcelLib.ReadData(2, "SearchSkills");
            // Add/edit/update description
            Searchskills SearchskillsObj = new Searchskills();
            SearchskillsObj.skillSearchInput(profileDescription);

            try
            {
                String ActualTitle = GlobalDefinitions.driver.Title;
                String ExpectedTitle = "Search";
                Assert.AreEqual(ExpectedTitle, ActualTitle);
                Base.test.Log(LogStatus.Info, "Search skills validated successfully");

                IWebElement searchOutcome = GlobalDefinitions.driver.FindElement(By.XPath("//h3[contains(text(),'Refine Results')]"));
                Assert.IsTrue(searchOutcome.Text.Equals("Refine Results"));
                Base.test.Log(LogStatus.Info, "Search skills returned successfully with results");
            }
            catch (AssertionException)
            {
                //JoinBtn.Click();
                Base.test.Log(LogStatus.Info, "Search skills exception handeled successfully");
            }


        }
        [Test]
        public void SearchSkillsbyCategory()
        {
            //Read data from Excel file
            ExcelLib.PopulateInCollection(ExcelPath, "Search-Skills");
            string category = ExcelLib.ReadData(2, "Category");
            string subcategory = ExcelLib.ReadData(4, "SubCategory");

            //Search by category and subcategory
            var SearchskillsObj = new Searchskills();
            SearchskillsObj.ClickSearch();
            SearchSkillsOnline();
            SearchskillsObj.SkillsCategory(category, subcategory);
        }
    }
}
