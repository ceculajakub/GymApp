using System.Collections.Generic;
using System.Linq;
using GymApp.Data;
using GymApp.Models.DataBase;

namespace GymApp.Repositories
{
    public class UserMeasurementsRepository : IUserMeasurementsRepository
    {
        private readonly DataContext _context;

        public UserMeasurementsRepository(DataContext context)
        {
            _context = context;
        }

        public UserMeasurement Add(UserMeasurement entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public List<UserMeasurement> GetByUserId(int userId)
        {
            return _context.UserMeasurements
                .Where(p => p.User.Id == userId)
                .ToList();
        }

        public UserMeasurement GetById(int measurementId)
        {
            return _context.UserMeasurements
                .Where(p => p.Id == measurementId)
                .FirstOrDefault();
        }

        public UserMeasurement Update(UserMeasurement entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
    public interface IUserMeasurementsRepository
    {
        UserMeasurement Add(UserMeasurement entity);
        List<UserMeasurement> GetByUserId(int userId);
        UserMeasurement GetById(int measurementId);
        UserMeasurement Update(UserMeasurement entity);
    }
}
