using TaxCalculator.EntityBase.Entity;
using Microsoft.EntityFrameworkCore;
using TaxCalculator.EntityBase.Entity;

namespace TaxCalculator.EntityBase.Context
{
    public class TaxCalculatorDbContext : DbContext
    {
        public TaxCalculatorDbContext(DbContextOptions<TaxCalculatorDbContext> options)
            : base(options)
        {
        }

        public DbSet<City> City { get; set; }
        public DbSet<CityTaxRule> CityTaxRule { get; set; }
        public DbSet<Holiday> Holiday { get; set; }
        public DbSet<MonthTaxExemption> MonthTaxExemption { get; set; }
        public DbSet<TaxAmount> TaxAmount { get; set; }
        //public DbSet<TaxRecord> TaxRecord { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleExemption> VehicleExemption { get; set; }
        public DbSet<WeekendDay> WeekendDay { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityTaxRule>()
                .Property(c => c.MaxAmountPerDay)
                .HasColumnType("decimal(18,2)"); 

            modelBuilder.Entity<TaxAmount>()
                .Property(t => t.Amount)
                .HasColumnType("decimal(18,2)");

            SeedData(modelBuilder);


            base.OnModelCreating(modelBuilder);
        }

        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1,  Name = "Gothenburg", Country = "Sweden" }
            );

            modelBuilder.Entity<CityTaxRule>().HasData(
                new CityTaxRule { Id = 1, CityId = 1, HasSingleChargeRule = true,MaxAmountPerDay = 60,SingleChargeWindowInMinutes = 60,Year =2013 }
            );

            modelBuilder.Entity<Holiday>().HasData(
                new Holiday { Id = 1, CityId = 1, IsExemptBeforeHoliday = true, ExemptDate = new DateTime(2013, 01, 15) },
                new Holiday { Id = 2, CityId = 1, IsExemptBeforeHoliday = true, ExemptDate = new DateTime(2013, 01, 25) },
                new Holiday { Id = 3, CityId = 1, IsExemptBeforeHoliday = true, ExemptDate = new DateTime(2013, 02, 17) },
                new Holiday { Id = 4, CityId = 1, IsExemptBeforeHoliday = true, ExemptDate = new DateTime(2013, 02, 25) },
                new Holiday { Id = 5, CityId = 1, IsExemptBeforeHoliday = true, ExemptDate = new DateTime(2013, 04, 26) },
                new Holiday { Id = 6, CityId = 1, IsExemptBeforeHoliday = true, ExemptDate = new DateTime(2013, 05, 28) }
            );

            modelBuilder.Entity<MonthTaxExemption>().HasData(
                new MonthTaxExemption { Id = 1, CityId = 1, Year = 2013,Month =7 }
            );

            modelBuilder.Entity<TaxAmount>().HasData(
                new TaxAmount { Id = 1, CityId = 1, Year = 2013, Amount = 8, StartTime = new TimeOnly(6, 0), EndTime = new TimeOnly(6, 29) },
                new TaxAmount { Id = 2, CityId = 1, Year = 2013, Amount = 13, StartTime = new TimeOnly(6, 30), EndTime = new TimeOnly(6, 59) },
                new TaxAmount { Id = 3, CityId = 1, Year = 2013, Amount = 18, StartTime = new TimeOnly(7, 0), EndTime = new TimeOnly(7, 59) },
                new TaxAmount { Id = 4, CityId = 1, Year = 2013, Amount = 13, StartTime = new TimeOnly(8, 0), EndTime = new TimeOnly(8, 29) },
                new TaxAmount { Id = 5, CityId = 1, Year = 2013, Amount = 8, StartTime = new TimeOnly(8, 30), EndTime = new TimeOnly(14, 59) },
                new TaxAmount { Id = 6, CityId = 1, Year = 2013, Amount = 13, StartTime = new TimeOnly(15, 0), EndTime = new TimeOnly(15, 29) },
                new TaxAmount { Id = 7, CityId = 1, Year = 2013, Amount = 18, StartTime = new TimeOnly(15, 30), EndTime = new TimeOnly(16, 59) },
                new TaxAmount { Id = 8, CityId = 1, Year = 2013, Amount = 13, StartTime = new TimeOnly(17, 0), EndTime = new TimeOnly(17, 59) },
                new TaxAmount { Id = 9, CityId = 1, Year = 2013, Amount = 8, StartTime = new TimeOnly(18, 0), EndTime = new TimeOnly(18, 29) },
                new TaxAmount { Id = 10, CityId = 1, Year = 2013, Amount = 0, StartTime = new TimeOnly(18, 30), EndTime = new TimeOnly(5, 59) }
            );


            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, VehicleType = "Emergency", LicensePlate = "EMG-001" },
                new Vehicle { Id = 2, VehicleType = "Emergency", LicensePlate = "EMG-002" },
                new Vehicle { Id = 3, VehicleType = "Busses", LicensePlate = "BUS-001" },
                new Vehicle { Id = 4, VehicleType = "Busses", LicensePlate = "BUS-002" },
                new Vehicle { Id = 5, VehicleType = "Diplomat", LicensePlate = "DPL-001" },
                new Vehicle { Id = 6, VehicleType = "Diplomat", LicensePlate = "DPL-002" },
                new Vehicle { Id = 7, VehicleType = "Motorcycles", LicensePlate = "MTR-001" },
                new Vehicle { Id = 8, VehicleType = "Motorcycles", LicensePlate = "MTR-002" },
                new Vehicle { Id = 9, VehicleType = "Military", LicensePlate = "MLT-001" },
                new Vehicle { Id = 10, VehicleType = "Military", LicensePlate = "MLT-002" },
                new Vehicle { Id = 11, VehicleType = "Foreign", LicensePlate = "FRG-001" },
                new Vehicle { Id = 12, VehicleType = "Foreign", LicensePlate = "FRG-002" },
                new Vehicle { Id = 13, VehicleType = "Foreign", LicensePlate = "FRG-003" },
                new Vehicle { Id = 14, VehicleType = "Foreign", LicensePlate = "FRG-004" },
                new Vehicle { Id = 15, VehicleType = "Foreign", LicensePlate = "FRG-005" },
                new Vehicle { Id = 16, VehicleType = "Cars", LicensePlate = "PRV-001" },
                new Vehicle { Id = 17, VehicleType = "Cars", LicensePlate = "PRV-002" },
                new Vehicle { Id = 18, VehicleType = "Cars", LicensePlate = "PRV-003" },
                new Vehicle { Id = 19, VehicleType = "Trucks", LicensePlate = "PKP-001" },
                new Vehicle { Id = 20, VehicleType = "Trucks", LicensePlate = "PKP-002" },
                new Vehicle { Id = 21, VehicleType = "Vans", LicensePlate = "VAN-001" },
                new Vehicle { Id = 22, VehicleType = "Vans", LicensePlate = "VAN-002" },
                new Vehicle { Id = 23, VehicleType = "Trucks", LicensePlate = "TRK-001" },
                new Vehicle { Id = 24, VehicleType = "Trucks", LicensePlate = "TRK-002" },
                new Vehicle { Id = 25, VehicleType = "Cars", LicensePlate = "LUX-001" }
            );


            modelBuilder.Entity<VehicleExemption>().HasData(
                new VehicleExemption { Id = 1, CityId = 1, VehicleType = "Emergency" },
                new VehicleExemption { Id = 2, CityId = 1, VehicleType = "Busses" },
                new VehicleExemption { Id = 3, CityId = 1, VehicleType = "Diplomat" },
                new VehicleExemption { Id = 4, CityId = 1, VehicleType = "Motorcycles" },
                new VehicleExemption { Id = 5, CityId = 1, VehicleType = "Military" },
                new VehicleExemption { Id = 6, CityId = 1, VehicleType = "Foreign" }
            );
            
            modelBuilder.Entity<WeekendDay>().HasData(
                new WeekendDay { Id = 1, CityId = 1, DayOfWeek = DayOfWeek.Saturday},
                new WeekendDay { Id = 2, CityId = 1, DayOfWeek = DayOfWeek.Sunday }
            );
        }
    }

}

