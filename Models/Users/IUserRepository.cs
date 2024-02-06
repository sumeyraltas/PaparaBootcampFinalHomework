using Microsoft.EntityFrameworkCore;

namespace PaparaBootcampFinalHomework.Models.Users
{
    public interface IUserRepository
    {
        List<User> GetAllUser();


        User AddUser(User user);


        void UpdateUser(User user);


        void DeleteUser(int id);


        User GetByIdUser(int id);
      
    }
}
