using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Notentool.Models.Entities;

namespace Notentool
{
	public class Context : IdentityDbContext<Benutzeraccount, UserRole, string>
	{
		private string ConnectionString { get; set; }
		public Context(DbContextOptions options): base(options)
		{
			Database.EnsureCreated();
		}

		public DbSet<Benutzeraccount> Benutzeraccounts { get; set; }

		public DbSet<Semester> Semesters { get; set; }

		public DbSet<Modul> Moduls { get; set; }

		public DbSet<Grade> Grades { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			/*modelBuilder.Entity<Semester>()
				.ToTable("Semester");

			modelBuilder.Entity<Modul>()
				.ToTable("Modul");

			modelBuilder.Entity<Grade>()
				.ToTable("Grade");*/
			
			base.OnModelCreating(modelBuilder);
		}
	}
}
