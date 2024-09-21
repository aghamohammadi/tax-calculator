using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.EntityBase.Entity
{



    [Table("VehicleExemption")]
    public class VehicleExemption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }  
        public string VehicleType { get; set; }
        public virtual City City { get; set; }
    }
}
