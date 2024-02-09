using PaparaBootcampFinalHomework.Shared;

namespace PaparaBootcampFinalHomework.Models.Payments
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }

       
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

    }
}
