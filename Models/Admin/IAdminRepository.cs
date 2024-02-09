
namespace PaparaBootcampFinalHomework.Models.Admin
{
    public interface IAdminRepository
    { 
        void AssignUsersToApartments(List<UserApartmentDTO> userApartments);
    }
}
