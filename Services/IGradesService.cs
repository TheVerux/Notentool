using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notentool.Models.Entities;

namespace Notentool.Services
{
    public interface IGradesService
    {
        /// <summary>
        /// Ruft alle Noten aus der Datenbank für ein Semester ab
        /// </summary>
        /// <param name="modulId">Die id des Moduls in der die Note abgerufen werden sollen</param>
        /// <returns><c>IEnumerable</c></returns>
        /// <author>Gion Rubitschung</author>
        IEnumerable<Grade> GetAllGrades(int modulId);

        /// <summary>
        /// Ruft eine Note nach seiner Id in der Datenbank ab
        /// </summary>
        /// <param name="id">Die id der Note</param>
        /// <returns><c>Note</c></returns>
        /// <author>Gion Rubitschung</author>
        Task<Grade> GetGradeByIdAsync(int id);

        /// <summary>
        /// Erstellt eine neue Note in der Datenbank
        /// </summary>
        /// <param name="grade">Die Note, welche in der Datenbank erstellt werden soll</param>
        /// <param name="modul">Das Modul in der die Note erstellt werden soll</param>
        /// <author>Gion Rubitschung</author>
        Task CreateGradeAsync(Grade grade, Modul modul);

        /// <summary>
        /// Aktualisiert eine Note in der Datenbank
        /// </summary>
        /// <param name="grade">Die Note, welche in der Datenbank aktualisiert werden soll</param>
        /// <param name="modul">Das Modul in der die Note erstellt werden soll. Wird mitgeben um zu überprüfen ob die Note ein Modul hinterlegt hat</param>
        /// <author>Gion Rubitschung</author>
        Task UpdateGradeAsync(Grade grade, Modul modul);

        /// <summary>
        /// Löscht eine Note in der Datenbank
        /// </summary>
        /// <param name="id">Die id der Note, welche gelöscht werden soll</param>
        /// <author>Gion Rubitschung</author>
        Task DeleteGradeAsync(int id);

        /// <summary>
        /// Überprüft ob eine Note in der Datenbank existiert
        /// </summary>
        /// <param name="id">Die id der Note</param>
        /// <returns><c>bool</c></returns>
        /// <author>Gion Rubitschung</author>
        bool GradeExists(int id);
    }
}
