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
		public Context(DbContextOptions options): base(options)
		{

		}

		public DbSet<Benutzeraccount> Benutzeraccounts { get; set; }

		public DbSet<Semester> Semesters { get; set; }

		public DbSet<Modul> Moduls { get; set; }

		public DbSet<Grade> Grades { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Benutzeraccount>()
				.ToTable("Benutzeraccount");

			modelBuilder.Entity<Semester>()
				.ToTable("Semester");

			modelBuilder.Entity<Modul>()
				.ToTable("Modul");

			modelBuilder.Entity<Grade>()
				.ToTable("Grade");

			modelBuilder.Entity<Benutzeraccount>()
				.HasMany(b => b.Semesters)
				.WithOne(s => s.Benutzeraccount);

			modelBuilder.Entity<Semester>()
				.HasMany(s => s.Moduls)
				.WithOne(m => m.Semester);

			modelBuilder.Entity<Modul>()
				.HasMany(m => m.Grades)
				.WithOne(g => g.Modul);
		}
	}
}
