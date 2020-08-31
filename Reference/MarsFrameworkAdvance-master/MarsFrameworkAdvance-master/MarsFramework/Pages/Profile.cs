using OpenQA.Selenium;
using MarsFramework.Global;
using System;
using RelevantCodes.ExtentReports;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace MarsFramework.Pages
{    
    //internal class Profile
    class profile
    {

        #region  Initialize Web Elements 
        //Click on Edit button
        private IWebElement AvailabilityTimeEdit => GlobalDefinitions.driver.FindElement(By.XPath("//i[@class='large calendar icon']//following-sibling::strong[text()='Availability']/ancestor::div[@class='item']//div[@class='right floated content']//i[@class='right floated outline small write icon']"));
        String AvailabilityTimeEditElePresent => "//i[@class='large calendar icon']//following-sibling::strong[text()='Availability']/ancestor::div[@class='item']//div[@class='right floated content']//i[@class='right floated outline small write icon']";
        
        //Click on Availability Type dropdown
        private IWebElement AvailabilityTime => GlobalDefinitions.driver.FindElement(By.XPath("//select[@name='availabiltyType']"));

        //Select on Availability Time // availabiltyType
        //private IWebElement AvailabilityTimeOpt => GlobalDefinitions.driver.FindElement(By.XPath("//option[@value='1']"));
        IWebElement EditAvailabilityTime => GlobalDefinitions.driver.FindElement(By.XPath("//select[@name='availabiltyType']"));
        
        //Click on Availability Hours option
        private IWebElement AvailabilityHours => GlobalDefinitions.driver.FindElement(By.XPath("//i[@class='large clock outline check icon']//following-sibling::strong[text()='Hours']/ancestor::div[@class='item']//div[@class='right floated content']//i[@class='right floated outline small write icon']"));
        
        //Click on Availability Hour dropdown
        //private IWebElement AvailabilityHoursOpt => GlobalDefinitions.driver.FindElement(By.XPath("//select[@name='availabiltyHour']"));
        IWebElement EditAvailabilityHours => GlobalDefinitions.driver.FindElement(By.XPath("//select[@name='availabiltyType']"));

        //Find Earn Target button salary
        private IWebElement Salary => GlobalDefinitions.driver.FindElement(By.XPath("//i[@class='large dollar icon']//following-sibling::strong[text()='Earn Target']/ancestor::div[@class='item']//div[@class='right floated content']//i[@class='right floated outline small write icon']"));
        // Select the salary targetted
        //private IWebElement EarnTargetSalaryOpt => GlobalDefinitions.driver.FindElement(By.XPath("//option[@value='0']"));
        IWebElement EditSalary => GlobalDefinitions.driver.FindElement(By.XPath("//select[@name='availabiltyTarget']"));

        //find Desctiption edit button
        private IWebElement DescriptionBtn => GlobalDefinitions.driver.FindElement(By.XPath("//h3[@class='ui dividing header'][text()='Description']//i[@class='outline write icon']"));
        //find description text box
        private IWebElement DescriptionValue => GlobalDefinitions.driver.FindElement(By.XPath("//textarea[@name='value']"));
        //Find Description Save Button
        private IWebElement DescriptionSave => GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ui twelve wide column']//button[@class='ui teal button'][text()='Save']"));
        // finding Language active tab
        private IWebElement LanguagesText => GlobalDefinitions.driver.FindElement(By.XPath("//A[@data-tab='first'][text()='Languages']"));
        // finding add new button
        private IWebElement AddNewLanguageBtn => GlobalDefinitions.driver.FindElement(By.XPath("//th[text()='Language']//following-sibling::th[@class='right aligned']/div[@class='ui teal button '][text()='Add New']"));
        // finding AddLanguageTextBox
        private IWebElement AddLanguageTextBox => GlobalDefinitions.driver.FindElement(By.XPath("(//INPUT[@type='text' and @placeholder='Add Language'])"));
        // selecting language level .. 
        //private IWebElement LanguageLvlOpt => GlobalDefinitions.driver.FindElement(By.XPath("//select[@class='ui dropdown']//option[@value='Native/Bilingual']"));
        IWebElement LanguageLvlSelect => GlobalDefinitions.driver.FindElement(By.XPath("//select[@class='ui dropdown' and @name='level']"));
        //finding add button on languages
        private IWebElement LanguageAddBtn => GlobalDefinitions.driver.FindElement(By.XPath("//input[@class='ui teal button']"));
        #endregion
        private IWebElement GermanRemoveBtn => GlobalDefinitions.driver.FindElement(By.XPath("//td[text()='German']//following-sibling::td[@class='right aligned']//i[@class='remove icon']"));
        //IWebElement getLanguagetextValue => GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]'"));
        public void EditProfile(string profileAvailabilityTime, string profileAvailabilityHours, string profileSalaryExpected)
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "profile");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath(AvailabilityTimeEditElePresent), 1);

            //update/edit availability time i.e. full time or part time
            AvailabilityTimeEdit.Click();
            AvailabilityTime.Click();
            new SelectElement(EditAvailabilityTime).SelectByText(profileAvailabilityTime);
            Base.test.Log(LogStatus.Info, "Availability time has been updated");

            //update/edit availability hours in a week
            AvailabilityHours.Click();
            new SelectElement(EditAvailabilityHours).SelectByText(profileAvailabilityHours);
            Base.test.Log(LogStatus.Info, "Availability hours has been updated");

            //update/edit salary in a week  
            Salary.Click();
            new SelectElement(EditSalary).SelectByText(profileSalaryExpected);
            Base.test.Log(LogStatus.Info, "Salary expected has been added/updated");
        }
        public void EditProfileDesc(string profileDescription)
        {
            //Click edit description button/icon
            DescriptionBtn.Click();

            //edit or update decription and save
            DescriptionValue.SendKeys("");
            DescriptionValue.Clear();
            DescriptionValue.SendKeys(profileDescription);
            DescriptionSave.Click();

            Base.test.Log(LogStatus.Info, "Description has been added/udated");
        }
        
        public void EditProfileLang(string profileLangName, string profileLangLevel)
        {
            LanguagesText.Click();
            AddNewLanguageBtn.Click();
            // remove German language if existss
            GermanRemoveBtn.Click();
            // add language name
            AddLanguageTextBox.SendKeys(profileLangName);
            // add language level
            new SelectElement(LanguageLvlSelect).SelectByText(profileLangLevel);
            LanguageAddBtn.Click();
            Base.test.Log(LogStatus.Info, "Language has been added");            
        }
    }
}
