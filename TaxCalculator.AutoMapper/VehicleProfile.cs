using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.DtoModels;
using TaxCalculator.EntityBase.Entity;

namespace TaxCalculator.AutoMapper
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleDto>();
        }
    }
}
