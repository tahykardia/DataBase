using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database
{
	public class LabDbContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public LabDbContext(DbContextOptions<LabDbContext> options) : base(options) { }

		public DbSet<ComputerInfo> ComputerInfo { get; set; }
		public DbSet<CPU> CPU { get; set; }
		public DbSet<GPU> Gpu { get; set; }
		public DbSet<RAM> Ram { get; set; }
		public DbSet<SSD> Ssd { get; set; }
		public DbSet<ComputersToRAM> ComputersToRAM { get; set; }
		public DbSet<ComputersToGPU> ComputersToGPU { get; set; }
		public DbSet<ComputersToSSD> ComputersToSSD { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
		}
	}
}
