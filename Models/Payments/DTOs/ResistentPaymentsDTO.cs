namespace PaparaBootcampFinalHomework.Models.Payments.DTOs
{
    public class ResistentPaymentsDTO
    {
        public int ResidentId { get; set; }
        public string CardCash { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentType { get; set; } 
        public decimal Amount { get; set; }
        public int Month { get;  set; }
    }
}