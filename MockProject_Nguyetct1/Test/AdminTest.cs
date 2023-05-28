using AutomationCore.Reports;
using FluentAssertions;
using MockProject_Nguyetct1.Models;
using MockProject_Nguyetct1.Page;
using NUnit.Allure.Core;

namespace MockProject_Nguyetct1.Test
{
    /// <summary>
    /// Test Admin page
    /// </summary>
    [TestFixture]
    [TestFixtureSource(typeof(AdminPage), nameof(AdminPage.GetJobs))]
    [AllureNUnit]

    public class AdminTest : BaseTest
    {
        private LoginPage loginPage;
        private AdminPage adminPage;
        private LogoutPage logoutPage;
        private ReportManagement report;
        private string? message;
        private Job _job;
        public AdminTest(Job job)
        {
            _job = job;

        }
        [SetUp]
        public void TestSetup()
        {
            //Init object LoginPage
            loginPage = new LoginPage(driver);

            //Login:
            loginPage.Login();

            //Init object LoginPage
            adminPage = new AdminPage(driver);

            //Init object LogoutPage
            logoutPage = new LogoutPage(driver);

            //Init report:
            report = new ReportManagement();

        }

        [Test, Description("TC01: Add job title pass")]
        public void TC01ADDJOBTITLEPASS()
        {
            //Action with admin page: click button, input data:
            adminPage.ClickAdminBtn();
            adminPage.ClickJobBtn();
            adminPage.ClickJobTitleBtn();
            adminPage.ClickAddJobTitleBtn();
            adminPage.InputJobTitle(_job.JobTitle ?? "");
            adminPage.InputJobDescription(_job.JobDescription ?? "");
            adminPage.ClickSaveJob();

            //Verify: Get message -> verify
            message = adminPage.GetMessageAdminPage();
            message.Should().Be("Success");
        }

        [Test, Description("TC02: Update job title pass")]
        public void TC02UPDATEJOBTITLEPASS()
        {
            adminPage.ClickAdminBtn();
            adminPage.ClickJobBtn();
            adminPage.ClickJobTitleBtn();
            //Update Job

            adminPage.UpdateJobs(_job);
            //Verify: Get message -> verify
            message = adminPage.GetMessageAdminPage();
            message.Should().Be("Success");


        }

        [Test, TestCaseSource(typeof(AdminPage), nameof(AdminPage.GetJobsUpdate)), Description("TC03: Delete job title pass")]
        public void TC02DELETEJOBTITLEPASS(Job job)
        {
            adminPage.ClickAdminBtn();
            adminPage.ClickJobBtn();
            adminPage.ClickJobTitleBtn();
            Thread.Sleep(1000);
            adminPage.DeleteJobs(job);

            //Verify: Get message -> verify
            message = adminPage.GetMessageAdminPage();
            message.Should().Be("Success");
        }

        [TearDown]
        public void TestTearDown()
        {
            //ScreenShot for cases fail:
            report.ScreenShotImageError(driver, message);
            //Logout:
            logoutPage.ClickUserDropdownBtn();
            logoutPage.ClickLogoutBtn();
        }
    }
}
