using AutomationCore.Helpers;
using AutomationWebDriver;
using AutomationWebDriver.Enums;
using OpenQA.Selenium;

namespace MockProject_Nguyetct1.Test
{
    /// <summary>
    /// Where the foundation code for the test case
    /// </summary>
    [TestFixture]
    public class BaseTest
    {
        //Declare driver:
        protected static IWebDriver driver;

        /// <summary>
        /// The method use to ontime init for browser, driver ...
        /// </summary>

        [OneTimeSetUp]
        public void SetUp()
        {
            //Init browser, Open browser, read config:
            var browser = ConfigurationHelper.GetValue<string>("browser");
            Enum.TryParse(browser, out BrowserTypes browsersType);
            driver = WebDriverFactory.OpenBrowser(browsersType);
        }

        /// <summary>
        /// The method use to onetime close variables was inited at AssemblyInitialize method.
        /// Ex: Browser, driver ...
        /// </summary>
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}
