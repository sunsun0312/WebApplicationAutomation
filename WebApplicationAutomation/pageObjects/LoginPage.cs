using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WebApplicationAutomation.pageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            // initiate objects in this page
            // it will identify all findsBy annotation and will initialize with the driver 
            PageFactory.InitElements(driver, this);
        }

        //PageObject factory
        // should not be public, if it is public, you are allowing anyone to change this variable from anywhere
        // and this findsby element will be failed
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        public IWebElement getUserName()
        {
            return username;
        }

        //driver.FindElement(By.CssSelector("input[type='password']"));

        //IList<IWebElement> radios = driver.FindElements(By.CssSelector(".customradio"));

        [FindsBy(How = How.CssSelector, Using = "input[type='password']")]
        private IWebElement password;

        public IWebElement getPassword()
        {
            return password;
        }



        //driver.FindElement(By.CssSelector("#terms")).Click();

        //driver.FindElement(By.CssSelector("#signInBtn")).Click();

        [FindsBy(How = How.CssSelector, Using = "#terms")]
        private IWebElement checkBox;

        [FindsBy(How = How.CssSelector, Using = "#signInBtn")]
        private IWebElement signInButton;

        public ProductsPage validLogin(String user, String pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            checkBox.Click();
            signInButton.Click();

            return new ProductsPage(driver);
        }
    }
}
