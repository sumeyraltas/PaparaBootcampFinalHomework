using PaparaBootcampFinalHomework.Shared;

namespace PaparaBootcampFinalHomework.Models.Users
{
    public class ResidentRepository(AppDbContext context) : IResidentRepository
    {
        private readonly AppDbContext _context = context;
        
        public List<Resident> GetAllUser()
        {
            return _context.Userss.ToList();
        }

        public Resident AddUser(Resident user)
        {
            _context.Userss.Add(user);
            return user;
        }

        public void UpdateUser(Resident user)
        {
            _context.Userss.Update(user);
        }

        public void DeleteUser(int id)
        {
            var user = _context.Userss.Find(id);
            if (user != null)
            {
                _context.Userss.Remove(user);
            }
        }

        public Resident GetByIdUser(int id)
        {
            return _context.Userss.Find(id);
        }
        
    }
}
