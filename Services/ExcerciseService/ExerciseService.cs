using AutoMapper;
using GymApp.Data;
using GymApp.Models.Api.Exercise;
using GymApp.Models.DataBase;
using System.Collections.Generic;
using System.Linq;

namespace GymApp.Services.ExerciseService
{
    public class ExerciseService : IExerciseService
    {
        private readonly DataContext _context;
        private IMapper _mapper { get; }
        public ExerciseService(DataContext _context, IMapper mapper)
        {
            this._context = _context;
            _mapper = mapper;
        }

        public Exercise Create(ExerciseFormModel model)
        {
            var entity = _mapper.Map<Exercise>(model);

            _context.Add<Exercise>(entity);
            _context.SaveChanges();

            return entity;
        }

        public List<ExerciseFormModel> GetList()
        {
            var Exercises = _context.Exercises.ToList();

            return _mapper.Map<List<ExerciseFormModel>>(Exercises);
        }

        public ExerciseFormModel Fetch(int id)
        {
            var Exercise = _context.Exercises
                                .Where(x => x.Id == id)
                                .FirstOrDefault();

            return _mapper.Map<ExerciseFormModel>(Exercise);
        }


        public void Delete(int exerciseId)
        {
            var entity = _context.Exercises
                .Where(x => x.Id == exerciseId)
                .FirstOrDefault();

            _context.Exercises.Remove(entity);

            _context.SaveChanges();
        }
    }
}
