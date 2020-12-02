using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notentool.Models.Entities
{
    /// <summary>
    /// Klasse für Noten
    /// Autoren: Gion Rubitschung und Noah Siroh Schönthal
    /// </summary>
	public class Grade
	{
		/// <summary>
		/// Die Id der Note
		/// </summary>
		public int GradeID { get; set; }

		/// <summary>
		/// Der Name der Note
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Der Wert der Note
		/// </summary>
		public double Note { get; set; }

		/// <summary>
		/// Die Gewichtung der Note
		/// </summary>
		public double Gewichtung { get; set; }

		/// <summary>
		/// Das Modul zu welchem die Note gehört
		/// </summary>
		public virtual Modul Modul { get; set; }

		/// <summary>
		/// Die Id des zugehörigen Moduls
		/// </summary>
        public int ModulID { get; set; }
	}
}
