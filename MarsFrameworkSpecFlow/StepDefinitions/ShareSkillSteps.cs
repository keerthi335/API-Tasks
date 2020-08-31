using MarsFramework.Global;
using MarsFramework.Pages;
using MarsFrameworkSpecFlow.PagesFeatures;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;


namespace MarsFrameworkSpecFlow.StepDefinitions
{
    [Binding]
    public class ShareSkillSteps
    {
        [Given(@"I am logged into the profile and clicked the ShareSkill button")]
        public void GivenIAmLoggedIntoTheProfileAndClickedTheShareSkillButton()
        {
            ProfilePage ShareSkillTest = new ProfilePage();
            ShareSkillTest.ClickShareSkillButton();
        }
        
        [When(@"I entered the skill details")]
        public void WhenIEnteredTheSkillDetails()
        {
            ShareSkill shareskill = new ShareSkill();
            shareskill.EnterShareSkill();
        }
        
        [Then(@"the new skill should be added in the ManageListings tab")]
        public void ThenTheNewSkillShouldBeAddedInTheManageListingsTab()
        {
                //Wait untill page is loaded
                GlobalDefinitions.driver.FindElement(By.LinkText("Manage Listings")).Click();

                By WaitCondition = By.XPath("//table[@class='ui striped table']");
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

                //IWebElement table = driver.FindElement(By.XPath("//table[@class='ui striped table']"));
                //Validate Category
                string ActualCategory = GlobalDefinitions.driver.FindElement(By.XPath("//table[@class='ui striped table']/tbody/tr[1]/td[2]")).Text;
                string ExpectedCategory = GlobalDefinitions.ExcelLib.ReadData(2, "Category");
                Assert.AreEqual(ExpectedCategory, ActualCategory);

                //Validate Title
                string ActualTitle = GlobalDefinitions.driver.FindElement(By.XPath("//table[@class='ui striped table']/tbody/tr[1]/td[3]")).Text;
                string ExpectedTitle = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                Assert.AreEqual(ExpectedTitle, ActualTitle);

                //Validate Description
                string ActualDescription = GlobalDefinitions.driver.FindElement(By.XPath("//table[@class='ui striped table']/tbody/tr[1]/td[4]")).Text;
                string ExpectedDescription = GlobalDefinitions.ExcelLib.ReadData(2, "Description");
                Assert.AreEqual(ExpectedDescription, ActualDescription);

                
            
            
        }
    }
}
