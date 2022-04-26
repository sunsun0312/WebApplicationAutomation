using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace WebApplicationAutomation.pageObjects
{
    public class ProductsPage
    {
        //new WebDriverWait(driver, TimeSpan.FromSeconds(8)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions
        //        .ElementIsVisible(By.PartialLinkText("Checkout")));

        //    IList<IWebElement> cards = driver.FindElements(By.CssSelector("app-card"));

        private IWebDriver driver;
        By cardTitle = By.CssSelector("h4.card-title");

        By addToCart = By.CssSelector("button.btn");

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;

        //driver.FindElement(By.PartialLinkText("Checkout")).Click();
        [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        private IWebElement checkoutButton;

        public void waitForCheckOutDisplay()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(8)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                    .ElementIsVisible(By.PartialLinkText("Checkout")));
        }

        public IList<IWebElement> getCards()
        {
            return cards;
        }


        public By getCardTitle()
        {
            return cardTitle;
        }

        public By addToCardButton()
        {
            return addToCart;
        }
        public CheckoutPage checkOut()
        {
            checkoutButton.Click();
            return new CheckoutPage(driver);
        }
    }
}
