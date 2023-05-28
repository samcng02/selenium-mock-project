using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationWebDriver.Extension
{
    /// <summary>
    /// Where extension functions are located for for test project
    /// Ex: MaximizeWindow,Go, GetWebElement...
    /// </summary>
    public static class AutomationExtensions
    {
        /// <summary>
        /// Set full size windown.
        /// </summary>
        /// <param name="driver"></param>
        /// 
        public static void MaximizeWindow(this IWebDriver driver)
        {
            driver.Manage().Window.Maximize();

        }

        /// <summary>
        /// Navigate new page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="url"></param>
        public static void Go(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Get a element
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static IWebElement GetWebElement(this IWebDriver driver, By by, int timeout = 30)
        {
            //Implicit Wait:
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
            var element = driver.FindElement(by);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            return element;
        }

        /// <summary>
        /// Get a element using javascript
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>

        public static IWebElement GetWebElementUsingJS(this IWebDriver driver, IJavaScriptExecutor executor, string locator)
        {
            var element = executor.ExecuteAsyncScript(
             "var callback = arguments[arguments.length - 1];" +
             "setTimeout(function() {" +
             $"  var element = {locator};" +
             "  callback(element);" +
            "},5000);"
            );

            var elementParse = ((IWebElement)element);
            return elementParse;
        }

        /// <summary>
        /// Excute a event (examples: button, <a/> tag, tag link...)
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        public static void Click(this IWebDriver driver, By locator)
        {
            driver.GetWebElement(locator).Click();
        }

        /// <summary>
        /// Input data
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="text"></param>
        public static void TypeText(this IWebDriver driver, By locator, string text)
        {
            driver.GetWebElement(locator).SendKeys(text);
        }

        /// <summary>
        /// Input value to Input frame using javascript
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="javaScriptExecutor"></param>
        /// <param name="locator"></param>
        /// <param name="text"></param>
        public static void TypeTextUseJS(this IWebDriver driver, IJavaScriptExecutor javaScriptExecutor, string locator, string text)
        {
            var findElement = driver.GetWebElementUsingJS(javaScriptExecutor, locator);
            findElement.SendKeys(text);
        }

        /// <summary>
        ///Clear value in Input frame. 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        public static void Clear(this IWebDriver driver, By locator)
        {
            driver.GetWebElement(locator).SendKeys(Keys.Control + "a");
            driver.GetWebElement(locator).SendKeys(Keys.Clear);
        }

        /// <summary>
        /// Get message in website
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <returns></returns>
        public static string GetMessage(this IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement result = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            var message = result.Text;
            return message;
        }



        public static void WaitUntilLocatorInVisible(this IWebDriver driver, By loadingLocator, int timeoutInSeconds = 20)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(loadingLocator));
        }
        public static void WaitUntilLocatorVisible(this IWebDriver driver, By locator, int timeoutInSeconds = 20)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

    }
}
