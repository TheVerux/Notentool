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
            /*var newUser = new Benutzeraccount()
            {
                UserName = user.Identity.Name,
                Email = user.Identity.Name
            };
            await _userManager.CreateAsync(newUser);
            await _userManager.AddClaimsAsync(newUser, user.Claims);*/
            return await _userManager.GetUserAsync(user);
        }
    }
}