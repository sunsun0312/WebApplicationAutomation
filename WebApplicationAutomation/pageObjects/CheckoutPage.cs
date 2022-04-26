using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WebApplicationAutomation.pageObjects
{
    public class CheckoutPage
    {
        private IWebDriver driver;

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //driver.FindElements(By.CssSelector("h4 a"))
        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkoutCards;

        //driver.FindElement(By.CssSelector(".btn-success")).Click();
        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement checkoutButton;

        public IList<IWebElement> getCards()
        {
            return checkoutCards;
        }

        public ConfirmPage checkOut()
        {
            checkoutButton.Click();
            return new ConfirmPage(driver);
        }
    }
}
