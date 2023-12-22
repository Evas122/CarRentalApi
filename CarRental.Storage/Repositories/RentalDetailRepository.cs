using CarRental.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Storage.Repositories
{
    public class RentalDetailRepository : IRentalDetailRepository
    {
        private List<RentalDetail> rentalDetails = new();
        public RentalDetailRepository() { }

        public List<RentalDetail> GetRentalDetails()
        {
            return rentalDetails;
        }

        public RentalDetail InsertRentalDetails(int avgnumberofkilometres, int driverlicenseyear, int carid, DateTime carrentaldate, DateTime carreturndate)
        {
            RentalDetail rental = new() { AvgNumberOfKilometres = avgnumberofkilometres, DriverLicenseYear = driverlicenseyear, CarId = carid, CarRentalDate = carrentaldate, CarReturnDate = carreturndate };
            rentalDetails.Add(rental);
            return rental;
        }
    }
}
