using System.Collections.Generic;
using AutoMapper;
using GymApp.Data.Repositories;
using GymApp.Models.Api.Exercise;
using GymApp.Models.DataBase;

namespace GymApp.Services.ExerciseService
{
    // Serwis odpowiedzialny za logikę biznesową dotyczącą ćwiczeń.
    // Wykorzystuje repozytorium do operacji na bazie danych, w celu uniknięcia podwójnej odpowiedzialności serwisu
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        private IMapper _mapper { get; }

        public ExerciseService(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public Exercise Create(ExerciseFormModel model)
        {
            var entity = _mapper.Map<Exercise>(model);
            return _exerciseRepository.Create(entity);
        }

        public List<ExerciseFormModel> GetList()
        {
            var exercises = _exerciseRepository.GetAll();
            return _mapper.Map<List<ExerciseFormModel>>(exercises);
        }

        public ExerciseFormModel Fetch(int id)
        {
            var exercise = _exerciseRepository.GetById(id);
            return _mapper.Map<ExerciseFormModel>(exercise);
        }

        public void Delete(int exerciseId)
        {
            var entity = _exerciseRepository.GetById(exerciseId);
            _exerciseRepository.Delete(entity);
        }
    }
}