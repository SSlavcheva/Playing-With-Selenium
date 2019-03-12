using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPractice.Pages
{
    public abstract class BasePage
    {
        private IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebDriver Driver => this.driver;
        public WebDriverWait Wait => new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        public string BaseUrl => "http://automationpractice.com/index.php";
    }
}
