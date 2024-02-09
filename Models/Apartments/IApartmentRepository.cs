using PaparaBootcampFinalHomework.Models.Users;

namespace PaparaBootcampFinalHomework.Models.Apartments
{
    public interface IApartmentRepository
    {
        List<Apartment> GetAllApartment();


        Apartment AddApartment(Apartment apartment);
        List<int?> GetAllApartmentIds();

        void UpdateApartment(Apartment apartment);


        void DeleteApartment(int id);


        Apartment GetByIdApartment(int id);
    }
}
