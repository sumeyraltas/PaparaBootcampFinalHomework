using Microsoft.AspNetCore.Http.HttpResults;
using PaparaBootcampFinalHomework.Models.Payments;
using PaparaBootcampFinalHomework.Shared;

namespace PaparaBootcampFinalHomework.Models.MonthlyExpense
{
    public class MonthlyExpenseRepository(AppDbContext context) : IMonthlyExpenseRepository
    {
        private readonly AppDbContext _context;

        public List<MonthlyExpense> GetAllMonthlyExpenses()
        {
            return _context.MonthlyExpenses.ToList();
        }
        public MonthlyExpense AddMonthlyBills(MonthlyExpense monthlyExpense)
        {
            _context.MonthlyExpenses.Add(monthlyExpense);

            return monthlyExpense;
        }
        public List<MonthlyExpense> GetAllGasBills()
        {
            return _context.MonthlyExpenses
                .Where(p =>  p.GasBill > 0)
                .ToList();
        }
        public List<MonthlyExpense> GetAllElectricityBill()
        {
            return _context.MonthlyExpenses
                .Where(p => p.ElectricityBill > 0)
                .ToList();
        }
        public List<MonthlyExpense> GetAllWaterBill()
        {
            return _context.MonthlyExpenses
                .Where(p => p.WaterBill > 0)
                .ToList();
        }
    }
}
