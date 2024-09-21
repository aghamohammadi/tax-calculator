using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.DtoModels;

namespace TaxCalculator.Service.Contracts
{
    public interface ITaxAmountService
    {
        Task<decimal> GetTaxAmount(TimeOnly time, int cityId, int year);

        
    }
}
