using Allure.Net.Commons;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace AutomationCore.Reports
{
    public class ReportManagement : IReport
    {
        /// <summary>
        /// Screenshot tests case is failed
        /// </summary>
        /// <param name="driver"></param>
        public void ScreenShotImageError(IWebDriver driver, string message)
        {
            //Check test case is failed
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                //Convert WebDriver to TakesScreenshot and use GetScreenshot to capture screenshot
                //Finally, as result to byte array.

                byte[] content = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;

                //Add capture to report:
                AllureLifecycle.Instance.AddAttachment(message, "image/png", content);
            }
        }
    }
}
