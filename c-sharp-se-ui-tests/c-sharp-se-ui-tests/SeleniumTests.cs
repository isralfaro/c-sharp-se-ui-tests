using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace c_sharp_se_ui_tests
{
    public class Tests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            // Get driver folder path dynamically
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            // Create ChromeDriver object (Executes tests on Google Chrome)
            driver = new ChromeDriver(path + @"\drivers\");
        }

        [Test]
        public void VerifyLogo()
        {
            driver.Navigate().GoToUrl("https://www.browserstack.com/");

            Assert.IsTrue(driver.FindElement(By.ClassName("bstack-mm-logo")).Displayed);
        }

        [Test]
        public void VerifyMenuItemCount()
        {
            ReadOnlyCollection<IWebElement> menuItem = driver.FindElements(By.XPath("//div[@class='bstack-mm-nav']//div[contains(@class, 'bstack-mm-li')]"));

            Assert.AreEqual(6, menuItem.Count());
        }

        [Test]
        public void VerifyPricingPage() 
        {
            driver.Navigate().GoToUrl("https://browserstack.com/pricing");

            IWebElement contactUsPageHeader = driver.FindElement(By.TagName("h1"));

            Assert.IsTrue(contactUsPageHeader.Text.Contains("Real device cloud of 20,000 + real iOS & Android devices, instantly accessible"));
        }

        [OneTimeTearDown]
        public void TearDown() 
        {
            driver.Quit();
        }
    }
}