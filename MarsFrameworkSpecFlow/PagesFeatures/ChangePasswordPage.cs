using MarsFramework.Global;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFrameworkSpecFlow.PagesFeatures
{
    public class ChangePasswordPage
    {
        //Finding OldPassword Element
        private IWebElement OldPassword => GlobalDefinitions.driver.FindElement(By.Name("oldPassword"));

        //Finding NewPassword Element
        private IWebElement NewPassword => GlobalDefinitions.driver.FindElement(By.Name("newPassword"));

        //Finding ConfirmPassword Element
        private IWebElement ConfirmPassword => GlobalDefinitions.driver.FindElement(By.Name("confirmPassword"));

        //Finding Save Button
        private IWebElement Save => GlobalDefinitions.driver.FindElement(By.XPath("//button[@class='ui button ui teal button']"));

        internal void ChangePassword(string OldPwd, string NewPwd, string ConfirmPwd)
        {
            OldPassword.SendKeys(OldPwd);
            NewPassword.SendKeys(NewPwd);
            ConfirmPassword.SendKeys(ConfirmPwd);

            Save.Click();
        }
        public static bool ValidateChangePassword()
        {
            try
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//button[text()='Sign Out']"));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
