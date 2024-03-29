﻿using AutoMapper;
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
                    ApartmentId = request.ApartmentId,
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
        public List<ResistentPaymentsDTO> GetResidentPayments(int id)
        {
            using var transaction = _unitOfWork.BeginTransaction();
            var residentPayments = _paymentRepository.GetResidentPayments(id);
            _unitOfWork.Commit();
            transaction.Commit();
            return MapToResistentPaymentsDTO(residentPayments);
        }

        public ResponseDto<string> MakePayment(ResistentPaymentsDTO request)
        {
            using var transaction = _unitOfWork.BeginTransaction();

            foreach (var apartmentId in apartmentRepository.GetAllApartmentIds()) // Assuming you have a method to get all apartment IDs
            {
                var payment = new Payment
                {
                    ApartmentId = apartmentId,
                    ResidentId = request.ResidentId,
                    CardCash = request.CardCash,
                    PaymentDate = DateTime.Now,
                    PaymentType = request.PaymentType,
                    Amount = request.Amount,
                    Month = request.Month
                };

                _paymentRepository.MakePayment(payment);
            }

            _unitOfWork.Commit();
            transaction.Commit();

            return ResponseDto<string>.Success("");
        }

        private List<ResistentPaymentsDTO> MapToResistentPaymentsDTO(List<Payment> payments)
        {
            List<ResistentPaymentsDTO> dtoList = new List<ResistentPaymentsDTO>();

            foreach (var payment in payments)
            {
                ResistentPaymentsDTO dto = new ResistentPaymentsDTO
                {
                    ResidentId = payment.ResidentId,
                    CardCash = payment.CardCash,
                    PaymentType = payment.PaymentType,
                    Amount = payment.Amount,
                };

                dtoList.Add(dto);
            }

            return dtoList;
        }
    }
}
