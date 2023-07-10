using CarRental.Storage.Entities;

namespace CarRental.Storage.Repositories
{
    public interface ICarModelRepository
    {
        List<CarModel> GetCars();
        CarModel GetCarModelById(int carId);
    }
}