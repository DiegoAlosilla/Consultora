using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium.BaseClass
{
    public class BaseTest
    {

        public IWebDriver driver;

        [OneTimeSetUp]
        public void Open()
        {
            driver = new ChromeDriver
            {
                Url = "http://localhost:9001/"
            };
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void Close()
        {
            driver.Quit();
        }
    }
}
