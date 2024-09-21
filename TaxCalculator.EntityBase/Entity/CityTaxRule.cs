using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.EntityBase.Entity
{


    [Table("CityTaxRule")]
    public class CityTaxRule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("City")]
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
        public virtual City City { get; set; }

    }
}
