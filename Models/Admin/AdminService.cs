using AutoMapper;
using Models.Shared.ResponseDto;
using PaparaBootcampFinalHomework.Models.Admin.DTOs;
using PaparaBootcampFinalHomework.Models.Apartments;
using PaparaBootcampFinalHomework.Models.UnitOfWorks;
using PaparaBootcampFinalHomework.Models.Users;

namespace PaparaBootcampFinalHomework.Models.Admin
{
    public class AdminService(IResidentRepository userRepository, IApartmentRepository apartmentRepository,IMapper mapper, IUnitOfWork unitOfWork, IAdminRepository adminRepository) : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IResidentRepository _residentRepository;
        private readonly IApartmentRepository _apartmentRepository;
   
        public void AssignResidentToApartments(List<UserApartmentDTO> userApartments)
        {
            foreach (var userApartment in userApartments)
            {
                var user = _residentRepository.GetByIdUser(userApartment.UserId);
                var apartment = _apartmentRepository.GetByIdApartment(userApartment.ApartmentId);

                if (user != null && apartment != null)
                {
                    apartment.Resident = user;
                    _apartmentRepository.UpdateApartment(apartment);
                }
            }
        }
    }
}
