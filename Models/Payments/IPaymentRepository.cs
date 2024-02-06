namespace PaparaBootcampFinalHomework.Models.Payments
{
    public interface IPaymentRepository
    {
        Payment AddMonthlyBills(Payment payment);
        Payment GetMonthlyBillsByMonth(DateTime payment);
        List<Payment> GetUserPayments(int userId);
        //UserPayment
       
        //BuildingExpense,
        List<MonthlyExpense> GetAllMonthlyExpenses();
    }
}