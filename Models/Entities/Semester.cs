using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notentool.Models.Entities
{
	public class Semester
	{
		public int SemesterID { get; set; }

		public string Name { get; set; }

		public Benutzeraccount Benutzeraccount { get; set; }

		public ICollection<Modul> Moduls { get; set; }
	}
}
