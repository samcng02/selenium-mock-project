using OpenQA.Selenium;

namespace AutomationCore.Reports
{
    /// <summary>
    /// Report interface
    /// </summary>
    public interface IReport
    {
        /// <summary>
        /// The method use to capture screenshot test cases faild: 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="massage"></param>
        public void ScreenShotImageError(IWebDriver driver, string massage);
    }
}
