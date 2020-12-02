using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notentool.Models.Entities;

namespace Notentool.Services
{
    public interface ISemestersService
    {
        /// <summary>
        /// Ruft alle Semester aus der Datenbank für eine Benutzer ab
        /// </summary>
        /// <param name="user">Der Benutzer für den die Semester abgerufen werden sollen</param>
        /// <returns><c>IEnumerable</c></returns>
        /// <author>Gion Rubitschung</author>
        IEnumerable<Semester> GetAllSemesters(Benutzeraccount user);

        /// <summary>
        /// Ruft ein Semester nach seiner Id in der Datenbank ab
        /// </summary>
        /// <param name="id">Die id des Semesters</param>
        /// <returns><c>Semester</c></returns>
        /// <author>Gion Rubitschung</author>
        Task<Semester> GetSemesterByIdAsync(int id);

        /// <summary>
        /// Erstellt ein neues Semester in der Datenbank
        /// </summary>
        /// <param name="semester">Das Semester, welches in der Datenbank erstellt werden soll</param>
        /// <param name="user">Der Benutzer in der das Semester erstellt werden soll</param>
        /// <author>Gion Rubitschung</author>
        Task CreateSemesterAsync(Semester semester, Benutzeraccount user);

        /// <summary>
        /// Aktualisiert ein Semester in der Datenbank
        /// </summary>
        /// <param name="semester">Das Semester, welches in der Datenbank aktualisiert werden soll</param>
        /// <param name="user">Der Benutzer in der das Semester aktualisiert werden soll. Wird mitgeben um zu überprüfen ob das Semester einen Benutzer hinterlegt hat</param>
        /// <author>Gion Rubitschung</author>
        Task UpdateSemesterAsync(Semester semester, Benutzeraccount user);

        /// <summary>
        /// Löscht ein Semester in der Datenbank
        /// </summary>
        /// <param name="id">Die id des Semesters, welches gelöscht werden soll</param>
        /// <author>Gion Rubitschung</author>
        Task DeleteSemesterAsync(int id);

        /// <summary>
        /// Überprüft ob ein Semester in der Datenbank existiert
        /// </summary>
        /// <param name="id">Die id des Semesters</param>
        /// <returns><c>bool</c></returns>
        /// <author>Gion Rubitschung</author>
        bool SemesterExists(int id);
    }
}
