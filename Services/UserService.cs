using System;
using System.Linq;
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

        public async Task<Benutzeraccount> GetOrCreateUser(ClaimsPrincipal claims)
        {
            var userId = claims.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;
            if (userId == null)
            {
                userId = new Guid().ToString();
            }
            Benutzeraccount user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                user = new Benutzeraccount()
                {
                    Email = claims.Identity.Name,
                    UserName = claims.Identity.Name,
                    Id = userId
                };
                await _userManager.CreateAsync(user);
                await _userManager.AddClaimsAsync(user, claims.Claims);
                var users = _userManager.Users;
            }
            return user;
        }
    }
}