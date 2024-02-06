namespace PaparaBootcampFinalHomework.Models.Payments
{
    public class MonthlyExpense
    {
        public int Id { get; set; }
        public DateTime ExpenseMonth { get; set; }
        public decimal ElectricityBill { get; set; }
        public decimal WaterBill { get; set; }
        public decimal GasBill { get; set; }
        public bool IsPaid { get; set; }
    }
}
