using System.Linq;
using GymApp.Data;
using GymApp.Models.DataBase;

namespace GymApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User GetByUsername(string username)
        {
            return _context.Users
                .FirstOrDefault(x => x.Username.Equals(username));
        }

        public User GetById(int id)
        {
            return _context.Users
                .FirstOrDefault(x => x.Id == id);
        }

        public bool UserExists(string username)
        {
            return _context.Users
                .Any(x => x.Username.Equals(username));
        }

        public User Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
    public interface IUserRepository
    {
        User Add(User user);
        User GetByUsername(string username);
        User GetById(int id);
        bool UserExists(string username);
        User Update(User user);
    }
}
