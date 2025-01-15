using System.Collections.Generic;
using System.Linq;
using GymApp.Data;
using GymApp.Models.DataBase;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly DataContext _context;

        public TrainingRepository(DataContext context)
        {
            _context = context;
        }

        public Training Create(Training entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Training GetById(int id)
        {
            return _context.Trainings
                .Include(t => t.ExercisesDone)
                .FirstOrDefault(t => t.Id == id);
        }

        public List<Training> GetAll()
        {
            return _context.Trainings.Include(t => t.ExercisesDone).ToList();
        }

        public void Delete(Training entity)
        {
            _context.Trainings.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Training entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }

    public interface ITrainingRepository
    {
        Training Create(Training entity);
        Training GetById(int id);
        List<Training> GetAll();
        void Delete(Training entity);
        void Update(Training entity);
    }
}
