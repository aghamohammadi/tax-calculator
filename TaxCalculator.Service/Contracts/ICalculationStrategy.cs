using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Service.Contracts
{
    public interface ICalculationStrategy
    {
        Task<decimal> CalculateTaxAsync(string cityName, int year, string vehicleLicensePlate, DateTime[] dates);
    }

}
    