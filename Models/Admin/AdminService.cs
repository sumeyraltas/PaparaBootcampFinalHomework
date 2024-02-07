using AutoMapper;
using Models.Shared.ResponseDto;
using PaparaBootcampFinalHomework.Models.UnitOfWorks;
using PaparaBootcampFinalHomework.Models.Users;

namespace PaparaBootcampFinalHomework.Models.Admin
{
    public class AdminService(IMapper mapper, IUnitOfWork unitOfWork, IAdminRepository adminRepository) : IAdminService
    {
        private readonly IAdminRepository _adminRepository;




    }
}
