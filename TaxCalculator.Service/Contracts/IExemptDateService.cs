using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.DtoModels;

namespace TaxCalculator.Service.Contracts
{

    public interface IExemptDateService
    {
        Task<bool> CheckMonthExemption(DateTime date, int cityId);
        Task<bool> CheckWeekendExemption(DateTime date, int cityId);
        Task<bool> CheckHolidayExemption(DateTime date, int cityId);
        Task<bool> CheckBeforeHolidayExemption(DateTime date, int cityId);
    }
}
