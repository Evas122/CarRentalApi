using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Storage.Entities
{
    public class RentalPrice
    {
        public double FinalRentalPrice { get; set; }
        public double PricePerDay { get; set; }
        public int RentDays { get; set; }
        public double FuelCost { get; set; }
        public double NetPrice { get; set; }
        public double GrossPrice { get; set; }
    }
}
