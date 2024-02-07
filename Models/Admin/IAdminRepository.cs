using Microsoft.EntityFrameworkCore;
using PaparaBootcampFinalHomework.Models.Apartments;
using PaparaBootcampFinalHomework.Models.Payments;
using PaparaBootcampFinalHomework.Models.Users;

namespace PaparaBootcampFinalHomework.Models.Admin
{
    public interface IAdminRepository
    {
         
        void AssignUsersToApartments(List<UserApartmentDTO> userApartments);


    }
}
