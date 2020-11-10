using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notentool.Models.Entities
{
	public class Benutzeraccount
	{
		public int BenutzeraccountID { get; set; }

		public string Benutzername { get; set; }

		public string Passwort { get; set; }

		public ICollection<Semester> Semesters { get; set; }
	}
}
