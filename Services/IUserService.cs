using System.Security.Claims;
using System.Threading.Tasks;
using Notentool.Models.Entities;

namespace Notentool.Services
{
    /// <summary>
    /// Interface für den Datenbankzugriff der Benutzer
    /// Autoren: Gion Rubitschung und Noah Siroh Schönthal
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Ruft den aktuellen Benutzer aus der Datenbank ab. Falls dieser nicht existiert wird ein neuer Benutzer erstellt
        /// </summary>
        /// <param name="claims">Der aktuelle Benutzer gespeichert in ClaimsPrincipals</param>
        /// <returns></returns>
        Task<Benutzeraccount> GetOrCreateUser(ClaimsPrincipal claims);
    }
}