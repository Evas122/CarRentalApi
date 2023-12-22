using CarRental.Service.Query;
using CarRental.Storage.Data_Acces_Layer;
using CarRental.Storage.Entities;
using CarRental.Storage.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service.Handlers
{
    public class GetCarModelsQueryHandler : IRequestHandler<GetCarModelsQuery, List<CarModel>>
    {
        private readonly ICarModelRepository _carModelRepository;
        public GetCarModelsQueryHandler(ICarModelRepository carModelRepository)
        {
            _carModelRepository = carModelRepository;
          
        }
        public Task<List<CarModel>> Handle(GetCarModelsQuery request, CancellationToken cancellationToken)
        {
        
           var cars = _carModelRepository.GetCars();
           return Task.FromResult(cars);
           
        }
    }
}
