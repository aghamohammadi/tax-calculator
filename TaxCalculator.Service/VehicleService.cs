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
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public VehicleService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<VehicleDto> GetByLicensePlateAsync(string licensePlate)
        {

            var vehicle = await _unitOfWork.VehicleRepository.Get(a => a.LicensePlate.ToLower() == licensePlate.ToLower())
                .FirstOrDefaultAsync();
            if (vehicle == null)
                return null;

            return _mapper.Map(vehicle, new VehicleDto());
        }        
        
        
        public async Task<bool> HasVehicleExemption(int cityId,string vehicleType)
        {

            return await _unitOfWork.VehicleExemptionRepository.IsExistAsync(a => a.VehicleType.ToLower() == vehicleType.ToLower() && a.CityId== cityId);
            
        }


    }
}
