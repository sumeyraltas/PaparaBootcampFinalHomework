using PaparaBootcampFinalHomework.Models.Payments;

namespace PaparaBootcampFinalHomework.Models.Apartments.DTOs
{
    public class ApartmentDTO
    {
        // public int Id { get; set; }
        public required string BlockInfo { get; set; }
        public required bool IsOccupied { get; set; }
        public string? Type { get; set; }
        public required int Floor { get; set; }
        public required int ApartmentNumber { get; set; }
        public required string OwnerTenant { get; set; }
        public required int ResidentId { get; set; }

        //public ICollection<Payment> Payments { get; set; }
    }
}
