using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaxCalculator.DtoModels.Enums;

namespace TaxCalculator.EntityBase.Entity
{
    [Table("Vehicle")]
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string VehicleType { get; set; }


    }
}
