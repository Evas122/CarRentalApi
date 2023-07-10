using CarRental.Service.Commands;
using CarRental.Service.Query;
using CarRental.Storage.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CarRentalUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CarRentalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarRentalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetRentalCarController")]
        public async Task<ActionResult<List<CarModel>>> Get()
        {

            return await _mediator.Send(new GetCarModelsQuery());
        }

        [HttpPost(Name = "PostRental")]
        public async Task<ActionResult> AddRental([FromForm] AddRentalCommand command)
        {
            var rentalDetails = await _mediator.Send(command);
            return RedirectToAction("RentPriceCalc", new
            {
                AvgNumberOfKilometres = command.AvgNumberOfKilometres,
                DriverLicenseYear = command.DriverLicenseYear,
                CarId = command.CarId,
                CarRentalDate = command.CarRentalDate,
                CarReturnDate = command.CarReturnDate
            });
            
        }

        [HttpGet("RentalCost")]
        public async Task<ActionResult> RentPriceCalc([FromQuery] int AvgNumberOfKilometres, [FromQuery] int DriverLicenseYear, [FromQuery] int CarId, [FromQuery] DateTime CarRentalDate, [FromQuery] DateTime CarReturnDate)
        {
            int NumberOfDays =(int)(CarReturnDate - CarRentalDate).TotalDays;
            var query = new GetRentalCostQuery
            {
                CarId = CarId,
                NumberOfDays = NumberOfDays,
                DriverLicenseYear = DriverLicenseYear,
                AvgNumberOfKilometres = AvgNumberOfKilometres,

            };

            var rentalcost = await _mediator.Send(new GetRentalCostQuery(query));
            return Ok(rentalcost);
        }
        // GET: CarRentalController
       
    }
}
