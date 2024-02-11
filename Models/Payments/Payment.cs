using PaparaBootcampFinalHomework.Models.Apartments;
using PaparaBootcampFinalHomework.Models.Users;

namespace PaparaBootcampFinalHomework.Models.Payments
{
    public class Payment
    {
        public int Id { get; set; }
        public int? ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }
        public Resident? Resident { get; set; }
        public int ResidentId { get; set; }
        public string? CardCash { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? PaymentType { get; set; } // Dues/Bill (Electricity/Water/Gas)
        public required decimal Amount { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public MonthlyExpense.MonthlyExpense? MonthlyExpense { get; set; }
    }
}
