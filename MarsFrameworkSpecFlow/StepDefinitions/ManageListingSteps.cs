using MarsFramework.Global;
using MarsFramework.Pages;
using MarsFrameworkSpecFlow.PagesFeatures;
using MarsFrameworkSpecFlow.PagesFeatures.Helpers;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace MarsFrameworkSpecFlow.StepDefinitions
{
    [Binding]
    public class ManageListingsSteps
    {
        [Given(@"I am logged into the profile with '(.*)' and '(.*)' and click on ManageListings tab")]
        public void GivenIAmLoggedIntoTheProfileAndClickOnManageListingsTab(string username, string pwd)
        {
            //Initialize Chrome Browser
            Initialization.Initialize();

            //Navigate to the SkillSwap website
            Initialization.NavigateUrl();
            
            //Login to the website
            Initialization.LoginSteps(username, pwd);

            //Click on ManageListings Tab
            ProfilePage EditListingTest = new ProfilePage();
            EditListingTest.ClickManageListingsTab();

        }

        [Given(@"click the Edit button of '(.*)'")]
        public void GivenClickTheEditButtonOf(string EditRecord)
        {
            ManageListingsPage EditListingTest = new ManageListingsPage();
            EditListingTest.ClickEditListings(EditRecord);

        }
        
        [Given(@"click the Delete button of '(.*)'")]
        public void GivenClickTheDeleteButtonOf(string DeleteRecord)
        {
            ManageListingsPage DeleteListingTest = new ManageListingsPage();
            DeleteListingTest.ClickDeleteListings(DeleteRecord);

        }

        [When(@"I entered the details of skill")]
        public void WhenIEnteredTheDetailsOfSkill()
        {
            ShareSkill EditSkillInstance = new ShareSkill();
            EditSkillInstance.EnterShareSkill();
        }
        
        [Then(@"the '(.*)' item should be added in the ManageListings tab")]
        public void ThenTheItemShouldBeAddedInTheManageListingsTab(string ValidateEditRecord)
        {
            bool result = ManageListingsPage.ValidateEdit(ValidateEditRecord);
            Assert.IsTrue(result);
        }
        
        [Then(@"the '(.*)' should be removed from ManageListings tab")]
        public void ThenTheSkillShouldBeRemovedFromManageListingsTab(string ValidateDeleteRecord)
        {
            bool result = ManageListingsPage.ValidateDelete(ValidateDeleteRecord);
            Assert.IsTrue(result);
        }
    }
}
