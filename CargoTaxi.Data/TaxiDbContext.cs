using CargoTaxi.Data.Models;
using CargoTaxi.Data.Utils;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Data.Entity;


namespace CargoTaxi.Data
{
    public class TaxiDbContext : IdentityDbContext<ApplicationUser>
    {
        public TaxiDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarCategory> CarCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var converter = new EnumToStringConverter<EnumCategories>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
              .HasRequired(x => x.Category);

            modelBuilder.Entity<Car>()
              .HasMany(x => x.Orders)
              .WithOptional(x => x.Car)
              .HasForeignKey(x => x.CarId);

            modelBuilder.Entity<CarCategory>()
                .HasMany(x => x.Cars)
                .WithRequired(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.Orders)
                .WithRequired(x => x.Client)
                .HasForeignKey(x => x.ClientId);

            modelBuilder.Entity<ApplicationUser>()
                 .HasMany(x => x.Cars)
                 .WithRequired(x => x.Driver)
                 .HasForeignKey(x => x.DriverId);

            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("date"));
        }
        public static TaxiDbContext Create()
        {
            return new TaxiDbContext();
        }

    }
}
