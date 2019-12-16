using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;

namespace RegisterAndLoginToFacebook
{
    [TestFixture]
    public class TestFacebookRegisterAndLogin
    {
        public static IWebDriver _driver;
        Excel.Application excelApp;
        Excel.Workbook UsersWorkbook;
        Excel.Worksheet testUsersSheet;
        Excel.Range usersDataRange;
        Excel.Worksheet loginUsersSheet;
        Excel.Range loginUsersRange;

        string user_First_Name;
         string user_Last_Name;
         string user_Email;
         string user_Password;
        string login_email;
        string login_password;
        string userName_afterLogin;
         string user_birth_day;
         string user_birth_month;
         string user_birth_year;
        string user_gender;
      
        RegisterClass register;
        LoginClass login;
  
        [OneTimeSetUp]
        public void Setup()
        {//to disable show notification alert from chrome browser
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-notifications");
            string ChromeDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(ChromeDriverPath,options);
            excelApp = new Excel.Application();
            string fileToRead = (new FileInfo(Assembly.GetExecutingAssembly().Location).Directory).FullName + @"\Test_Users_List.xlsx";
            UsersWorkbook = excelApp.Workbooks.Open(fileToRead);
            testUsersSheet = UsersWorkbook.Sheets[1];
            usersDataRange = testUsersSheet.UsedRange;
            loginUsersSheet = UsersWorkbook.Sheets[2];
            loginUsersRange = loginUsersSheet.UsedRange;
            register = new RegisterClass(_driver);
            login = new LoginClass(_driver);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.facebook.com/");



        }
        [Test, Order(1)]

        public void TestFacebookRegister()
        {
            
             
            int rowCount = usersDataRange.Rows.Count;
            int colCount = usersDataRange.Columns.Count;

            for (int i = 2; i <= rowCount; i++)
            {
              
                for (int j = 1; j <= colCount; j++)
                {
                    if (usersDataRange.Cells[i, j] != null && usersDataRange.Cells[i, j].Value != null)
                    {

                        if (j == 1)
                        {
                            user_First_Name = usersDataRange.Cells[i, 1].Value;
                            register.setTheFirstName(user_First_Name);
                        }
                        else if (j == 2)
                        {
                            user_Last_Name = usersDataRange.Cells[i, 2].Value;
                            register.setTheLasttName(user_Last_Name);
                        }

                        else if (j == 3)
                        {
                            user_Email = usersDataRange.Cells[i, 3].Value;
                            register.setTheEmail(user_Email);
                            register.setTheEmailAgain(user_Email);
                        }

                        else if (j == 4)
                        {
                            user_Password = usersDataRange.Cells[i, 4].Value;
                            register.setThePassword(user_Password);
                        }

                        else if (j == 5)
                        {
                            user_birth_day = Convert.ToString(usersDataRange.Cells[i, 5].Value);
                            register.setTheBirthDay(user_birth_day);
                        }

                        else if (j == 6)
                        {
                            user_birth_month = usersDataRange.Cells[i, 6].Value;
                            register.setTheBirthMonth(user_birth_month);
                        }

                        else if (j == 7)
                        {
                            user_birth_year = Convert.ToString(usersDataRange.Cells[i, 7].Value);
                            register.setTheBirthYear(user_birth_year);
                        }

                          
                        else if (j == 8)
                        {
                            user_gender = usersDataRange.Cells[i, 8].Value;
                            Thread.Sleep(2000);
                            if (user_gender == "Male")
                            { 
                                register.setTheGenderAsMale();

                            }
                            else if (user_gender == "Female")
                            {
                                register.setTheGenderAsFemale();

                            }
                            else if (user_gender == "Set Later")
                            {
                                register.setTheGenderAsCustome();
                            }
                        }
                    }
                }
                
                register.clickSignUp();
                string AfterRegister = login.AfterLogin();
                Assert.AreEqual(user_First_Name, AfterRegister);
                login.logOut();
                Assert.AreEqual("We hope to see you again soon.", _driver.FindElement(By.ClassName("_15lg")).Text);
            }
        }


        [Test, Order(2)]

        public void TestFacebook_Login()
        {
            //_driver.Navigate().Refresh();
            int row = loginUsersRange.Rows.Count;
            int col = loginUsersRange.Columns.Count;

            for (int i = 2; i <= row; i++)
            {
                for (int j = 1; j <= col; j++)
                {
                    if (loginUsersRange.Cells[i, j] != null && loginUsersRange.Cells[i, j].Value != null)
                    {

                        if (j == 1)
                        {

                            login_email = loginUsersRange.Cells[i, 1].Value;
                            login.setTheLoginEmail(login_email);
                      

                           
                        }
                        else if (j == 2)
                        {
                            login_password = loginUsersRange.Cells[i, 2].Value;
                            login.setTheLoginPassword(login_password);
                        }

                        else if (j == 3)
                        {
                            userName_afterLogin = loginUsersRange.Cells[i, 3].Value;
                            
                        }



                    }
                }
                Thread.Sleep(2000);
                login.clickLogin();
                string AfterRegister = login.AfterLogin();
                Assert.AreEqual(userName_afterLogin, AfterRegister);
                login.logOut();
                Assert.AreEqual("We hope to see you again soon.", _driver.FindElement(By.ClassName("_15lg")).Text);
            }

             
        }
        

        [OneTimeTearDown]
        public void CleanUp()
        {
            excelApp.Quit();
            _driver.Quit();
        }
    }
}
