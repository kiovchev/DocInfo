using DocInfo.Data.Models;
using DocInfo.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace DocInfo.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public async Task CreateUserShouldReturnIdentityResult()
        {
            var mgr = SetupAndReturnUserManager();
            var userService = new UserService(mgr.Object);

            var actualResult = await userService.CreateUserAsync("pesho1", "123456", "pesho@pesho.bg");
            var expectedResult = IdentityResult.Success;

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async Task GetUserByNameShouldReturnsNotNull()
        {
            var mgr = SetupAndReturnUserManager();
            var userService = new UserService(mgr.Object);

            var actualResult = await userService.GetUserByName(It.IsAny<string>());

            Assert.NotNull(actualResult);
        }

        [Fact]
        public async Task HaveUserShouldReturnTestId()
        {
            var mgr = SetupAndReturnUserManager();
            var userService = new UserService(mgr.Object);

            var actualResult = await userService.HaveUser("test");
            var expectedResult = "testId";

            Assert.NotNull(actualResult);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async Task CheckPasswordShouldReturnTrue()
        {
            var mgr = SetupAndReturnUserManager();
            var userService = new UserService(mgr.Object);

            var actualResult = await userService.CheckPassword("test", "testPassword");

            Assert.True(actualResult);
        }

        private Mock<UserManager<ApplicationUser>> SetupAndReturnUserManager() 
        {
            var store = new Mock<IUserStore<ApplicationUser>>();
            var mgr = new Mock<UserManager<ApplicationUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<ApplicationUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<ApplicationUser>());

            mgr.Setup(x => x.DeleteAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.UpdateAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(true);
            mgr.Setup(x => x.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(new ApplicationUser { Email = "test@test.test", UserName = "test", Id = "testId" });

            return mgr;
        }
    }
}
