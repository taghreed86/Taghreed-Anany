using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Threading;

namespace RegisterAndLoginToFacebook
{
    class LoginClass
    {
        IWebDriver _driver;
        IWebElement loginEmail_txt;
        IWebElement loginPassword_txt;
        IWebElement login_btn;
        IWebElement user_Account;
        IWebElement settings_menu;
        IWebElement logOut_option;
        public LoginClass(IWebDriver driver)
        {
            _driver = driver;
        }
        public void setTheLoginEmail(string e_mail)
        {
            loginEmail_txt = _driver.FindElement(By.Id("email"));
            RegisterClass.wait_Element(_driver, By.Id("email"));
            loginEmail_txt.Click();
            loginEmail_txt.SendKeys(e_mail);
        }
        public void setTheLoginPassword(string Pass)
        {
            loginPassword_txt = _driver.FindElement(By.Id("pass"));
            RegisterClass.wait_Element(_driver, By.Id("pass"));
            loginPassword_txt.Click();
            loginPassword_txt.SendKeys(Pass);
        }
        public void clickLogin()
        {
            
            login_btn = _driver.FindElement(By.Id("u_0_b"));
            login_btn.Submit();
        }

     

        public string AfterLogin()
        {
            RegisterClass.wait_Element(_driver, By.XPath("//span[@class='_1vp5']"));
            user_Account = _driver.FindElement(By.XPath("//span[@class='_1vp5']"));
           
            return user_Account.Text;

        }
        public void logOut()
        {
            settings_menu = _driver.FindElement(By.Id("logoutMenu"));
          
            settings_menu.Click();
            RegisterClass.wait_Element(_driver, By.XPath("//*[contains(text(),'Log Out')]"));
            logOut_option = _driver.FindElement(By.XPath("//*[contains(text(),'Log Out')]"));
            Actions action2 = new Actions(_driver);
            action2.MoveToElement(logOut_option).ClickAndHold().Build().Perform();
            logOut_option.Click();
        }
    }
}
