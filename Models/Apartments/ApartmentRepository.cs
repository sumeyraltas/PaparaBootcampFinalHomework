
using PaparaBootcampFinalHomework.Shared;

namespace PaparaBootcampFinalHomework.Models.Apartments
{
    public class ApartmentRepository(AppDbContext context) : IApartmentRepository
    {
        private readonly AppDbContext _context = context;
        public Apartment AddApartment(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
            return apartment;
        }

        public void DeleteApartment(int id)
        {
            var apartment = _context.Apartments.Find(id);
            if (apartment != null)
            {
                _context.Apartments.Remove(apartment);
            }
        }

        public List<Apartment> GetAllApartment()
        {
            return _context.Apartments.ToList();
        }
        public List<int> GetAllApartmentIds()
        {
            return _context.Apartments.Select(a => a.Id).ToList();
        }
        public Apartment GetByIdApartment(int id)
        {
            return _context.Apartments.SingleOrDefault(x => x.Id == id);
        }

        public void UpdateApartment(Apartment apartment)
        {
            _context.Apartments.Update(apartment);
        }
    }
}
