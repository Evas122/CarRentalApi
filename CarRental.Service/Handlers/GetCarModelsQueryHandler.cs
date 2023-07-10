using CarRental.Service.Query;
using CarRental.Storage.Entities;
using CarRental.Storage.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service.Handlers
{
    public class GetCarModelsQueryHandler : IRequestHandler<GetCarModelsQuery, List<CarModel>>
    {
        private readonly ICarModelRepository _repository;
        public GetCarModelsQueryHandler(ICarModelRepository repository)
        {
            _repository = repository;
        }
        public Task<List<CarModel>> Handle(GetCarModelsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetCars());
        }
    }
}
