using PaparaBootcampFinalHomework.Models.Payments;

namespace PaparaBootcampFinalHomework.Models.MonthlyExpense
{
    public class MonthlyExpense
    {
        public int Id { get; set; }
        public DateTime ExpenseMonth { get; set; }
        public decimal ElectricityBill { get; set; }
        public decimal WaterBill { get; set; }
        public decimal GasBill { get; set; }
        public bool IsPaid { get; set; }
        public int Year { get; internal set; }
        public int Month { get; internal set; }
        public ICollection<Payment> Payments { get;  set; }
    }
}
