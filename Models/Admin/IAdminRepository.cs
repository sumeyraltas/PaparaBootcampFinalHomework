using Microsoft.EntityFrameworkCore;
using PaparaBootcampFinalHomework.Models.Apartments;
using PaparaBootcampFinalHomework.Models.Payments;
using PaparaBootcampFinalHomework.Models.Users;

namespace PaparaBootcampFinalHomework.Models.Admin
{
    public interface IAdminRepository
    {
         Apartment AddApartments(Apartment apartment);


         User AddUsers(User user);
        void AssignUsersToApartments(List<UserApartmentDTO> userApartments);


         Payment AddPayments(Payment payment);
       
    }
}
