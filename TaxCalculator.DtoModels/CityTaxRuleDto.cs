using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.DtoModels
{
    public class CityTaxRuleDto
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int Year { get; set; }
        public bool HasSingleChargeRule { get; set; }
        public int SingleChargeWindowInMinutes { get; set; }
        //public bool HasWeekendExemption { get; set; }
        //public bool HasHolidayExemption { get; set; }
        //public bool HasBeforHolidayExemption { get; set; }
        //public bool HasSpecialMonthExemption { get; set; }
        //public bool HasVehicleExemption { get; set; }

        public decimal MaxAmountPerDay { get; set; }

    }
}
