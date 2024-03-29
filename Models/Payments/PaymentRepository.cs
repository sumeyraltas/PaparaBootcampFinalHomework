﻿using Models.Shared.ResponseDto;
using PaparaBootcampFinalHomework.Shared;

namespace PaparaBootcampFinalHomework.Models.Payments
{
    public class PaymentRepository(AppDbContext context) : IPaymentRepository
    {
        private readonly AppDbContext _context = context;

        public Payment AddPaymentBills(Payment payment)
        {
            _context.Payments.Add(payment);

            return payment;
        }
        public List<Payment> GetMonthlyBillsByMonth(int month)
        {
            return _context.Payments
                .Where(p => p.Month == month)
                .ToList();
        }

        public List<Payment> GetUserPayments()
        {
            return _context.Payments.ToList();

        }
        public List<Payment> GetResidentPayments(int residentId)
        {
            return _context.Payments
                .Where(p => p.ResidentId == residentId)
                .ToList();
        }
        public ResponseDto<int> MakePayment(Payment request)
        {
            _context.Payments.Add(request);

            return ResponseDto<int>.Success(request.Id);
        }
    }
}
