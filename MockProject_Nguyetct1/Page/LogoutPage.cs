using AutomationWebDriver.Extension;
using OpenQA.Selenium;

namespace MockProject_Nguyetct1.Page
{
    /// <summary>
    ///  Where the foundation code for the Logout testing
    /// </summary>
    public class LogoutPage : BasePage
    {
        /// <summary>
        /// Contrutor inherited driver from BasePage's driver.
        /// </summary>
        /// <param name="driver"></param>
        public LogoutPage(IWebDriver driver) : base(driver) { }

        #region Declare and init loactors:
        private By userDropdownBtn = By.XPath("//span[@class='oxd-userdropdown-tab' ]");
        private By logoutBtn = By.XPath("//a[text()= 'Logout' ]");
        #endregion

        /// <summary>
        /// The method use to click dropdown list button
        /// </summary>
        public void ClickUserDropdownBtn()
        {
            driver.Click(userDropdownBtn);
        }

        /// <summary>
        /// The method use to click logout button
        /// </summary>
        public void ClickLogoutBtn()
        {
            driver.Click(logoutBtn);
        }
    }
}
