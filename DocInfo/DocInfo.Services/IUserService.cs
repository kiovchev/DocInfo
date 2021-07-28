using DocInfo.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DocInfo.Services
{
    public interface IUserService
    {
        Task<string> HaveUser(string username);

        Task<bool> CheckPassword(string username, string password);

        Task<IdentityResult> CreateUserAsync(string name, string password, string email);

        Task<ApplicationUser> GetUserByName(string name);
    }
}
