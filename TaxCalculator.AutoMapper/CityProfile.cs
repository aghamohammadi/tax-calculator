using AutoMapper;
using TaxCalculator.DtoModels;
using TaxCalculator.EntityBase.Entity;

namespace TaxCalculator.AutoMapper
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>();
            CreateMap<CityTaxRule, CityTaxRuleDto>();
        }
    }
}
