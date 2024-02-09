namespace PaparaBootcampFinalHomework.Models.MonthlyExpense.DTOs
{
    public class ElectricityBillsDTO
    {
        public int Id { get; set; }
        public decimal ElectricityBill { get; set; }
        public bool IsPaid { get; set; }
        public int Year { get; internal set; }
        public int Month { get; internal set; }
    }
}