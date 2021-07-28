namespace DocInfo.Services
{
    using DocInfo.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;

    public class UserService : IUserService 
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<bool> CheckPassword(string username, string password)
        {
            var user = await this.GetUserByName(username);
            var passwordValid = await this.userManager.CheckPasswordAsync(user, password);

            return passwordValid;
        }

        public async Task<IdentityResult> CreateUserAsync(string name, string password, string email)
        {
            var user = new ApplicationUser
            {
                Email = email,
                UserName = name
            };

            var result = await this.userManager.CreateAsync(user, password);

            return result;
        }

        public async Task<ApplicationUser> GetUserByName(string name)
        {
            var currentUser = await this.userManager.FindByNameAsync(name);

            return currentUser;
        }

        public async Task<string> HaveUser(string username)
        {
            var userId = string.Empty;
            var user = await this.userManager.FindByNameAsync(username);
            if (user != null)
            {
                userId = user.Id;
            }

            return userId;
        }
    }
}
