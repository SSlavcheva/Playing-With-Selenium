using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPractice.Pages
{
    public partial class RegistrationPage
    {
        public IWebElement GenderInput => Driver.FindElement(By.Id("id_gender2"));
        public IWebElement FirstName => Wait.Until(d => { return d.FindElement(By.Id("customer_firstname")); });        
        public IWebElement LastName => Driver.FindElement(By.Id("customer_lastname"));
        public IWebElement Password => Driver.FindElement(By.Id("passwd"));
        public IWebElement Days => Driver.FindElement(By.Id("days"));
        public IWebElement DayOption => Driver.FindElement(By.XPath("//*[@id=\"days\"]/option[6]"));
        public IWebElement Months => Driver.FindElement(By.Id("months"));
        public IWebElement MonthOption => Driver.FindElement(By.XPath("//*[@id=\"months\"]/option[6]"));
        public IWebElement Years => Driver.FindElement(By.Id("years"));
        public IWebElement YearOption => Driver.FindElement(By.XPath("//*[@id=\"years\"]/option[8]"));
        public IWebElement Address => Driver.FindElement(By.Id("address1"));
        public IWebElement City=> Driver.FindElement(By.Id("city"));
        public IWebElement State => Driver.FindElement(By.Id("id_state"));
        public IWebElement StateOption => Driver.FindElement(By.XPath("//*[@id=\"id_state\"]/option[6]"));

        
        public IWebElement Zip => Driver.FindElement(By.Id("postcode"));
        public IWebElement HomePhone => Driver.FindElement(By.Id("phone"));
        public IWebElement Mobile =>Driver.FindElement(By.Id("phone_mobile"));
        public IWebElement AddressAlias => Driver.FindElement(By.Id("alias"));
        public IWebElement RegisterButton => Driver.FindElement(By.XPath("//*[@id=\"submitAccount\"]/span"));
    }
}
