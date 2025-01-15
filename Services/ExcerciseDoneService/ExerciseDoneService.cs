using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GymApp.Data.Repositories;
using GymApp.Models.Api.ExercisesDone;
using GymApp.Models.DataBase;

namespace GymApp.Services.ExerciseDoneService
{
    public class ExerciseDoneService : IExerciseDoneService
    {
        private readonly IExerciseDoneRepository _exerciseDoneRepository;
        private IMapper _mapper { get; }

        public ExerciseDoneService(IExerciseDoneRepository exerciseDoneRepository, IMapper mapper)
        {
            _exerciseDoneRepository = exerciseDoneRepository;
            _mapper = mapper;
        }

        public void Create(List<ExerciseDoneFormModel> exercises, int trainingId)
        {
            var entities = exercises.Select(exercise =>
            {
                var entity = _mapper.Map<ExerciseDone>(exercise);
                entity.TrainingId = trainingId;
                return entity;
            }).ToList();

            _exerciseDoneRepository.Create(entities);
        }
    }
}