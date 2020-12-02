using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notentool.Models.Entities;

namespace Notentool.Services
{
    /// <summary>
    /// Interface für den Datenbankzugriff der Noten
    /// Autoren: Gion Rubitschung und Noah Siroh Schönthal
    /// </summary>
    public interface IGradesService
    {
        /// <summary>
        /// Ruft alle Noten aus der Datenbank für ein Semester ab
        /// </summary>
        /// <param name="modulId">Die id des Moduls in der die Note abgerufen werden sollen</param>
        /// <returns>Liste der Noten als <c>IEnumerable</c></returns>
        IEnumerable<Grade> GetAllGrades(int modulId);

        /// <summary>
        /// Ruft eine Note nach seiner Id in der Datenbank ab
        /// </summary>
        /// <param name="id">Die id der Note</param>
        /// <returns>Note als <c>Grade</c></returns>
        Task<Grade> GetGradeByIdAsync(int id);

        /// <summary>
        /// Erstellt eine neue Note in der Datenbank
        /// </summary>
        /// <param name="grade">Die Note, welche in der Datenbank erstellt werden soll</param>
        /// <param name="modul">Das Modul in der die Note erstellt werden soll</param>
        Task CreateGradeAsync(Grade grade, Modul modul);

        /// <summary>
        /// Aktualisiert eine Note in der Datenbank
        /// </summary>
        /// <param name="grade">Die Note, welche in der Datenbank aktualisiert werden soll</param>
        /// <param name="modul">Das Modul in der die Note erstellt werden soll. Wird mitgeben um zu überprüfen ob die Note ein Modul hinterlegt hat</param>
        Task UpdateGradeAsync(Grade grade, Modul modul);

        /// <summary>
        /// Löscht eine Note in der Datenbank
        /// </summary>
        /// <param name="id">Die id der Note, welche gelöscht werden soll</param>
        Task DeleteGradeAsync(int id);

        /// <summary>
        /// Überprüft ob eine Note in der Datenbank existiert
        /// </summary>
        /// <param name="id">Die id der Note</param>
        /// <returns>Existenz der Note als <c>bool</c></returns>
        bool GradeExists(int id);
    }
}
