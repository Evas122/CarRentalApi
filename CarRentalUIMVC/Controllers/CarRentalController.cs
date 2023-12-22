using Microsoft.AspNetCore.Mvc;
using CarRental.Service.Commands;
using CarRental.Service.Query;
using CarRental.Storage.Entities;
using MediatR;
using CarRental.Storage.Repositories;

namespace CarRentalUIMVC.Controllers
{
    public class CarRentalController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ICarModelRepository _carModelRepository;

        public CarRentalController(IMediator mediator, ICarModelRepository carModelRepository)
        {
            _mediator = mediator;
            _carModelRepository = carModelRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CarIndexView()
        {
            var query = new GetCarModelsQuery();
            var result =  _mediator.Send(query).Result;
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> CarRentalCalculatorView()
        {
            var carModels = _carModelRepository.GetCars();
            ViewBag.CarModels = carModels;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CarRentalCalculatorView (AddRentalCommand command)
        {
            var rentalDetails = await _mediator.Send(command);
            return RedirectToAction("RentPriceCalcResult", new
            {
                AvgNumberOfKilometres = command.AvgNumberOfKilometres,
                DriverLicenseYear = command.DriverLicenseYear,
                CarId = command.CarId,
                CarRentalDate = command.CarRentalDate,
                CarReturnDate = command.CarReturnDate
            });
        }

        [HttpGet]
        public async Task<ActionResult> RentPriceCalcResult(int AvgNumberOfKilometres, int DriverLicenseYear, int CarId, DateTime CarRentalDate, DateTime CarReturnDate)
        {
            int NumberOfDays = (int)(CarReturnDate - CarRentalDate).TotalDays;
            var query = new GetRentalCostQuery
            {
                CarId = CarId,
                NumberOfDays = NumberOfDays,
                DriverLicenseYear = DriverLicenseYear,
                AvgNumberOfKilometres = AvgNumberOfKilometres,

            };

            var rentalcost = await _mediator.Send(new GetRentalCostQuery(query));
            return View(rentalcost);
        }

    }
}
