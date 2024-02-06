namespace PaparaBootcampFinalHomework.Models.Users
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        private readonly AppDbContext _context = context;

        public List<User> GetAllUser()
        {
            return _context.Users.ToList();
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            return user;
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
        }

        public User GetByIdUser(int id)
        {
            return _context.Users.Find(id);
        }
    }
}
