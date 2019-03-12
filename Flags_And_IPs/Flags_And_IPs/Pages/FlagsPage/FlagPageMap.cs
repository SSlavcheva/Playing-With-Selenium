using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flags_And_IPs.Pages.FlagsPage
{
    public partial class FlagPage
    {
        public IWebElement PrivacyButtonLink => Driver.FindElement(By.XPath("//*[@id=\"footer\"]/p/a[2]"));

        public IWebElement Country => Driver.FindElement(By.XPath(" //*[@id=\"content\"]/dl[1]/dd[2]"));
        public IWebElement Capital => Driver.FindElement(By.XPath("//*[@id=\"content\"]/dl[1]/dd[3]"));
        public IWebElement Code => Driver.FindElement(By.XPath("//*[@id=\"content\"]/dl[1]/dd[10]/em"));
       
        //*[@id="content"]/dl[1]/dd[2]

    }
}
