using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notentool.Models.Entities
{
	public class Modul
	{
		public int ModulID { get; set; }

		public string Name { get; set; }

		public Semester Semester { get; set; }

		public ICollection<Grade> Grades { get; set; }
	}
}
