using AutoMapper;
using GymApp.Data;
using GymApp.Models.Api.User;
using GymApp.Models.DataBase;
using System;
using System.Linq;
using System.Text;


namespace GymApp.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext context;
        private IMapper Mapper { get; }
        public UserService(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.Mapper = mapper;
        }

        public User Login(string userName, string password)
        {
            var user = context.Users.FirstOrDefault(x => x.Username.Equals(userName));

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public User Create(UserFormModel model, string password)
        {
            var user = Mapper.Map<User>(model);

            byte[] passwordHash, passwordSalt;
            CreatePasswordHashSalt(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            if (user.Height > 100)
            {
                user.Height /= 100;
            }

            context.Users.Add(user);
            context.SaveChanges();

            return user;
        }

        public bool UserExists(string userName)
        {
            if (context.Users.Any(x => x.Username.Equals(userName)))
                return true;

            return false;
        }

        private void CreatePasswordHashSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (var i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != password[i])
                        return false;
                }
                return true;
            }
        }

        public User Fetch(long id)
        {
            var result = context.Users
                .Where(p => p.Id == id)
                .FirstOrDefault();

            return result;
        }

        public User Update(UserFormModel model, User user)
        {
            var updateUser = Mapper.Map<User>(model);

            byte[] passwordHash, passwordSalt;
            if (!String.IsNullOrEmpty(model.Password))
            {
                CreatePasswordHashSalt(model.Password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }
            
            
            user.Height = updateUser.Height > 0 ? updateUser.Height : user.Height;
            user.Weight = updateUser.Weight > 0 ? updateUser.Weight : user.Weight;
            if (!String.IsNullOrEmpty(updateUser.Username))
                user.Username = updateUser.Username;
            if(!String.IsNullOrEmpty(updateUser.Gender))
                user.Gender = updateUser.Gender;
            
            if (user.Height > 100)
            {
                user.Height /= 100;
            }
            context.Users.Update(user);
            context.SaveChanges();

            return user;
        }
      
    }
}
