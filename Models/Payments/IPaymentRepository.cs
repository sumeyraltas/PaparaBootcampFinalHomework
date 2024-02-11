using Microsoft.EntityFrameworkCore;
using Models.Shared.ResponseDto;
using PaparaBootcampFinalHomework.Models.Payments.DTOs;

namespace PaparaBootcampFinalHomework.Models.Payments
{
    public interface IPaymentRepository
    {
        List<Payment> GetMonthlyBillsByMonth(int payment);
        List<Payment> GetUserPayments();
        Payment AddPaymentBills(Payment payment);
        List<Payment> GetResidentPayments(int residentId);
        ResponseDto<int> MakePayment(Payment request);
    }
}