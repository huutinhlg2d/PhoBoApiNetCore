using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BussinessObject.PhoBo.Models;
using System.Diagnostics;
using System.IO;

namespace BussinessObject.PhoBo.Data
{
    public class PhoBoContext : DbContext
    {
        public PhoBoContext(DbContextOptions<PhoBoContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Debug.WriteLine("CURRENT DIRECTORY " + Directory.GetCurrentDirectory());
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            Debug.WriteLine("CONNECT STRING " + configuration.GetConnectionString("PhoBoDB"));
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PhoBoDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photographer>().ToTable("Photographer");
            modelBuilder.Entity<Customer>().ToTable("Customer");

            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, Name = "Admin", Email = "admin@phobo.com", Password = "admin@@", Role = UserRole.Admin }
            );

            modelBuilder.Entity<Photographer>().HasData(
                new Photographer() { Id = 2, Name = "Hồ Hữu Tình", AvatarUrl = @"Resource\Images\huutinh.jpg", DateOfBirth = new System.DateTime(2001, 10, 17), Email = "huutinh@phobo.com", Password = "123123", Rate = 0, Role = UserRole.Photographer },
                new Photographer() { Id = 3, Name = "Phạm Tấn Hoàng", AvatarUrl = @"Resource\Images\tanhoang.jpg", DateOfBirth = new System.DateTime(1999, 5, 22), Email = "tanhoang@phobo.com", Password = "123123", Rate = 0, Role = UserRole.Photographer }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer() { Id = 4, Name = "Trương Thị Uyên Trang", AvatarUrl = @"Resource\Images\uyentrang.jpg", DateOfBirth = new System.DateTime(2001, 1, 1), Email = "uyentrang@phobo.com", Password = "123123", Role = UserRole.Customer },
                new Customer() { Id = 5, Name = "Trần Quốc Khánh", AvatarUrl = @"Resource\Images\quockhanh.jpg", DateOfBirth = new System.DateTime(2001, 1, 10), Email = "quockhanh@phobo.com", Password = "123123", Role = UserRole.Customer }
            );

            modelBuilder.Entity<Concept>().HasData(
                new Concept() { Id = 1, Name = "Marriage" },
                new Concept() { Id = 2, Name = "Graduation" },
                new Concept() { Id = 3, Name = "Anniversary" },
                new Concept() { Id = 4, Name = "Birthday" },
                new Concept() { Id = 5, Name = "Travel" }
             );
        }

        public DbSet<User> User { get; set; }
        public DbSet<Photographer> Photographer { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<BookingConceptConfig> BookingConceptConfig { get; set; }
        public DbSet<BookingConceptImage> BookingConceptImage { get; set; }
        public DbSet<Concept> Concept { get; set; }
        public DbSet<Booking> Booking { get; set; }
    }
}
