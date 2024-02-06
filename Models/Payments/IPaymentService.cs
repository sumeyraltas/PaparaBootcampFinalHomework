using Models.Shared.ResponseDto;

namespace PaparaBootcampFinalHomework.Models.Payments
{
    public interface IPaymentService
    {
        ResponseDto<int> AddMonthlyBills(PaymentDTO request);
        List<PaymentDTO> GetBuildingExpenses();
        // List<UserPaymentDTO>
        ResponseDto<PaymentDTO> GetMonthlyBillsByMonth(DateTime billingMonth);
        List<PaymentDTO> GetUserPayments(int userId);
        //List<BuildingExpenseDTO>
        ResponseDto<int> AddMonthlyBillsForAllApartments(PaymentDTO request);
        ResponseDto<int> AddMonthlyBillsForOneApartment(PaymentDTO request);
    }
}
