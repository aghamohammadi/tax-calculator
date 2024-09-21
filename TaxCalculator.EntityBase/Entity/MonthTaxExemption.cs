using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.EntityBase.Entity
{

    [Table("MonthTaxExemption")]
    public class MonthTaxExemption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        public int Year { get; set; }  
        public int Month { get; set; }  
        public virtual City City { get; set; }
    }

}
