using CarRental.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace CarRental.Storage.Data_Acces_Layer
{
    public class CarRentalContext : DbContext
    {

        public DbSet<CarModel> Cars { get; set; }

        public CarRentalContext()
        {

        }
        public CarRentalContext(DbContextOptions<CarRentalContext> options) : base(options)
        {     
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=CarDb;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModel>().ToTable("Cars");

            modelBuilder.Entity<CarModel>().HasData(
                new CarModel { CarId = 1, Name = "car1", PriceCategory = "Basic", CarLocation = "Rzeszów", PricePerDay = 360, AverageFuelConsumption = 6.7, AvailableModels = 7 },
                new CarModel { CarId = 2, Name = "car2", PriceCategory = "Standard", CarLocation = "Rzeszów", PricePerDay = 460, AverageFuelConsumption = 8.2, AvailableModels = 1 },
                new CarModel { CarId = 3, Name = "car3", PriceCategory = "Medium", CarLocation = "Warszawa", PricePerDay = 525, AverageFuelConsumption = 5.3, AvailableModels = 5 },
                new CarModel { CarId = 4, Name = "car4", PriceCategory = "Premium", CarLocation = "Rzeszów", PricePerDay = 754, AverageFuelConsumption = 12.1, AvailableModels = 2 }
                );
            
        }
           
    }
     
}
