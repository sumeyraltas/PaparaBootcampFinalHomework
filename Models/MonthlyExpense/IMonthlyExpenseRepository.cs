using PaparaBootcampFinalHomework.Models.Payments;

namespace PaparaBootcampFinalHomework.Models.MonthlyExpense
{
    public interface IMonthlyExpenseRepository
    {
        List<MonthlyExpense> GetAllGasBills();
        List<MonthlyExpense> GetAllElectricityBill();
        List<MonthlyExpense> GetAllWaterBill();
        MonthlyExpense AddMonthlyBills(MonthlyExpense payment);
        List<MonthlyExpense> GetAllMonthlyExpenses();

    }
}
