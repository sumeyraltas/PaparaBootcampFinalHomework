using Models.Shared.ResponseDto;

namespace PaparaBootcampFinalHomework.Models.Users
{
    public interface IResidentService
    {
        ResponseDto<List<ResidentDTO>> GetAllUser();
         ResidentDTO GetByIdUser(int id);
        void DeleteUser(int id);
        ResponseDto<int> AddUser(ResidentDTO request);

         void UpdateUser(ResidentDTO request);
}
}
