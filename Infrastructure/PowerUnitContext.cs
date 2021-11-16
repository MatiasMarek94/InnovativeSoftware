using System;
using InnovativeSoftware.Models;
using Microsoft.EntityFrameworkCore;

namespace InnovativeSoftware.Infrastructure
{
    public class PowerUnitContext : DbContext
    {
        public PowerUnitContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}powerunit.db";
        }

        public DbSet<PowerUnit> PowerUnits { get; set; }

        public string DbPath { get; set; }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PowerUnit>()
                .Property(e => e.Tags).HasConversion<string>(
                    v => string.Join(",", v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}