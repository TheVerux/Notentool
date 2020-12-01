using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notentool.Models.Entities
{
	public class Semester
	{
        public Semester()
        {
			Moduls = new HashSet<Modul>();
        }
		public int SemesterID { get; set; }

		public string Name { get; set; }

		public virtual Benutzeraccount Benutzeraccount { get; set; }

		public string BenutzeraccountId { get; set; }

		public virtual ICollection<Modul> Moduls { get; set; }
	}
}
