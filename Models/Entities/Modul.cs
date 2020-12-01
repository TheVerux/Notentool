using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notentool.Models.Entities
{
	public class Modul
	{
        public Modul()
        {
			Grades = new HashSet<Grade>();
        }
		public int ModulID { get; set; }

		public string Name { get; set; }

		public virtual Semester Semester { get; set; }

		public int SemesterID { get; set; }

		public virtual ICollection<Grade> Grades { get; set; }
	}
}
