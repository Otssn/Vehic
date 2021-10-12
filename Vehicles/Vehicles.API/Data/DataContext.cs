using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Data.Entities;

namespace Vehicles.API.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<DocumentTypes> DocumentTypes { get; set; }
        public DbSet<Procedures> Procedures { get; set; }
        public DbSet<History> histories { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehiclePhoto> VehiclePhotos { get; set; }
        public DbSet<VehicleTypes> VehicleTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Brand>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<DocumentTypes>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Procedures>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Vehicle>().HasIndex(x => x.Plaque).IsUnique();
            modelBuilder.Entity<VehicleTypes>().HasIndex(x => x.Description).IsUnique();
        }
    }
}
