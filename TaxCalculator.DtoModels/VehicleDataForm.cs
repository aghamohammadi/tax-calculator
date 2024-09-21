using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.DtoModels
{
    public class VehicleDataForm
    {
        public string City { get; set; }
        public int Year { get; set; }
        public string VehicleLicensePlate { get; set; }
        public DateTime[] Dates { get; set; }

    }
}
