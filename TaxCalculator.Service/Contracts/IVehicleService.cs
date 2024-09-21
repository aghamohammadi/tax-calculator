using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.DtoModels;

namespace TaxCalculator.Service.Contracts
{
    public interface IVehicleService
    {
        Task<VehicleDto> GetByLicensePlateAsync(string licensePlate);
        Task<bool> HasVehicleExemption(int cityId, string vehicleType);
    }
}
