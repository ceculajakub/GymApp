using System;
using AutoMapper;
using GymApp.Models.Api.Training;
using GymApp.Models.DataBase;
using GymApp.Repositories;
using GymApp.Services.ExerciseDoneService;

namespace GymApp.Services.TrainingService
{

    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly IExerciseDoneService _exerciseDoneService;
        private IMapper _mapper { get; }

        public TrainingService(ITrainingRepository trainingRepository, IMapper mapper, IExerciseDoneService exerciseDoneService)
        {
            _trainingRepository = trainingRepository;
            _mapper = mapper;
            _exerciseDoneService = exerciseDoneService;
        }

        public Training Create(TrainingFormModel model)
        {
            var training = _mapper.Map<Training>(model);
            training.ExecutionTime = DateTime.Now;
            training.UserId = _trainingRepository.GetById(training.TrainingPlanId).UserId;

            var createdTraining = _trainingRepository.Create(training);

            if (model.ExercisesDone != null)
                _exerciseDoneService.Create(model.ExercisesDone, createdTraining.Id);

            return createdTraining;
        }

        public TrainingViewModel Fetch(int trainingId)
        {
            var entity = _trainingRepository.GetById(trainingId);
            return _mapper.Map<TrainingViewModel>(entity);
        }

        public Training Update(TrainingFormModel model, int trainingId)
        {
            var entity = _trainingRepository.GetById(trainingId);
            var updatedEntity = _mapper.Map<TrainingFormModel, Training>(model, entity);

            _trainingRepository.Update(updatedEntity);
            return updatedEntity;
        }

        public void Delete(int trainingId)
        {
            var entity = _trainingRepository.GetById(trainingId);
            _trainingRepository.Delete(entity);
        }
    }
}