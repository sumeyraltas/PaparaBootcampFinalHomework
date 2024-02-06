using Models.Shared.ResponseDto;

namespace PaparaBootcampFinalHomework.Models.Users
{
    public interface IUserService
    {
        ResponseDto<List<UserDTO>> GetAllUser();
         UserDTO GetByIdUser(int id);
        void DeleteUser(int id);
        ResponseDto<int> AddUser(UserDTO request);

         void UpdateUser(UserDTO request);
}
}
