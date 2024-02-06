using Models.Shared.ResponseDto;
namespace PaparaBootcampFinalHomework.Models.Apartments
{
    public interface IApartmentService
    {
        ResponseDto<List<ApartmentDTO>> GetAllApartment();
        ApartmentDTO GetByIdApartment(int id);
        void DeleteApartment(int id);
        ResponseDto<int> AddApartment(ApartmentDTO request);

        void UpdateApartment(ApartmentDTO request);
    }
}
