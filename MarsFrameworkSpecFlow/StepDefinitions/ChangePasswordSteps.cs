using MarsFrameworkSpecFlow.PagesFeatures;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace MarsFrameworkSpecFlow.StepDefinitions
{
    [Binding]
    public class ProfileFeaturesSteps
    {
        [Given(@"I logged in the system and click on Profile DropDown box")]
        public void GivenILoggedInTheSystemAndClickOnProfileDropDownBox()
        {
            ProfilePage profilePage = new ProfilePage();
            profilePage.ClickProfileDropDown();
        }
        
        [Given(@"Click on ChangePassword Button")]
        public void GivenClickOnChangePasswordButton()
        {
            ProfilePage ProPage = new ProfilePage();
            ProPage.ClickChangePassword();
        }
        
        [When(@"I provide the value for fields '(.*)', '(.*)' and '(.*)'")]
        public void WhenIProvideTheValueForFieldsAnd(string OldPassword, string NewPassword, string ConfirmPassword)
        {
            ChangePasswordPage changePassword = new ChangePasswordPage();
            changePassword.ChangePassword(OldPassword, NewPassword, ConfirmPassword);
        }
        
        [Then(@"the password should change successfully by returning to home page")]
        public void ThenThePasswordShouldChangeSuccessfullyByReturningToHomePage()
        {
            bool result = ChangePasswordPage.ValidateChangePassword();
            Assert.IsTrue(result);
        }
    }
}
