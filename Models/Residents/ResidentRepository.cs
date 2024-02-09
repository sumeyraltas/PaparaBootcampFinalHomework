using PaparaBootcampFinalHomework.Shared;

namespace PaparaBootcampFinalHomework.Models.Users
{
    public class ResidentRepository(AppDbContext context) : IResidentRepository
    {
        private readonly AppDbContext _context = context;
        
        public List<Resident> GetAllUser()
        {
            return _context.Residents.ToList();
        }

        public Resident AddUser(Resident user)
        {
            _context.Residents.Add(user);
            return user;
        }

        public void UpdateUser(Resident user)
        {
            _context.Residents.Update(user);
        }

        public void DeleteUser(int id)
        {
            var user = _context.Residents.Find(id);
            if (user != null)
            {
                _context.Residents.Remove(user);
            }
        }

        public Resident GetByIdUser(int id)
        {
            return _context.Residents.Find(id);
        }
        
    }
}
