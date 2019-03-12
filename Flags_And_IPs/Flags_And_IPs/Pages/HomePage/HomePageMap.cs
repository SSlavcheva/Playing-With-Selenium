using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flags_And_IPs.Pages.HomePage
{
    public partial class HomePage
    {
        public IWebElement CountriesOfEuropeLink => this.Driver.FindElement(By.XPath("//*[@id=\"leftmenu-style\"]/ul[2]/li[1]/a"));

    }
}
