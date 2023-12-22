using CarRental.Storage.Entities;

namespace CarRental.Storage.Repositories
{
    public interface IRentalDetailRepository
    {
        List<RentalDetail> GetRentalDetails();

        RentalDetail InsertRentalDetails(int avgnumberofkilometres, int driverlicenseyear, int carid, DateTime carrentaldate, DateTime carreturndate);

        
    }
}