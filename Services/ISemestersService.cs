using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notentool.Models.Entities;

namespace Notentool.Services
{
    /// <summary>
    /// Interface für den Datenbankzugriff der Semester
    /// Autoren: Gion Rubitschung und Noah Siroh Schönthal
    /// </summary>
    public interface ISemestersService
    {
        /// <summary>
        /// Ruft alle Semester aus der Datenbank für eine Benutzer ab
        /// </summary>
        /// <param name="user">Der Benutzer für den die Semester abgerufen werden sollen</param>
        /// <returns>Liste der Semester als <c>IEnumerable</c></returns>
        IEnumerable<Semester> GetAllSemesters(Benutzeraccount user);

        /// <summary>
        /// Ruft ein Semester nach seiner Id in der Datenbank ab
        /// </summary>
        /// <param name="id">Die id des Semesters</param>
        /// <returns>Semester als <c>Semester</c></returns>
        Task<Semester> GetSemesterByIdAsync(int id);

        /// <summary>
        /// Erstellt ein neues Semester in der Datenbank
        /// </summary>
        /// <param name="semester">Das Semester, welches in der Datenbank erstellt werden soll</param>
        /// <param name="user">Der Benutzer in der das Semester erstellt werden soll</param>
        Task CreateSemesterAsync(Semester semester, Benutzeraccount user);

        /// <summary>
        /// Aktualisiert ein Semester in der Datenbank
        /// </summary>
        /// <param name="semester">Das Semester, welches in der Datenbank aktualisiert werden soll</param>
        /// <param name="user">Der Benutzer in der das Semester aktualisiert werden soll. Wird mitgeben um zu überprüfen ob das Semester einen Benutzer hinterlegt hat</param>
        Task UpdateSemesterAsync(Semester semester, Benutzeraccount user);

        /// <summary>
        /// Löscht ein Semester in der Datenbank
        /// </summary>
        /// <param name="id">Die id des Semesters, welches gelöscht werden soll</param>
        Task DeleteSemesterAsync(int id);

        /// <summary>
        /// Überprüft ob ein Semester in der Datenbank existiert
        /// </summary>
        /// <param name="id">Die id des Semesters</param>
        /// <returns>Existenz des Semesters als <c>bool</c></returns>
        bool SemesterExists(int id);
    }
}
