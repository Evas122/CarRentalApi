using CarRental.Storage.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service.Query
{
    public class GetRentalCostQuery : IRequest<RentalPrice>
    {
        public GetRentalCostQuery() { }
        public GetRentalCostQuery(int CarId, int NumberOfDays, int DriverLicenseYear, double AvgNumberOfKilometres)
        {
            CarId = CarId;
            NumberOfDays = NumberOfDays;
            DriverLicenseYear = DriverLicenseYear;
            AvgNumberOfKilometres = AvgNumberOfKilometres;
        }
        
        public GetRentalCostQuery(GetRentalCostQuery query)
        { 
            CarId = query.CarId;
            NumberOfDays = query.NumberOfDays;
            DriverLicenseYear = query.DriverLicenseYear;
            AvgNumberOfKilometres = query.AvgNumberOfKilometres;
        }
        public int CarId { get; set; }
        public int NumberOfDays { get; set; }
        public int DriverLicenseYear { get; set; }
        public double AvgNumberOfKilometres { get; set; }
    }
}
