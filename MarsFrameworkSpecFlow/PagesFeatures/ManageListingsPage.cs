using AutoItX3Lib;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using MarsFramework.Global;
using MarsFramework.Pages;

namespace MarsFrameworkSpecFlow.PagesFeatures
{
    public class ManageListingsPage
    {
        //Elements

        internal void ClickEditListings(string EditSkill)
        {
            By WaitCondition = By.XPath("//th[text()='Image']");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            GlobalDefinitions.driver.FindElement(By.XPath("//td[contains(text(),'" + EditSkill + "')]//following-sibling::td//child::i[@class='outline write icon']")).Click();

        }        
        
        public static bool ValidateEdit(string ValidateEditRecord)
        {
            GlobalDefinitions.driver.FindElement(By.LinkText("Manage Listings")).Click();

            By WaitCondition = By.XPath("(//button[@class='ui button'])[1]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);
            try
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//td[contains(text(),'" + ValidateEditRecord + "')]"));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ClickDeleteListings(string DeleteSkill)
        {
            
            By WaitCondition1 = By.XPath("//th[text()='Image']");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition1, 60);

            IWebElement delete = GlobalDefinitions.driver.FindElement(By.XPath("//td[contains(text(),'" + DeleteSkill + "')]//following-sibling::td//child::i[@class='remove icon']"));

            //Click on Delete button
            delete.Click();

            //Click Yes on Popup window
            // GlobalDefinitions.driver.SwitchTo().Alert().Accept();

            GlobalDefinitions.driver.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']")).Click();

        }

        public static bool ValidateDelete(string ValidateDeleteRecord)
        {
            By WaitCondition = By.XPath("//th[contains(text(),'Title')]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            try
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//th[contains(text(),'" + ValidateDeleteRecord + "')]"));
                return false;
            }
            catch
            {
                return true;
            }
        }
    }
}
