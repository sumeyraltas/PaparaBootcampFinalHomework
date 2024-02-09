using AutoMapper;
using Models.Shared.ResponseDto;
using PaparaBootcampFinalHomework.Models.Apartments;
using PaparaBootcampFinalHomework.Models.Payments.DTOs;
using PaparaBootcampFinalHomework.Models.UnitOfWorks;

namespace PaparaBootcampFinalHomework.Models.Payments
{
    public class PaymentService(IPaymentRepository paymentRepository, IApartmentRepository apartmentRepository, IMapper mapper, IUnitOfWork unitOfWork) : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository = paymentRepository;
        private readonly IApartmentRepository _apartmentRepository = apartmentRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
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

            _unitOfWork.Commit();
            transaction.Commit();

            return ResponseDto<int>.Success(paymentsToAdd.First().Id);
        }
        public ResponseDto<int> AddPayment(PaymentDTO request)
        {
            using var transaction = _unitOfWork.BeginTransaction();

            var payment = new Payment
            {
                ApartmentId = request.ApartmentId,
                ResidentId = request.ResidentId,
                CardCash = request.CardCash,
                PaymentDate = DateTime.Now,
                PaymentType = request.PaymentType,
                Amount = request.Amount,
                Year = request.Year,
                Month = request.Month,
                MonthlyExpense = request.MonthlyExpense
            };

            _paymentRepository.AddPaymentBills(payment);
            _unitOfWork.Commit();
            transaction.Commit();

            return ResponseDto<int>.Success(payment.Id);
        }

        public List<PaymentDTO> GetMonthlyBillsByMonth(int billingMonth)
        {
            using var transaction = _unitOfWork.BeginTransaction();

            var monthlyBills = _paymentRepository.GetMonthlyBillsByMonth(billingMonth);

            _unitOfWork.Commit();
            transaction.Commit();

            return _mapper.Map<List<PaymentDTO>>(monthlyBills);
        }


        public List<PaymentDTO> GetUserPayments()
        {
            using var transaction = _unitOfWork.BeginTransaction();
            var userPayments = _paymentRepository.GetUserPayments();
            _unitOfWork.Commit();
            transaction.Commit();
            return _mapper.Map<List<PaymentDTO>>(userPayments);
        }


    }
}
