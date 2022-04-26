using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using WebApplicationAutomation.pageObjects;
using WebApplicationAutomation.utilities;

namespace WebApplicationAutomation.tests
{
    public class UnitTest1 : Base
    {

        [Test, TestCaseSource("AddTestDataConfig")]
        // will run twice using different parameters
        /* [TestCase("rahulshettyacademy", "learning")] // define globally 1st test
        [TestCase("rahulshetty", "learning")] // 2nd test */
        public void TestCheckOut(String username, String password, String[] expectedOptions)
        {
            String[] actualProducts = new String[2];

            LoginPage loginPage = new LoginPage(getDriver());

            ProductsPage productsPage = loginPage.validLogin(username, password);
            productsPage.waitForCheckOutDisplay();

            IList<IWebElement> cards = productsPage.getCards();

            foreach (IWebElement card in cards)
            {
                if (expectedOptions.Contains(card.FindElement(productsPage.getCardTitle()).Text))
                {
                    card.FindElement(productsPage.addToCardButton()).Click();
                }
            }

            CheckoutPage checkoutPage = productsPage.checkOut();

            IList<IWebElement> products = checkoutPage.getCards();
            for (int i = 0; i < products.Count; i++)
            {
                actualProducts[i] = products[i].Text;
            }

            Assert.AreEqual(expectedOptions, actualProducts);

            ConfirmPage confirmPage = checkoutPage.checkOut();

            confirmPage.searchCountry("au");
            confirmPage.waitForSearchingCountry("Austria");

            confirmPage.purchase();

            String message = driver.FindElement(confirmPage.getMessage()).Text;

            StringAssert.Contains("Success", message);
        }

        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("password"), getDataParser().extractDataArray("products"));
            yield return new TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("password"), getDataParser().extractDataArray("products"));
            yield return new TestCaseData(getDataParser().extractData("username_wrong"), getDataParser().extractData("password_wrong"), getDataParser().extractDataArray("products"));

        }
    }
}
