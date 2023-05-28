using AutomationWebDriver.Extension;
using OpenQA.Selenium;
namespace MockProject_Nguyetct1.Page
{
    /// <summary>
    /// Where the foundation code for the test project
    /// </summary>
    public class BasePage
    {
        //Declare diver:
        protected IWebDriver driver;

        /// <summary>
        /// Contructor BagePage
        /// </summary>
        /// <param name="driver"></param>
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// The method find a text in website. If found then return true else return false.
        /// </summary>
        /// <param name="by"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public bool FindText(By by, int timeout = 5)
        {

            var getElement = driver.GetWebElement(by, timeout);
            if (getElement is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
