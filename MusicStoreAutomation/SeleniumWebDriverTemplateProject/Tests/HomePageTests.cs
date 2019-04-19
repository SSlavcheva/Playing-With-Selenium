using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using SeleniumWebDriverTemplateProject.Helpers;
using SeleniumWebDriverTemplateProject.Pages;
using SeleniumWebDriverTemplateProject.Tests.Abstract;
using System;
using System.Threading;
namespace SeleniumWebDriverTemplateProject.Tests
{
    class HomePageTests : DesktopSeleniumTestFixturePrototype
    {
        public HomePageTests(Browsers browser) : base(browser)
        { }

        [Test]
        public void AreOffersInHomePageTest()
        {
            var homePageInstance = HomePage.NavigateTo(this.Driver);

            Thread.Sleep(4000);

            homePageInstance.SignInButton.Click();

            Thread.Sleep(4000);

            Driver.SwitchTo().ActiveElement();
            homePageInstance.NameTextBox.SendKeys("hudhcjd");

        }
    }
}
