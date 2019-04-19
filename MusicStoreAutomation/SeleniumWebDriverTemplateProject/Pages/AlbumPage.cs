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
    class AlbumPage : Page
    {
        [FindsBy(How = How.CssSelector, Using = ".button a")]
        public IWebElement AddToCartButton => Driver.FindElement(By.Id(""));
    }
}
