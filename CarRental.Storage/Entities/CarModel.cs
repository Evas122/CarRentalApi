using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Storage.Entities
{
    public class CarModel
    {
        [Key]
        public int CarId { get; set; }
        public string? Name { get; set; }
        public string? PriceCategory { get; set; }
        public string? CarLocation { get; set; }
        public double PricePerDay { get; set; }
        public double AverageFuelConsumption { get; set; }
        public int AvailableModels { get; set; }
       
    }
   
}
