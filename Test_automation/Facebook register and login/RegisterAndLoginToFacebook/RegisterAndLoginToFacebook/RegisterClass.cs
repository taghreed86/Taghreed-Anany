using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace RegisterAndLoginToFacebook
{
    class RegisterClass
    {
        IWebDriver _driver;
        IWebElement first_Name_txt;
        IWebElement last_Name_txt;
        IWebElement email_txt;
        IWebElement email_txt2;
        IWebElement password_txt;
        IWebElement birth_day_list;
        IWebElement birth_month_list;
        IWebElement birth_year_list;
        IWebElement female_radioBtn;
        IWebElement male_radioBtn;
        IWebElement custome_radioBtn;
        IWebElement reason_list;
        IWebElement type_gender_txt;
        IWebElement signUp_btn;
      
        public RegisterClass(IWebDriver driver)
        {
            _driver = driver;
        }
        public void setTheFirstName(string f_name)
        {
            first_Name_txt = _driver.FindElement(By.Id("u_0_m"));
            wait_Element(_driver, By.Id("u_0_m"));
            first_Name_txt.Click();
            first_Name_txt.SendKeys(f_name);
            
           
        }
        public void setTheLasttName(string l_name)
        {
            last_Name_txt = _driver.FindElement(By.Id("u_0_o"));
            wait_Element(_driver, By.Id("u_0_o"));
            last_Name_txt.Click();
            last_Name_txt.SendKeys(l_name);
        }
        public void setTheEmail(string email)
        {
            email_txt = _driver.FindElement(By.Id("u_0_r"));
            wait_Element(_driver, By.Id("u_0_r"));
            email_txt.Click();
            email_txt.SendKeys(email);
        }

        public void setTheEmailAgain(string email)
        {
            email_txt2 = _driver.FindElement(By.Id("u_0_u"));
            wait_Element(_driver, By.Id("u_0_u"));
            email_txt2.Click();
            email_txt2.SendKeys(email);
        }
        public void setThePassword(string passowrd)
        {
            password_txt = _driver.FindElement(By.Id("u_0_w"));
            wait_Element(_driver, By.Id("u_0_w"));
            password_txt.Click();
            password_txt.SendKeys(passowrd);
        }

        public void setTheBirthDay(string birth_day)
        {
           
            birth_day_list = _driver.FindElement(By.Id("day"));
            SelectElement dayElement = new SelectElement(birth_day_list);
            dayElement.SelectByText(birth_day);
         
        }

        public void setTheBirthMonth(string birth_month)
        {
            
            birth_month_list = _driver.FindElement(By.Id("month"));
            SelectElement monthElement = new SelectElement(birth_month_list);
            monthElement.SelectByText(birth_month);

        }

        public void setTheBirthYear(string birth_year)
        {
            birth_year_list = _driver.FindElement(By.Id("year"));
            SelectElement yearElement = new SelectElement(birth_year_list);
            yearElement.SelectByText(birth_year);
            

        }

        //Wait the Gender frame to be accessible
     
        public void setTheGenderAsFemale()
        {
            
            female_radioBtn = _driver.FindElement(By.XPath("//input[@id='u_0_6']"));
            wait_Element(_driver, By.XPath("//input[@id='u_0_6']"));
            if (female_radioBtn.Displayed)
            {
                female_radioBtn.Click();
            }
            
        }
        public void setTheGenderAsMale()
        {
            
            male_radioBtn = _driver.FindElement(By.XPath("//input[@id='u_0_7']"));
            wait_Element(_driver, By.XPath("//input[@id='u_0_7']"));
            if (male_radioBtn.Displayed)
            {
                male_radioBtn.Click();
            }
           
        }
        public void setTheGenderAsCustome()
        {
            
            custome_radioBtn = _driver.FindElement(By.XPath("//input[@id='u_0_8']"));
            wait_Element(_driver, By.XPath("//input[@id='u_0_8']"));
            custome_radioBtn.Click();

          
            reason_list = _driver.FindElement(By.XPath("//*[@class='_7-16 _5dba']"));
            wait_Element(_driver, By.XPath("//*[@class='_7-16 _5dba']"));

            SelectElement reasonElement = new SelectElement(reason_list);
            reasonElement.SelectByValue("2");


            
            //type_gender_txt = _driver.FindElement(By.XPath("//input[@id='u_0_11']"));
            //wait_Element(_driver, By.Id("//input[@id='u_0_11']"));
            //if (type_gender_txt.Displayed)
            //{
            //    type_gender_txt.Click();
            //    type_gender_txt.SendKeys("Male");
            //}
            


        }

        public void clickSignUp()
        {
            
            signUp_btn = _driver.FindElement(By.Id("u_0_13"));
            wait_Element(_driver, By.Id("u_0_13"));

            signUp_btn.Submit();



        }


        public static void wait_Element(IWebDriver ch_driver,By locator)
        {
            WebDriverWait wait = new WebDriverWait(ch_driver, TimeSpan.FromSeconds(12));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));

        }

      

    


    }
}
