using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Models;

namespace WinFormsApp1.Context
{
	public class AppDbContext : DbContext
	{
		public DbSet<Student> Students { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<Contract> Contracts { get; set; }
		public DbSet<WorkTable> WorkTables { get; set; }

		string connectionString = "Host=localhost;Port=5432; Database=webapi; " +
			"Username=postgres; Password=20050725";

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql(connectionString);
		}
	}
}
