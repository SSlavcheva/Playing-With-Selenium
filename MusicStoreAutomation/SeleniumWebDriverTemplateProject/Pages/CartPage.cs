using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebDriverTemplateProject.Pages.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverTemplateProject.Pages
{
    class CartPage : Page
    {
        [FindsBy(How = How.LinkText, Using = "Checkout >>")]
        public IWebElement CheckOutButton { get; set; }
    }
}
