using Microsoft.EntityFrameworkCore;
using MMD.Domain;
using MMD.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Dal
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Accelerometer> Accelerometers { get; set; }
        public DbSet<AssemblyMms> AssemblyMms {get; set;}
        public DbSet<CalibrationMms> CalibrationMmses { get; set; }
        public DbSet<CalibrationProduct> CalibrationProducts { get; set; }
        public DbSet<ConfiguringMms> ConfiguringMmses { get; set; }
        public DbSet<ConfiguringProduct> ConfiguringProducts { get; set; }
        public DbSet<Consignment> Consignments { get; set; }
        public DbSet<Gyroscope> Gyroscopes { get; set; }
        public DbSet<MakeProduct> MakeProducts { get; set; }
        public DbSet<MobileTestingMms> MobileTestingMmses { get; set; }
        public DbSet<MobileTestingProduct> MobileTestingProducts { get; set; }
        public DbSet<Plate> Plates { get; set; }
        public DbSet<StationaryTestingMms> StationaryTestingMms { get; set; }
        public DbSet<StationaryTestingProduct> StationaryTestingProducts { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
 

        //public ApplicationContext()
        //{
        //    Database.EnsureDeleted();
        //    Database.EnsureCreated();
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MSI;Database=myDataBase;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }
    }
}
