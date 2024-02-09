using PaparaBootcampFinalHomework.Models.Payments;
using System.ComponentModel.DataAnnotations.Schema;
using PaparaBootcampFinalHomework.Models.Users;

namespace PaparaBootcampFinalHomework.Models.Apartments
{
    public class Apartment
    {
        public int? Id { get; set; }
        public string? BlockInfo { get; set; }
        public bool? IsOccupied { get; set; }
        public string? Type { get; set; }
        public int? Floor { get; set; }
        public int? ApartmentNumber { get; set; }
        public string? OwnerTenant { get; set; }
        public int? ResidentId { get; set; }
        [ForeignKey("ResidentId")]
        public Resident? Resident { get; set; }
          public ICollection<Payment>? Payments { get; set; }
    }
}
