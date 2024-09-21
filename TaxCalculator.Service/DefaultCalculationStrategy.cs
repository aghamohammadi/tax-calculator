using System;
using TaxCalculator.Service.Contracts;

namespace TaxCalculator.Service
{
    public class DefaultCalculationStrategy : ICalculationStrategy
    {

        private readonly ICityService _cityService;
        private readonly IVehicleService _vehicleService;
        private readonly IExemptDateService _exemptDateService;
        private readonly ITaxAmountService _taxAmountService;

        public DefaultCalculationStrategy(ICityService cityService, IVehicleService vehicleService, IExemptDateService exemptDateService, ITaxAmountService taxAmountService)
        {
            _cityService = cityService;
            _vehicleService = vehicleService;
            _exemptDateService = exemptDateService;
            _taxAmountService = taxAmountService;
        }
        public async Task<decimal> CalculateTaxAsync(string cityName, int year, string vehicleLicensePlate, DateTime[] dates)
        {
            var city = await _cityService.GetCityAsync(cityName);
            if (city == null)
                throw new Exception("City not found");
            var taxRule = await _cityService.GetRulesAsync(city.Id, year);
            if (taxRule == null)
                throw new Exception("Tax rules not found");

            var vehicle = await _vehicleService.GetByLicensePlateAsync(vehicleLicensePlate);
            if (vehicle == null)
                throw new Exception("Vehicle not found");

  
            var hasVehicleExemption= await _vehicleService.HasVehicleExemption(city.Id, vehicle.VehicleType);
            if (hasVehicleExemption)
                return 0;
            

            // Step 3: Calculate tax based on each date
            decimal totalTax = 0;
            DateTime lastTaxedDate = DateTime.MinValue;
            DateTime singleChargeStartDate = DateTime.MinValue;
            decimal dailyTax = 0;
            decimal singleChargeMaxTax = 0;
            decimal nextTax = 0;

            foreach (var date in dates.OrderBy(d => d))
            {
                // Skip exempt dates
                if (await IsExemptDate(date, city.Id))
                    continue;

                //get tax amount for the time
                var taxAmount =await GetTaxAmountForTime(TimeOnly.FromDateTime(date), city.Id, year);

                if (taxAmount == 0)
                    continue;


                nextTax = taxAmount;


                // Check for single charge rule
                if (taxRule.HasSingleChargeRule && (date - singleChargeStartDate).TotalMinutes < taxRule.SingleChargeWindowInMinutes)
                {
                    //find max amount for single charge rule
                    if (nextTax > singleChargeMaxTax)
                    {
                        //update the total tax, because the previous amount was not the largest value
                        totalTax -= singleChargeMaxTax;
                        //update the dailyTax, because the previous amount was not the largest value
                        if (date.Date == lastTaxedDate.Date)
                            dailyTax -= singleChargeMaxTax;

                        singleChargeMaxTax = nextTax;
                    }
                    else
                        nextTax = 0;
                    
                }
                else
                {
                    //determine start date ragne for single charge rule
                    singleChargeStartDate = date;
                    singleChargeMaxTax = nextTax;
                }

                //check for Max Amount Per Day
                if (date.Date == lastTaxedDate.Date )
                {
                    if(dailyTax + nextTax > taxRule.MaxAmountPerDay)
                        nextTax = taxRule.MaxAmountPerDay - dailyTax;
                    dailyTax += nextTax;
                }
                else
                    dailyTax = nextTax;



                totalTax += nextTax;
                lastTaxedDate = date;
            }

            return totalTax;
        }


        private async Task<bool> IsExemptDate(DateTime date, int cityId)
        {
            // Check if the date is in exempt month
            if (await _exemptDateService.CheckMonthExemption(date, cityId))
                return true;

            // Check for weekends
            if (await _exemptDateService.CheckWeekendExemption(date, cityId))
                return true;

            // Check for holidays
            if (await _exemptDateService.CheckHolidayExemption(date, cityId))
                return true;

            // Check day before holidays
            if (await _exemptDateService.CheckBeforeHolidayExemption(date, cityId))
                return true;

            return false;
        }


        private async Task<decimal> GetTaxAmountForTime(TimeOnly time, int cityId, int year)
        {
            return await _taxAmountService.GetTaxAmount(time,  cityId,  year);

        }
    }
}
