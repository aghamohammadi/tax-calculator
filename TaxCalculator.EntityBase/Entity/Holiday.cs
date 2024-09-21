using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.EntityBase.Entity
{
    [Table("Holiday")]
    public class Holiday
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("City")]

        public int CityId { get; set; }
        public DateTime ExemptDate { get; set; }
        public bool IsExemptBeforeHoliday { get; set; }
        public virtual City City { get; set; }

    }

}
