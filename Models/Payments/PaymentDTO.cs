using PaparaBootcampFinalHomework.Models.Apartments;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaparaBootcampFinalHomework.Models.Payments
{
    public class PaymentDTO
    {
        internal string paymentType;

        public int Id { get; set; }
        public int ApartmentId { get; set; }

        public Apartment Apartment { get; set; }
        public string CardCash { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentType { get; set; } // Dues/Bill (Electricity/Water/NaturalGas)
        public decimal Amount { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
