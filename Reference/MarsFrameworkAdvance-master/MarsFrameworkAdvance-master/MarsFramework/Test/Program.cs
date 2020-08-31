using NUnit.Framework;
using MarsFramework.Pages;
using MarsFramework.Global;
using OpenQA.Selenium;
using System;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {
            [Test, Order(1)]
            public void SignIn()
            {
/*                
                String IsSignOutVisible = "//button[@class='ui green basic button'][text()='Sign Out']";
                test = extent.StartTest("Signin test started");
                var mySignin = new SignIn();
                mySignin.LoginSteps();
                By WaitConditionforIsSignOutVisible = By.XPath(IsSignOutVisible);
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitConditionforIsSignOutVisible, 10);
                mySignin.validateSteps();
*/
            }
            [Test, Order(3)]
            public void SignUp()
            {
                //test = extent.StartTest("Signup test started");
                //var mySignup = new SignUp();
                //mySignup.register();
            }
            [Test, Order(2)]
            public void ProfilePage()
            {
                //test = extent.StartTest("Profile test started");
                //var myProfile = new profile();
                //myProfile.EditProfile();
                //myProfile.EditProfileValidate();               
            }

            [Test, Order(4)]
            public void SearchskillPage()
            {
                //test = extent.StartTest("Search test started");
                //var mySearch = new Searchskills();
                //mySearch.skillSearch();
                //mySearch.ValidateSearchSkills();
            }

        }
    }
}