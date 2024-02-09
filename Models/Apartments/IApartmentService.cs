using Models.Shared.ResponseDto;
using PaparaBootcampFinalHomework.Models.Apartments.DTOs;
namespace PaparaBootcampFinalHomework.Models.Apartments
{
    public interface IApartmentService
    {
        ResponseDto<List<ApartmentDTO>> GetAllApartment();
        ApartmentDTO GetByIdApartment(int id);
        void DeleteApartment(int id);
        ResponseDto<int> AddApartment(ApartmentDTO request);

        ResponseDto<int> UpdateApartment(ApartmentDTO request);
    }
}
