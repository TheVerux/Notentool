using System.Security.Claims;
using System.Threading.Tasks;
using Notentool.Models.Entities;

namespace Notentool.Services
{
    public interface IUserService
    {
        Task<Benutzeraccount> GetOrCreateUser(ClaimsPrincipal user);
    }
}