using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Storage.Entities
{
    public class RentalDetails
    {
        public int AvgNumberOfKilometres { get; set; }
        public int DriverLicenseYear { get; set; }
        public int CarId { get; set; }
        public DateTime CarRentalDate { get; set; }
        public DateTime CarReturnDate { get; set; }

    }
}
