using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.DtoModels;

namespace TaxCalculator.Service.Contracts
{
    public interface ICityService
    {
        Task<CityDto> GetCityAsync(string cityName);
        Task<CityTaxRuleDto> GetRulesAsync(int cityId, int year);

    }
}
