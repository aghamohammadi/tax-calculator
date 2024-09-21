using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Repositories;
using TaxCalculator.Service.Contracts;

namespace TaxCalculator.Service
{
    public class ExemptDateService : IExemptDateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ExemptDateService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> CheckBeforeHolidayExemption(DateTime date, int cityId)
        {
            return await _unitOfWork.HolidayRepository.IsExistAsync(a => a.ExemptDate.Date == date.Date.AddDays(1) && a.CityId == cityId);
        }

        public async Task<bool> CheckHolidayExemption(DateTime date, int cityId)
        {
            return await _unitOfWork.HolidayRepository.IsExistAsync(a => a.ExemptDate.Date == date.Date && a.CityId == cityId);
        }

        public async Task<bool> CheckMonthExemption(DateTime date, int cityId)
        {
            return await _unitOfWork.MonthTaxExemptionRepository.IsExistAsync(a => a.Year == date.Date.Year && a.Month == date.Month && a.CityId == cityId);
        }

        public async Task<bool> CheckWeekendExemption(DateTime date, int cityId)
        {
            return await _unitOfWork.WeekendDayRepository.IsExistAsync(a => a.DayOfWeek == date.Date.DayOfWeek && a.CityId == cityId);
        }
    }
}
