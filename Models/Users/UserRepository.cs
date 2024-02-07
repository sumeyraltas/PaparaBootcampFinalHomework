using PaparaBootcampFinalHomework.Shared;

namespace PaparaBootcampFinalHomework.Models.Users
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        private readonly AppDbContext _context = context;
        
        public List<User> GetAllUser()
        {
            return _context.Userss.ToList();
        }

        public User AddUser(User user)
        {
            _context.Userss.Add(user);
            return user;
        }

        public void UpdateUser(User user)
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

        public User GetByIdUser(int id)
        {
            return _context.Userss.Find(id);
        }
        
    }
}
