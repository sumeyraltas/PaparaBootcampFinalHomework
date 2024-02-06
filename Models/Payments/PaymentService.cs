using AutoMapper;
using Models.Shared.ResponseDto;
using PaparaBootcampFinalHomework.Models.Apartments;
using PaparaBootcampFinalHomework.Models.UnitOfWorks;
using PaparaBootcampFinalHomework.Models.Users;

namespace PaparaBootcampFinalHomework.Models.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public ResponseDto<int> AddMonthlyBills(PaymentDTO request)
        {
            
                using var transaction = _unitOfWork.BeginTransaction();

                var payment = new Payment { };
                _paymentRepository.AddMonthlyBills(payment);
                _unitOfWork.Commit();
                transaction.Commit();

                return ResponseDto<int>.Success(payment.Id);
        }
        public ResponseDto<int> AddMonthlyBillsForAllApartments(PaymentDTO request)
        {
           
            using var transaction = _unitOfWork.BeginTransaction();

            var paymentsToAdd = new List<Payment>();

            foreach (var apartmentId in _apartmentRepository.GetAllApartmentIds())
            {
                var payment = new Payment
                {
                 
                    CardCash = request.CardCash,
                    PaymentDate = DateTime.Now,
                    PaymentType = request.PaymentType,
                    Amount = request.Amount, 
                    Year = request.Year,
                    Month = request.Month
                };

                paymentsToAdd.Add(payment);
            }

          //  _paymentRepository.AddMonthlyBills(paymentsToAdd);
            _unitOfWork.Commit();
            transaction.Commit();

            return ResponseDto<int>.Success(paymentsToAdd.First().Id);
        }

        public ResponseDto<int> AddMonthlyBillsForOneApartment(PaymentDTO request)
        {
            // Kullanıcıdan fatura mı yoksa aidat mı olduğunu al

            using var transaction = _unitOfWork.BeginTransaction();

            var payment = new Payment
            {
                ApartmentId = request.ApartmentId,
                CardCash = request.CardCash,
                PaymentDate = DateTime.Now,
                PaymentType = request.PaymentType,
                Amount =request.Amount, 
                Year = request.Year,
                Month = request.Month
            };

            _paymentRepository.AddMonthlyBills(payment);
            _unitOfWork.Commit();
            transaction.Commit();

            return ResponseDto<int>.Success(payment.Id);
        }
        public List<PaymentDTO> GetBuildingExpenses()
        {
            var allMonthlyExpenses = _paymentRepository.GetAllMonthlyExpenses();
            var buildingExpenses = new List<PaymentDTO>();

            foreach (var monthlyExpense in allMonthlyExpenses)
            {
                var totalExpense = monthlyExpense.ElectricityBill + monthlyExpense.WaterBill + monthlyExpense.GasBill;
                var buildingExpenseDto = new PaymentDTO
                {
                   
                };
                buildingExpenses.Add(buildingExpenseDto);
            }

            return buildingExpenses;
        }

        public ResponseDto<PaymentDTO> GetMonthlyBillsByMonth(DateTime billingMonth)
        {
            using var transaction = _unitOfWork.BeginTransaction();

            var monthlyBills = _paymentRepository.GetMonthlyBillsByMonth(billingMonth);

            _unitOfWork.Commit();
            transaction.Commit(); 
            
            return ResponseDto<PaymentDTO>.Success(monthlyBills);
        }

        public List<PaymentDTO> GetUserPayments(int userId)
        {
            var userPayments = _paymentRepository.GetUserPayments(userId);
            return _mapper.Map<List<PaymentDTO>>(userPayments);
        }
   
    }
}
