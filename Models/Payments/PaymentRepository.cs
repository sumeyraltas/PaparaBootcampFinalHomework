namespace PaparaBootcampFinalHomework.Models.Payments
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        public Payment AddMonthlyBills(Payment payment)
        {
            _context.Payments.Add(payment);
     
            return payment;
        }

        public List<MonthlyExpense> GetAllMonthlyExpenses()
        {
            return _context.MonthlyExpenses.ToList();
        }

        public Payment GetMonthlyBillsByMonth(DateTime payment)
        {
            return _context.Payments.SingleOrDefault(b => b.PaymentDate == payment);
        }
     
        public List<Payment> GetUserPayments(int userId)
        {
            // return _context.PaymentDTO.Where(u => u.UserId == userId).ToList();
            return _context.Payments.ToList();

        }

    }
}
