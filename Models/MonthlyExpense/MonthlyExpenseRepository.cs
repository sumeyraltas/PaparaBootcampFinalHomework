using PaparaBootcampFinalHomework.Models.Payments;
using PaparaBootcampFinalHomework.Shared;

namespace PaparaBootcampFinalHomework.Models.MonthlyExpense
{
    public class MonthlyExpenseRepository : IMonthlyExpenseRepository
    {
        private readonly AppDbContext _context;

        public MonthlyExpenseRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<MonthlyExpense> GetAllMonthlyExpenses()
        {
            return _context.MonthlyExpenses.ToList();
        }
        public MonthlyExpense AddMonthlyBills(MonthlyExpense monthlyExpense)
        {
            _context.MonthlyExpenses.Add(monthlyExpense);

            return monthlyExpense;
        }
        public List<Payment> GetAllGasBills()
        {
            return _context.Payments
                .Where(p => p.MonthlyExpense != null && p.MonthlyExpense.GasBill > 0)
                .ToList();
        }
        public List<Payment> GetAllElectricityBill()
        {
            return _context.Payments
                .Where(p => p.MonthlyExpense != null && p.MonthlyExpense.ElectricityBill > 0)
                .ToList();
        }
        public List<Payment> GetAllWaterBill()
        {
            return _context.Payments
                .Where(p => p.MonthlyExpense != null && p.MonthlyExpense.WaterBill > 0)
                .ToList();
        }
    }
}
