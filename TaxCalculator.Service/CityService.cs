using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaxCalculator.DtoModels;
using TaxCalculator.Repositories;
using TaxCalculator.Service.Contracts;

namespace TaxCalculator.Service
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CityService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CityDto> GetCityAsync(string cityName)
        {

            var city = await _unitOfWork.CityRepository.Get(a => a.Name.ToLower() == cityName.ToLower())
                .FirstOrDefaultAsync();
            if (city == null)
                return null;

          

            return _mapper.Map(city, new CityDto());
        }


        public async Task<CityTaxRuleDto> GetRulesAsync(int cityId, int year)
        {

            

            var rule = await _unitOfWork.CityTaxRuleRepository.Get(a => a.CityId == cityId && a.Year == year)
                .FirstOrDefaultAsync();
            if (rule == null)
                return null;
            return _mapper.Map(rule, new CityTaxRuleDto());
        }
    }
}
