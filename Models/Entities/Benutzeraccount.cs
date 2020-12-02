using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notentool.Models.Entities
{
	/// <summary>
	/// Klasse für Benutzeraccounts. Erbt von <c>IdentityUser</c>
	/// Autoren: Gion Rubitschung und Noah Siroh Schönthal
	/// </summary>
	public class Benutzeraccount : IdentityUser
	{
        public Benutzeraccount()
        {
			Semesters = new HashSet<Semester>();
        }

		/// <summary>
		/// Die Semester des Benutzers
		/// </summary>
		public virtual ICollection<Semester> Semesters { get; set; }
	}
}
