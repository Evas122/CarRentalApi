using CarRental.Storage.Entities;

namespace CarRental.Storage.Repositories
{
    public interface IRentalDetailsRepository
    {
        List<RentalDetails> GetRentalDetails();

        RentalDetails InsertRentalDetails(int avgnumberofkilometres, int driverlicenseyear, int carid, DateTime carrentaldate, DateTime carreturndate);

        
    }
}