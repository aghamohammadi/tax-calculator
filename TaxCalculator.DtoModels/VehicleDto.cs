using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.DtoModels
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string VehicleType { get; set; }
    }
}
