using CarRental.Service.Commands;
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
    public class AddRentalCommandHandler : IRequestHandler<AddRentalCommand, RentalDetail>
    {
        private readonly IRentalDetailRepository _repository;

        public AddRentalCommandHandler(IRentalDetailRepository repository)
        {
            _repository = repository;
        }
        public Task<RentalDetail> Handle(AddRentalCommand request, CancellationToken cancellationToken)
        {
            var rentalDetails = new RentalDetail()
            {
                AvgNumberOfKilometres = request.AvgNumberOfKilometres,
                DriverLicenseYear = request.DriverLicenseYear,
                CarId = request.CarId,
                CarRentalDate = request.CarRentalDate,
                CarReturnDate = request.CarReturnDate,
             };

            _repository.InsertRentalDetails(rentalDetails.AvgNumberOfKilometres, rentalDetails.DriverLicenseYear, rentalDetails.CarId, rentalDetails.CarRentalDate, rentalDetails.CarReturnDate);
            
            
            
            return Task.FromResult(rentalDetails);
        }
       
    }
}
