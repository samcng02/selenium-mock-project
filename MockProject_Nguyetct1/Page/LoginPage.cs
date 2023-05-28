using AutomationCore.Helpers;
using AutomationWebDriver.Extension;
using OpenQA.Selenium;

namespace MockProject_Nguyetct1.Page
{
    /// <summary>
    /// Where the foundation code for the Login testing
    /// </summary>
    public class LoginPage : BasePage
    {
        IJavaScriptExecutor executor;
        /// <summary>
        /// Contrutor inherited driver from BasePage's driver.
        /// </summary>
        /// <param name="driver"></param>
        public LoginPage(IWebDriver driver) : base(driver)
        {
            executor = (IJavaScriptExecutor)driver;
        }

        #region Declare and init loactors:
        private By usernameInput = By.CssSelector("input[name='username']");
        private By passwordInput = By.CssSelector("input[name='password']");
        private By loginBtn = By.CssSelector("button[type='submit']");
        public By dashboardTxt = By.XPath("//h6[text()='Dashboard']");
        public By InvalidTxt = By.XPath("//p[text()='Invalid credentials']");

        // Locator by JS:
        private string usernameInputJS = "document.getElementsByClassName('oxd-form-row')[0].children[0].children[1].children[0]";
        private string passwordInputJS = "document.getElementsByClassName('oxd-form-row')[1].children[0].children[1].children[0]";

        public string username = ConfigurationHelper.GetValue<string>("username");
        public string usernameInvalid = ConfigurationHelper.GetValue<string>("usernameinvalid");

        public string password = ConfigurationHelper.GetValue<string>("password");
        #endregion



        /// <summary>
        /// The method go to Login page.
        /// </summary>
        public void GoToLoginPge()
        {
            // Get url from config file
            var url = ConfigurationHelper.GetValue<string>("url");
            //Go to Login page:
            driver.Go(url);
        }

        /// <summary>
        /// The method is input username data.
        /// </summary>
        /// <param name="username"></param>
        public void InputUserName(string username)
        {
            driver.TypeText(usernameInput, username);
        }

        /// <summary>
        /// The method is input username data with Js.
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="username"></param>
        public void InputUserNameUsingJS(IJavaScriptExecutor executor, string username)
        {
            driver.TypeTextUseJS(executor, usernameInputJS, username);
        }

        /// <summary>
        /// The method is input password data with Js.
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="username"></param>
        public void InputPasswordeUsingJS(IJavaScriptExecutor executor, string username)
        {
            driver.TypeTextUseJS(executor, passwordInputJS, password);
        }

        /// <summary>
        /// The method is input password data.
        /// </summary>
        /// <param name="password"></param>
        public void InputPassWord(string password)
        {
            driver.TypeText(passwordInput, password);
        }

        /// <summary>
        /// The method is click login button.
        /// </summary>
        public void ClickLoginBtn()
        {
            driver.Click(loginBtn);
        }

        /// <summary>
        /// The method use to login.
        /// </summary>

        public void Login()
        {
            GoToLoginPge();
            InputUserName(username);
            InputPassWord(password);
            ClickLoginBtn();

        }
    }
}
