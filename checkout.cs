using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Checkout
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheCheckoutTest()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=common/home");
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("input-email")).Click();
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("testabc123@test.com");
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("abc12345");
            driver.FindElement(By.Id("input-password")).SendKeys(Keys.Enter);
            driver.FindElement(By.LinkText("Show All Laptops & Notebooks")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/div[4]/div/div/div[2]/div[2]/button/span")).Click();
            driver.FindElement(By.Id("button-cart")).Click();
            driver.FindElement(By.Id("cart-total")).Click();
            driver.FindElement(By.XPath("//div[@id='cart']/ul/li[2]/div/p/a/strong")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'Checkout')]")).Click();
            driver.FindElement(By.Id("input-payment-firstname")).Click();
            driver.FindElement(By.Id("input-payment-firstname")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=input-payment-firstname | ]]
            driver.FindElement(By.Id("input-payment-firstname")).Clear();
            driver.FindElement(By.Id("input-payment-firstname")).SendKeys("Test");
            driver.FindElement(By.Id("input-payment-lastname")).Click();
            driver.FindElement(By.Id("input-payment-lastname")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=input-payment-lastname | ]]
            driver.FindElement(By.Id("input-payment-lastname")).Clear();
            driver.FindElement(By.Id("input-payment-lastname")).SendKeys("User");
            driver.FindElement(By.Id("input-payment-company")).Click();
            driver.FindElement(By.Id("input-payment-company")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=input-payment-company | ]]
            driver.FindElement(By.Id("input-payment-address-1")).Click();
            driver.FindElement(By.Id("input-payment-address-1")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=input-payment-address-1 | ]]
            driver.FindElement(By.Id("input-payment-address-1")).Clear();
            driver.FindElement(By.Id("input-payment-address-1")).SendKeys("Adresa");
            driver.FindElement(By.Id("input-payment-city")).Click();
            driver.FindElement(By.Id("input-payment-city")).Clear();
            driver.FindElement(By.Id("input-payment-city")).SendKeys("Osijek");
            driver.FindElement(By.Id("input-payment-postcode")).Click();
            driver.FindElement(By.Id("input-payment-postcode")).Clear();
            driver.FindElement(By.Id("input-payment-postcode")).SendKeys("31000");
            driver.FindElement(By.Id("payment-new")).Click();
            driver.FindElement(By.Id("input-payment-zone")).Click();
            new SelectElement(driver.FindElement(By.Id("input-payment-zone"))).SelectByText("Conwy");
            driver.FindElement(By.Id("input-payment-zone")).Click();
            driver.FindElement(By.Id("button-payment-address")).Click();
            driver.FindElement(By.Id("button-shipping-address")).Click();
            driver.FindElement(By.Name("comment")).Click();
            driver.FindElement(By.Name("comment")).Clear();
            driver.FindElement(By.Name("comment")).SendKeys("Komentar");
            driver.FindElement(By.Id("button-shipping-method")).Click();
            driver.FindElement(By.Name("agree")).Click();
            driver.FindElement(By.Id("button-payment-method")).Click();
            driver.FindElement(By.Id("button-confirm")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
