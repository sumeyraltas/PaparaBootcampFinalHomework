﻿namespace PaparaBootcampFinalHomework.Models.Payments.DTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
         public int ResidentId { get; set; }
        public string CardCash { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentType { get; set; } // Dues/Bill (Electricity/Water/NaturalGas)
        public decimal Amount { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public MonthlyExpense.MonthlyExpense MonthlyExpense { get; set; }
    }
}
