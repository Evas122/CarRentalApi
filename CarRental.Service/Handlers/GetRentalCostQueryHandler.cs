﻿using CarRental.Service.Query;
using CarRental.Storage.Entities;
using CarRental.Storage.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service.Handlers
{
    public class GetRentalCostQueryHandler : IRequestHandler<GetRentalCostQuery, RentalPrice>
    {
        private readonly ICarModelRepository _carModelRepository;
        private readonly IRentalDetailsRepository _rentalDetailsRepository;

        public GetRentalCostQueryHandler(ICarModelRepository carModelRepository, IRentalDetailsRepository rentalDetailsRepository)
        {
            _carModelRepository = carModelRepository;
            _rentalDetailsRepository = rentalDetailsRepository;
        }

        public Task<RentalPrice> Handle(GetRentalCostQuery request, CancellationToken cancellationToken)
        {
            var car = _carModelRepository.GetCarModelById(request.CarId);

            double BaseRentalPrice = car.PricePerDay * request.NumberOfDays;
            double RentalPrice = BaseRentalPrice * MultiplerByCategory(car.PriceCategory);

            int DrivingExpYears = DateTime.Now.Year - request.DriverLicenseYear;

            if (DrivingExpYears > 5)
            {
                RentalPrice *= 1.2;
            }

            if (DrivingExpYears < 3 && car.PriceCategory == "Premium")
            {
                throw new Exception("You cannot rent this car!");
            }

            if (car.AvailableModels < 3)
            {
                RentalPrice *= 1.15;
            }

            double FuelCost = FuelCostCalc(request.AvgNumberOfKilometres, car.AverageFuelConsumption);

            double NetPrice = RentalPrice + FuelCost;
            double GrossPrice = NetPrice * 1.23;

            var RentalPriceCost = new RentalPrice
            {
                FinalRentalPrice = RentalPrice,
                PricePerDay = car.PricePerDay,
                RentDays = request.NumberOfDays,
                FuelCost = FuelCost,
                NetPrice = NetPrice,
                GrossPrice = GrossPrice,
            };

            return Task.FromResult(RentalPriceCost);
            
        }

        private double MultiplerByCategory(string priceCategory)
        {
            double multiplier = 1.0;

            switch (priceCategory)
            {
                case "Basic":
                    multiplier = 1.0;
                    break;
                case "Standard":
                    multiplier = 1.3;
                    break;
                case "Medium":
                    multiplier = 1.6;
                    break;
                case "Premium":
                    multiplier = 2.0;
                    break;
            }

            return multiplier;
        }

        private double FuelCostCalc(double AvgNumberOfKilometres, double AvgerageFuelConsumption)
        {
            double FuelPrice = 5.45;
            double FuelCost = (AvgNumberOfKilometres / 100 * AvgerageFuelConsumption * FuelPrice);
            return FuelCost;
        }

    }
}

