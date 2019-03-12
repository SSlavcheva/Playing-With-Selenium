using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flags_And_IPs.Pages.CountryIps
{
   public partial  class CountryIp
    {
        public IWebElement PeerGuardianRadioButton => Driver.FindElement(By.XPath("/html/body/form/input[3]"));

        public IWebElement CountryContainer => Driver.FindElement(By.XPath("/html/body/table/tbody"));

        public IList<IWebElement> Countries => CountryContainer.FindElements(By.TagName("a"));
        
        public IWebElement GenerateButton => Driver.FindElement(By.XPath("/html/body/form/input[5]"));

        public IWebElement InputField => Driver.FindElement(By.XPath("/html/body/form/input[1]"));

        public IWebElement IPresult => Driver.FindElement(By.XPath("/html/body/pre/text()"));
               

    }
}
