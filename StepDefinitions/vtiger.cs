using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowExample.StepDefinitions
{
    [Binding]
    internal class vtiger
    {
        public IWebDriver driver;
        [Given(@"User is on Login Page")]
        public void GivenUserIsOnLoginPage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:100/");
            driver.Manage().Window.Maximize();
        }

        [Then(@"Enter valid credential")]
        public void ThenEnterValidCredential()
        {
            driver.FindElement(By.Name("user_name")).SendKeys("admin");
            driver.FindElement(By.Name("user_password")).SendKeys("admin");
        }

        [Then(@"click on Login button")]
        public void ThenClickOnLoginButton()
        {
            driver.FindElement(By.Name("Login")).Click();
        }

        [Then(@"verify home page")]
        public void ThenVerifyHomePage()
        {
            Assert.AreEqual(true,driver.FindElement(By.XPath("//a[text()='Home']")).Displayed);
        }

        [Then(@"close the browser")]
        public void ThenCloseTheBrowser()
        {
            driver.Close();
        }


    }
}
