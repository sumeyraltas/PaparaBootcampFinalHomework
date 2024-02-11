using Models.Shared.ResponseDto;
using PaparaBootcampFinalHomework.Models.Residents.DTOs;

namespace PaparaBootcampFinalHomework.Models.Users
{
    public interface IResidentService
    {
        ResponseDto<List<ResidentDTO>> GetAllUser();
        ResidentDTO GetByIdUser(int id);
        void DeleteUser(int id);
        ResponseDto<string> AddUser(ResidentDTO request);
        void UpdateUser(ResidentDTO request);
    }
}
