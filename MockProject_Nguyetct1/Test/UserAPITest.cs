using APITesting.Controllers;
using FluentAssertions;
using NUnit.Allure.Core;

namespace MockProject_Nguyetct1.Test
{
    [TestFixture]
    [AllureNUnit]
    public class UserAPITest
    {
        [Test, Description("TC01: Test user register account pass")]
        public void TC01USERREGISTERPASS()
        {
            var result = UserService.UserRegister();
            result.Should().Be(200);
        }

        [Test]
        public void TC02GETALLUSERSPASS()
        {
            var result = UserService.GetAllUsers();
            result.Should().NotBeNull();
        }
    }
}
