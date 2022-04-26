using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace WebApplicationAutomation.pageObjects
{
    public class ConfirmPage
    {
        private IWebDriver driver;

        By success = By.CssSelector(".alert-success");

        public ConfirmPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //driver.FindElement(By.Id("country")).SendKeys("au");
        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement country;


        //driver.FindElement(By.CssSelector("label[for*='checkbox']")).Click();
        [FindsBy(How = How.CssSelector, Using = "label[for*='checkbox']")]
        private IWebElement checkbox;

        //driver.FindElement(By.CssSelector("input[value='Purchase']")).Click();
        [FindsBy(How = How.CssSelector, Using = "input[value='Purchase']")]
        private IWebElement purchaseButton;

        public void searchCountry(String keyword)
        {
            country.SendKeys(keyword);
        }

        public void waitForSearchingCountry(String country)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(8)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions
            .ElementIsVisible(By.LinkText(country)));
            driver.FindElement(By.LinkText(country)).Click();
        }

        public void purchase()
        {
            checkbox.Click();
            purchaseButton.Click();
        }

        public By getMessage()
        {
            return success;
        }
    }
}
