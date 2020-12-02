using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notentool.Models.Entities
{
    /// <summary>
    /// Klasse für Module
    /// Autoren: Gion Rubitschung und Noah Siroh Schönthal
    /// </summary>
	public class Modul
	{
        public Modul()
        {
			Grades = new HashSet<Grade>();
        }

		/// <summary>
		/// Die Id des Moduls
		/// </summary>
		public int ModulID { get; set; }

		/// <summary>
		/// Der Name des Moduls
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Das Semester zu welchem das Modul gehört
		/// </summary>
		public virtual Semester Semester { get; set; }

		/// <summary>
		/// Die Id des zugehörigen Semesters
		/// </summary>
		public int SemesterID { get; set; }

		/// <summary>
		/// Die Noten des Moduls
		/// </summary>
		public virtual ICollection<Grade> Grades { get; set; }
	}
}
