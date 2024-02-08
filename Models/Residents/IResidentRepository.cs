using Microsoft.EntityFrameworkCore;

namespace PaparaBootcampFinalHomework.Models.Users
{
    public interface IResidentRepository
    {
        List<Resident> GetAllUser();


        Resident AddUser(Resident user);


        void UpdateUser(Resident user);


        void DeleteUser(int id);


        Resident GetByIdUser(int id);
      
    }
}
