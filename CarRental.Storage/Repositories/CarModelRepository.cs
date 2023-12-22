using CarRental.Storage.Data_Acces_Layer;
using CarRental.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Storage.Repositories
{
    public class CarModelRepository : ICarModelRepository
    {
        private readonly CarRentalContext _context;

        public CarModelRepository(CarRentalContext context)
        {
            _context = context;
        }

        public List<CarModel> GetCars()
        {
            return _context.Cars.ToList();
        }

        public CarModel GetCarModelById(int carId)
        {
            
                return _context.Cars.Find(carId);
        }
    }
}
