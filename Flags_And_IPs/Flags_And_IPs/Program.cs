using Flags_And_IPs.Models;
using Flags_And_IPs.Pages.ContentPage;
using Flags_And_IPs.Pages.CountryIps;
using Flags_And_IPs.Pages.FlagsPage;
using Flags_And_IPs.Pages.HomePage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Flags_And_IPs
{
    public class StartUp
    {
        private HomePage homePage;

        public static void Main(string[] args)
        {
         
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://www.countries-ofthe-world.com");

            var homePage = new HomePage(driver);
            homePage.CountriesOfEuropeLink.Click();

            var contentPage = new ContentPage(driver);
            var listOFCountries = contentPage.CountriesContainer.FindElements(By.TagName("li"));

            List<string> urls = new List<string>();

            foreach (var country in listOFCountries)
            {
                urls.Add(country.Text);
            }
                              
        

            var finalCountryNames = CheckValidUrls(urls);

            foreach (var countryname in finalCountryNames)
            {
                driver.Url = $"http://flagpedia.net/{countryname}";

                FlagPage flagPage = new FlagPage(driver);

                Actions actions = new Actions(driver);
                actions.MoveToElement(flagPage.PrivacyButtonLink);
                actions.Perform();


                CountryModel newCountry = new CountryModel(flagPage.Country.Text, flagPage.Capital.Text, flagPage.Code.Text);

                Thread.Sleep(1000);

                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                       
                var path = $"..\\..\\..\\ScreenShoots";

                screenshot.SaveAsFile($"{path}/{newCountry.CountryName}-{newCountry.CapitalName}-{newCountry.CountryCode}.png", ScreenshotImageFormat.Png);


            }

            CountryIp ipPage = new CountryIp(driver);
            driver.Url = "http://services.ce3c.be/ciprg/ ";
            ipPage.PeerGuardianRadioButton.Click();
            var countries = new List<string>();
            ipPage.FillData(finalCountryNames);
         
        }    

        private static List<string> CheckValidUrls(List<string> url)
        {
            var finalUrlsList = url.Where(u => u.Length > 1).ToList();

                for (var i = 0; i < finalUrlsList.Count; i++)
                {
                  
                    var country = finalUrlsList[i];

                    if (country.Contains("Vatican"))
                    {
                    finalUrlsList[i] = "vatican-city";
                    }
                    if (country == "Bosnia and Herzegovina")
                    {
                    finalUrlsList[i] = "bosnia-and-herzegovina";
                    }
                    if (country.Contains("United"))
                    {
                    finalUrlsList[i] = "The-United-Kingdom";
                    }
                    if (country.Contains("Macedonia"))
                    {
                    finalUrlsList[i] = "Macedonia";
                    }

                    if (country == "Czechia")
                    {
                    finalUrlsList[i] = "Czech-Republic";
                    }

                    if (country == "San Marino")
                    {
                    finalUrlsList[i] = "San-Marino";
                    }

               
                }
            return finalUrlsList;
            }
        }
    }
