﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebDriverTemplateProject.Helpers;
using SeleniumWebDriverTemplateProject.Pages.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverTemplateProject.Pages
{
    public class HomePage : Page
    {

        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/div/div[4]/a")]
        public IWebElement SignInButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"first_name\"]")]
        public IWebElement NameTextBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#logoutForm ul > li")]
        public IWebElement UserGreetingTextBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#logoutForm ul > li + li")]
        public IWebElement LogoutButton { get; set; }

        [FindsBy(How = How.Id, Using = "registerLink")]
        public IWebElement RegisterButton { get; set; }

        [FindsBy(How = How.Id, Using = "loginLink")]
        public IWebElement LoginButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "navbar-inverse")]
        public IWebElement NavigationBarRoot { get; set; }

        [FindsBy(How = How.Id, Using = "album-list")]
        public IWebElement AlbumListRoot { get; set; }

        public bool IsCartVisible()
        {
            return this.NavigationBarRoot.FindElements(By.Id("cart-status")).Any();
        }

        public int GetCartItemCount()
        {
            if (!this.IsCartVisible()) { return 0; }
            string cartItemCountAsString = this.NavigationBarRoot.FindElement(By.Id("cart-status")).Text;
            return int.Parse(cartItemCountAsString);
        }

        public IList<IWebElement> GetAlbums()
        {
            IList<IWebElement> list = AlbumListRoot.FindElements(By.TagName("a")).ToList();
            return list;
        }

        //public static HomePage NavigateTo(IWebDriver driver)
        //{
        //    var page = LoginPage.NavigateTo(driver);
        //    System.Threading.Thread.Sleep(3000);

        //    page.LogIn();

        //    var homePageInstance = PageFactoryExtensions.InitPage<HomePage>(driver);

        //    return homePageInstance;
        //}

        public static HomePage NavigateTo(IWebDriver driver)
        {
            string baseURL = GeneralSettings.Default.BaseURL;
            driver.Navigate().GoToUrl(baseURL);

            if (driver.Manage().Cookies.AllCookies.Any())
            {
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Navigate().GoToUrl(baseURL);
            }

           // driver.Navigate().GoToUrl(baseURL);

            var homePageInstance = PageFactoryExtensions.InitPage<HomePage>(driver);

            //Page.GlobalWait(driver).Until(d => driver.FindElements(By.Id("lfootercc")).Any());

            return homePageInstance;
        }
    }
}
