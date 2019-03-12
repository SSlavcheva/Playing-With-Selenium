using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace AutomationPractice.Pages.LoginPage
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement EmailField =>Driver.FindElement(By.Id("email_create"));
        public IWebElement CreateAnAcountButton => Driver.FindElement(By.XPath("//*[@id=\"SubmitCreate\"]/span"));




    }
}
