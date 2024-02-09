namespace PaparaBootcampFinalHomework.Models.MonthlyExpense.DTOs
{
    public class WaterBillsDTO
    {
        public int Id { get; set; }
        public decimal WaterBill { get; set; }
        public bool IsPaid { get; set; }
        public int Year { get; internal set; }
        public int Month { get; internal set; }
    }
}