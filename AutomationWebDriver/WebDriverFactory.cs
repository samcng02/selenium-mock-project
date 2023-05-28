using AutomationWebDriver.Enums;
using AutomationWebDriver.Extension;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace AutomationWebDriver
{
    /// <summary>
    /// Place to create WebDrivers.
    /// Ex: ChromeDriver, FirefoxDriver, EdgeDriver...
    /// </summary>
    public class WebDriverFactory
    {
        /// <summary>
        /// The method will open browser following a browser type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static IWebDriver? OpenBrowser(BrowserTypes type = BrowserTypes.CHROME)
        {
            //Declare driver:
            IWebDriver? driver;
            switch (type)
            {
                case BrowserTypes.CHROME:
                    driver = new ChromeDriver("Drivers/Chrome");
                    break;
                case BrowserTypes.FIREFOX:
                    driver = new FirefoxDriver("Drivers/FireFox");
                    break;
                default:
                    throw new Exception("Browser type is not exist");
            }
            driver?.MaximizeWindow();

            return driver;
        }
    }
}