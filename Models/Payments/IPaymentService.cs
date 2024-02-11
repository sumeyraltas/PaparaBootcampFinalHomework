
using Models.Shared.ResponseDto;
using PaparaBootcampFinalHomework.Models.MonthlyExpense.DTOs;
using PaparaBootcampFinalHomework.Models.Payments.DTOs;

namespace PaparaBootcampFinalHomework.Models.Payments
{
    public interface IPaymentService
    {
        ResponseDto<int> AddPayment(PaymentDTO request);
        List<PaymentDTO> GetMonthlyBillsByMonth(int billingMonth);
        List<PaymentDTO> GetUserPayments();
        ResponseDto<int> AddMonthlyBillsForAllApartments(PaymentDTO request);
        List<ResistentPaymentsDTO> GetResidentPayments(int id);
        ResponseDto<string> MakePayment(ResistentPaymentsDTO request);
    }
}
