using CarRental.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Storage.Repositories
{
    public class CarModelRepository : ICarModelRepository
    {
        public List<CarModel> cars = new();

        public CarModelRepository()
        {
            cars.Add(new CarModel { CarId = 0, Name = "car1", PriceCategory = "Basic", CarLocation = "Rzeszów", PricePerDay = 360, AverageFuelConsumption = 6.7, AvailableModels = 7 });
            cars.Add(new CarModel { CarId = 1, Name = "car2", PriceCategory = "Standard", CarLocation = "Rzeszów", PricePerDay = 460, AverageFuelConsumption = 8.2, AvailableModels = 1 });
            cars.Add(new CarModel { CarId = 2, Name = "car3", PriceCategory = "Medium", CarLocation = "Warszawa", PricePerDay = 525, AverageFuelConsumption = 5.3, AvailableModels = 5 });
            cars.Add(new CarModel { CarId = 3, Name = "car4", PriceCategory = "Premium", CarLocation = "Rzeszów", PricePerDay = 754, AverageFuelConsumption = 12.1, AvailableModels = 2 });
        }

        public List<CarModel> GetCars()
        {
            return cars;
        }

        public CarModel GetCarModelById(int carId)
        {
                return cars[carId];
        }
    }
}
