using CarRental.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Storage.Repositories
{
    public class RentalDetailsRepository : IRentalDetailsRepository
    {
        private List<RentalDetails> rentalDetails = new();
        public RentalDetailsRepository() { }

        public List<RentalDetails> GetRentalDetails()
        {
            return rentalDetails;
        }

        public RentalDetails InsertRentalDetails(int avgnumberofkilometres, int driverlicenseyear, int carid, DateTime carrentaldate, DateTime carreturndate)
        {
            RentalDetails rental = new() { AvgNumberOfKilometres = avgnumberofkilometres, DriverLicenseYear = driverlicenseyear, CarId = carid, CarRentalDate = carrentaldate, CarReturnDate = carreturndate };
            rentalDetails.Add(rental);
            return rental;
        }
    }
}
