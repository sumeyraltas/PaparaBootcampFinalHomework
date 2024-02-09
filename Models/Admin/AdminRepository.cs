using PaparaBootcampFinalHomework.Models.Admin.DTOs;
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




    }
}
