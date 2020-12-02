using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notentool.Models.Entities
{
    /// <summary>
    /// Klasse für Semester
    /// Autoren: Gion Rubitschung und Noah Siroh Schönthal
    /// </summary>
	public class Semester
	{
        public Semester()
        {
			Moduls = new HashSet<Modul>();
        }

		/// <summary>
		/// Die Id des Semesters
		/// </summary>
		public int SemesterID { get; set; }

		/// <summary>
		/// Der Name des Semesters
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Der Benutzer zu welchem das Semester gehört
		/// </summary>
		public virtual Benutzeraccount Benutzeraccount { get; set; }

        /// <summary>
        /// Die Id des zugehörigen Benutzers
        /// </summary>
		public string BenutzeraccountId { get; set; }

		/// <summary>
		/// Die Module des Semesters
		/// </summary>
		public virtual ICollection<Modul> Moduls { get; set; }
	}
}
