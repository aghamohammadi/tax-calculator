using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.EntityBase.Entity
{
    [Table("City")]
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public virtual ICollection<CityTaxRule> CityTaxRules { get; set; }
        public virtual ICollection<Holiday> Holidays { get; set; }
        public virtual ICollection<MonthTaxExemption> MonthTaxExemptions { get; set; }
        public virtual ICollection<TaxAmount> TaxAmounts { get; set; }
        public virtual ICollection<VehicleExemption> VehicleExemptions { get; set; }
        public virtual ICollection<WeekendDay> WeekendDays { get; set; }
    }

}
