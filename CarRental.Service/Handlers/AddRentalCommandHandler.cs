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
    public class AddRentalCommandHandler : IRequestHandler<AddRentalCommand, RentalDetails>
    {
        private readonly IRentalDetailsRepository _repository;

        public AddRentalCommandHandler(IRentalDetailsRepository repository)
        {
            _repository = repository;
        }
        public Task<RentalDetails> Handle(AddRentalCommand request, CancellationToken cancellationToken)
        {
            var rentalDetails = new RentalDetails()
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
