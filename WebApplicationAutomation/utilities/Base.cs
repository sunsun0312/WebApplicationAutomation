using System;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace WebApplicationAutomation.utilities
{
    public class Base
    {
        public IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            //Global Configuration
            String browserName = ConfigurationManager.AppSettings["browser"];
            //String browserName = "Chrome";
            InitBrowser(browserName);

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

        }

        public void InitBrowser(String browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "Edge":
                    driver = new EdgeDriver();
                    break;
            }
        }

        public IWebDriver getDriver()
        {
            return driver;
        }

        public static JsonReader getDataParser()
        {
            return new JsonReader();
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }
    }
}
