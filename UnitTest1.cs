using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections;

namespace SafeSendAssignment
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://returns-cpa.safesendreturns.com/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void GetTop3EsignedClientIDs()
        {
            string emailAddress = "txtUsername";
            string password = "txtPassword";
            string signIn = "btnLogin"; 
            string deliveryReturns = "Delivered Returns"; 
            string filter = "//span[@title=\"Toggle dropdown menu\"]";
            string clearFilter = "Clear Filter";
            string statusFilter = "//div[@class=\"Select-placeholder\"]/span";

            string esign = "//td[@title = 'E - Signed']";

            string clientId = "//tbody/tr/td[3]/div";

            driver.FindElement(By.Id(emailAddress)).SendKeys("test170423@yopmail.com");
            driver.FindElement(By.Id(password)).SendKeys("Test@1234");
            driver.FindElement(By.Id(signIn)).Click();
            driver.FindElement(By.LinkText(deliveryReturns)).Click();
            driver.FindElement(By.XPath(filter)).Click();
            driver.FindElement(By.LinkText(clearFilter)).Click();
            driver.FindElement(By.XPath(statusFilter)).Click();
            driver.FindElement(By.XPath(esign)).Click();
            IList ClientIDList = driver.FindElements(By.XPath(clientId));
            int i = 0;

            foreach (var item in ClientIDList)
            {
                if (i < 3)
                {
                    TestContext.Progress.WriteLine(item);
                    i++;
                }
            }
        }
    }
}