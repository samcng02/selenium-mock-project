using APITesting.Services;
using FluentAssertions;
using NUnit.Allure.Core;

namespace MockProject_Nguyetct1.Test
{
    [TestFixture]
    [AllureNUnit]
    public class AdminAuthenAPITest
    {
        [Test, Description("TC01: Test admin authenticate pass")]
        public void TC01USERREGISTERPASS()
        {
            var result = AdminService.AdminAuthen();
            result.Should().NotBeNull();
        }

    }
}
