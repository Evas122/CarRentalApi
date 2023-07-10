using CarRental.Storage.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service.Commands
{
    public  class AddRentalCommand : IRequest<RentalDetails>
    {
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public int AvgNumberOfKilometres { get; set; }
        public int DriverLicenseYear { get; set; }
        public int CarId { get; set; }
        public DateTime CarRentalDate { get; set; }
        public DateTime CarReturnDate { get; set; }
    }
}
