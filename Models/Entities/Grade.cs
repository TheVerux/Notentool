using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notentool.Models.Entities
{
	public class Grade
	{
		public int GradeID { get; set; }

		public string Name { get; set; }

		public double Note { get; set; }

		public double Gewichtung { get; set; }

		public virtual Modul Modul { get; set; }

        public int ModulID { get; set; }
	}
}
