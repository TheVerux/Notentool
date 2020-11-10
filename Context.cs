using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Notentool.Models.Entities;

namespace Notentool
{
	public class Context : DbContext
	{
		private string ConnectionString { get; set; }
		public Context(string connectionString)
		{
			ConnectionString = connectionString;
		}

		public DbSet<Benutzeraccount> Benutzeraccounts { get; set; }

		public DbSet<Semester> Semesters { get; set; }

		public DbSet<Modul> Moduls { get; set; }

		public DbSet<Grade> Grades { get; set; }

		/*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(ConnectionString);
			}
		}*/
	}
}
