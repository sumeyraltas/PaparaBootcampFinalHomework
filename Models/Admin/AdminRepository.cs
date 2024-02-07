using PaparaBootcampFinalHomework.Models.Apartments;
using PaparaBootcampFinalHomework.Models.Payments;
using PaparaBootcampFinalHomework.Models.Users;
using PaparaBootcampFinalHomework.Shared;

namespace PaparaBootcampFinalHomework.Models.Admin
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }


        public void AssignUsersToApartments(List<UserApartmentDTO> userApartments)
        {
            // Map DTOs to entities and add to context
            // _context.UserApartments.AddRange(userApartments);

        }


    }
}
