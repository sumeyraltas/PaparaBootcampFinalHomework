using PaparaBootcampFinalHomework.Models.Payments;

namespace PaparaBootcampFinalHomework.Models.MonthlyExpense
{
    public interface IMonthlyExpenseRepository
    {
        List<Payment> GetAllGasBills();
        List<Payment> GetAllElectricityBill();

        List<Payment> GetAllWaterBill();
        MonthlyExpense AddMonthlyBills(MonthlyExpense payment);
        List<MonthlyExpense> GetAllMonthlyExpenses();

    }
}
