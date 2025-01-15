using GymApp.Models.DataBase;
using System.Collections.Generic;

namespace GymApp.Data.Repositories
{
    public class ExerciseDoneRepository : IExerciseDoneRepository
    {
        private readonly DataContext _context;

        public ExerciseDoneRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(List<ExerciseDone> exercises)
        {
            _context.AddRange(exercises);
            _context.SaveChanges();
        }
    }
    public interface IExerciseDoneRepository
    {
        void Create(List<ExerciseDone> exercises);
    }
}
