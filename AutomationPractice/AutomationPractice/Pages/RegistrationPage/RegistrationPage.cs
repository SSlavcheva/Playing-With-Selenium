using AutomationPractice.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPractice.Pages
{
    public partial class RegistrationPage:BasePage
    {
        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillForm(User user)
        {

            FirstName.SendKeys(user.FirstName);
            LastName.SendKeys(user.LastName);
           
            Password.SendKeys(user.Password);
            Days.Click();
            DayOption.Click();
            Months.Click();
            MonthOption.Click();
            Years.Click();
            YearOption.Click();          
            Address.SendKeys(user.Address);
            City.SendKeys(user.City);
            State.Click();
            StateOption.Click();
            Zip.SendKeys(user.ZipCode);         
           
            HomePhone.SendKeys(user.HomePhone);
            Mobile.SendKeys(user.MobilePhone);
            AddressAlias.Clear();
            AddressAlias.SendKeys(user.AddressAlias);
            RegisterButton.Click();
        }

    }
}
