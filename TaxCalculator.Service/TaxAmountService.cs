using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.EntityBase.Entity;
using TaxCalculator.Repositories;
using TaxCalculator.Service.Contracts;

namespace TaxCalculator.Service
{
    public class TaxAmountService : ITaxAmountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public TaxAmountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<decimal> GetTaxAmount(TimeOnly time, int cityId, int year)
        {
            var taxAmount =await _unitOfWork.TaxAmountRepository
                .Get(ta => ta.Year == year && ta.StartTime <= time && ta.EndTime > time).FirstOrDefaultAsync();
            return taxAmount?.Amount ?? 0;
        }
    }
}
