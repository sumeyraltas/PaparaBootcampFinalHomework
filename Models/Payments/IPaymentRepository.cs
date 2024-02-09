using Microsoft.EntityFrameworkCore;

namespace PaparaBootcampFinalHomework.Models.Payments
{
    public interface IPaymentRepository
    {
        List<Payment> GetMonthlyBillsByMonth(int payment);
        List<Payment> GetUserPayments();
        Payment AddPaymentBills(Payment payment);

    }
}