using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notentool.Models.Entities
{
	public class Benutzeraccount : IdentityUser
	{
		public ICollection<Semester> Semesters { get; set; }
	}
}
