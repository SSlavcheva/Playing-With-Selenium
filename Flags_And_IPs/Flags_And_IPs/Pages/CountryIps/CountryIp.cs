using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace Flags_And_IPs.Pages.CountryIps
{
    public partial class CountryIp : BasePage
    {
        public CountryIp(IWebDriver driver) : base(driver)
        {
        }

        public void FillData(List<string> names)
        {
            foreach (var item in names)
            {
                InputField.Clear();
                InputField.SendKeys(item);
                GenerateButton.Click();
            
                Thread.Sleep(5000);

                string text = Driver.FindElement(By.XPath("/html/body")).Text;


                File.WriteAllText($"..\\..\\..\\IPs\\{item}.txt", text);
              
                // Console.WriteLine(text);
                Driver.Navigate().Back();
            }

        

        }
    }
}
