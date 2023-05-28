using AutomationCore.Reports;
using MockProject_Nguyetct1.Page;
using NUnit.Allure.Core;
using OpenQA.Selenium;

namespace MockProject_Nguyetct1.Test
{
    [TestFixture]
    [AllureNUnit]
    public class LoginTestCase : BaseTest
    {
        private LoginPage loginPage;
        private LogoutPage logoutPage;
        private ReportManagement report;

        private bool isFind;
        private readonly string failMessage = "Login Fail";
        private IJavaScriptExecutor executor;

        [SetUp]
        public void Setup()
        {
            //Init object LoginPage
            loginPage = new LoginPage(driver);

            //Go to Login page:
            loginPage.GoToLoginPge();

            isFind = false;

            //Init JavascriptExecutor
            executor = (IJavaScriptExecutor)driver;

            //Init object LogoutPage
            logoutPage = new LogoutPage(driver);

            //Init report:
            report = new ReportManagement();

        }

        [Test, Description("Login with case pass. Logout after login success")]
        public void TC01LOGINPASS()
        {
            //Input data:
            //loginPage.InputUserName(username);
            loginPage.InputUserNameUsingJS(executor, loginPage.username);
            loginPage.InputPasswordeUsingJS(executor, loginPage.password);

            //Click login button to login:
            loginPage.ClickLoginBtn();

            //Verify:
            //Find Dashboard text (true ->find or false ->not find)
            isFind = loginPage.FindText(loginPage.dashboardTxt);
            Assert.True(isFind);

            //Logout:
            logoutPage.ClickUserDropdownBtn();
            logoutPage.ClickLogoutBtn();

        }

        [Test, Description("Login with case fail-Invalid username or passwork")]
        public void TC02LOGINFAILINVALIDACCOUNT()
        {
            loginPage.InputUserName(loginPage.usernameInvalid);
            loginPage.InputPassWord(loginPage.password);
            loginPage.ClickLoginBtn();

            //Verify:
            //Find notice "Invalid" text (true ->find or false ->not find)
            isFind = loginPage.FindText(loginPage.InvalidTxt);
            Assert.True(isFind);
        }

        [Test, Description("Login in with case fail")]
        public void TC03LOGINFAILINVALIDACCOUNT()
        {
            loginPage.InputUserName(loginPage.usernameInvalid);
            loginPage.InputPassWord(loginPage.password);
            loginPage.ClickLoginBtn();

            //Verify:
            //Find Dashboard text (true ->find or false ->not find)
            isFind = loginPage.FindText(loginPage.dashboardTxt);
            Assert.True(isFind);
        }

        [TearDown]
        public void TearDown()
        {
            //ScreenShot for cases fail:
            report.ScreenShotImageError(driver, failMessage);

        }
    }
}
