using PaparaBootcampFinalHomework.Models.Admin.DTOs;

namespace PaparaBootcampFinalHomework.Models.Admin
{
    public interface IAdminService
    {
        void AssignResidentToApartments(List<UserApartmentDTO> userApartments);
    }
}
