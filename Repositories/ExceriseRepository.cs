using System.Collections.Generic;
using System.Linq;
using GymApp.Models.DataBase;

namespace GymApp.Data.Repositories
{
    // Repozytorium odpowiedzialne za operacje CRUD na encjach ćwiczeń.
    // Zastosowanie wzorca "Repository Pattern", który oddziela logikę dostępu do danych od reszty aplikacji, czyli też po części wprowadzenie w życie zasady SRP
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly DataContext _context;

        public ExerciseRepository(DataContext context)
        {
            _context = context;
        }

        public Exercise Create(Exercise entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Exercise GetById(int id)
        {
            return _context.Exercises.FirstOrDefault(x => x.Id == id);
        }

        public List<Exercise> GetAll()
        {
            return _context.Exercises.ToList();
        }

        public void Delete(Exercise entity)
        {
            _context.Exercises.Remove(entity);
            _context.SaveChanges();
        }
    }

    public interface IExerciseRepository
    {
        Exercise Create(Exercise entity);
        Exercise GetById(int id);
        List<Exercise> GetAll();
        void Delete(Exercise entity);
    }
}