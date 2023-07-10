using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Storage.Entities;
using CarRental.Storage.Repositories;

namespace CarRental.Service.Query
{
    public class GetCarModelsQuery : IRequest<List<CarModel>>
    {
      
    }
}
