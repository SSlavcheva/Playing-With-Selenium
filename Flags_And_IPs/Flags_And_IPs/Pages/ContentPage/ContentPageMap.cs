using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flags_And_IPs.Pages.ContentPage
{
   public partial class ContentPage
    {
        public IWebElement CountriesContainer => Driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]"));
        
    }
}
