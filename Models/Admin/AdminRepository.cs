using PaparaBootcampFinalHomework.Models.Apartments;
using PaparaBootcampFinalHomework.Models.Payments;
using PaparaBootcampFinalHomework.Models.Users;

namespace PaparaBootcampFinalHomework.Models.Admin
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }

        public Apartment AddApartments(Apartment apartment)
        {
            // Map DTOs to entities and add to context
             _context.Apartments.Add(apartment);
           return apartment;
        }

        public User AddUsers(User user)
        {
            // Map DTOs to entities and add to context
            _context.Users.AddRange(user);
            return user;
         
        }

        public void AssignUsersToApartments(List<UserApartmentDTO> userApartments)
        {
            // Map DTOs to entities and add to context
            // _context.UserApartments.AddRange(userApartments);
      
        }

        public Payment AddPayments(Payment payment)
        {
            // Map DTOs to entities and add to context
             _context.Payments.Add(payment);
             return payment;
        }

    }
}
