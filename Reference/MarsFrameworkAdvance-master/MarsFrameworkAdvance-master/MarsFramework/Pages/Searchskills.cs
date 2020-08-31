using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MarsFramework.Pages
{
    class Searchskills
    {
        //Finding search skill text box
        private IWebElement SeachSkillstext => GlobalDefinitions.driver.FindElement(By.XPath("//input[@placeholder='Search skills']"));
        //Finding search skill button/icon
        private IWebElement SeachSkillBtn => GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='account-profile-section']//div[@class='ui secondary menu']//div[@class='ui small icon input search-box']//i[@class='search link icon']"));
        IWebElement AllCategory => GlobalDefinitions.driver.FindElement(By.XPath("//b[contains(text(),'All Categories')]"));
        private IWebElement SubCategorylink => GlobalDefinitions.driver.FindElement(By.XPath("//a[text()='Programming & Tech']"));
        private IWebElement FilterOnlineBtn => GlobalDefinitions.driver.FindElement(By.XPath("//button[@class='ui button'][text() ='Online']"));
        private IWebElement FilterOnsiteBtn => GlobalDefinitions.driver.FindElement(By.XPath("//button[@class='ui button'][text() ='Onsite']"));
        private IWebElement FilterShowAllBtn => GlobalDefinitions.driver.FindElement(By.XPath("//button[@class='ui button'][text() ='ShowAll']"));

        internal void ClickSearch()
        {
            //Click on searcch text box
            SeachSkillstext.Click();
        }
        public void skillSearchInput(string profileDescription)
        {
            //Sending "Test Analyst" to Seach Skills
            SeachSkillstext.SendKeys(profileDescription);
            // Clicking search skills button
            SeachSkillBtn.Click();
            // Selecting category - programming and Tech
            //SubCategorylink.Click();
        }
        internal void SkillsCategory(string category, string subcategory)
        {
            AllCategory.Click();
            GlobalDefinitions.driver.FindElement(By.XPath("//a[contains(text(),'" + category + "')]")).Click();
            GlobalDefinitions.driver.FindElement(By.XPath("//a[contains(text(),'" + subcategory + "')]")).Click();
        }
        internal void FilterbyOnline()
        {
            // Selecting Online filter
            FilterOnlineBtn.Click();
        }
        internal void FilterbyOnsite()
        {
            // Selecting Onsite filter
            FilterOnsiteBtn.Click();
        }
        internal void FilterbyShowAll()
        {
            // Selecting Show all filter
            FilterShowAllBtn.Click();
        }
    }
}
