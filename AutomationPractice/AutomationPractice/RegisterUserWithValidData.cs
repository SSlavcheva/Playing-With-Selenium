
using AutomationPractice.Models;
using AutomationPractice.Pages;
using AutomationPractice.Pages.LoginPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace AutomationPractice
{
    [TestFixture]
    public class AutomationPractice
    {
        private IWebDriver driver;
        private HomePage homePage;
        private LoginPage loginPage;
        private RegistrationPage registrationPage;


        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
            registrationPage = new RegistrationPage(driver);
        }
                
        [Test]

        public void RegisterUserWithValidData()
        {
            var path = Path.GetFullPath(Directory.GetCurrentDirectory() + "/../../../Models/ValidUserData.json");
            var user = User.FromJson(File.ReadAllText(path));
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.Manage().Window.Maximize();


            HomePage homePage = new HomePage(driver);
            LoginPage loginPage = new LoginPage(driver);
            RegistrationPage registration = new RegistrationPage(driver);



            homePage.signInButton.Click();
            loginPage.EmailField.SendKeys($"abv{Randomgenerator()}@abv.bg");
            loginPage.CreateAnAcountButton.Click();

            registration.FillForm(user);         


        }

        private static string Randomgenerator()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
    }
}
