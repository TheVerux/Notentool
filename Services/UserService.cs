using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Notentool.Models.Entities;

namespace Notentool.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<Benutzeraccount> _userManager;

        public UserService(UserManager<Benutzeraccount> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Benutzeraccount> GetOrCreateUser(ClaimsPrincipal user)
        {
            // Todo: if user doesn't exist, create new user
            return await _userManager.GetUserAsync(user);
        }
    }
}