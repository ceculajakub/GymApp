using System;
using AutoMapper;
using GymApp.Models.Api.User;
using GymApp.Models.DataBase;
using GymApp.Repositories;
using System.Linq;
using System.Text;

namespace GymApp.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private IMapper Mapper { get; }

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            Mapper = mapper;
        }

        public User Login(string userName, string password)
        {
            var user = _userRepository.GetByUsername(userName);

            if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
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
                user.Height /= 100;

            return _userRepository.Add(user);
        }

        public bool UserExists(string userName)
        {
            return _userRepository.UserExists(userName);
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

                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public User Fetch(int id)
        {
            return _userRepository.GetById(id);
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
            if (!String.IsNullOrEmpty(updateUser.Gender))
                user.Gender = updateUser.Gender;

            if (user.Height > 100)
                user.Height /= 100;

            return _userRepository.Update(user);
        }
    }
}
