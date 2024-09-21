using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TaxCalculator.EntityBase.Entity
{
    [Table("WeekendDay")]
    public class WeekendDay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public virtual City City { get; set; }
    }

}
